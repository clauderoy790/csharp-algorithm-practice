using AlgorithmPractice;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class DayTwo : Resolver
    {
        List<PasswordInfo> passwords;

        public DayTwo()
        {
            passwords = new List<PasswordInfo>();
            var pass = ReadInputFileToString();
            foreach (var p in pass)
            {
                passwords.Add(ProcessPassword(p));
            }
        }

        protected override object PartOne()
        {
            int nbValid = 0;
            foreach(var password in passwords) {
                int count = password.Password.Count((c) => {
                    return c == password.Character;
                });
                if (count >= password.MinOccurence && count <= password.MaxOccurence) {
                    nbValid++;
                }
            }
            return nbValid;
        }

        protected override object PartTwo()
        {
            int nbValid = 0;
            foreach(var password in passwords) {
                bool first = IndexValid(password.MinOccurence-1,password.Password) && password.Password[password.MinOccurence-1] == password.Character;
                bool second = IndexValid(password.MaxOccurence-1,password.Password) && password.Password[password.MaxOccurence-1] == password.Character;
                if (first ^ second) {
                    nbValid++;
                }
            }
            return nbValid;
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