using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    DL.Empresa queryLinkq = new DL.Empresa();

                    queryLinkq.Nombre = empresa.Nombre;
                    queryLinkq.Telefono = empresa.Telefono;
                    queryLinkq.Email = empresa.Email;
                    queryLinkq.DireccionWeb = empresa.DireccionWeb;
                    queryLinkq.Logo = empresa.Logo;

                    cnn.Empresas.Add(queryLinkq);
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Empresas.FromSqlRaw("EmpresaGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = row.IdEmpresa;
                            empresa.Nombre = row.Nombre;
                            empresa.Telefono = row.Telefono;
                            empresa.Email = row.Email;
                            empresa.DireccionWeb = row.DireccionWeb;
                            empresa.Logo = row.Logo;
                            result.Objects.Add(empresa);
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

        public static ML.Result Delete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var queryLinkq = (from tblEmpresa in cnn.Empresas
                                        where tblEmpresa.IdEmpresa == empresa.IdEmpresa
                                        select tblEmpresa).First();

                    cnn.Empresas.Remove(queryLinkq);
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

        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new DL.HcardenasProgramcionNcapasContext())
                {
                    var queryLinkq = (from tblEmpresa in cnn.Empresas
                                        where tblEmpresa.IdEmpresa == empresa.IdEmpresa
                                        select tblEmpresa).SingleOrDefault();

                    if (queryLinkq != null)
                    {
                        queryLinkq.Nombre = empresa.Nombre;
                        queryLinkq.Telefono = empresa.Telefono;
                        queryLinkq.Email = empresa.Email;
                        queryLinkq.DireccionWeb = empresa.DireccionWeb;
                        queryLinkq.Logo = empresa.Logo;
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

        public static ML.Result GetById(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.HcardenasProgramcionNcapasContext cnn = new HcardenasProgramcionNcapasContext())
                {
                    var query = cnn.Empresas.FromSqlRaw($"EmpresabyId {idEmpresa}").ToList().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;
                        empresa.Logo = query.Logo;

                        result.Object = empresa;
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
