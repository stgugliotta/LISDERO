using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Persona 
    /// </summary>
  	public class PersonaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Persona 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Persona Load(int id)
			{
				Persona oReturn = new Persona();
				try
				{
					using (DALPersona dalPersona = new DALPersona())
                	{
						oReturn = dalPersona.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Persona
        /// </summary>
        /// <param name="oPersona"></param>
      	public void Delete(Persona oPersona)
			{
				try
				{
					using (DALPersona dalPersona = new DALPersona())
					{
						dalPersona.Delete(oPersona);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Persona 
		/// </summary>
        /// <param name="oPersona"></param>
     	public void Update(Persona oPersona)
			{
				try
				{
					using (DALPersona dalPersona = new DALPersona())
					{
						dalPersona.Update(oPersona);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Persona 
		/// </summary>
        /// <param name="oPersona"></param>
     	public void Insert(Persona oPersona)
		{
				try
				{
					using (DALPersona dalPersona = new DALPersona())
					{
						dalPersona.Insert(oPersona);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Persona 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>               
		/// <returns></returns>
		public Persona GetPersona(int id)
			{
				Persona oReturn = new Persona();
				try
				{
					using (DALPersona dalPersona = new DALPersona())
                	{
						oReturn = dalPersona.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}


        public Persona GetPersonaByCodigo(int codigo)
			{
				Persona oReturn = new Persona();
                List<Domicilio> listaDeDomicilios=new List<Domicilio>();
                List<Telefono> listaDeTelefonos = new List<Telefono>();
                List<Email> listaDeEmails = new List<Email>();
				try
				{
					using (DALPersona dalPersona = new DALPersona())
                	{
                        oReturn = dalPersona.GetPersonaByCodigo(codigo);
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
        /// M?todo para traer una lista de la totalidad de los objetos Persona
		/// de la tabla dbo.TBL_Persona
        /// </summary>
        /// <returns></returns>
       	public List<Persona> GetAllPersonas()
		{
			List<Persona> lstPersona = new List<Persona>();
            try
            {
                using (DALPersona dalPersona = new DALPersona())
                {
                    lstPersona = dalPersona.GetAllPersonas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPersona;
			
			}
	}
}
