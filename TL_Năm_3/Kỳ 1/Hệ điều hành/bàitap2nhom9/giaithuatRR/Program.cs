﻿// C# program to implement Round Robin
// Scheduling with different arrival time
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class GFG
{
    public static void RoundRobin(String[] p, int[] a, int[] b, int n)
    {
        // result of average times
        int res = 0;
        int resc = 0;

        // for sequence storage
        String seq = "";

        // copy the burst array and arrival array
        // for not effecting the actual array
        int[] res_b = new int[b.Length];
        int[] res_a = new int[a.Length];

        for (int i = 0; i < res_b.Length; i++)
        {
            res_b[i] = b[i];
            res_a[i] = a[i];
        }

        // critical time of system
        int t = 0;

        // for store the waiting time
        int[] w = new int[p.Length];

        // for store the Completion time
        int[] comp = new int[p.Length];

        while (true)
        {
            Boolean flag = true;
            for (int i = 0; i < p.Length; i++)
            {

                // these condition for if
                // arrival is not on zero

                // check that if there come before qtime
                if (res_a[i] <= t)
                {
                    if (res_a[i] <= n)
                    {
                        if (res_b[i] > 0)
                        {
                            flag = false;
                            if (res_b[i] > n)
                            {

                                // make decrease the b time
                                t += n;
                                res_b[i] = res_b[i] - n;
                                res_a[i] = res_a[i] + n;
                                seq += "->" + p[i];
                            }
                            else
                            {

                                // for last time
                                t += res_b[i];

                                // store comp time
                                comp[i] = t - a[i];

                                // store wait time
                                w[i] = t - b[i] - a[i];
                                res_b[i] = 0;

                                // add sequence
                                seq += "->" + p[i];
                            }
                        }
                    }
                    else if (res_a[i] > n)
                    {

                        // is any have less arrival time
                        // the coming process then execute them
                        for (int j = 0; j < p.Length; j++)
                        {

                            // compare
                            if (res_a[j] < res_a[i])
                            {
                                if (res_b[j] > 0)
                                {
                                    flag = false;
                                    if (res_b[j] > n)
                                    {
                                        t += n;
                                        res_b[j] = res_b[j] - n;
                                        res_a[j] = res_a[j] + n;
                                        seq += "->" + p[j];
                                    }
                                    else
                                    {
                                        t += res_b[j];
                                        comp[j] = t - a[j];
                                        w[j] = t - b[j] - a[j];
                                        res_b[j] = 0;
                                        seq += "->" + p[j];
                                    }
                                }
                            }
                        }

                        // now the previous porcess according to
                        // ith is process
                        if (res_b[i] > 0)
                        {
                            flag = false;

                            // Check for greaters
                            if (res_b[i] > n)
                            {
                                t += n;
                                res_b[i] = res_b[i] - n;
                                res_a[i] = res_a[i] + n;
                                seq += "->" + p[i];
                            }
                            else
                            {
                                t += res_b[i];
                                comp[i] = t - a[i];
                                w[i] = t - b[i] - a[i];
                                res_b[i] = 0;
                                seq += "->" + p[i];
                            }
                        }
                    }
                }

                // if no process is come on thse critical
                else if (res_a[i] > t)
                {
                    t++;
                    i--;
                }
            }

            // for exit the while loop
            if (flag)
            {
                break;
            }
        }

        Console.WriteLine("name   ctime   wtime");
        for (int i = 0; i < p.Length; i++)
        {
            Console.WriteLine(" " + p[i] + "\t" +
                                 comp[i] + "\t" + w[i]);

            res += w[i];
            resc += comp[i];
        }

        Console.WriteLine("Average waiting time is " +
                               (float)res / p.Length);
        Console.WriteLine("Average compilation time is " +
                                  (float)resc / p.Length);
        Console.WriteLine("Sequence is like that " + seq);
    }

    // Driver Code
    public static void Main()
    {
        // name of the process
        String[] name = { "p1", "p2", "p3", "p4" };

        // arrival for every process
        int[] arrivaltime = { 0, 1, 2, 3 };

        // burst time for every process
        int[] bursttime = { 10, 4, 5, 3 };

        // quantum time of each process
        int q = 3;

        // cal the function for output
        RoundRobin(name, arrivaltime, bursttime, q);
    }
}

// This code is contributed by Rajput-Ji