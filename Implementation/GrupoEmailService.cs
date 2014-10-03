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
	/// Accion		: Implementacion de la Interface de la Entidad GrupoEmail
    /// Objeto		: DB_LISDERO.dbo.tbl_GrupoEmail
	/// Descripcion	: 
	/// </summary>
    public class GrupoEmailService : IGrupoEmailService
    {
        #region IGrupoEmailService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto GrupoEmailDataContracts
		/// </summary>
        /// <value>GrupoEmailDataContracts</value>
        public GrupoEmailDataContracts Load(int id)
		 {
			 try
            {
                GrupoEmailAdmin GrupoEmailAdmin = new GrupoEmailAdmin();
                return (GrupoEmailDataContracts)GrupoEmailAdmin.Load(id);
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
        /// implementacion de la interfaz para eliminar un GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        public void Delete(GrupoEmailDataContracts oGrupoEmail)
		{
            try
            {
                GrupoEmailAdmin grupoEmailAdmin = new GrupoEmailAdmin();
                grupoEmailAdmin.Delete((GrupoEmail)oGrupoEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        public void Update(GrupoEmailDataContracts oGrupoEmail)
		{
            try
            {
                GrupoEmailAdmin grupoEmailAdmin = new GrupoEmailAdmin();
                grupoEmailAdmin.Update((GrupoEmail)oGrupoEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        public void Insert(GrupoEmailDataContracts oGrupoEmail)
		{
			try
            {
                GrupoEmailAdmin grupoEmailAdmin = new GrupoEmailAdmin();
                grupoEmailAdmin.Insert((GrupoEmail)oGrupoEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        public GrupoEmailDataContracts GetGrupoEmail(int id)
		 {
			 try
            {
                GrupoEmailAdmin grupoEmailAdmin = new GrupoEmailAdmin();
                return (GrupoEmailDataContracts)grupoEmailAdmin.Load(id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetGrupoEmail : GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        public List<GrupoEmailDataContracts> GetAllGrupoEmails()
		 {
			 try
            {
                GrupoEmailAdmin grupoEmailAdmin = new GrupoEmailAdmin();
                List<GrupoEmail> resultList = grupoEmailAdmin.GetAllGrupoEmails();

                return resultList.ConvertAll<GrupoEmailDataContracts>(
                    delegate(GrupoEmail tempGrupoEmail) { return (GrupoEmailDataContracts)tempGrupoEmail; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmails : GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}