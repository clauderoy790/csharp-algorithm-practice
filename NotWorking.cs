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
using System.Linq;

class Solution {
    static void Main(String[] args) {

        var counts = new string[] {
            "900,google.com",
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
            "1,google.co.uk"
        };
        
        var val = calculateClicksByDomain(counts);
        
        foreach(var pair in val) {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        
        

        
    }
    static Dictionary<string, int> calculateClicksByDomain(string[] input) {
        var returnVal = new Dictionary<string,int>();
        List<DomainInfo> infos = new List<DomainInfo>();
        foreach(var str in input) {
            var split = str.Split(",");
            
            DomainInfo info = new DomainInfo(split[0],split[1]);
            infos.Add(info);
        }
                                             
                                             foreach(var info in infos) {
                                                 foreach(var domain in info.domains) {
                                                     if (!returnVal.ContainsKey(domain)) {
                                                         returnVal[domain] = 0;
                                                     }
                                                     returnVal[domain] += info.clickCount;
                                                 }
                                             }
                                             
        return returnVal;
    }
    class DomainInfo {
            public int clickCount;
            public List<string> domains;
            public DomainInfo(string clickCount, string fullDomain) {
                this.domains = processDomains(fullDomain);
                this.clickCount = int.Parse(clickCount);
                
            }
        
            List<string> processDomains(string domains) {
                //mobile.sports.yahoo.com
                var final = new List<string>();
                var subDomains = domains.Split(".").ToList();
                //Iterate through all subdomains
                //for(int i = 0;i <subDomains.Count;++i) {
                    //Console.WriteLine("subdomain: "+subDomains[0]);
                    //Console.WriteLine("domain count: "+subDomains.Count);
                    string domain = subDomains[0];
                        /*for(int j = 1; j< subDomains.Count;++j) {
                            domain += "."+subDomains[j];
                            //Console.WriteLine("inside loop: "+domain);
                             final.Add(domain);
                        }*/
                        for(int j = subDomains.Count-1; j> 0;--j) {
                            domain += "."+subDomains[j];
                            //Console.WriteLine("inside loop: "+domain);
                             final.Add(domain);
                        }
                       
                //}
                return final;
            }
        }
}
