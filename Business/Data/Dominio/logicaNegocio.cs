using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Data.Dominio
{
    public class logicaNegocio
    {
        pruebaTecEntities db;

        public logicaNegocio()
        {
            db = new pruebaTecEntities();
        }


        public bool  crearUsuario(UsuariosCE user)
        {
            bool respuesta = true;

            try
            {

                Usuario usu = new Usuario();

                usu.Usuario1 = user.Usuario;
                usu.pass = db.EncrypPassword(user.password).FirstOrDefault();
                usu.fechaCreacion = DateTime.Now;
                db.Usuario.Add(usu);

                Personas per = new Personas();
                per.IdUsuario = usu.IdUsuario;
                per.Nombres = user.Nombres;
                per.Apellidos = user.Apellidos;
                per.Email = user.Email;
                per.TipoIdentificacion = user.TipoIdentificacion;
                per.NumeroIdentificacion = long.Parse(user.NroIdentificacion);
                per.fechaCreacion = DateTime.Now;
                db.Personas.Add(per);
                db.SaveChanges();
                


            }
            catch(Exception e)
            {
                respuesta = false;
            }



            



            return respuesta;
        }


    }
}
