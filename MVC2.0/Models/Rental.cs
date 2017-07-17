using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2._0.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public DateTime DateRental { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }


    }
}