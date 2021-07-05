using System;
using Advent;

namespace AlgorithmPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //IResolve res = new DayThree();
            IResolve res = new DomainProblem();
            Console.WriteLine($"Resolving {res.GetType().ToString()}!");
            res.Resolve();
        }
    }
}
