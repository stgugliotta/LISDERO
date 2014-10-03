using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto PersonaLiviano 
    /// </summary>
  	public class PersonaLivianoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto PersonaLiviano 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public PersonaLiviano Load(int id)
			{
				PersonaLiviano oReturn = new PersonaLiviano();
				try
				{
					using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
                	{
						oReturn = dalPersonaLiviano.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto PersonaLiviano
        /// </summary>
        /// <param name="oPersonaLiviano"></param>
      	public void Delete(PersonaLiviano oPersonaLiviano)
			{
				try
				{
					using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
					{
						dalPersonaLiviano.Delete(oPersonaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto PersonaLiviano 
		/// </summary>
        /// <param name="oPersonaLiviano"></param>
     	public void Update(PersonaLiviano oPersonaLiviano)
			{
				try
				{
					using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
					{
						dalPersonaLiviano.Update(oPersonaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto PersonaLiviano 
		/// </summary>
        /// <param name="oPersonaLiviano"></param>
     	public void Insert(PersonaLiviano oPersonaLiviano)
		{
				try
				{
					using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
					{
						dalPersonaLiviano.Insert(oPersonaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto PersonaLiviano 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public PersonaLiviano GetPersonaLiviano(int id)
			{
				PersonaLiviano oReturn = new PersonaLiviano();
				try
				{
					using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
                	{
						oReturn = dalPersonaLiviano.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos PersonaLiviano
		/// de la tabla dbo.TBL_PersonaLiviano
        /// </summary>
        /// <returns></returns>
       	public List<PersonaLiviano> GetAllPersonaLivianos()
		{
			List<PersonaLiviano> lstPersonaLiviano = new List<PersonaLiviano>();
            try
            {
                using (DALPersonaLiviano dalPersonaLiviano = new DALPersonaLiviano())
                {
                    lstPersonaLiviano = dalPersonaLiviano.GetAllPersonaLivianos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPersonaLiviano;
			
			}
	}
}
