using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Iva 
    /// </summary>
  	public class IvaAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Iva 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Iva Load(int id)
			{
				Iva oReturn = new Iva();
				try
				{
					using (DALIva dalIva = new DALIva())
                	{
						oReturn = dalIva.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Iva
        /// </summary>
        /// <param name="oIva"></param>
      	public void Delete(Iva oIva)
			{
				try
				{
					using (DALIva dalIva = new DALIva())
					{
						dalIva.Delete(oIva);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Iva 
		/// </summary>
        /// <param name="oIva"></param>
     	public void Update(Iva oIva)
			{
				try
				{
					using (DALIva dalIva = new DALIva())
					{
						dalIva.Update(oIva);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Iva 
		/// </summary>
        /// <param name="oIva"></param>
     	public void Insert(Iva oIva)
		{
				try
				{
					using (DALIva dalIva = new DALIva())
					{
						dalIva.Insert(oIva);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Iva 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>    
		/// <returns></returns>
		public Iva GetIva(int id)
			{
				Iva oReturn = new Iva();
				try
				{
					using (DALIva dalIva = new DALIva())
                	{
						oReturn = dalIva.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Iva
		/// de la tabla dbo.TBL_IVA
        /// </summary>
        /// <returns></returns>
       	public List<Iva> GetAllIvas()
		{
			List<Iva> lstIva = new List<Iva>();
            try
            {
                using (DALIva dalIva = new DALIva())
                {
                    lstIva = dalIva.GetAllIvas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstIva;
			
			}
	}
}
