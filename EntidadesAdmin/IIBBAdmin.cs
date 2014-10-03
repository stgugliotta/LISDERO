using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto IIBB 
    /// </summary>
  	public class IIBBAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto IIBB 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public IIBB Load(int id)
			{
				IIBB oReturn = new IIBB();
				try
				{
					using (DALIIBB dalIIBB = new DALIIBB())
                	{
						oReturn = dalIIBB.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto IIBB
        /// </summary>
        /// <param name="oIIBB"></param>
      	public void Delete(IIBB oIIBB)
			{
				try
				{
					using (DALIIBB dalIIBB = new DALIIBB())
					{
						dalIIBB.Delete(oIIBB);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto IIBB 
		/// </summary>
        /// <param name="oIIBB"></param>
     	public void Update(IIBB oIIBB)
			{
				try
				{
					using (DALIIBB dalIIBB = new DALIIBB())
					{
						dalIIBB.Update(oIIBB);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto IIBB 
		/// </summary>
        /// <param name="oIIBB"></param>
     	public void Insert(IIBB oIIBB)
		{
				try
				{
					using (DALIIBB dalIIBB = new DALIIBB())
					{
						dalIIBB.Insert(oIIBB);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto IIBB 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public IIBB GetIIBB(int id)
			{
				IIBB oReturn = new IIBB();
				try
				{
					using (DALIIBB dalIIBB = new DALIIBB())
                	{
						oReturn = dalIIBB.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos IIBB
		/// de la tabla dbo.TBL_IIBB
        /// </summary>
        /// <returns></returns>
       	public List<IIBB> GetAllIIBBs()
		{
			List<IIBB> lstIIBB = new List<IIBB>();
            try
            {
                using (DALIIBB dalIIBB = new DALIIBB())
                {
                    lstIIBB = dalIIBB.GetAllIIBBs();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstIIBB;
			
			}
	}
}
