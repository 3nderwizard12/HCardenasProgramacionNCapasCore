using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubPoliza
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "SubPolizaGetAll";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            result.Objects = new List<object>();

                            foreach (DataRow row in dt.Rows)
                            {
                                ML.SubPoliza subPoliza = new ML.SubPoliza();

                                subPoliza.IdSubPoliza = byte.Parse(row[0].ToString());
                                subPoliza.Nombre = row[1].ToString();

                                result.Objects.Add(subPoliza);

                                //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                            }
                        }
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

        public static ML.Result GetById(int idPoliza)
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

                        collection[0] = new SqlParameter("@IdSubPoliza", SqlDbType.Int);
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

                                poliza.IdPoliza = Int32.Parse(row[0].ToString());
                                poliza.Nombre = row[1].ToString();

                                result.Object = poliza;
                            }
                        }
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
    }
}
