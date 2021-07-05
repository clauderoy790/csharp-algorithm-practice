using System;
using System.IO;
using AlgorithmPractice;
using System.Collections.Generic;

namespace Advent {
    public abstract class Resolver : IResolve
    {
        public void Resolve() {
            var a1 = PartOne();
            var a2 = PartTwo();
            System.Console.WriteLine($"Part one! Answer is: {a1}");
            System.Console.WriteLine($"Part two! Answer is: {a2}");
        }
        protected abstract object PartOne();

        protected abstract object PartTwo();

        protected List<string> ReadInputFileToString() {
            return ReadInputFile<string>((line) => {
                return true;
            });
        }

        protected List<int> ReadInputFileToInt() {
            return ReadInputFile<int>((line) => {
                int nb;
                return int.TryParse(line,out nb);
            });
        }

        private List<T> ReadInputFile<T>(Func<string,bool> condition) {
            List<T> lst = new List<T>();
            if (condition == null) {
                throw new ArgumentException("condition function can't be null");
            }
            
            string filename = GetType().Name;
            filename = filename.Substring(0,1).ToLower()+filename.Substring(1)+".txt";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"adventOfCode/inputs",filename);
            using (var sr = new System.IO.StreamReader(filePath)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    if (condition(line))
                        lst.Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
            return lst;
        }
    }
}