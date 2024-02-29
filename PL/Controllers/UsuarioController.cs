using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ML;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private IHostingEnvironment environment;
        private IConfiguration configuration;
        public UsuarioController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            environment = _environment;
            configuration = _configuration;
        }

        // GET: Usuario
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    ML.Result result = BL.Usuario.GetAll(usuario);

        //    if (result.Correct)
        //    {
        //        usuario.Usuarios = result.Objects;
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
        //    }

        //    return View(usuario);
        //}

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAll(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(usuario);
        }

        //[HttpGet]
        //public ActionResult Form(int? idUsuario)
        //{
        //    ML.Result resultRole = BL.Role.GetAll();
        //    ML.Result resultPais = BL.Pais.GetAll();

        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Role = new ML.Role();

        //    usuario.Direccion = new ML.Direccion();
        //    usuario.Direccion.Colonia = new ML.Colonia();
        //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
        //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

        //    if (resultRole.Correct)
        //    {
        //        usuario.Role.Roles = resultRole.Objects;
        //        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
        //    }
        //    if (idUsuario == null)
        //    {
        //        return View(usuario);
        //    }
        //    else
        //    {
        //        ML.Result result = BL.Usuario.GetById(idUsuario.Value);

        //        if (result.Correct)
        //        {
        //            usuario = (ML.Usuario)result.Object;

        //            ML.Result resultDireccion = BL.DIreccion.GetById(usuario.Direccion.IdDireccion);
        //            ML.Result resultColonia = BL.Colonia.GetById(usuario.Direccion.Colonia.IdColonia);
        //            ML.Result resultMunicipio = BL.Municipio.GetById(usuario.Direccion.Colonia.Municipio.IdMunicipio);
        //            ML.Result resultEstado = BL.Estado.GetById(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);

        //            usuario.Role.Roles = resultRole.Objects;

        //            usuario.Direccion.Direcciones = resultDireccion.Objects;
        //            usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
        //            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
        //            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
        //            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
        //            return View(usuario);
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
        //            return View("Modal");
        //        }
        //    }
        //}

        //[HttpPost]
        //public ActionResult Form(ML.Usuario usuario)
        //{
        //    IFormFile file = Request.Form.Files["inpImagen"];

        //    if (file != null)
        //    {
        //        usuario.Image = Convert.ToBase64String(ConvertToBytes(file));
        //    }

        //    ML.Result result = new ML.Result();
        //    if (usuario.IdUsuario == 0)
        //    {
        //        //add
        //        result = BL.Usuario.Add(usuario);

        //        if (result.Correct)
        //        {
        //            ViewBag.Message = "Registro correctamente insertado";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al insertar el registro";
        //        }
        //    }
        //    else
        //    {
        //        //update
        //        result = BL.Usuario.Update(usuario);
        //        if (result.Correct)
        //        {
        //            ViewBag.Message = "Registro correctamente actualizado";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al actualizar el registro";
        //        }

        //    }
        //    return View("Modal");

        //    //if (ModelState.IsValid)
        //    //{

        //    //}
        //    //else
        //    //{

        //    //    ML.Result resultRole = BL.Role.GetAll();
        //    //    ML.Result resultPais = BL.Pais.GetAll();

        //    //    usuario.Role = new ML.Role();

        //    //    usuario.Direccion = new ML.Direccion();
        //    //    usuario.Direccion.Colonia = new ML.Colonia();
        //    //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
        //    //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //    //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

        //    //    usuario.Role.Roles = resultRole.Objects;
        //    //    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

        //    //    return View(usuario);
        //    //}
        //}


        //[HttpGet]
        //public ActionResult Delete(int idUsuario)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.IdUsuario = idUsuario;

        //    ML.Result result = BL.Usuario.Delete(usuario);
        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "Registro correctamente Eliminado";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ocurrio un error al eliminar el registro";
        //    }
        //    return View("Modal");
        //}

        public JsonResult GetEstado(int idPais)
        {
            var result = BL.Estado.GetById(idPais);

            return Json(result.Objects);
        }

        public JsonResult GetMunicipio(int idEstado)
        {
            var result = BL.Municipio.GetById(idEstado);

            return Json(result.Objects);
        }

        public JsonResult GetColonia(int idMunicipio)
        {
            var result = BL.Colonia.GetById(idMunicipio);

            return Json(result.Objects);
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        [HttpPost]
        public JsonResult CambiarStatus(int idAlumno, bool status)
        {

            ML.Result result = BL.Usuario.CambiarEstatus(idAlumno, status);

            return Json(result);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            ML.Result result = BL.Usuario.GetByUserName(username);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (password == usuario.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Contraseña Invalida";
                    return PartialView("ModalLogin");
                }
            }
            else
            {
                ViewBag.Message = "Usuario Invalido";
                return PartialView("ModalLogin");
            }
        }


        [HttpGet]
        public ActionResult GetAll()
        {   
            ML.Usuario resultUsuario = new ML.Usuario();
            resultUsuario.Usuarios = new List<object>();

            using (var client = new HttpClient())
            {
                string urlApi = configuration["urlWebApi"];
                client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("Usuario/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario ResultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultUsuario.Usuarios.Add(ResultItemList);
                    }
                }
            }
            return View(resultUsuario);
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Result resultRole = BL.Role.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Role = new ML.Role();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (resultRole.Correct)
            {
                usuario.Role.Roles = resultRole.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }
            if (idUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                {
                    string urlApi = configuration["urlWebApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Usuario/GetById/" + idUsuario);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        usuario = (ML.Usuario)result.Object;
                        ML.Result resultDireccion = BL.DIreccion.GetById(usuario.Direccion.IdDireccion);
                        ML.Result resultColonia = BL.Colonia.GetById(usuario.Direccion.Colonia.IdColonia);
                        ML.Result resultMunicipio = BL.Municipio.GetById(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                        ML.Result resultEstado = BL.Estado.GetById(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);

                        usuario.Role.Roles = resultRole.Objects;

                        usuario.Direccion.Direcciones = resultDireccion.Objects;
                        usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    }
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                usuario.Image = Convert.ToBase64String(ConvertToBytes(file));
            }

            if (usuario.IdUsuario == 0)
            {
                //add
                using (var client = new HttpClient())
                {
                    string urlApi = configuration["urlWebApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Registro correctamente insertado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar el registro";
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                //update
                using (var client = new HttpClient())
                {
                    string urlApi = configuration["urlWebApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var postTask = client.PutAsJsonAsync<ML.Usuario>("Usuario/Update/" + usuario.IdUsuario,usuario);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Registro correctamente actualizado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar el actualizado";
                        return PartialView("Modal");
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                string urlApi = configuration["urlWebApi"];
                client.BaseAddress = new Uri(urlApi);

                var postTask = client.GetAsync("Usuario/Delete/" + idUsuario);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Registro correctamente Eliminado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar el registro";
                    return PartialView("Modal");
                }
            }
        }
    }
}
