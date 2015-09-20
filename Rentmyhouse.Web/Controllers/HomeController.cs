using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentmyhouse.Repository;
using Rentmyhouse.Interfaces;
using Rentmyhouse.Models;
using Rentmyhouse.Helpers;


namespace Rentmyhouse.Controllers
{
    public class HomeController : Controller
    {

        public const int PageSize = 3;

        #region Private member variables...
        private IAdvertRepository advertRepository;
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Controller to initialize User Repository
        /// </summary>
        public HomeController()
        {
            this.advertRepository = new AdvertRepository(new olympicsEntities());
        } 
        #endregion

        
        public ActionResult Index()
        {
   
            var advertPaged = new PagedData<sporteventstable>();
            IEnumerable<sporteventstable> adverts = advertRepository.GetAdvertsForHomepageGallery();

            advertPaged.Data = adverts.Take(PageSize);
            advertPaged.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)adverts.Count() / PageSize));
            advertPaged.CurrentPage = 1;

            ViewData["HomepageGalleryAdverts"] = advertPaged;
            ViewBag.Css = "home";

            return View();

        }


        public ActionResult HomepageGallery(int page)
        {
            var advertPaged = new PagedData<sporteventstable>();
            IEnumerable<sporteventstable> adverts = advertRepository.GetAdvertsForHomepageGallery();

            advertPaged.Data = adverts.Skip(PageSize * (page - 1)).Take(PageSize);

            advertPaged.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)adverts.Count() / PageSize));
            advertPaged.CurrentPage = 1;


            return PartialView(advertPaged);
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
