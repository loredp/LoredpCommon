using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Greedy;

namespace Algorithm.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            GreedyChooseAlgorithm algorithm;

            algorithm = new GreedyChooseAlgorithm();
            Console.WriteLine(string.Join(",",algorithm.GetGreedyChooseOptimal()));

            Console.Read();
        }
    }
}
