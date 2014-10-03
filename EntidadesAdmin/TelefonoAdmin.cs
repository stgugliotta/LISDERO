using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Telefono 
    /// </summary>
  	public class TelefonoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Telefono 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Telefono Load(int id)
			{
				Telefono oReturn = new Telefono();
				try
				{
					using (DALTelefono dalTelefono = new DALTelefono())
                	{
						oReturn = dalTelefono.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Telefono
        /// </summary>
        /// <param name="oTelefono"></param>
      	public void Delete(Telefono oTelefono)
			{
				try
				{
					using (DALTelefono dalTelefono = new DALTelefono())
					{
						dalTelefono.Delete(oTelefono);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Telefono 
		/// </summary>
        /// <param name="oTelefono"></param>
     	public void Update(Telefono oTelefono)
			{
				try
				{
					using (DALTelefono dalTelefono = new DALTelefono())
					{
						dalTelefono.Update(oTelefono);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Telefono 
		/// </summary>
        /// <param name="oTelefono"></param>
     	public void Insert(Telefono oTelefono)
		{
				try
				{
					using (DALTelefono dalTelefono = new DALTelefono())
					{
						dalTelefono.Insert(oTelefono);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Telefono 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>    
		/// <returns></returns>
		public Telefono GetTelefono(int id)
			{
				Telefono oReturn = new Telefono();
				try
				{
					using (DALTelefono dalTelefono = new DALTelefono())
                	{
						oReturn = dalTelefono.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Telefono
		/// de la tabla dbo.TBL_Telefono
        /// </summary>
        /// <returns></returns>
       	public List<Telefono> GetAllTelefonos()
		{
			List<Telefono> lstTelefono = new List<Telefono>();
            try
            {
                using (DALTelefono dalTelefono = new DALTelefono())
                {
                    lstTelefono = dalTelefono.GetAllTelefonos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTelefono;
			
			}
	}
}
