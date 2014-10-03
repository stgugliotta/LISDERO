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
    /// Accion		: Implementacion de la Interface de la Entidad AgendaEstado
	/// Objeto		: DB_LISDERO.dbo.tbl_agenda_estado
	/// Descripcion	: 
	/// </summary>
    public class AgendaEstadoService : IAgendaEstadoService
	{
		#region IAgendaEstadoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto AgendaEstadoDataContracts
		/// </summary>
		/// <value>AgendaEstadoDataContracts</value>
		public AgendaEstadoDataContracts Load(int id)
		 {
			 try
            {
			    AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                return (AgendaEstadoDataContracts)agendaEstadoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un AgendaEstadoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(AgendaEstadoDataContracts oAgendaEstado)
		{
            try
            {
                AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                agendaEstadoAdmin.Delete((AgendaEstado)oAgendaEstado);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto AgendaEstadoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Update(AgendaEstadoDataContracts oAgendaEstado)
		{
            try
            {
                AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                agendaEstadoAdmin.Update((AgendaEstado)oAgendaEstado);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto AgendaEstadoDataContracts
		/// </summary>
		/// <value>void</value>
        public void Insert(AgendaEstadoDataContracts oAgendaEstado)
		{
			try
            {
                AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                agendaEstadoAdmin.Insert((AgendaEstado)oAgendaEstado);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto AgendaEstadoDataContracts
		/// </summary>
		/// <value>void</value>
        public AgendaEstadoDataContracts GetAgendaEstado(int id)
		 {
			 try
            {
                AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                return (AgendaEstadoDataContracts)agendaEstadoAdmin.Load(id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAgendaEstado : AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AgendaEstadoDataContracts
		/// </summary>
		/// <value>void</value>
        public List<AgendaEstadoDataContracts> GetAllAgendaEstado()
		 {
			 try
            {
                AgendaEstadoAdmin agendaEstadoAdmin = new AgendaEstadoAdmin();
                List<AgendaEstado> resultList = agendaEstadoAdmin.GetAllAgendaEstados();

                return resultList.ConvertAll<AgendaEstadoDataContracts>(
                    delegate(AgendaEstado tempAgendaEstado) { return (AgendaEstadoDataContracts)tempAgendaEstado; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAgendaEstados : AgendaEstadoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}