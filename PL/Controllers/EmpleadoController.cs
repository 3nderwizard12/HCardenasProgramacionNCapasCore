using BL;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            ML.Empleado empleado = new ML.Empleado();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(empleado);
        }

        public ActionResult EmpleadoDependienteGetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            ML.Empleado empleado = new ML.Empleado();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(string? numeroEmpleado)
        {
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            if (resultEmpresa.Correct)
            {
                empleado.action = "Add";
                empleado.Empresa.Empresas = resultEmpresa.Objects;
            }
            if (numeroEmpleado == "" || numeroEmpleado == null)
            {
                return View(empleado);
            }
            else
            {
                ML.Result result = BL.Empleado.GetById(numeroEmpleado);
                if (result.Correct)
                {
                    empleado.action = "Update";
                    empleado = (ML.Empleado)result.Object;
                    empleado.Empresa.Empresas = resultEmpresa.Objects;
                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                empleado.Foto = Convert.ToBase64String(ConvertToBytes(file));
            }
            ML.Result result = new ML.Result();
            if (empleado.action == "Add")
            {
                //Add
                result = BL.Empleado.Add(empleado);

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
                result = BL.Empleado.Update(empleado);
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
        public ActionResult Delete(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;

            ML.Result result = BL.Empleado.Delete(empleado);
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
