using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Essentialbooks.Models
{
    public class UserRatingAverage
    {

        public string Name { get; set; }
        public int NumberOfReviews { get; set; }
        public double AverageRating { get; set; }

    }
}