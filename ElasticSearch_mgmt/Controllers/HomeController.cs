using ElasticSearch_mgmt.Models;
using ElasticSearch_mgmt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch_mgmt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ElasticClient _client;
        private readonly managestr managestr;
        private readonly WorkWithElastic workWithElastic;

        public HomeController(ILogger<HomeController> logger, ElasticClient client, managestr managestr, WorkWithElastic workWithElastic)
        {
            _logger = logger;
            _client = client;
            this.managestr = managestr;
            this.workWithElastic = workWithElastic;
        }

        //public IActionResult Index()
        //{
        //    allform abc =new allform();
        //    return View( abc);
        //}
        //[HttpPost]
        public IActionResult Index(validform validform)
        {
            //var list = _client.Search<MGMT>(s => s.Size(validform.count).Query(q => q.MatchAll())).Documents.ToList();
           

            if (validform.phaseProperty != null)              
                validform.phaseProperty = managestr.checkstr(validform.phaseProperty);
            

            var market = workWithElastic.GetAllMarket(new MGMT());

            var marketProperty = workWithElastic.GetAllMarket(new Property());

            allform abc = new allform();
            abc.market = market;
            abc.marketProperty = marketProperty;
          
            




            if (validform.marketProperty == "null")
            {
                var listProperty = _client.Search<Property>(s => s.Size(validform.countProperty).Index("property").Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(validform.phaseProperty)))).Documents.ToList();
                abc.searchProperty = listProperty;
            }
            else
            {
                var listProperty = _client.Search<Property>(s => s.Size(validform.countProperty).Index("property").Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(validform.phaseProperty)) && q.Match(m => m.Field(f => f.market
                  ).Query(validform.marketProperty)))).Documents.ToList();
                abc.searchProperty = listProperty;
            }




            return View(abc);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ViewMgmt(string name,string market,int count)
        {
            if (name != null)
                name = managestr.checkstr(name);
          
            if (market == "null")
            {
                var list = _client.Search<MGMT>(s => s.Size(count).Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(name)))).Documents.ToList();
               return PartialView(list);
            }
            else
            {
                var list = _client.Search<MGMT>(s => s.Size(count).Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(name)) && q.Match(m => m.Field(f => f.market
                  ).Query(market)))).Documents.ToList();
                return PartialView(list);
            }

        }
        public IActionResult ViewProp(string name, string market, int count)
        {
            if (name != null)
                name = managestr.checkstr(name);

            if (market == "null")
            {
                var list = _client.Search<Property>(s => s.Index("property").Size(count).Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(name)))).Documents.ToList();
                return PartialView(list);
            }
            else
            {
                var list = _client.Search<Property>(s => s.Index("property").Size(count).Query(q => q.MatchPhrase(m => m.Field(f => f.name).Slop(3).Query(name)) && q.Match(m => m.Field(f => f.market
                  ).Query(market)))).Documents.ToList();
                return PartialView(list);
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
