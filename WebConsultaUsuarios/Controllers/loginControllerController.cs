using Business.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebConsultaUsuarios.Controllers
{
    public class loginControllerController : Controller
    {

        public loginControllerController()
        {
            Business.Data.Dominio.ApiHelper.InitializeClient();
        }

        // GET: loginController
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult login()
        {
            Session["login"] = null;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> login(userLoginCE model)
        {
            ViewBag.validacion = "";
            if (ModelState.IsValid)
            {


                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


                Business.Data.Dominio.ApiHelper api = new Business.Data.Dominio.ApiHelper();
                string url = "http://localhost:17045/Api/login/Authenticate";
                using (HttpResponseMessage response = await Business.Data.Dominio.ApiHelper.ApiClient.PostAsync(url,data))
                {
                    if (response.IsSuccessStatusCode)
                    {
                       // var result = response.Content.ReadAsStringAsync().Result;
                        var resp = await response.Content.ReadAsStringAsync();

                        var details = JObject.Parse(resp);

                        Session["login"] = details["data"];
                      return  RedirectToAction("Index", "Prueba");
                    }else
                    {
                        ViewBag.validacion = "Usuario o contraseña no son validos";
                    }
                }

                return View(model);
            }
            else
            {
                return View();
            }


        }




    }  
}