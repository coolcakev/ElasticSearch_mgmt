using ElasticSearch_mgmt.Models;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Services
{
    public class SreviceFile
    {
        ElasticClient _client { get; set; }
        public SreviceFile(ElasticClient client)
        {
            _client = client;
        }
        public void Conect()
        {
            string json = File.ReadAllText("mgmt.json");
            string json1 = File.ReadAllText("properties.json");



            List<MGMT> people = JsonConvert.DeserializeObject<List<MGMT1>>(json).Select(s => s.mgmt).Distinct(new temp()).ToList();
            List<Property> people1 = JsonConvert.DeserializeObject<List<Property1>>(json1).Select(s => s.property).Distinct(new propertycomp()).ToList();


            var bulkIndexResponse = _client.Bulk(b => b
            .Index("mgmt")
            .IndexMany(people)
            );
            bulkIndexResponse = _client.Bulk(b => b
           .Index("property")
           .IndexMany(people1)
           );
        }


    }
}
