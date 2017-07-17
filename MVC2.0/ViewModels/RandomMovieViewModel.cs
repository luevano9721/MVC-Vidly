using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2._0.Models;

namespace MVC2._0.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }



    }
}