
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Models
{
    public class validform
    {
        [Required]
        public string phase { get; set; }
        public string market { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "кількість результатів має бути меншою за 10 000")]
        public int count { get; set; }
        [Required]


        ///////////////////////////////////////////////////////////////////////////////////
        public string phaseProperty { get; set; }
        public string marketProperty { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "кількість результатів має бути меншою за 10 000")]
        public int countProperty { get; set; }

    }
    public class allform
    {
        public validform Validform { get; set; }
        //public ISearchResponse<mgmt> searchperson { get; set; }
        public List<MGMT> searchperson { get; set; }
        public List<Property> searchProperty { get; set; }

        public List<string> market { get; set; }

        public List<string> marketProperty { get; set; }


    }
}
