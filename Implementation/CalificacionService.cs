using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
	/// <summary>
	/// Creado		: 2013-05-16
	/// Accion		: Implementacion de la Interface de la Entidad Calificacion
	/// Objeto		: DB_LISDERO.dbo.tbl_calificacion
	/// Descripcion	: 
	/// </summary>
	public class CalificacionService: ICalificacionService
	{
		#region ICalificacionService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>CalificacionDataContracts</value>
		public CalificacionDataContracts Load(int id)
		 {
			 try
            {
			    CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                return (CalificacionDataContracts)calificacionAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(CalificacionDataContracts oCalificacion)
		{
            try
            {
                CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                	calificacionAdmin.Delete((Calificacion)oCalificacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(CalificacionDataContracts oCalificacion)
		{
            try
            {
                CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                	calificacionAdmin.Update((Calificacion)oCalificacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(CalificacionDataContracts oCalificacion)
		{
			try
            {
                CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                	calificacionAdmin.Insert((Calificacion) oCalificacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		public CalificacionDataContracts GetCalificacion(int id)
		 {
			 try
            {
			    CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                return (CalificacionDataContracts)calificacionAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCalificacion : CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		public List<CalificacionDataContracts> GetAllCalificacions()
		 {
			 try
            {
                CalificacionAdmin calificacionAdmin = new CalificacionAdmin();
                 List<Calificacion> resultList = calificacionAdmin.GetAllCalificacions();

                return resultList.ConvertAll<CalificacionDataContracts>(
                    delegate(Calificacion tempCalificacion) { return (CalificacionDataContracts)tempCalificacion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCalificacions : CalificacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}