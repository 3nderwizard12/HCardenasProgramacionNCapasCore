using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BL
{
    public class Poliza
    {
        public static ML.Result add(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    DL.Poliza queryLinkq = new DL.Poliza();

                    queryLinkq.Nombre = poliza.Nombre;
                    queryLinkq.IdSubPoliza = poliza.SubPoliza.IdSubPoliza;
                    queryLinkq.NumeroPoliza = poliza.NumeroPoliza;
                    queryLinkq.FechaCreacion = DateTime.Now;
                    queryLinkq.FechaModificacion = DateTime.Now;
                    queryLinkq.IdUsuario = poliza.Usuario.IdUsuario;

                    cnn.Polizas.Add(queryLinkq);
                    cnn.SaveChanges();

                    result.Correct = true;
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

        public static ML.Result add_SQL(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PolizaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = poliza.Nombre;

                        collection[1] = new SqlParameter("@NombreSubPoliza", SqlDbType.VarChar);
                        //poliza.SubPoliza = new ML.SubPoliza();
                        collection[1].Value = poliza.SubPoliza.Nombre;

                        collection[2] = new SqlParameter("@NumeroPoliza", SqlDbType.VarChar);
                        collection[2].Value = poliza.NumeroPoliza;

                        collection[3] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);
                        collection[3].Value = poliza.Usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
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

        public static ML.Result Delete(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var queryLinkq = (from tblPolizas in cnn.Polizas
                                      where tblPolizas.IdSubPoliza == poliza.IdPoliza
                                      select tblPolizas).First();
                    cnn.Polizas.Remove(queryLinkq);
                    cnn.SaveChanges();
                    result.Correct = true;
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

        public static ML.Result Delete_SQL(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PolizaDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdPoliza", SqlDbType.Int);
                        collection[0].Value = poliza.IdPoliza;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
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

        public static ML.Result Update(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var queryLinkq = (from tblPoliza in cnn.Polizas
                                      where tblPoliza.IdPoliza == poliza.IdPoliza
                                      select tblPoliza).SingleOrDefault();

                    if (queryLinkq != null)
                    {
                        queryLinkq.Nombre = poliza.Nombre;
                        queryLinkq.IdSubPoliza = poliza.SubPoliza.IdSubPoliza;
                        queryLinkq.NumeroPoliza = poliza.NumeroPoliza;
                        queryLinkq.FechaModificacion = DateTime.Now;
                        queryLinkq.IdUsuario = poliza.Usuario.IdUsuario;
                        cnn.SaveChanges();
                        
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

        public static ML.Result Update_SQL(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PolizaUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("@IdPoliza", SqlDbType.VarChar);
                        collection[0].Value = poliza.IdPoliza;

                        collection[1] = new SqlParameter("@IdSubPoliza", SqlDbType.VarChar);
                        collection[1].Value = poliza.SubPoliza.IdSubPoliza;

                        collection[2] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[2].Value = poliza.Nombre;

                        collection[3] = new SqlParameter("@NombreSubPoliza", SqlDbType.VarChar);
                        collection[3].Value = poliza.SubPoliza.Nombre;

                        collection[4] = new SqlParameter("@NumeroPoliza", SqlDbType.VarChar);
                        collection[4].Value = poliza.NumeroPoliza;

                        collection[5] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);
                        collection[5].Value = poliza.Usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var queryLINKQ = (from tblPolizas in cnn.Polizas
                                      join tblSubPolizas in cnn.SubPolizas on tblPolizas.IdSubPoliza equals tblSubPolizas.IdSubPoliza
                                      join tblusuarios in cnn.Usuarios on tblPolizas.IdUsuario equals tblusuarios.IdUsuario
                                      select new
                                      {
                                          idPoliza = tblPolizas.IdPoliza,
                                          nombre = tblPolizas.Nombre,
                                          idSubPoliza = tblSubPolizas.IdSubPoliza,
                                          nombreSubPoliza = tblSubPolizas.Nombre,
                                          numeroPoliza = tblPolizas.NumeroPoliza,
                                          fechaCreacion = tblPolizas.FechaCreacion,
                                          fechaModificacion = tblPolizas.FechaModificacion,
                                          idUsuario = tblusuarios.IdUsuario,
                                          nombreUsuario = tblusuarios.Nombre,
                                          apellidoPaterno = tblusuarios.ApellidoPaterno,
                                          apellidoMaterno = tblusuarios.ApellidoMaterno
                                      }).ToList();

                    result.Objects = new List<object>();

                    foreach (var row in queryLINKQ)
                    {
                        ML.Poliza poliza = new ML.Poliza();

                        poliza.IdPoliza = row.idPoliza;
                        poliza.Nombre = row.nombre;

                        poliza.SubPoliza = new ML.SubPoliza();
                        poliza.SubPoliza.IdSubPoliza = row.idSubPoliza;
                        poliza.SubPoliza.Nombre = row.nombreSubPoliza;

                        poliza.NumeroPoliza = row.numeroPoliza;
                        poliza.FechaCreacion = Convert.ToDateTime(row.fechaCreacion);
                        poliza.FechaModificacion = Convert.ToDateTime(row.fechaModificacion);

                        poliza.Usuario = new ML.Usuario();
                        poliza.Usuario.IdUsuario = row.idUsuario;
                        poliza.Usuario.Nombre = row.nombreUsuario;
                        poliza.Usuario.ApellidoPaterno = row.apellidoPaterno;
                        poliza.Usuario.ApellidoMaterno = row.apellidoMaterno;

                        result.Objects.Add(poliza);
                    }
                    result.Correct = true;
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

        public static ML.Result GetAll_SQL()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PolizaGetAll";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            result.Objects = new List<object>();

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    ML.Poliza poliza = new ML.Poliza();

                                    poliza.IdPoliza = Int32.Parse(row[0].ToString());
                                    poliza.Nombre = row[1].ToString();

                                    poliza.SubPoliza = new ML.SubPoliza();
                                    poliza.SubPoliza.IdSubPoliza = byte.Parse(row[2].ToString());
                                    poliza.SubPoliza.Nombre = row[3].ToString();

                                    poliza.NumeroPoliza = row[4].ToString();
                                    poliza.FechaCreacion = Convert.ToDateTime(row[5].ToString());
                                    poliza.FechaModificacion = Convert.ToDateTime(row[6].ToString());

                                    poliza.Usuario = new ML.Usuario();
                                    poliza.Usuario.IdUsuario = Int32.Parse(row[7].ToString());
                                    poliza.Usuario.Nombre = row[8].ToString();
                                    poliza.Usuario.ApellidoPaterno = row[9].ToString();
                                    poliza.Usuario.ApellidoMaterno = row[10].ToString();

                                    result.Objects.Add(poliza);
                                    //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                                }

                                result.Correct = true;
                            }
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

        public static ML.Result GetById(int idPoliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var queryLINKQ = (from tblPolizas in cnn.Polizas
                                      join tblSubPolizas in cnn.SubPolizas on tblPolizas.IdSubPoliza equals tblSubPolizas.IdSubPoliza
                                      join tblusuarios in cnn.Usuarios on tblPolizas.IdUsuario equals tblusuarios.IdUsuario
                                      where tblPolizas.IdSubPoliza == idPoliza
                                      select new
                                      {
                                          idPoliza = tblPolizas.IdPoliza,
                                          nombre = tblPolizas.Nombre,
                                          idSubPoliza = tblSubPolizas.IdSubPoliza,
                                          nombreSubPoliza = tblSubPolizas.Nombre,
                                          numeroPoliza = tblPolizas.NumeroPoliza,
                                          fechaCreacion = tblPolizas.FechaCreacion,
                                          fechaModificacion = tblPolizas.FechaModificacion,
                                          idUsuario = tblusuarios.IdUsuario,
                                          nombreUsuario = tblusuarios.Nombre,
                                          apellidoPaterno = tblusuarios.ApellidoPaterno,
                                          apellidoMaterno = tblusuarios.ApellidoMaterno
                                      }).FirstOrDefault();
                    if (queryLINKQ != null)
                    {
                        ML.Poliza poliza = new ML.Poliza();
                        poliza.IdPoliza = queryLINKQ.idPoliza;
                        poliza.Nombre = queryLINKQ.nombre;

                        ML.SubPoliza subPoliza = new ML.SubPoliza();
                        poliza.SubPoliza.IdSubPoliza = queryLINKQ.idSubPoliza;
                        poliza.SubPoliza.Nombre = queryLINKQ.nombreSubPoliza;

                        poliza.NumeroPoliza = queryLINKQ.numeroPoliza;
                        poliza.FechaCreacion = Convert.ToDateTime(queryLINKQ.fechaCreacion);
                        poliza.FechaModificacion = Convert.ToDateTime(queryLINKQ.fechaModificacion);

                        ML.Usuario usuario = new ML.Usuario();
                        poliza.Usuario.IdUsuario = queryLINKQ.idUsuario;
                        poliza.Usuario.Nombre = queryLINKQ.nombreUsuario;
                        poliza.Usuario.ApellidoPaterno = queryLINKQ.apellidoPaterno;
                        poliza.Usuario.ApellidoMaterno = queryLINKQ.apellidoMaterno;

                        result.Object = poliza;
                    }
                    result.Correct = true;
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

        public static ML.Result GetById_SQL(int idPoliza)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PolizaById";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdPoliza", SqlDbType.Int);
                        collection[0].Value = idPoliza;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            result.Objects = new List<object>();
                            if (dt.Rows.Count > 0)
                            {
                                ML.Poliza poliza = new ML.Poliza();
                                DataRow row = dt.Rows[0];

                                poliza.IdPoliza = Convert.ToInt32(row[0].ToString());
                                poliza.Nombre = row[1].ToString();

                                poliza.SubPoliza = new ML.SubPoliza();
                                poliza.SubPoliza.IdSubPoliza = byte.Parse(row[2].ToString());
                                poliza.SubPoliza.Nombre = row[3].ToString();

                                poliza.NumeroPoliza = row[4].ToString();
                                poliza.FechaCreacion = Convert.ToDateTime(row[5].ToString());
                                poliza.FechaModificacion = Convert.ToDateTime(row[6].ToString());

                                poliza.Usuario = new ML.Usuario();
                                poliza.Usuario.IdUsuario = Int32.Parse(row[7].ToString());
                                poliza.Usuario.Nombre = row[8].ToString();
                                poliza.Usuario.ApellidoPaterno = row[9].ToString();
                                poliza.Usuario.ApellidoMaterno = row[10].ToString();

                                result.Object = poliza;
                                result.Correct = true;
                            }
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
    }
}
