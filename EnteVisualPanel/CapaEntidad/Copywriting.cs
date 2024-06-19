using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Copywriting
    {


        public int Id { get; set; }
        public Cliente IdCliente { get; set; }
        public Combo IdCombo { get; set; }
        public decimal Precio { get; set; }
        public string Vencimiento { get; set; }
        public string Extras { get; set; }
        public string Mes { get; set; }
        public bool Abonado { get; set; }



    }
}
