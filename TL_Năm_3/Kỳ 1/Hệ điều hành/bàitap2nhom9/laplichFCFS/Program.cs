using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// C# program for implementation of FCFS  
// scheduling  
class GFG
{

    // Function to find the waiting time for all  
    // processes  
    static void FindWaitingTime(int[] Processes, int n, int[] bt, int[] wt)
    {
        // waiting time for first process is 0  
        wt[0] = 0;

        // calculating waiting time  
        for (int i = 1; i < n; i++)
        {
            wt[i] = bt[i - 1] + wt[i - 1];
        }
    }

    // Function to calculate turn around time  
    static void FindTurnAroundTime(int[] Processes, int n,
            int[] bt, int[] wt, int[] tat)
    {
        // calculating turnaround time by adding  
        // bt[i] + wt[i]  
        for (int i = 0; i < n; i++)
        {
            tat[i] = bt[i] + wt[i];
        }
    }

    // Function to calculate average time  
    static void FindavgTime(int[] processes, int n, int[] bt)
    {
        int[] wt = new int[n];
        int[] tat = new int[n];
        int total_wt = 0, total_tat = 0;

        //Function to find waiting time of all processes  
        FindWaitingTime(processes, n, bt, wt);

        //Function to find turn around time for all processes  
        FindTurnAroundTime(processes, n, bt, wt, tat);

        //Display processes along with all details  
        Console.Write("Processes Burst time Waiting"
                    + " time Turn around time\n");

        // Calculate total waiting time and total turn  
        // around time  
        for (int i = 0; i < n; i++)
        {
            total_wt += wt[i];
            total_tat += tat[i];
            Console.Write(" {0} ", (i + 1));
            Console.Write("     {0} ", bt[i]);
            Console.Write("     {0}", wt[i]);
            Console.Write("     {0}\n", tat[i]);
        }
        float s = (float)total_wt / (float)n;
        int t = total_tat / n;
        Console.Write("Average waiting time = {0}", s);
        Console.Write("\n");
        Console.Write("Average turn around time = {0} ", t);
    }

    // Driver code  
    public static void Main(string[] Args)
    {
        // process id's  
        int[] processes = { 1, 2, 3 };
        int n = processes.Length;

        // Burst time of all processes  
        int[] burst_time = { 10, 5, 8 };

        FindavgTime(processes, n, burst_time);
    }
}

// This code contributed by Rajput-Ji 