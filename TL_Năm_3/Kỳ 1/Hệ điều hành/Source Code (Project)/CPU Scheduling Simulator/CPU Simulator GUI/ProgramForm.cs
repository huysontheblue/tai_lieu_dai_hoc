using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPU_Simulator
{
    public partial class ProgramForm : Form
    {
        public ProgramForm()
        {
            InitializeComponent();

            Table.Columns.Add("Process Name", typeof (string));
            Table.Columns.Add("Arrival Time", typeof (int));
            Table.Columns.Add("Burst Time", typeof (int));
            Table.Columns.Add("Priority", typeof (int));
            Table.Columns.Add("Start Time(s)", typeof (string));
            Table.Columns.Add("Completion Time", typeof (int));
            Table.Columns.Add("Waiting Time", typeof (int));
            Table.Columns.Add("Turnaround Time", typeof (int));
            Table.Columns.Add("Interrupt Time(s)", typeof (string));
            dataGridView.DataSource = Table;
            DisableControls();
        }

        public List<Process> Processes { get; } = new List<Process>();
        public DataTable Table { get; } = new DataTable();
        private void CalculateAndDisplayResults(ICollection<Process> clonedProcesses, int maxEndTime,
            StringBuilder cpuWorkflow)
        {
            int totalProcessesWaitingTime = 0,
                totalProcessesTurnaroundTime = 0,
                totalProcessesResponseTime = 0,
                cpuExecutionTime = 0,
                processesCount = clonedProcesses.Count;

            foreach (var p in clonedProcesses)
            {
                var processWaitingTime = p.CompletionTime - p.ArrivalTime - p.BurstTime;
                totalProcessesWaitingTime += processWaitingTime;

                var processTurnaroundTime = p.CompletionTime - p.ArrivalTime;
                totalProcessesTurnaroundTime += processTurnaroundTime;

                cpuExecutionTime += p.BurstTime;

                if (p.InterruptTime.Any())
                    totalProcessesResponseTime += p.InterruptTime.First() - p.ArrivalTime;
                else
                    totalProcessesResponseTime += processTurnaroundTime;

                Table.Rows.Add(
                    p.ProcessName,
                    p.ArrivalTime,
                    p.BurstTime,
                    p.Priority,
                    string.Join(", ", p.StartTime),
                    p.CompletionTime,
                    processWaitingTime,
                    processTurnaroundTime,
                    p.InterruptTime.Any() ? string.Join(", ", p.InterruptTime) : "None"
                    );
            }
            dataGridView.DataSource = Table;

            cpuWorkflowBox.Text = cpuWorkflow.ToString();

            averageWaitingTimeLabel.Text =
                Math.Round((double) totalProcessesWaitingTime/processesCount, 2)
                .ToString(CultureInfo.InvariantCulture);

            averageTurnaroundTimeLabel.Text =
                Math.Round((double) totalProcessesTurnaroundTime/processesCount, 2)
                    .ToString(CultureInfo.InvariantCulture);

            averageResponseTimeLabel.Text =
                Math.Round((double) totalProcessesResponseTime/processesCount, 2)
                .ToString(CultureInfo.InvariantCulture);

            utilizationLabel.Text =
                Math.Round((double) cpuExecutionTime/maxEndTime*100, 2)
                .ToString(CultureInfo.InvariantCulture) + '%';

            throughputLabel.Text =
                Math.Round((double) processesCount/cpuExecutionTime, 2)
                .ToString(CultureInfo.InvariantCulture);

            cpuExecutionTimeLabel.Text = cpuExecutionTime.ToString();
        }

        #region Getting input data

        private void RandomBtn_Click(object sender, EventArgs e)
        {
            var randomNumber = new Random();

            ClearForm();

            for (var i = 0; i < randomNumber.Next(3, 9); i++)
            {
                Processes.Add(new Process("P" + (i + 1),
                    randomNumber.Next(0, 9),
                    randomNumber.Next(1, 11),
                    randomNumber.Next(0, 6))
                    );

                Table.Rows.Add(
                    Processes[i].ProcessName,
                    Processes[i].ArrivalTime,
                    Processes[i].BurstTime,
                    Processes[i].Priority
                    );
            }
            EnableControls();
            dataGridView.DataSource = Table;
        }

        private void ReadFile()
        {
            ClearForm();
            try
            {
                if (new FileInfo(openFileDialog.FileName).Length > 3072)
                    throw new Exception("Data input file is too big!");
                var textFile = File.ReadAllText(openFileDialog.FileName);
                var lines = textFile.Split('\n').ToList();
                lines.RemoveAll(p => p.ToString() == "\r" || p.ToString() == "");
                if (lines.Count > 101)
                    throw new Exception("Too many processes, don't you think? \n100 Process Max.");
                if (lines.Count < 3)
                    throw new Exception("Data input file is empty! \n2 Process Min.");

                for (var i = 1; i < lines.Count; i++)
                {
                    var tabs = lines[i].Split('\t');

                    var check = tabs[1] + tabs[2] + tabs[3];
                    var isNumeric = int.TryParse(check, out int temp);
                    int.TryParse(tabs[1], out int arrivalTime);
                    int.TryParse(tabs[2], out int burstTime);
                    int.TryParse(tabs[3], out int priority);

                    if (!isNumeric
                        || arrivalTime < 0
                        || burstTime < 1
                        || burstTime > 25
                        || priority < 0)
                        throw new Exception(
                            "Data input file contains invalid information(s).\nMake sure for all processes:\nArrival time >= 0, burst time >= 1 and <= 25, priority >= 0\nPlease check line number " +
                            ++i + " in the text file.");

                    Processes.Add(new Process(tabs[0], arrivalTime, burstTime, priority));
                }

                MessageBox.Show(@"File has been read successfully!",
                    @"Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                EnableControls();

                foreach (var process in Processes)
                {
                    Table.Rows.Add(
                        process.ProcessName,
                        process.ArrivalTime,
                        process.BurstTime,
                        process.Priority);
                }
            }
            catch (Exception e)
            {
                ClearForm();
                DisableControls();

                MessageBox.Show(e.Message,
                    @"Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion Getting input data

        #region Scheduling algorithms

        private void SolveAndDisplayResults_FCFS()
        {
            var clonedProcesses = Process.SortProcesses(Process.Filters.WithoutSpecialCaseSorting,
                Process.Filters.ArrivalTime,
                Process.Clone(Processes));

            var cpuWorkflow = new StringBuilder(" ");
            var currentTime = 0;

            foreach (var p in clonedProcesses)
            {
                if (p.ArrivalTime > currentTime)
                {
                    cpuWorkflow.AppendFormat("[Idle {0}-{1}] ", currentTime, p.ArrivalTime);
                    currentTime = p.ArrivalTime;
                }
                cpuWorkflow.Append(p.ProcessName + ' ');
                p.StartTime.Add(currentTime);
                currentTime += p.BurstTime;
                p.CompletionTime = currentTime;
            }
            CalculateAndDisplayResults(clonedProcesses, currentTime, cpuWorkflow);
        }

        private void SolveAndDisplayResults_SJF_PS(CheckBox isPreemptiveOn,
            Process.Filters sortingCase)
        {
            var clonedProcesses = Process.SortProcesses(Process.Filters.WithSpecialCaseSorting,
                sortingCase == Process.Filters.TimeLeft ? Process.Filters.TimeLeft : Process.Filters.Priority,
                Process.Clone(Processes));

            var arrivals = new List<Process>();
            Process previousProcess = null;
            var cpuWorkflow = new StringBuilder(" ");
            var propertyInfo = typeof (Process).GetProperty(sortingCase.ToString());
            var currentTime = 0;
            int? previousTime = null;
            var isStarted = true;

            while (clonedProcesses.Any(p => p.TimeLeft > 0))
            {
                arrivals.AddRange(clonedProcesses.FindAll(p => p.ArrivalTime == currentTime
                                                               && p.HasArrived != true));
                arrivals.ForEach(p => p.HasArrived = true);

                if (arrivals.Count == 0)
                {
                    if (isStarted)
                    {
                        previousTime = currentTime;
                        isStarted = false;
                    }
                    currentTime++;
                    continue;
                }

                isStarted = true;
                if (currentTime > previousTime)
                {
                    cpuWorkflow.AppendFormat("[Idle {0}-{1}] ", previousTime, currentTime);
                    previousTime = null;
                }

                var currentProcess = arrivals.OrderBy(p => propertyInfo.GetValue(p, null))
                    .FirstOrDefault();
                cpuWorkflow.Append(currentProcess.ProcessName + ' ');
                arrivals.Remove(currentProcess);

                if (previousProcess != null && previousProcess.TimeLeft != 0)
                    previousProcess.InterruptTime.Add(currentTime);

                previousProcess = currentProcess;
                currentProcess.StartTime.Add(currentTime);

                while (true)
                {
                    currentProcess.TimeLeft--;
                    currentTime++;
                    if (currentProcess.TimeLeft == 0)
                    {
                        currentProcess.CompletionTime = currentTime;
                        break;
                    }

                    arrivals.AddRange(clonedProcesses.FindAll(p => p.ArrivalTime == currentTime));
                    arrivals.ForEach(p => p.HasArrived = true);

                    if (!isPreemptiveOn.Checked
                        || !arrivals.Any(p =>
                            (int)propertyInfo.GetValue(p, null) < (int)propertyInfo.GetValue(currentProcess, null)))
                        continue;

                    arrivals.Add(currentProcess);
                    break;
                }
            }
            CalculateAndDisplayResults(clonedProcesses, currentTime, cpuWorkflow);
        }

        private void SolveAndDisplayResults_RR()
        {
            var clonedProcesses = Process.SortProcesses(Process.Filters.WithoutSpecialCaseSorting,
                Process.Filters.ArrivalTime,
                Process.Clone(Processes));

            var arrivals = new List<Process>();
            Process previousProcess = null;
            var cpuWorkflow = new StringBuilder(" ");
            var currentTime = 0;
            int? previousTime = null;
            var isStarted = true;

            while (clonedProcesses.Any(p => p.TimeLeft > 0))
            {
                arrivals.AddRange(clonedProcesses.FindAll(p => p.ArrivalTime <= currentTime
                                                               && p.HasArrived != true));
                arrivals.ForEach(p => p.HasArrived = true);

                if (arrivals.Count == 0)
                {
                    if (isStarted)
                    {
                        previousTime = currentTime;
                        isStarted = false;
                    }
                    currentTime++;
                    continue;
                }

                isStarted = true;
                if (currentTime > previousTime)
                {
                    cpuWorkflow.AppendFormat("[Idle {0}-{1}] ", previousTime, currentTime);
                    previousTime = null;
                }

                var currentProcess = arrivals.First();
                cpuWorkflow.Append(currentProcess.ProcessName + ' ');
                arrivals.Remove(currentProcess);

                currentProcess.StartTime.Add(currentTime);

                if (previousProcess != null && previousProcess.TimeLeft != 0)
                    previousProcess.InterruptTime.Add(currentTime);

                previousProcess = currentProcess;

                if (currentProcess.TimeLeft > Convert.ToInt32(timeQuantumBox.Text))
                {
                    currentProcess.TimeLeft -= Convert.ToInt32(timeQuantumBox.Text);
                    currentTime += Convert.ToInt32(timeQuantumBox.Text);
                }
                else
                {
                    currentTime += currentProcess.TimeLeft;
                    currentProcess.CompletionTime = currentTime;
                    currentProcess.TimeLeft = 0;
                }

                arrivals.AddRange(clonedProcesses.FindAll(p => p.ArrivalTime <= currentTime
                                                               && p.HasArrived != true));
                arrivals.ForEach(p => p.HasArrived = true);

                if (currentProcess.TimeLeft != 0)
                    arrivals.Add(currentProcess);
            }
            CalculateAndDisplayResults(clonedProcesses, currentTime, cpuWorkflow);
        }

        #endregion Scheduling algorithms

        #region Form controls

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Table.Clear();

            if (fcfsBtn.Checked)
            {
                SolveAndDisplayResults_FCFS();
            }
            else if (sjfBtn.Checked)
            {
                SolveAndDisplayResults_SJF_PS(sjfPreemtiveCheck, Process.Filters.TimeLeft);
            }
            else if (psBtn.Checked)
            {
                SolveAndDisplayResults_SJF_PS(psPreemtiveCheck, Process.Filters.Priority);
            }
            else if (rrBtn.Checked)
            {
                SolveAndDisplayResults_RR();
            }
            Cursor = Cursors.Default;
        }

        private void ClearForm()
        {
            averageWaitingTimeLabel.Text = @"N/A";
            averageTurnaroundTimeLabel.Text = @"N/A";
            averageResponseTimeLabel.Text = @"N/A";
            utilizationLabel.Text = @"N/A";
            throughputLabel.Text = @"N/A";
            cpuExecutionTimeLabel.Text = @"N/A";
            Table.Clear();
            cpuWorkflowBox.Clear();
            Processes.Clear();
        }

        private void DisableControls()
        {
            fcfsBtn.Enabled = false;
            sjfBtn.Enabled = false;
            psBtn.Enabled = false;
            rrBtn.Enabled = false;
            sjfPreemtiveCheck.Enabled = false;
            psPreemtiveCheck.Enabled = false;
            timeQuantumBox.Enabled = false;
            calcBtn.Enabled = false;
        }

        private void EnableControls()
        {
            fcfsBtn.Enabled = true;
            sjfBtn.Enabled = true;
            psBtn.Enabled = true;
            rrBtn.Enabled = true;

            if (fcfsBtn.Checked
                || sjfBtn.Checked
                || psBtn.Checked
                || rrBtn.Checked)
                calcBtn.Enabled = true;

            if (sjfBtn.Checked)
                sjfPreemtiveCheck.Enabled = true;
            if (psBtn.Checked)
                psPreemtiveCheck.Enabled = true;
            if (rrBtn.Checked)
                timeQuantumBox.Enabled = true;
        }

        private void FcfsBtn_CheckedChanged(object sender, EventArgs e)
        {
            calcBtn.Enabled = true;
            sjfPreemtiveCheck.Enabled = false;
            psPreemtiveCheck.Enabled = false;
            timeQuantumBox.Enabled = false;
        }

        private void FileBrowser_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            Cursor = Cursors.WaitCursor;
            ReadFile();
            Cursor = Cursors.Default;
        }

        private void PsBtn_CheckedChanged(object sender, EventArgs e)
        {
            calcBtn.Enabled = true;
            sjfPreemtiveCheck.Enabled = false;
            psPreemtiveCheck.Enabled = true;
            timeQuantumBox.Enabled = false;
        }

        private void RrBtn_CheckedChanged(object sender, EventArgs e)
        {
            calcBtn.Enabled = true;
            sjfPreemtiveCheck.Enabled = false;
            psPreemtiveCheck.Enabled = false;
            timeQuantumBox.Enabled = true;
        }

        private void SjfBtn_CheckedChanged(object sender, EventArgs e)
        {
            calcBtn.Enabled = true;
            sjfPreemtiveCheck.Enabled = true;
            psPreemtiveCheck.Enabled = false;
            timeQuantumBox.Enabled = false;
        }

        #endregion Form controls
    }
}