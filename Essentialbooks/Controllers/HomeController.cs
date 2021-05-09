using Essentialbooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Essentialbooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Overview()
        {

            ApplicationDbContext db = new ApplicationDbContext();

            var mediaR = db.MediaRatings.ToList();
            var textP = db.TextPieces.ToList();



            List<MediaRatingAverage> mra = new List<MediaRatingAverage>();
          


            foreach (var tp in textP)
            {
                /*  IEnumerable<MediaRating> mediaRatingsL =
                       from m in mediaR
                       where m.MediaId == tp.Id
                       select m;
                       */
                //                var dd = mediaRatingsL.ToList().ToString().Count();
                MediaRatingAverage mediaRatingAverage = new MediaRatingAverage();
                
                mediaRatingAverage.Author = tp.Author;
                mediaRatingAverage.Title = tp.Title;
                mediaRatingAverage.Rating = 0;

                //  var xx = mediaRatingsL.ToList();

                //    double result = (from yy in mediaR where yy.MediaId == tp.Id select yy.Rating).Average();
                var result = mediaR.Where(xx => xx.MediaId == tp.Id);
                double average = 0;
                if (result.Any())
                {
                    average = result.Select(x => x.Rating).Average();
                }

                mediaRatingAverage.Rating = Math.Round(average, 1);


                //     mediaRatingAverage.Rating = mediaR.Average(m => m.Rating);
                // if (dd > 0)
                // {
                //  mediaRatingAverage.Rating = mediaRatingsL.Average(zz => zz.Rating);
                //  }
                mra.Add(mediaRatingAverage);


            }



            return View(mra);
        }
        public ActionResult UserList()
        {
            //User Name
            //Number of reviews
            //User Avergare rating

            ApplicationDbContext db = new ApplicationDbContext();

            List<UserRatingAverage> ura = new List<UserRatingAverage>();

            var UserList = db.Users.ToList();
            var MediaRatingList = db.MediaRatings.ToList();

            foreach (var user in db.Users)
            {
                UserRatingAverage UserRatingAverageUnit = new UserRatingAverage();

                UserRatingAverageUnit.Name = user.UserName;
                UserRatingAverageUnit.NumberOfReviews = MediaRatingList.Where(x => x.UserId == user.Id).Count();
                UserRatingAverageUnit.AverageRating = Math.Round(MediaRatingList.Where(x=>x.UserId == user.Id).Select(x=>x.Rating).Average(), 1);



                ura.Add(UserRatingAverageUnit);

            }


            return View(ura);
        }


    }

}