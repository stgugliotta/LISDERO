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
	/// Accion		: Implementacion de la Interface de la Entidad TipoEvento
	/// Objeto		: DB_LISDERO.dbo.tbl_TipoEvento
	/// Descripcion	: 
	/// </summary>
	public class TipoEventoService: ITipoEventoService
	{
		#region ITipoEventoService   M E M B E R S 
		/// <summary>
        /// Implementacion de la Interfaz para retornar un objeto TipoEventoDataContracts
		/// </summary>
        /// <value>TipoEventoDataContracts</value>
        public TipoEventoDataContracts Load(int id)
		 {
			 try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                return (TipoEventoDataContracts)tipoEventoAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// implementacion de la interfaz para eliminar un TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Delete(TipoEventoDataContracts oTipoEvento)
		{
            try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                tipoEventoAdmin.Delete((TipoEvento)oTipoEvento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Update(TipoEventoDataContracts oTipoEvento)
		{
            try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                tipoEventoAdmin.Update((TipoEvento)oTipoEvento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Insert(TipoEventoDataContracts oTipoEvento)
		{
			try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                tipoEventoAdmin.Insert((TipoEvento)oTipoEvento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        public TipoEventoDataContracts GetTipoEvento(int id)
		 {
			 try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                return (TipoEventoDataContracts)tipoEventoAdmin.Load(id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetTipoEvento : TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        public List<TipoEventoDataContracts> GetAllTiposDeEvento()
		 {
			 try
            {
                TipoEventoAdmin tipoEventoAdmin = new TipoEventoAdmin();
                List<TipoEvento> resultList = tipoEventoAdmin.GetAllTiposDeEvento();

                return resultList.ConvertAll<TipoEventoDataContracts>(
                    delegate(TipoEvento tempTipoEvento) { return (TipoEventoDataContracts)tempTipoEvento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllTiposDeEvento: TipoEventoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}