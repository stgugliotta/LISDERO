using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad AgendaDataContracts(EMACSA_NUCLEO.dbo.TBL_Agenda)
    /// </summary>
    public interface IAgendaService
    {
        /// <summary>
        /// Interface para retornar un objeto AgendaDataContracts
        /// </summary>
        /// <value>AgendaDataContracts</value>
        AgendaDataContracts Load(int idTarea);

        /// <summary>
        /// interface para eliminar un AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(AgendaDataContracts oAgenda);

        /// <summary>
        /// Interface para actualiza un objeto AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(AgendaDataContracts oAgenda);

        /// <summary>
        /// Inteface para Insertar un objeto AgendaDataContracts
        /// </summary>
        /// <value>void</value>
        long Insert(AgendaDataContracts oAgenda);

        /// <summary>
        /// Interface para  rertornar objeto AgendaDataContracts
        /// </summary>
        /// <value>AgendaDataContracts</value>
        AgendaDataContracts GetAgenda(int idTarea);

        /// <summary>
        /// Interface para  rertornar una lista de objeto AgendaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AgendaDataContracts>]]></value>
        List<AgendaDataContracts> GetAllAgendas();

        /// <summary>
        /// Interface para  rertornar una lista de objeto AgendaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AgendaDataContracts>]]></value>
        List<AgendaDataContracts> GetAllAgendasByAnalista(string analista);

        List<AgendaHistoriaDataContracts> GetAllAgendasHistoriaByIdTarea(int idTarea);

        AgendaHistoriaDataContracts LoadHistorica(int idTareaHistoria);
        /// <summary>
        /// Interface para  rertornar una lista de objeto AgendaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<AgendaDataContracts>]]></value>
        List<AgendaDataContracts> GetAllAgendasByAnalistaYFecha(string analista,DateTime fecha);

        List<AgendaDataContracts> BuscarAgendaPorFiltros(Boolean IdTarea, string FiltroIdTarea, Boolean Hora, string FiltroHora, Boolean Evento, string FiltroEvento, Boolean TipoEvento, string FiltroTipoEvento, Boolean Usuario, string FiltroUsuario, Boolean FechaAct, string FiltroFechaAct, Boolean Prioridad, string FiltroPrioridad, Boolean Tarea, string FiltroTarea, Boolean Estado, string FiltroEstado, Boolean Contacto, string contacto);
    }
}
