using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class ImportImagen
    {
       public string nombre { get; set; }
       public string nombreImagen { get; set; }

        [DisplayName("Archivo")]
        public HttpPostedFileBase Archivo { get; set; }
    }
}