using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2._0.Models
{
    public class Genre
    {

        public byte id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}