using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto EmpresaLiviano 
    /// </summary>
  	public class EmpresaLivianoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto EmpresaLiviano 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public EmpresaLiviano Load(int id)
			{
				EmpresaLiviano oReturn = new EmpresaLiviano();
				try
				{
					using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
                	{
						oReturn = dalEmpresaLiviano.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto EmpresaLiviano
        /// </summary>
        /// <param name="oEmpresaLiviano"></param>
      	public void Delete(EmpresaLiviano oEmpresaLiviano)
			{
				try
				{
					using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
					{
						dalEmpresaLiviano.Delete(oEmpresaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto EmpresaLiviano 
		/// </summary>
        /// <param name="oEmpresaLiviano"></param>
     	public void Update(EmpresaLiviano oEmpresaLiviano)
			{
				try
				{
					using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
					{
						dalEmpresaLiviano.Update(oEmpresaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto EmpresaLiviano 
		/// </summary>
        /// <param name="oEmpresaLiviano"></param>
     	public void Insert(EmpresaLiviano oEmpresaLiviano)
		{
				try
				{
					using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
					{
						dalEmpresaLiviano.Insert(oEmpresaLiviano);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto EmpresaLiviano 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public EmpresaLiviano GetEmpresaLiviano(int id)
			{
				EmpresaLiviano oReturn = new EmpresaLiviano();
				try
				{
					using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
                	{
						oReturn = dalEmpresaLiviano.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos EmpresaLiviano
		/// de la tabla dbo.TBL_EmpresaLiviano
        /// </summary>
        /// <returns></returns>
       	public List<EmpresaLiviano> GetAllEmpresaLivianos()
		{
			List<EmpresaLiviano> lstEmpresaLiviano = new List<EmpresaLiviano>();
            try
            {
                using (DALEmpresaLiviano dalEmpresaLiviano = new DALEmpresaLiviano())
                {
                    lstEmpresaLiviano = dalEmpresaLiviano.GetAllEmpresaLivianos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaLiviano;
			
			}
	}
}
