using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clases.seguridad
{
    public class clase_persona
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string telefono { get; set; }

        public clase_persona()
        {

        }
    }
}
