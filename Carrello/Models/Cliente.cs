using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.Models
{
    public class Cliente : ClienteBase
    {


        public virtual ICollection<Cliente> Clienti { get; set; }


    }
}