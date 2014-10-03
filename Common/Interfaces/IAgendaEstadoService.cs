using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad AgendaEstadoDataContracts(DB_LISDERO.dbo.TBL_Agenda_Estado)
	/// </summary>
    public interface IAgendaEstadoService
	{
		/// <summary>
        /// Interface para retornar un objeto AgendaEstadoDataContracts 
		/// </summary>
        /// <value>AgendaEstadoDataContracts </value>
		AgendaEstadoDataContracts Load(int id);
		
		/// <summary>
        /// interface para eliminar un AgendaEstadoDataContracts 
		/// </summary>
		/// <value>void</value>
        void Delete(AgendaEstadoDataContracts oAgendaEstado);

        /// <summary>
		/// Interface para actualiza un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(AgendaEstadoDataContracts oAgendaEstado);
		
        /// <summary>
		/// Inteface para Insertar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(AgendaEstadoDataContracts oAgendaEstado);

        /// <summary>
        /// Interface para  rertornar objeto AgendaEstadoDataContracts 
		/// </summary>
        /// <value>AgendaEstadoDataContracts</value>
        AgendaEstadoDataContracts GetAgendaEstado(int id);
		
		/// <summary>
        /// Interface para  rertornar una lista de objeto AgendaEstadoDataContracts 
		/// </summary>
        /// <value>ListList<![CDATA[<AgendaEstadoDataContracts>]]></value>
        List<AgendaEstadoDataContracts> GetAllAgendaEstado();
	}
}
