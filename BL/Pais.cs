using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Pais.FromSqlRaw($"PaisGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = row.IdPais;
                            pais.Nombre = row.Nombre;

                            result.Objects.Add(pais);

                            //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                        }
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

        public static ML.Result GetById(int idPais)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Pais.FromSqlRaw($"PaisGetById {idPais}").ToList().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Pais pais = new ML.Pais();
                        pais.IdPais = query.IdPais;
                        pais.Nombre = query.Nombre;

                        result.Objects.Add(pais);
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
