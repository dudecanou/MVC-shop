using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_miSessionHA.Models
{
    public class Accessoire
    {
        public int AccessoireID { get; set; }

        public int SkateboardID { get; set; }

        
        public string NomAcc { get; set; }

        public string Type { get; set; }


        [Display(Name = "Prix ")]
        public int Prix { get; set; }
       
        [ForeignKey("SkateboardID")]
        public virtual Skateboard Skateboard { get; set; }

    }

}
