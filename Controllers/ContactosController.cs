using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBlazorCrud.Models.Response;
using WebServiceBlazorCrud.Models;

namespace WebServiceBlazorCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (dbWIPContext db = new dbWIPContext())
                {
                    var lst = db.Contactos.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch(Exception ex) {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(Contacto model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (dbWIPContext db = new dbWIPContext())
                {
                    Contacto oContacto = new Contacto();
                    oContacto.Nombres = model.Nombres;
                    oContacto.Apellidos = model.Apellidos;
                    oContacto.Telefono = model.Telefono;
                    oContacto.Correo = model.Correo;
                    db.Contactos.Add(oContacto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(Contacto model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (dbWIPContext db = new dbWIPContext())
                {
                    Contacto oContacto = db.Contactos.Find(model.Id);
                    oContacto.Nombres = model.Nombres;
                    oContacto.Apellidos = model.Apellidos;
                    oContacto.Telefono = model.Telefono;
                    oContacto.Correo = model.Correo;
                    db.Entry(oContacto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (dbWIPContext db = new dbWIPContext())
                {
                    Contacto oContacto = db.Contactos.Find(Id);
                    db.Remove(oContacto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
