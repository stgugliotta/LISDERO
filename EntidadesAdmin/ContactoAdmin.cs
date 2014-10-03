using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Contacto 
    /// </summary>
  	public class ContactoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Contacto 
        /// </summary>
        /// <param name="codigo"></param>		
		/// <returns></returns>
		 public Contacto Load(int codigo)
			{
				Contacto oReturn = new Contacto();
				try
				{
					using (DALContacto dalContacto = new DALContacto())
                	{
						oReturn = dalContacto.Load( codigo);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Contacto
        /// </summary>
        /// <param name="oContacto"></param>
      	public void Delete(Contacto oContacto)
			{
				try
				{
					using (DALContacto dalContacto = new DALContacto())
					{
						dalContacto.Delete(oContacto);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Contacto 
		/// </summary>
        /// <param name="oContacto"></param>
     	public void Update(Contacto oContacto)
			{
				try
				{
					using (DALContacto dalContacto = new DALContacto())
					{
						dalContacto.Update(oContacto);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Contacto 
		/// </summary>
        /// <param name="oContacto"></param>
     	public void Insert(Contacto oContacto)
		{
				try
				{
					using (DALContacto dalContacto = new DALContacto())
					{
						dalContacto.Insert(oContacto);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Contacto 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="codigo"></param>   
		/// <returns></returns>
		public Contacto GetContacto(int codigo)
			{
				Contacto oReturn = new Contacto();
				try
				{
					using (DALContacto dalContacto = new DALContacto())
                	{
						oReturn = dalContacto.Load( codigo);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Contacto
		/// de la tabla dbo.TBL_Contacto
        /// </summary>
        /// <returns></returns>
       	public List<Contacto> GetAllContactos()
		{
			List<Contacto> lstContacto = new List<Contacto>();
            try
            {
                using (DALContacto dalContacto = new DALContacto())
                {
                    lstContacto = dalContacto.GetAllContactos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstContacto;
			
			}
	}
}
