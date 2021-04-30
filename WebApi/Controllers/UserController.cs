using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Data;
using WebApi.Models;
namespace WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class UserController : ApiController
    {
        pruebaTecEntities db;

        UserController()
        {
            db = new pruebaTecEntities();
        }
        // GET: api/User
        public List<UsuariosCE> Get()
        {
            List<Usuario> users = db.Usuario.ToList();
            List<UsuariosCE> lstUsers = new List<UsuariosCE>();

            foreach (var item in users)
            {
                UsuariosCE user = new UsuariosCE();
                user.Usuario = item.Usuario1;
                user.Nombres = item.Personas.Nombres;
                user.Apellidos = item.Personas.Apellidos;
                user.Email = item.Personas.Email;
                user.TipoIdentificacion = item.Personas.TipoIdentificacion;
                user.NroIdentificacion = item.Personas.NumeroIdentificacion.ToString();
                user.fullName = item.Personas.nombreCompleto;
                user.identificacionFull = item.Personas.identificacionFull;

                lstUsers.Add(user);
            }

            return lstUsers;
        }

        // GET: api/User/5
        public UsuariosCE Get(int id)
        {
            UsuariosCE user = new UsuariosCE();
            Usuario item = db.Usuario.Find(id);

            if (item != null)
            {
                user.Nombres = item.Personas.Nombres;
                user.Apellidos = item.Personas.Apellidos;
                user.Email = item.Personas.Email;
                user.TipoIdentificacion = item.Personas.TipoIdentificacion;
                user.NroIdentificacion = item.Personas.NumeroIdentificacion.ToString();
                user.fullName = item.Personas.nombreCompleto;
                user.identificacionFull = item.Personas.identificacionFull;
            }

            return user;
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            
        }


        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate(loginRequest req)
        {
            int? password = db.DecryptPassword(req.usuario,req.password).FirstOrDefault();


            if (password.HasValue && password.Value>0)
            {
                return Ok(new { data = db.Usuario.Where(x => x.Usuario1 == req.usuario).FirstOrDefault().Personas.nombreCompleto });
            }
            else
            {
                return Unauthorized();
            }

        }


        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(UsuariosCE req)
        {
            Business.Data.Dominio.logicaNegocio dom = new Business.Data.Dominio.logicaNegocio();
            if (dom.crearUsuario(req))
            {
                return Ok(new { data = "Usuario Creado" });
            }else
            {
                return InternalServerError();
            }

        }
    }
}
