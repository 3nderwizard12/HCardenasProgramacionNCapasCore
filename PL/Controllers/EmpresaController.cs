using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpresaController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empresa.GetAll();
            ML.Empresa empresa = new ML.Empresa();

            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(empresa);
        }

        [HttpGet]
        public ActionResult Form(int? idEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();

            if (idEmpresa == null)
            {
                return View(empresa);
            }
            else
            {
                ML.Result result = BL.Empresa.GetById(idEmpresa.Value);
                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;
                    return View(empresa);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                empresa.Logo = Convert.ToBase64String(ConvertToBytes(file));
            }

            ML.Result result = new ML.Result();
            if (empresa.IdEmpresa == 0)
            {
                //add
                result = BL.Empresa.Add(empresa);

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
                //update
                result = BL.Empresa.Update(empresa);
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
        public ActionResult Delete(int idEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();
            empresa.IdEmpresa = idEmpresa;

            ML.Result result = BL.Empresa.Delete(empresa);
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

        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
