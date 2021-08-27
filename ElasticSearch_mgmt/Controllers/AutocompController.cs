using ElasticSearch_mgmt.Models;
using ElasticSearch_mgmt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Controllers
{
    public class AutocompController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ElasticClient _client;
        private readonly managestr managestr;
        private readonly WorkWithElastic workWithElastic;

        public AutocompController(ILogger<HomeController> logger, ElasticClient client, managestr managestr, WorkWithElastic workWithElastic)
        {
            _logger = logger;
            _client = client;
            this.managestr = managestr;
            this.workWithElastic = workWithElastic;
        }
        public IActionResult automgmt(string term)
        {

            var name = workWithElastic.getsomebyname(new MGMT(),  term);


            return Json(name);
        }
        public IActionResult autoprop(string term)
        {

            var name = workWithElastic.getsomebyname(new Property(), term);


            return Json(name);
        }
    }
}
