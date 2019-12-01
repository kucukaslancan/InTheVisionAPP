using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InTheVision.Models
{
    public class SettingsMv
    {
        movieDBEntities _db = new movieDBEntities();

        public int getMovieCount()
        {
            // Tüm filmlerin sayısını döndürür.
            
            int count = _db.Movies.Count();
            return count;
        }
    }
}