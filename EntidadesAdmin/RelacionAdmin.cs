using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Relacion 
    /// </summary>
    public class RelacionAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Relacion 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
        public Relacion Load(int codigo1, int codigo2)
			{
                Relacion oReturn = new Relacion();
				try
				{
                    using (DALRelacion dalRelacion = new DALRelacion())
                	{
                        oReturn = dalRelacion.Load(codigo1, codigo2);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Relacion
        /// </summary>
        /// <param name="oRelacion"></param>
        public void Delete(Relacion oRelacion)
			{
				try
				{
                    using (DALRelacion dalRelacion = new DALRelacion())
					{
                        dalRelacion.Delete(oRelacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Relacion 
		/// </summary>
        /// <param name="oRelacion"></param>
        public void Update(Relacion oRelacion)
			{
				try
				{
                    using (DALRelacion dalRelacion = new DALRelacion())
					{
                        dalRelacion.Update(oRelacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Relacion 
		/// </summary>
        /// <param name="oRelacion"></param>
        public void Insert(Relacion oRelacion)
		{
				try
				{
                    using (DALRelacion dalRelacion = new DALRelacion())
					{
                        dalRelacion.Insert(oRelacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Relacion 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
        public Relacion GetRelacion(int codigo1, int codigo2)
			{
                Relacion oReturn = new Relacion();
				try
				{
                    using (DALRelacion dalRelacion = new DALRelacion())
                	{
                        oReturn = dalRelacion.Load(codigo1, codigo2);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Relacion
        /// de la tabla dbo.TBL_Relacion
        /// </summary>
        /// <returns></returns>
        public List<Relacion> GetAllRelaciones()
		{
            List<Relacion> lstRelacion = new List<Relacion>();
            try
            {
                using (DALRelacion dalRelacion = new DALRelacion())
                {
                    lstRelacion = dalRelacion.GetAllRelaciones();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRelacion;
			
			}
	}
}
