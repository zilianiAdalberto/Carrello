using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrello.Models
{


    [Table("Clienti")]
    public class Cliente
    {
        [Display(Name = "Id")]

        [Column("ClienteId")]
        public int ClienteId { get; set; }

        [Column("ClienteNome")]
        public string ClienteNome { get; set; }

        [Column("ClienteLista")]
        public IEnumerable<SelectListItem> ClienteLista { get; set; }
    }
}


