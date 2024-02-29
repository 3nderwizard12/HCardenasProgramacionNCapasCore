using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PolizaController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Poliza.GetAll_SQL();
            ML.Poliza poliza = new ML.Poliza();

            if (result.Correct)
            {
                poliza.Polizas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta";
            }
            return View(poliza);
        }

        [HttpGet]
        public ActionResult Form(int? idPoliza)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultUsuario = BL.Usuario.GetAll(usuario);

            ML.Poliza poliza = new ML.Poliza();
            poliza.SubPoliza = new ML.SubPoliza();
            poliza.Usuario = new ML.Usuario();

            if (resultUsuario.Correct)
            {
                poliza.Usuario.Usuarios = resultUsuario.Objects;
            }
            if (idPoliza == null)
            {
                return View(poliza);
            }
            else
            {
                ML.Result result = BL.Poliza.GetById_SQL(idPoliza.Value);
                if (result.Correct)
                {
                    ML.Result resultSubPoliza = BL.SubPoliza.GetById(poliza.SubPoliza.IdSubPoliza);

                    poliza = (ML.Poliza)result.Object;
                    poliza.Usuario.Usuarios = resultUsuario.Objects;
                    poliza.SubPoliza.SubPolizas = resultSubPoliza.Objects;
                    return View(poliza);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();
            if (poliza.IdPoliza == 0)
            {
                //Add
                result = BL.Poliza.add_SQL(poliza);

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
                result = BL.Poliza.Update_SQL(poliza);
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
        public ActionResult Delete(int idPoliza)
        {
            ML.Poliza poliza = new ML.Poliza();
            poliza.IdPoliza = idPoliza;

            ML.Result result = BL.Poliza.Delete_SQL(poliza);
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
