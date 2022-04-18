using System;
using System.Collections.Generic;

namespace Common
{
    public static class Settings
    {
        public static Uri[] ElasticUris(){
            Uri[] uris = new[]
            {
                new Uri("http://10.10.100.1:9200"),
                new Uri("http://10.10.100.2:9200"),
                new Uri("http://10.10.100.3:9200"),
                new Uri("http://10.10.101.5:9200"),
            };
            return uris;
        }

        public static List<string> IcoList()
        {
            return new List<string>()
            {
                "00000078",
                "00020711",
                "00212423",
                "00303461",
                "00872113",
                "27065464",
                "27332730",
                "28000811",
                "47013591",
                "60076658",
                "60275847",
                "61774235",
                "65947959",
                "70882525",
                "70890749"
            };
        }
    }
    
}

