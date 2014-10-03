using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Domicilio 
    /// </summary>
  	public class DomicilioAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Domicilio 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Domicilio Load(int id)
			{
				Domicilio oReturn = new Domicilio();
				try
				{
					using (DALDomicilio dalDomicilio = new DALDomicilio())
                	{
						oReturn = dalDomicilio.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Domicilio
        /// </summary>
        /// <param name="oDomicilio"></param>
      	public void Delete(Domicilio oDomicilio)
			{
				try
				{
					using (DALDomicilio dalDomicilio = new DALDomicilio())
					{
						dalDomicilio.Delete(oDomicilio);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Domicilio 
		/// </summary>
        /// <param name="oDomicilio"></param>
     	public void Update(Domicilio oDomicilio)
			{
				try
				{
					using (DALDomicilio dalDomicilio = new DALDomicilio())
					{
						dalDomicilio.Update(oDomicilio);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Domicilio 
		/// </summary>
        /// <param name="oDomicilio"></param>
     	public void Insert(Domicilio oDomicilio)
		{
				try
				{
					using (DALDomicilio dalDomicilio = new DALDomicilio())
					{
						dalDomicilio.Insert(oDomicilio);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Domicilio 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>            
		/// <returns></returns>
		public Domicilio GetDomicilio(int id)
			{
				Domicilio oReturn = new Domicilio();
				try
				{
					using (DALDomicilio dalDomicilio = new DALDomicilio())
                	{
						oReturn = dalDomicilio.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Domicilio
		/// de la tabla dbo.TBL_Domicilio
        /// </summary>
        /// <returns></returns>
       	public List<Domicilio> GetAllDomicilios()
		{
			List<Domicilio> lstDomicilio = new List<Domicilio>();
            try
            {
                using (DALDomicilio dalDomicilio = new DALDomicilio())
                {
                    lstDomicilio = dalDomicilio.GetAllDomicilios();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDomicilio;
			
			}
	}
}
