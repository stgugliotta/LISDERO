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
    /// Creado		: 2010-02-26
    /// Accion		: Implementacion de la Interface de la Entidad Agenda
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_agenda
    /// Descripcion	: 
    /// </summary>
    public class AgendaService : IAgendaService
    {
        #region IAgendaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto AgendaDataContracts
        /// </summary>
        /// <value>AgendaDataContracts</value>
        public AgendaDataContracts Load(int idTarea)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                return (AgendaDataContracts)agendaAdmin.Load(idTarea);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(AgendaDataContracts oAgenda)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                agendaAdmin.Delete((Agenda)oAgenda);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(AgendaDataContracts oAgenda)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                agendaAdmin.Update((Agenda)oAgenda);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public long Insert(AgendaDataContracts oAgenda)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                return agendaAdmin.Insert((Agenda)oAgenda);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public AgendaDataContracts GetAgenda(int idTarea)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                return (AgendaDataContracts)agendaAdmin.Load(idTarea);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetAgenda : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AgendaDataContracts> GetAllAgendas()
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                List<Agenda> resultList = agendaAdmin.GetAllAgendas();

                return resultList.ConvertAll<AgendaDataContracts>(
                    delegate(Agenda tempAgenda) { return (AgendaDataContracts)tempAgenda; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAgendas : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AgendaDataContracts> GetAllAgendasByAnalista(string analista)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                List<Agenda> resultList = agendaAdmin.GetAllAgendasByAnalista(analista);

                return resultList.ConvertAll<AgendaDataContracts>(
                    delegate(Agenda tempAgenda) { return (AgendaDataContracts)tempAgenda; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAgendasByAnalista : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<AgendaDataContracts> GetAllAgendasByAnalistaYFecha(string analista,DateTime fecha)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                List<Agenda> resultList = agendaAdmin.GetAllAgendasByAnalistaYFecha(analista,fecha);

                return resultList.ConvertAll<AgendaDataContracts>(
                    delegate(Agenda tempAgenda) { return (AgendaDataContracts)tempAgenda; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllAgendasByAnalistaYFecha : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<AgendaHistoriaDataContracts> GetAllAgendasHistoriaByIdTarea(int idTarea)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                List<AgendaHistoria> resultList = agendaAdmin.GetAllAgendasHistoriaByIdTarea(idTarea);

                return resultList.ConvertAll<AgendaHistoriaDataContracts>(
                    delegate(AgendaHistoria tempAgenda) { return (AgendaHistoriaDataContracts)tempAgenda; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepción Técnica - GetAllAgendasHistoriaByIdTarea : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurrió una Excepción en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<AgendaDataContracts> BuscarAgendaPorFiltros(Boolean IdTarea, string FiltroIdTarea, Boolean Hora, string FiltroHora, Boolean Evento, string FiltroEvento, Boolean TipoEvento, string FiltroTipoEvento, Boolean Usuario, string FiltroUsuario, Boolean FechaAct, string FiltroFechaAct, Boolean Prioridad, string FiltroPrioridad, Boolean Tarea, string FiltroTarea, Boolean Estado, string FiltroEstado, Boolean Contacto, string FiltroContacto)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                List<Agenda> resultList = agendaAdmin.BuscarAgendaPorFiltros(IdTarea, FiltroIdTarea, Hora, FiltroHora, Evento, FiltroEvento, TipoEvento, FiltroTipoEvento, Usuario, FiltroUsuario, FechaAct, FiltroFechaAct, Prioridad, FiltroPrioridad, Tarea, FiltroTarea, Estado, FiltroEstado, Contacto, FiltroContacto);

                return resultList.ConvertAll<AgendaDataContracts>(
                      delegate(Agenda tempAgenda) { return (AgendaDataContracts)tempAgenda; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepción Técnica - BuscarAgendaPorFiltros : AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurrió una Excepción en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public AgendaHistoriaDataContracts LoadHistorica(int idTareaHistoria)
        {
            try
            {
                AgendaAdmin agendaAdmin = new AgendaAdmin();
                return (AgendaHistoriaDataContracts)agendaAdmin.LoadHistorica(idTareaHistoria);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - LoadHistorica: AgendaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }




        #endregion

        #region IAgendaService Members


      
        #endregion

       
    }
}