using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace clases.seguridad
{
    public class clase_info
    {
        public string pub_id { get; set; }
        public byte[] logo { get; set; }
        public string pr_info { get; set; }
        public MemoryStream Imagen { get; set; }

        public clase_info()
        {

        }
    }
}
