using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad CalificacionDataContracts(DB_LISDERO.dbo.TBL_Calificacion)
	/// </summary>
	public interface ICalificacionService
	{
		/// <summary>
		/// Interface para retornar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>CalificacionDataContracts</value>
		CalificacionDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(CalificacionDataContracts oCalificacion);

        /// <summary>
		/// Interface para actualiza un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(CalificacionDataContracts oCalificacion);
		
        /// <summary>
		/// Inteface para Insertar un objeto CalificacionDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(CalificacionDataContracts oCalificacion);

        /// <summary>
		/// Interface para  rertornar objeto CalificacionDataContracts
		/// </summary>
		/// <value>CalificacionDataContracts</value>
	    CalificacionDataContracts GetCalificacion(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto CalificacionDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<CalificacionDataContracts>]]></value>
		List<CalificacionDataContracts> GetAllCalificacions();
	}
}
