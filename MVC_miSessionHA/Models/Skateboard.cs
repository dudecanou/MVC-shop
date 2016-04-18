using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_miSessionHA.Models
{
    public class Skateboard
    {
        [Key]
        public int SkateboardID { get; set; }

        public int MarqueID { get; set; }

        [Display(Name = "Skateboard")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Longueur inadéquate")]
        public string Style { get; set; }


        public string Image { get; set; }

        public virtual Marque Marque { get; set; }

    }
}