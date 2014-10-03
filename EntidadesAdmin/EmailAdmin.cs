using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Email 
    /// </summary>
  	public class EmailAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Email 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Email Load(int id)
			{
				Email oReturn = new Email();
				try
				{
					using (DALEmail dalEmail = new DALEmail())
                	{
						oReturn = dalEmail.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Email
        /// </summary>
        /// <param name="oEmail"></param>
      	public void Delete(Email oEmail)
			{
				try
				{
					using (DALEmail dalEmail = new DALEmail())
					{
						dalEmail.Delete(oEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Email 
		/// </summary>
        /// <param name="oEmail"></param>
     	public void Update(Email oEmail)
			{
				try
				{
					using (DALEmail dalEmail = new DALEmail())
					{
						dalEmail.Update(oEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Email 
		/// </summary>
        /// <param name="oEmail"></param>
     	public void Insert(Email oEmail)
		{
				try
				{
					using (DALEmail dalEmail = new DALEmail())
					{
						dalEmail.Insert(oEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Email 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>    
		/// <returns></returns>
		public Email GetEmail(int id)
			{
				Email oReturn = new Email();
				try
				{
					using (DALEmail dalEmail = new DALEmail())
                	{
						oReturn = dalEmail.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Email
		/// de la tabla dbo.TBL_Email
        /// </summary>
        /// <returns></returns>
       	public List<Email> GetAllEmails()
		{
			List<Email> lstEmail = new List<Email>();
            try
            {
                using (DALEmail dalEmail = new DALEmail())
                {
                    lstEmail = dalEmail.GetAllEmails();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmail;
			
			}
	}
}
