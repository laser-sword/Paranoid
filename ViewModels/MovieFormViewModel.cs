using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Paranoid.Models;
namespace Paranoid.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}