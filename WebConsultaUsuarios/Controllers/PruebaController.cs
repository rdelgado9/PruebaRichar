using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebConsultaUsuarios.Controllers
{
    public class PruebaController : Controller
    {

       public PruebaController()
        {
            Business.Data.Dominio.ApiHelper.InitializeClient();
        }
        // GET: Prueba
        public async Task<ActionResult> Index()
        {
            if (Session["login"] != null)
            {
                Business.Data.Dominio.ApiHelper api = new Business.Data.Dominio.ApiHelper();
                string url = "http://localhost:17045/Api/user";
                using (HttpResponseMessage response = await Business.Data.Dominio.ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        List<UsuariosCE> contributors = JsonConvert.DeserializeObject<List<UsuariosCE>>(resp);
                        View(contributors);
                    }
                }



                return View();
            }else
            {
                return RedirectToAction("login", "loginController");
            }
            
        }


        public  ActionResult CrearUsuario()
        {

            return View();

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CrearUsuario(UsuariosCE usr)
        {


                if (ModelState.IsValid)
                {
                    var json = JsonConvert.SerializeObject(usr);
                    var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    Business.Data.Dominio.ApiHelper api = new Business.Data.Dominio.ApiHelper();
                    string url = "http://localhost:17045/Api/login/Crear";
                    using (HttpResponseMessage response = await Business.Data.Dominio.ApiHelper.ApiClient.PostAsync(url, data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Prueba");
                        }
                    }
                }




                return View();


           
        }


    }
}