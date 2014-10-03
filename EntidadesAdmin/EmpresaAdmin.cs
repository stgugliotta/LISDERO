using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Empresa 
    /// </summary>
  	public class EmpresaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Empresa 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Empresa Load(int id)
			{
				Empresa oReturn = new Empresa();
				try
				{
					using (DALEmpresa dalEmpresa = new DALEmpresa())
                	{
						oReturn = dalEmpresa.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Empresa
        /// </summary>
        /// <param name="oEmpresa"></param>
      	public void Delete(Empresa oEmpresa)
			{
				try
				{
					using (DALEmpresa dalEmpresa = new DALEmpresa())
					{
						dalEmpresa.Delete(oEmpresa);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Empresa 
		/// </summary>
        /// <param name="oEmpresa"></param>
     	public void Update(Empresa oEmpresa)
			{
				try
				{
					using (DALEmpresa dalEmpresa = new DALEmpresa())
					{
						dalEmpresa.Update(oEmpresa);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Empresa 
		/// </summary>
        /// <param name="oEmpresa"></param>
     	public void Insert(Empresa oEmpresa)
		{
				try
				{
					using (DALEmpresa dalEmpresa = new DALEmpresa())
					{
						dalEmpresa.Insert(oEmpresa);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        public Empresa GetEmpresaByCodigo(int codigo)
        {
            Empresa oReturn = new Empresa();
            List<Domicilio> listaDeDomicilios = new List<Domicilio>();
            List<Telefono> listaDeTelefonos = new List<Telefono>();
            List<Email> listaDeEmails = new List<Email>();
            try
            {
                using (DALEmpresa dalEmpresa = new DALEmpresa())
                {
                    oReturn = dalEmpresa.GetEmpresaByCodigo(codigo);
                }
                using (DALDomicilio dalDomicilio = new DALDomicilio())
                {
                    listaDeDomicilios = dalDomicilio.GetAllDomiciliosPersonasPorCodigo(codigo);
                }
                oReturn.Domicilios = listaDeDomicilios;

                using (DALTelefono dalTelefono = new DALTelefono())
                {
                    listaDeTelefonos = dalTelefono.GetAllTelefonosPersonasPorCodigo(codigo);
                }
                oReturn.Telefonos = listaDeTelefonos;


                using (DALEmail dalEmail = new DALEmail())
                {
                    listaDeEmails = dalEmail.GetAllEmailsPersonasPorCodigo(codigo);
                }
                oReturn.Emails = listaDeEmails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
		/// <summary>
        /// M?todo de lectura de objeto Empresa 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>                
		/// <returns></returns>
		public Empresa GetEmpresa(int id)
			{
				Empresa oReturn = new Empresa();
				try
				{
					using (DALEmpresa dalEmpresa = new DALEmpresa())
                	{
						oReturn = dalEmpresa.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Empresa
		/// de la tabla dbo.TBL_Empresa
        /// </summary>
        /// <returns></returns>
       	public List<Empresa> GetAllEmpresas()
		{
			List<Empresa> lstEmpresa = new List<Empresa>();
            try
            {
                using (DALEmpresa dalEmpresa = new DALEmpresa())
                {
                    lstEmpresa = dalEmpresa.GetAllEmpresas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresa;
			
		}
	}
}
