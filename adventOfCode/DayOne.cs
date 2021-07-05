using AlgorithmPractice;
using System;
using System.IO;
using System.Collections.Generic;

namespace Advent
{
    public class DayOne : Resolver
    {
        List<int> expenses;

        public DayOne() {
            expenses = ReadInputFileToInt();
        }

        protected override object PartOne()
        {
            int answer = 0;
            for(int i = 0; i< expenses.Count;++i) {
                int nb1 = expenses[i];
                for(int j = i;j <expenses.Count;j++) {
                    int nb2 = expenses[j];
                    if (nb1 + nb2 == 2020) {
                        answer = nb1*nb2;
                        break;
                    }
                }
            }
            return answer;  
        }

        protected override object PartTwo() {
            int answer = 0;
            for (int i = 0; i < expenses.Count; ++i)
            {
                int nb1 = expenses[i];
                for (int j = i+1; j < expenses.Count; j++)
                {
                    int nb2 = expenses[j];
                    for (int k = j+1; k < expenses.Count; ++k)
                    {
                        int nb3 = expenses[k];
                        if (nb1 + nb2 + nb3 == 2020)
                        {
                            answer = nb1 * nb2 * nb3;
                            break;
                        }

                    }
                }
            }
            return answer;  
        }
    }
}