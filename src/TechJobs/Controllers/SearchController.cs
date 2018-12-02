using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
            //parameters- type of search, search term
                //named based on corresponding form field names
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchType.Equals("all"))
            // if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm); 
            }

  
            ViewBag.columns = ListController.columnChoices;
            ViewBag.jobs = jobs;
     
            return View("Index");
        }


    }
}
