using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_miSessionHA.Models
{
    public class Marque
    {
        public int MarqueID { get; set; }

        [Display(Name = "Marque")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Longueur inadéquate")]
        public string Nom { get; set; }
        public string Pays { get; set; }

    }
}