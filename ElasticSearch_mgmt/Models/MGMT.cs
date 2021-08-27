using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Models
{
    public class MGMT
    {      

        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
    }

    public class MGMT1
    {
        public MGMT mgmt { get; set; }
    }


    public class temp : IEqualityComparer<MGMT>
    {
        public new bool Equals(MGMT x, MGMT y)
        {
            return x.mgmtID == y.mgmtID && x.name == y.name && x.market == y.market && x.state == y.state;
        }



        public int GetHashCode(MGMT obj)
        {
            return obj.mgmtID.GetHashCode() ^ obj.name.GetHashCode() ^ obj.state.GetHashCode() ^ obj.market.GetHashCode();
        }
    }
}
