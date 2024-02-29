using Microsoft.AspNetCore.Mvc;
using ML;

namespace PL.Controllers
{
    public class DependienteController : Controller
    {
        public ActionResult GetById(string numeroEmpleado, string nombreEmpleado)
        {
            ML.Result result = BL.Dependiente.GetByEmpleado(numeroEmpleado);

            ML.Dependiente dependiente = new ML.Dependiente();

            ML.Result resultDependienteTipo = BL.DependienteTipo.GetAll();
            dependiente.DependienteTipo = new ML.DependienteTipo();

            if (result.Correct)
            {
                dependiente.DependienteTipo.DependienteTipos = resultDependienteTipo.Objects;
                dependiente.Empleado = new ML.Empleado();
                dependiente.Empleado.NumeroEmpleado = numeroEmpleado;
                dependiente.Empleado.Nombre = nombreEmpleado;
                dependiente.Dependientes = result.Objects;
                return View(dependiente);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(dependiente);
        }

        [HttpGet]
        public ActionResult GetById(string numeroEmpleado, string nombreEmpleado,int? idDependiente)
        {
            ML.Result result = BL.Dependiente.GetByEmpleado(numeroEmpleado);

            ML.Dependiente dependiente = new ML.Dependiente();

            ML.Result resultDependienteTipo = BL.DependienteTipo.GetAll();
            dependiente.DependienteTipo = new ML.DependienteTipo();

            if (resultDependienteTipo.Correct)
            {
                dependiente.action = "Add";
                dependiente.Empleado = new ML.Empleado();
                dependiente.DependienteTipo.DependienteTipos = resultDependienteTipo.Objects;
                dependiente.Empleado.NumeroEmpleado = numeroEmpleado;
                dependiente.Empleado.Nombre = nombreEmpleado;
                dependiente.Dependientes = result.Objects;
            }
            if (idDependiente == null)
            {
                return View(dependiente);
            }
            else
            {
                ML.Result resultById = BL.Dependiente.GetById(idDependiente.Value);

                if (resultById.Correct)
                {
                    dependiente.action = "Update";
                    dependiente = (ML.Dependiente)resultById.Object;
                    dependiente.Empleado = new ML.Empleado();
                    dependiente.DependienteTipo.DependienteTipos = resultDependienteTipo.Objects;
                    dependiente.Empleado.NumeroEmpleado = numeroEmpleado;
                    dependiente.Empleado.Nombre = nombreEmpleado;
                    dependiente.Dependientes = result.Objects;
                    return View(dependiente);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            if (dependiente.IdDependiente == 0)
            {
                //Add
                result = BL.Dependiente.Add(dependiente);

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
                result = BL.Dependiente.Update(dependiente);
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
        public ActionResult Delete(int idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.IdDependiente = idDependiente;

            ML.Result result = BL.Dependiente.Delete(dependiente);
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
