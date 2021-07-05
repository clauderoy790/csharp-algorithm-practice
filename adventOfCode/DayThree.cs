using AlgorithmPractice;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class DayThree : Resolver
    {
        List<string> map;
        int x,y, width,height = 0;

        public DayThree()
        {
            map = ReadInputFileToString();
            height = map.Count;
            width = map[0].Length;
        }

        protected override object PartOne()
        {
            return countTrees(3,1);
        }

        protected override object PartTwo()
        {
            ulong answer = 1;

            int[,] offets = new int[,]{
                {1,1},
                {3,1},
                {5,1},
                {7,1},
                {1,2},
            };

            for(int i = 0; i<offets.GetLength(0);++i){
                int trees = countTrees(offets[i,0],offets[i,1]);
                answer *= (ulong)trees;
            }

            return answer;
        }

        private int countTrees(int offsetX, int offsetY) {
            int trees = 0;
            for(x=0,y=0;y<height;x+=offsetX,y+=offsetY) {
                if (map[y][x%width] == '#') {
                    trees++;
                }
            }
            return trees;
        }

        private bool IndexValid(int index, string password) {
            return index >= 0 && index < password.Length;
        }

        PasswordInfo ProcessPassword(string passwordString)
        {
            PasswordInfo info = new PasswordInfo();
            try
            {
                string[] split = passwordString.Split(": ");
                info.Password = split[1];
                split = split[0].Split(' ');
                info.Character = split[1][0];
                split = split[0].Split('-');
                info.MinOccurence = int.Parse(split[0]);
                info.MaxOccurence = int.Parse(split[1]);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Failed to parse password {passwordString}. Error: {e.Message}");
            }
            return info;
        }

        class PasswordInfo
        {
            public int MinOccurence { get; set; }
            public int MaxOccurence { get; set; }
            public char Character { get; set; }
            public string Password { get; set; }
        }
    }
}