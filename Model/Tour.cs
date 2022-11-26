using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model
{
    public class Tour
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? Date { get; set; }
        public List<Reservations>? Reservations { get; set; }



    }
}
