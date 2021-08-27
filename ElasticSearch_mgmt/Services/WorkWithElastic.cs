using ElasticSearch_mgmt.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Services
{
    public class WorkWithElastic
    {
        private readonly ElasticClient client;

        public WorkWithElastic(ElasticClient client)
        {
            this.client = client;
        }
        public List<string> GetAllMarket(object obj)
        {
            if (obj is MGMT)
            {
                return client.Search<MGMT>(s => s.Size(10000).Query(q => q.MatchAll())).Documents.Select(i => i.market).Distinct().OrderBy(i=>i).ToList();
            }
            else if (obj is Property)
            {
                return client.Search<Property>(s => s.Size(10000).Query(q => q.MatchAll())).Documents.Select(i => i.market).Distinct().OrderBy(i => i).ToList();

            }
            return new List<string>();
       
        }
  
    
        public List<string> getsomebyname(object obj,string name)
        {
            
            if (obj is MGMT)
            {
                var temp = client.Search<MGMT>(s => s
                .Size(10000)
                      .Query(q => q
                          .Match(m => m
                              .Field(f => f.name)
                              .Query(name)
                              .Fuzziness(Fuzziness.EditDistance(1))
                              .PrefixLength(1)
                              .ZeroTermsQuery(ZeroTermsQuery.All)))).Documents.Select(s=>s.name).Distinct().Where((i,count)=>count<=6).ToList();
               return temp;
            }
            else if (obj is Property)
            {
                var temp = client.Search<Property>(s => s
                .Index("property")
                 .Size(10000)
                       .Query(q => q
                           .Match(m => m
                               .Field(f => f.name)
                               .Query(name)
                               .Fuzziness(Fuzziness.EditDistance(1))
                               .PrefixLength(1)
                               .ZeroTermsQuery(ZeroTermsQuery.All)))).Documents.Select(s => s.name).Distinct().Where((i, count) => count <= 6).ToList();

                
            return temp;
            }
            return new List<string> ();
        }

    }
}
