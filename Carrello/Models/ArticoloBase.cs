using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.Models
{
    public class ArticoloBase
    {
        public int ArticoloId { get; set; }

        public string ArticoloNome { get; set; }

        public int ClienteId { get; set; }



    }
}