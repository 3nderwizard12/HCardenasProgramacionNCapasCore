using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        public static ML.Result Add(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"DependienteAdd '{dependiente.Empleado.NumeroEmpleado}', '{dependiente.Nombre}', '{dependiente.ApellidoPaterno}', '{dependiente.FechaNacimiento}', '{dependiente.EstadoCivil}', '{dependiente.Genero}', '{dependiente.Telefono}', '{dependiente.RFC}', {dependiente.DependienteTipo.IdDependienteTipo}");

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
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result Delete(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"DependienteDelete {dependiente.IdDependiente}");

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
                throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int queryEF = cnn.Database.ExecuteSqlRaw($"DependienteUpdate {dependiente.IdDependiente}, '{dependiente.Empleado.NumeroEmpleado}', '{dependiente.Nombre}', '{dependiente.ApellidoPaterno}', '{dependiente.FechaNacimiento}', '{dependiente.EstadoCivil}', '{dependiente.Genero}', '{dependiente.Telefono}', '{dependiente.RFC}', {dependiente.DependienteTipo.IdDependienteTipo}");

                    if (queryEF > 0)
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
                throw;
            }

            return result;
        }

        public static ML.Result GetByEmpleado(string numeroEmpleado)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Dependientes.FromSqlRaw($"DependienteByEmpleado '{numeroEmpleado}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();

                            dependiente.IdDependiente = row.IdDependiente;

                            dependiente.Empleado = new ML.Empleado();
                            dependiente.Empleado.NumeroEmpleado = row.NumeroEmpleado;
                            dependiente.Empleado.Nombre = row.NombreEmpleado;

                            dependiente.Nombre = row.Nombre;
                            dependiente.ApellidoPaterno = row.ApellidoPaterno;
                            dependiente.Apellidomaterno = row.ApellidoMaterno;
                            dependiente.FechaNacimiento = row.FechaNacimiento.ToString();
                            dependiente.EstadoCivil = row.EstadoCivil;
                            dependiente.Genero = row.Genero;
                            dependiente.Telefono = row.Telefono;
                            dependiente.RFC = row.Rfc;

                            dependiente.DependienteTipo = new ML.DependienteTipo();
                            dependiente.DependienteTipo.Nombre = row.NombreDependienteTipo;

                            result.Objects.Add(dependiente);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetById(int idDependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Dependientes.FromSqlRaw($"DependienteById {idDependiente}").ToList().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Dependiente dependiente = new ML.Dependiente();

                        dependiente.IdDependiente = query.IdDependiente;

                        dependiente.Empleado = new ML.Empleado();
                        dependiente.Empleado.NumeroEmpleado = query.NumeroEmpleado;
                        dependiente.Empleado.Nombre = query.NombreEmpleado;

                        dependiente.Nombre = query.Nombre;
                        dependiente.ApellidoPaterno = query.ApellidoPaterno;
                        dependiente.Apellidomaterno = query.ApellidoMaterno;
                        dependiente.FechaNacimiento = query.FechaNacimiento.ToString();
                        dependiente.EstadoCivil = query.EstadoCivil;
                        dependiente.Genero = query.Genero;
                        dependiente.Telefono = query.Telefono;
                        dependiente.RFC = query.Rfc;

                        dependiente.DependienteTipo = new ML.DependienteTipo();
                        dependiente.DependienteTipo.IdDependienteTipo = query.IdDependienteTipo;
                        dependiente.DependienteTipo.Nombre = query.NombreDependienteTipo;

                        result.Object = dependiente;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                throw;
            }
            return result;
        }
    }
}
