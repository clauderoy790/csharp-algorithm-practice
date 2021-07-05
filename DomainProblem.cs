/*
You are in charge of a display advertising program. Your ads are displayed on websites all over the internet. You have some CSV input data that counts how many times that users have clicked on an ad on each individual domain. Every line consists of a click count and a domain name, like this:

counts = [ "900,google.com",
     "60,mail.yahoo.com",
     "10,mobile.sports.yahoo.com",
     "40,sports.yahoo.com",
     "300,yahoo.com",
     "10,stackoverflow.com",
     "20,overflow.com",
     "5,com.com",
     "2,en.wikipedia.org",
     "1,m.wikipedia.org",
     "1,mobile.sports",
     "1,google.co.uk"]

Write a function that takes this input as a parameter and returns a data structure containing the number of clicks that were recorded on each domain AND each subdomain under it. For example, a click on "mail.yahoo.com" counts toward the totals for "mail.yahoo.com", "yahoo.com", and "com". (Subdomains are added to the left of their parent domain. So "mail" and "mail.yahoo" are not valid domains. Note that "mobile.sports" appears as a separate domain near the bottom of the input.)

Sample output (in any order/format):

calculateClicksByDomain(counts) =>
com:                     1345
google.com:              900
stackoverflow.com:       10
overflow.com:            20
yahoo.com:               410
mail.yahoo.com:          60
mobile.sports.yahoo.com: 10
sports.yahoo.com:        50
com.com:                 5
org:                     3
wikipedia.org:           3
en.wikipedia.org:        2
m.wikipedia.org:         1
mobile.sports:           1
sports:                  1
uk:                      1
co.uk:                   1
google.co.uk:            1

n: number of domains in the input
(individual domains and subdomains have a constant upper length)

*/

using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    public class DomainProblem : IResolve
    {

        string[] input = new string[] { "900,google.com",
        "60,mail.yahoo.com",
        "10,mobile.sports.yahoo.com",
        "40,sports.yahoo.com",
        "300,yahoo.com",
        "10,stackoverflow.com",
        "20,overflow.com",
        "5,com.com",
        "2,en.wikipedia.org",
        "1,m.wikipedia.org",
        "1,mobile.sports",
        "1,google.co.uk"};

        public void Resolve()
        {

            var info = new DomainInfo(input[8]);
            var domainInfos = BuildDomainInfos(input);
            var clickCounts = CountClicks(domainInfos);

            PrintResult(clickCounts);
        }

        List<DomainInfo> BuildDomainInfos(string[] input)
        {
            List<DomainInfo> results = new List<DomainInfo>();

            foreach (var str in input)
            {
                results.Add(new DomainInfo(str));
            }
            return results;
        }

        Dictionary<string, int> CountClicks(List<DomainInfo> domainInfos)
        {
            Dictionary<string, int> clickCounts = new Dictionary<string, int>();
            foreach (var info in domainInfos)
            {
                foreach (var domain in info.domains)
                {
                    if (!clickCounts.ContainsKey(domain))
                    {
                        clickCounts[domain] = 0;
                    }
                    clickCounts[domain] += info.clickCount;
                }
            }
            return clickCounts;
        }


        void PrintResult(Dictionary<string, int> results)
        {
            foreach (var pair in results)
            {
                System.Console.WriteLine($"domain: {pair.Key}, has {pair.Value} clicks.");
            }
        }

        class DomainInfo
        {
            public int clickCount;
            public List<string> domains;
            public DomainInfo(string input)
            {
                domains = new List<string>();
                var split = input.Split(',');
                this.clickCount = int.Parse(split[0]);
                BuildDomains(split[1]);
            }

            private void BuildDomains(string input)
            {
                var split = input.Split(".");

                //Start looping from the end of the domain e.g: google.com <-
                for (int i = split.Length - 1; i >= 0; --i)
                {
                    string domain = "";

                    //Add every subdomain
                    for (int j = i; j < split.Length; j++)
                    {
                        domain += split[j];
                        //If we're not at out last domain
                        if (j < split.Length - 1)
                        {
                            domain += ".";
                        }
                    }
                    domains.Add(domain);
                }
            }
        }
    }
}