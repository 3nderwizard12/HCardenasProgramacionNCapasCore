using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PL.Controllers
{
    public class CargaMasivaEmpleadoController : Controller
    {
        private IHostingEnvironment environment;
        private IConfiguration configuration;
        public CargaMasivaEmpleadoController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            environment = _environment;
            configuration = _configuration;
        }

        [HttpGet]
        public IActionResult CargaMasiva()
        {
            ML.Result result = new ML.Result();
            return View(result);
        }

        [HttpPost]
        public IActionResult CargaMasiva(ML.Empleado empleado)
        {
            IFormFile file = Request.Form.Files["FileExcel"];

            if (HttpContext.Session.GetString("PathArchivo") == null)
            {

                if (file != null)
                {
                    //.xsls , .xls, .csv
                    //obtener el nombre de nuestro archivo
                    string fileName = Path.GetFileName(file.FileName);

                    string folderPath = configuration["PathFolder"];
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    string extensionAppsettings = configuration["TipoExcel"];

                    if (extensionArchivo == extensionAppsettings)
                    {
                        string filePath = Path.Combine(environment.ContentRootPath, folderPath, Path.GetFileNameWithoutExtension(fileName)) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        //crear una copia del archivo cargado
                        if (!System.IO.File.Exists(filePath))
                        {
                            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            string connString = configuration["ExcelConString"] + filePath;//cadena de conexion y ruta especifica del archivo

                            //crear un metodo en BL.Semestre
                            ML.Result resultExcelDt = BL.Empleado.ConvertExcelToDataTable(connString);

                            if (resultExcelDt.Correct)
                            {
                                ML.Result resultValidacion = BL.Empleado.ValidarExcel(resultExcelDt.Objects);

                                if (resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    HttpContext.Session.SetString("PathArchivo", filePath);//crear la session
                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Message = "El excel no contiene registros";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "El archivo que se intenta procesar no es un excel";
                    }
                }
            }
            else
            {
                string rutaArchivoExcel = HttpContext.Session.GetString("PathArchivo");
                string connectionString = configuration["ExcelConString"] + rutaArchivoExcel;

                ML.Result resultData = BL.Empleado.ConvertExcelToDataTable(connectionString);

                if (resultData.Correct)
                {
                    ML.Result resultErrores = new ML.Result();
                    resultErrores.Objects = new List<object>();

                    foreach (ML.Empleado empleadoItem in resultData.Objects)
                    {
                        ML.Result resultAdd = BL.Empleado.Add(empleadoItem);
                        if (!resultAdd.Correct)
                        {
                            resultErrores.Objects.Add("No se insertó el Empleado con Numero de Empleado: " + empleadoItem.NumeroEmpleado + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con RFC: " + empleadoItem.RFC + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con Nombre: " + empleadoItem.Nombre + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con ApellidoPaterno: " + empleadoItem.ApellidoPaterno + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con ApellidoMaterno: " + empleadoItem.ApellidoMaterno + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con Email: " + empleadoItem.Email + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con Telefono: " + empleadoItem.Telefono + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con Fecha de nacimiento: " + empleadoItem.FechaNacimiento + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con NSS: " + empleadoItem.NSS + " Error: " + resultAdd.ErrorMessage);
                            resultErrores.Objects.Add("No se insertó el Empleado con ID Empresa: " + empleadoItem.Empresa.IdEmpresa + " Error: " + resultAdd.ErrorMessage);
                        }
                    }
                    if (resultErrores.Objects.Count > 0)
                    {
                        string fileError = Path.Combine(environment.WebRootPath, @"C:\Users\digis\Desktop\Error.txt");
                        using (StreamWriter writer = new StreamWriter(fileError))
                        {
                            foreach (string ln in resultErrores.Objects)
                            {
                                writer.WriteLine(ln);
                            }
                        }
                        ViewBag.Message = "No han sido registrados correctamente";
                    }
                    else
                    {
                        //borrar session
                        HttpContext.Session.Remove("PathArchivo");
                        ViewBag.Message = "Se han registrados correctamente";
                    }
                }
            }
            return PartialView("Modal");
        }
    }
}
