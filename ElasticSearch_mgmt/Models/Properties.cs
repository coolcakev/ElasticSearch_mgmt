using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Models
{
    public class Property
    {


        public int propertyID { get; set; }

        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }      
          
          
          
    }
    public class Property1
    {
        public Property property { get; set; }
    }
    public class propertycomp : IEqualityComparer<Property>
    {
        public new bool Equals(Property x, Property y)
        {

            return x.propertyID == y.propertyID && x.city == y.city && x.formerName == y.formerName && x.lat == y.lat && x.lng == y.lng && x.market == y.market && x.name == y.name && x.state == y.state && x.streetAddress == y.streetAddress;
        }



        public int GetHashCode(Property obj)
        {
            return obj.city.GetHashCode() ^ obj.formerName.GetHashCode() ^ obj.lat.GetHashCode() ^ obj.lng.GetHashCode() ^ obj.market.GetHashCode() ^ obj.name.GetHashCode() ^ obj.propertyID.GetHashCode() ^ obj.state.GetHashCode() ^ obj.streetAddress.GetHashCode();
        }
    }


}

    

