using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Rentmyhouse.Interfaces;
using Rentmyhouse.Models;


namespace Rentmyhouse.Repository
{
    public class AdvertRepository:IAdvertRepository
    {

        private olympicsEntities context;

        public AdvertRepository(olympicsEntities context)
        {
            this.context = context;
        }

        public IEnumerable<sporteventstable> GetAdverts()
        {
            return context
                    .sporteventstables
                    .Where(i => 
                        i.ss_id == 1 && 
                        i.strapproved == "yes")
                    .OrderByDescending(i => i.strdatetime);
        }


        public IEnumerable<sporteventstable> GetAdvertsForHomepageGallery()
        {
            return context
                    .sporteventstables
                    .Where(i => 
                        i.ss_id == 1 && 
                        i.strapproved == "yes" && 
                        !string.IsNullOrEmpty(i.strimage1))
                    .OrderByDescending(i => i.strdatetime)
                    .ToList();
        }



        public sporteventstable GetAdvertByID(int advertId)
        {
            return context.sporteventstables.Find(advertId);
        }

        public void InsertAdvert(sporteventstable advert)
        {
            context.sporteventstables.Add(advert);
        }

        public void DeleteAdvert(int advertId)
        {
            sporteventstable advert = context.sporteventstables.Find(advertId);
            context.sporteventstables.Remove(advert);
        }

        public void UpdateAdvert(sporteventstable advert)
        {
            context.Entry(advert).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
