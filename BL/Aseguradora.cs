using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"AseguradoraAdd'{aseguradora.Nombre}',{aseguradora.Usuario.IdUsuario}");

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

        public static ML.Result Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"AseguradoraDelete {aseguradora.IdAseguradora}");

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

        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"AseguradoraUpdate {aseguradora.IdAseguradora}, '{aseguradora.Nombre}', {aseguradora.Usuario.IdUsuario}");

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
                    var query = cnn.Aseguradoras.FromSqlRaw("AseguradoraGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = row.IdAseguradora;
                            aseguradora.Nombre = row.Nombre;
                            aseguradora.FechaCreacion = row.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = row.FechaModificacion.ToString();

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = row.IdUsuario;
                            aseguradora.Usuario.Nombre = row.NombreUsuario;
                            aseguradora.Usuario.ApellidoPaterno = row.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno = row.ApellidoMaterno;

                            result.Objects.Add(aseguradora);

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

        public static ML.Result GetById(int idAseguradora)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    //var query = cnn?.Aseguradoras?.FromSqlInterpolated($"SELECT Aseguradora.IdAseguradora, Aseguradora.Nombre, Aseguradora.FechaCreacion, Aseguradora.FechaModificacion, Usuario.IdUsuario, Usuario.Nombre AS NombreUsuario, Usuario.ApellidoPaterno, Usuario.ApellidoMaterno FROM Aseguradora INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario WHERE IdAseguradora = {idAseguradora}").FirstOrDefault();
                    var query = cnn.Aseguradoras.FromSqlRaw($"AseguradoraById {idAseguradora}").ToList().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = query.FechaModificacion.ToString();

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario;
                        aseguradora.Usuario.Nombre = query.Nombre;

                        result.Object = aseguradora;
                    }
                    result.Correct = true;
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