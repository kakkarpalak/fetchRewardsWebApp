using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fetchRewardsWebApplication.Models;
using Newtonsoft.Json;

namespace fetchRewardsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var json = (new WebClient()).DownloadString("https://fetch-hiring.s3.amazonaws.com/hiring.json");
            
            //Deserializing json
            dynamic itemss = JsonConvert.DeserializeObject<List<Item>>(json);
            List<Item> list = new List<Item>();
            foreach (var i in itemss ) {
               
                //Checking if the Item name is empty or null
                if (i.name != null && !String.IsNullOrEmpty(i.name))
                  {
                    //Adding each field to list
                    list.Add(new Item()
                    {
                        id = i.id,
                        listId = i.listId,
                        name = i.name,
                        nameId = int.Parse(i.name.Substring(5))
                    }
                    );
                  }
            }

            //Sort by list ID and then by name.
            list.Sort((x, y)
            => {
                var listIdComparison = x.listId.CompareTo(y.listId);
                if (listIdComparison != 0)
                    return listIdComparison;
                else return x.nameId.CompareTo(y.nameId);
            });
           
            return View(list);
        }
    }
}   