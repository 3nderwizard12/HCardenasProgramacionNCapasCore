using DL;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.NumeroEmpleado}', '{empleado.RFC}', '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', '{empleado.Email}', '{empleado.Telefono}', '{empleado.FechaNacimiento}', '{empleado.NSS}', '{empleado.Foto}', {empleado.Empresa.IdEmpresa}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result ConvertExcelToDataTable(string cnnString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection cnn = new OleDbConnection(cnnString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = cnn;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableEmpleado = new DataTable();

                        da.Fill(tableEmpleado);

                        if (tableEmpleado.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableEmpleado.Rows)
                            {
                                ML.Empleado empleado = new ML.Empleado();
                                empleado.NumeroEmpleado = row[0].ToString();
                                empleado.RFC = row[1].ToString();
                                empleado.Nombre = row[2].ToString();
                                empleado.ApellidoPaterno = row[3].ToString();
                                empleado.ApellidoMaterno = row[4].ToString();
                                empleado.Email = row[5].ToString();
                                empleado.Telefono = row[6].ToString();
                                empleado.FechaNacimiento = row[7].ToString();
                                empleado.NSS = row[8].ToString();
                                empleado.Foto = "";

                                empleado.Empresa = new ML.Empresa();
                                empleado.Empresa.IdEmpresa = Convert.ToInt32(row[9]);

                                result.Objects.Add(empleado);
                            }
                            result.Correct = true;
                        }

                        result.Object = tableEmpleado;

                        if (tableEmpleado.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result ValidarExcel(List<object> Object)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //DataTable  //Rows //Columns
                int i = 1;

                foreach (ML.Empleado empleado in Object)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();

                    error.IdRegistro = i++;

                    empleado.NumeroEmpleado = (empleado.Nombre == "") ? error.Mensaje += "Ingresar el NumeroEmpleado  " : empleado.NumeroEmpleado;
                    empleado.RFC = (empleado.RFC == "") ? error.Mensaje += "Ingresar el RFC  " : empleado.RFC;
                    empleado.Nombre = (empleado.Nombre == "") ? error.Mensaje += "Ingresar el nombre  " : empleado.Nombre;
                    empleado.ApellidoPaterno = (empleado.ApellidoPaterno == "") ? error.Mensaje += "Ingresar el ApellidoPaterno  " : empleado.ApellidoPaterno;
                    empleado.ApellidoMaterno = (empleado.ApellidoMaterno == "") ? error.Mensaje += "Ingresar el ApellidoMaterno  " : empleado.ApellidoMaterno;
                    empleado.Email = (empleado.Email == "") ? error.Mensaje += "Ingresar el Email  " : empleado.Email;
                    empleado.Telefono = (empleado.Telefono == "") ? error.Mensaje += "Ingresar el Telefono  " : empleado.Telefono;
                    empleado.FechaNacimiento = (empleado.FechaNacimiento == "") ? error.Mensaje += "Ingresar el Fecha de Nacimiento  " : empleado.FechaNacimiento;
                    empleado.NSS = (empleado.NSS == "") ? error.Mensaje += "Ingresar el NSS  " : empleado.NSS;

                    empleado.Empresa.IdEmpresa = (empleado.Empresa.IdEmpresa == null) ? Convert.ToInt32(error.Mensaje += "Ingresar el IdEmpresa  ") : empleado.Empresa.IdEmpresa;

                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoDelete '{empleado.NumeroEmpleado}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"EmpleadoUpdate '{empleado.NumeroEmpleado}', '{empleado.RFC}', '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', '{empleado.Email}', '{empleado.Telefono}', '{empleado.FechaNacimiento}', '{empleado.NSS}', '{empleado.Foto}', {empleado.Empresa.IdEmpresa}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.NumeroEmpleado = row.NumeroEmpleado;
                            empleado.RFC = row.Rfc;
                            empleado.Nombre = row.Nombre;
                            empleado.ApellidoPaterno = row.ApellidoPaterno;
                            empleado.ApellidoMaterno = row.ApelldioMaterno;
                            empleado.Email = row.Email;
                            empleado.Telefono = row.Telefono;
                            empleado.FechaNacimiento = row.FechaNacimiento.ToString();
                            empleado.NSS = row.Nss;
                            empleado.FechaIngreso = row.FechaIngreso.ToString();
                            empleado.Foto = row.Foto;

                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = row.IdEmpresa;
                            empleado.Empresa.Nombre = row.NombreEmpresa;
                            result.Objects.Add(empleado);
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result GetById(string nombreEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    //var query = cnn?.Aseguradoras?.FromSqlInterpolated($"SELECT Aseguradora.IdAseguradora, Aseguradora.Nombre, Aseguradora.FechaCreacion, Aseguradora.FechaModificacion, Usuario.IdUsuario, Usuario.Nombre AS NombreUsuario, Usuario.ApellidoPaterno, Usuario.ApellidoMaterno FROM Aseguradora INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario WHERE IdAseguradora = {idAseguradora}").FirstOrDefault();
                    var query = cnn.Empleados.FromSqlRaw($"EmpleadoById '{nombreEmpleado}'").ToList().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.NumeroEmpleado = query.NumeroEmpleado;
                        empleado.RFC = query.Rfc;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApelldioMaterno;
                        empleado.Email = query.Email;
                        empleado.Telefono = query.Telefono;
                        empleado.FechaNacimiento = query.FechaNacimiento.ToString();
                        empleado.NSS = query.Nss;
                        empleado.FechaIngreso = query.FechaIngreso.ToString();
                        empleado.Foto = query.Foto;

                        empleado.Empresa = new ML.Empresa();
                        empleado.Empresa.IdEmpresa = query.IdEmpresa;
                        empleado.Empresa.Nombre = query.NombreEmpresa;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }
    }
}
