﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrello.Models
{
    public class Articolo : ArticoloBase
    {

        public List<Cliente> Clienti { get; set; }

    }
}