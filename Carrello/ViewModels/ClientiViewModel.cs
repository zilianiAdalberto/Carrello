using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.ViewModel
{
    public class ClientiViewModel
    {

        public int ClienteId { get; set; }

        public string ClienteNome { get; set; }

        // public IEnumerable<Articolo> ClienteArticoli { get; set; }

     
            public Cliente client { get; set; }
            public IList<ArticoloBase> Articoli { get; set; }

        }


    }
}


