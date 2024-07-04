using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3GArguello.Models
{
    public class Country
    {
        [Key]

        []
        public int Id { get; set; }
        public Name name {  get; set; }

        public string region { get; set; }

        public string subregion { get; set; }

        public string status { get; set; }

        public string codigo { get; set; }
    }
}
