using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
    /// Interface para manejar la entidad TipoEventoDataContracts(DB_LISDERO.dbo.TBL_TipoEvento)
	/// </summary>
    public interface ITipoEventoService
	{
		/// <summary>
        /// Interface para retornar un objeto TipoEventoDataContracts
		/// </summary>
        /// <value>TipoEventoDataContracts</value>
        TipoEventoDataContracts Load(int id);
		
		/// <summary>
        /// interface para eliminar un TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(TipoEventoDataContracts oTipoEvento);

        /// <summary>
        /// Interface para actualiza un objeto TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(TipoEventoDataContracts oTipoEvento);
		
        /// <summary>
        /// Inteface para Insertar un objeto TipoEventoDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(TipoEventoDataContracts oTipoEvento);

        /// <summary>
        /// Interface para  rertornar objeto TipoEventoDataContracts
		/// </summary>
        /// <value>TipoEventoDataContracts</value>
        TipoEventoDataContracts GetTipoEvento(int id);
		
		/// <summary>
        /// Interface para  rertornar una lista de objeto TipoEventoDataContracts
		/// </summary>
        /// <value>ListList<![CDATA[<TipoEventoDataContracts>]]></value>
        List<TipoEventoDataContracts> GetAllTiposDeEvento();
	}
}
