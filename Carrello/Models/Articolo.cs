using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.Models
{
    public class Articolo
    {
        public int ArticoloId { get; set; }

        public string ArticoloNome { get; set; }

        public IEnumerable<Cliente> ArticoloClienti{ get; set; }

    }
}