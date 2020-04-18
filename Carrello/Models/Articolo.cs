using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrello.Models
{

    [Table("Articoli")]
    public class Articolo 
    {
        [Display(Name = "Id")]

        [Column("ArticoloId")]
        public int ArticoloId { get; set; }

        [Display(Name = "ArticoloNome")]

        [Column("ArticoloNome")]
        public string ArticoloNome { get; set; }

        [Column("ClienteId")]
        public int ClienteId { get; set; }



    }
}