using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2._0.Models;

namespace MVC2._0.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}