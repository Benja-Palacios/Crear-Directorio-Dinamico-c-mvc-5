using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class ImagenController : Controller
    {
        [HttpGet]
        public ActionResult ImageProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase archivo, ImportImagen importImagen,string nombrefolder, string nombreImagen )
        {
           // string nombreCarpeta = importImagen.nombre;

             string folder =Server.MapPath("~/Img/" + nombrefolder);
             string nombreImg = Server.MapPath("~/Img/" + nombrefolder.ToString()+"/"+nombreImagen);
          
            if(!Directory.Exists(folder))
            {
                string ruta = Server.MapPath("~/Img/" + nombrefolder.ToString() + "/" + nombreImagen.ToString()+".jpg");
                if(!Directory.Exists(nombreImg))
                {
                    if (archivo != null)
                    {
                        Directory.CreateDirectory(folder);
                       
                        archivo.SaveAs(ruta);
                        ViewBag.MensajeFolder = "El Nuevo Directorio es: " + nombrefolder.ToString();
                        ViewBag.MensajeImagen = "Se Guardo la Imagen";
                        return View("ImageProfile");
                    }
                    else 
                    {
                        ViewBag.MensajeImagen = "Seleccionar una Imagen";
                        return View("ImageProfile");
                    }
                }
                else
                {
                    ViewBag.MensajeImagen = "Ya existe el nombre de la Imagen";
                    return View("ImageProfile");
                }
            }
            else
            {
                ViewBag.MensajeImagen = "El Directorio " + nombrefolder.ToString() + " ya Existe";
                return View("ImageProfile");
            }
            
            

        }
    }
}