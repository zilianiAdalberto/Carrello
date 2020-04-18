using Carrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrello.ViewModels
{
    public class ClientiViewModel
    {

             public Cliente Cliente { get; set; }
        public IEnumerable<SelectListItem> ArticoliList { get; set; }
      

        }


    }



