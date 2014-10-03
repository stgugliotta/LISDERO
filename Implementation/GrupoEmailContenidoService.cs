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
	/// Accion		: Implementacion de la Interface de la Entidad GrupoEmailContenido
    /// Objeto		: DB_LISDERO.dbo.tbl_GrupoEmail_Contenid
	/// Descripcion	: 
	/// </summary>
    public class GrupoEmailContenidoService : IGrupoEmailContenidoService
    {
        #region IGrupoEmailContenidoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
        /// <value>GrupoEmailContenidoDataContracts</value>
        public GrupoEmailContenidoDataContracts Load(int idGrupoEmail, string codigoRelacion)
		 {
			 try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                return (GrupoEmailContenidoDataContracts)grupoEmailContenidoAdmin.Load(idGrupoEmail, codigoRelacion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// implementacion de la interfaz para eliminar un GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Delete(GrupoEmailContenidoDataContracts oGrupoEmailContenido)
		{
            try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                grupoEmailContenidoAdmin.Delete((GrupoEmailContenido)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Update(GrupoEmailContenidoDataContracts oGrupoEmailContenido)
		{
            try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                grupoEmailContenidoAdmin.Update((GrupoEmailContenido)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Insert(GrupoEmailContenidoDataContracts oGrupoEmailContenido)
		{
			try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                grupoEmailContenidoAdmin.Insert((GrupoEmailContenido)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        public GrupoEmailContenidoDataContracts GetGrupoEmailContenido(int idGrupoEmail, string codigoRelacion)
		 {
			 try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                return (GrupoEmailContenidoDataContracts)grupoEmailContenidoAdmin.Load(idGrupoEmail, codigoRelacion);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetGrupoEmailContenido : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        public List<GrupoEmailContenidoDataContracts> GetAllGrupoEmailContenido()
		 {
			 try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                List<GrupoEmailContenido> resultList = grupoEmailContenidoAdmin.GetAllGrupoEmailContenido();

                return resultList.ConvertAll<GrupoEmailContenidoDataContracts>(
                    delegate(GrupoEmailContenido tempGrupoEmailContenido) { return (GrupoEmailContenidoDataContracts)tempGrupoEmailContenido; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmailContenido : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>void</value>
        public List<GrupoEmailContenidoDataContracts> GetAllGrupoEmailContenidoByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                GrupoEmailContenidoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoAdmin();
                List<GrupoEmailContenido> resultList = grupoEmailContenidoAdmin.GetAllGrupoEmailContenidoByIdGrupoEmail(idGrupoEmail);

                return resultList.ConvertAll<GrupoEmailContenidoDataContracts>(
                    delegate(GrupoEmailContenido tempGrupoEmailContenido) { return (GrupoEmailContenidoDataContracts)tempGrupoEmailContenido; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmailContenidoByIdGrupoEmail : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }       


		#endregion
	}
}