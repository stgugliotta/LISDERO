using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Cargo 
    /// </summary>
  	public class CargoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Cargo 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Cargo Load(int id)
			{
				Cargo oReturn = new Cargo();
				try
				{
					using (DALCargo dalCargo = new DALCargo())
                	{
						oReturn = dalCargo.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Cargo
        /// </summary>
        /// <param name="oCargo"></param>
      	public void Delete(Cargo oCargo)
			{
				try
				{
					using (DALCargo dalCargo = new DALCargo())
					{
						dalCargo.Delete(oCargo);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Cargo 
		/// </summary>
        /// <param name="oCargo"></param>
     	public void Update(Cargo oCargo)
			{
				try
				{
					using (DALCargo dalCargo = new DALCargo())
					{
						dalCargo.Update(oCargo);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Cargo 
		/// </summary>
        /// <param name="oCargo"></param>
     	public void Insert(Cargo oCargo)
		{
				try
				{
					using (DALCargo dalCargo = new DALCargo())
					{
						dalCargo.Insert(oCargo);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Cargo 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Cargo GetCargo(int id)
			{
				Cargo oReturn = new Cargo();
				try
				{
					using (DALCargo dalCargo = new DALCargo())
                	{
						oReturn = dalCargo.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cargo
		/// de la tabla dbo.TBL_Cargo
        /// </summary>
        /// <returns></returns>
       	public List<Cargo> GetAllCargos()
		{
			List<Cargo> lstCargo = new List<Cargo>();
            try
            {
                using (DALCargo dalCargo = new DALCargo())
                {
                    lstCargo = dalCargo.GetAllCargos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCargo;
			
			}
	}
}
