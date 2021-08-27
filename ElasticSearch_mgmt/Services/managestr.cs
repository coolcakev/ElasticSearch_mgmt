using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Controllers
{
    public class managestr
    {
        public string checkstr(string str)
        {
           //.Select(s => new string(s.ToLower().Distinct().ToArray()))
            var qer = str.Split(" ").ToList().Where(i => i != "and" && i != "in" && i != "or" && i != "the").ToList();
            //edge engram
            return string.Join(" ", qer);
            
        }
    }
}
