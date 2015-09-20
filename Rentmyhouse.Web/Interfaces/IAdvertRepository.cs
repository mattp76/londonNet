using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rentmyhouse.Models;

namespace Rentmyhouse.Interfaces
{
    public interface IAdvertRepository: IDisposable
    {
        IEnumerable<sporteventstable> GetAdverts();
        IEnumerable<sporteventstable> GetAdvertsForHomepageGallery();
        sporteventstable GetAdvertByID(int advertId);
        void InsertAdvert(sporteventstable advert);
        void DeleteAdvert(int advertId);
        void UpdateAdvert(sporteventstable advert);
        void Save();
    }
}
