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
            int count = _db.Movies.Count();
            return count;
        }
    }
}