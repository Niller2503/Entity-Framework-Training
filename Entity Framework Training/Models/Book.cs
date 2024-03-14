using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Training.Vare
{
    public class Book
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        [MaxLength(50)]
        public string Beskrivelse { get; set; }
        [MaxLength(50)]
        public int LagerStatus { get; set; }
        [MaxLength(99)]
        public double Pris { get; set; }
    }
}
