using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string ClienteNome { get; set; }

        public IEnumerable<Articolo> ClienteArticoli { get; set; }

    }
}