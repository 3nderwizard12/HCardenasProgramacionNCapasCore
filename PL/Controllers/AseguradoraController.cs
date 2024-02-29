using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        public ActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(aseguradora);
        }
        [HttpGet]
        public ActionResult Form(int? idAseguradora)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultUsuario = BL.Usuario.GetAll(usuario);

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            if (resultUsuario.Correct)
            {
                aseguradora.Usuario.Usuarios = resultUsuario.Objects;
            }
            if (idAseguradora == null)
            {
                return View(aseguradora);
            }
            else
            {
                ML.Result result = BL.Aseguradora.GetById(idAseguradora.Value);
                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                    return View(aseguradora);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            if (aseguradora.IdAseguradora == 0)
            {
                //Add
                result = BL.Aseguradora.Add(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = "Registro correctamente insertado";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
            }
            else
            {
                //Update
                result = BL.Aseguradora.Update(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro correctamente actualizado";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int idAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = idAseguradora;

            ML.Result result = BL.Aseguradora.Delete(aseguradora);
            if (result.Correct)
            {
                ViewBag.Message = "Registro correctamente Eliminado";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro";
            }
            return View("Modal");
        }
    }
}
