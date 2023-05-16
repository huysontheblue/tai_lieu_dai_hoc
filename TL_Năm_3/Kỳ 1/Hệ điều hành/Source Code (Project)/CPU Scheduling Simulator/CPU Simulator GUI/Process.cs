using System.Collections.Generic;

namespace CPU_Simulator
{
    public class Process
    {
        public enum Filters : byte
        {
            TimeLeft,
            ArrivalTime,
            Priority,
            WithSpecialCaseSorting,
            WithoutSpecialCaseSorting
        }

        public static List<Process> Clone(List<Process> listToClone)
        {
            var clonedList = new List<Process>(listToClone.Count);
            listToClone.ForEach(
                item =>
                {
                    clonedList.Add(new Process(item.ProcessName, item.ArrivalTime, item.BurstTime, item.Priority));
                });
            return clonedList;
        }

        public static List<Process> SortProcesses(Filters specialSorting,
            Filters whichSortingCase,
            List<Process> processes)
        {
            var propertyInfo = typeof (Process).GetProperty(whichSortingCase.ToString());
            for (var k = 0; k < processes.Count; k++)
            {
                for (var i = k + 1; i < processes.Count; i++)
                {
                    Process temp;
                    if (processes[i].ArrivalTime < processes[k].ArrivalTime)
                    {
                        temp = processes[i];
                        processes.Remove(temp);
                        processes.Insert(k, temp);
                    }
                    else if (processes[i].ArrivalTime == processes[k].ArrivalTime
                             && specialSorting == Filters.WithoutSpecialCaseSorting)
                    {
                    }
                    else if (processes[i].ArrivalTime == processes[k].ArrivalTime
                             &&
                             (int) propertyInfo.GetValue(processes[i], null) <
                             (int) propertyInfo.GetValue(processes[k], null))
                    {
                        temp = processes[i];
                        processes.Remove(temp);
                        processes.Insert(k, temp);
                    }
                }
            }
            return processes;
        }

        #region Properties

        public string ProcessName { get; }
        public int BurstTime { get; }
        public int ArrivalTime { get; }
        public int Priority { get; }
        public List<int> StartTime { get; private set; }
        public int CompletionTime { get; set; }
        public List<int> InterruptTime { get; private set; }
        public int TimeLeft { get; set; }
        public bool HasArrived { get; set; }

        #endregion Properties

        #region Constructors

        public Process(string processName, int arrivalTime, int burstTime, int priority)
        {
            ProcessName = processName;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            Priority = priority;
            TimeLeft = burstTime;
            InterruptTime = new List<int>();
            StartTime = new List<int>();
        }

        public Process()
        {
        }

        #endregion Constructors
    }
}