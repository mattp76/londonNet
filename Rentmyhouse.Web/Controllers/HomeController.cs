using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentmyhouse.Repository;
using Rentmyhouse.Interfaces;
using Rentmyhouse.Models;
using Rentmyhouse.ViewModels;
using Rentmyhouse.Helpers;
using PagedList;


namespace Rentmyhouse.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string site)
        {

            ViewBag.Css = "home";
            ViewBag.Site = !string.IsNullOrEmpty(site) ? site : "london";

            return View();
        }


        public ActionResult HomeDiscover()
        {

            //dbContext get content from table: cms where contentAliasType = "homeDiscover"

            // Perform data access using the context 
            using (var context = new olympicsEntities())
            {
                // Perform data access using the context 
                var hd = from a in context.cms
                         where a.SS_ID == 1 && a.contentTypeAlias == "homeDiscover"
                         select a.content;
                             


                var viewModel = new HomeDiscoverViewModel()
                {
                    homeDiscover = hd.FirstOrDefault().ToString()
                };


                return PartialView(viewModel);
            }

        }

        public ActionResult HomepageGallery(int? page)
        {

            using (var context = new olympicsEntities()) 
            {     
                // Perform data access using the context 
                var adverts = from a in context.sporteventstables
                              where a.ss_id == 1 && !string.IsNullOrEmpty(a.strimage1) && a.strapproved == "yes"
                              orderby a.strdatetime descending
                              select a;

                int pageSize = 9;
                int pageNumber = (page ?? 1);
                return PartialView(adverts.ToPagedList(pageNumber, pageSize));
            }

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
