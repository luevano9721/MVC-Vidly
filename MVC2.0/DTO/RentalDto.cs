using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2._0.Models;

namespace MVC2._0.DTO
{
    public class RentalDto
    {
        public int Id { get; set; }

        public MovieDto Movie { get; set; }

        public int MovieId { get; set; }

        public CustomerDto Customer { get; set; }

        public int CustomerId { get; set; }
    }
}