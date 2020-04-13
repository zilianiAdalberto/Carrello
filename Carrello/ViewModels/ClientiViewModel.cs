using Carrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.ViewModels
{
    public class ClientiViewModel
    {

             public Cliente Cliente { get; set; }
            public IEnumerable<Articolo> ArticoliList { get; set; }

        }


    }



