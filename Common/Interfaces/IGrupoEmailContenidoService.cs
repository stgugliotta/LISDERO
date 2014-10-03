using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad GrupoEmailContenidoDataContracts(DB_LISDERO.dbo.TBL_GrupoEmail_Contenido)
	/// </summary>
    public interface IGrupoEmailContenidoService
	{
		/// <summary>
		/// Interface para retornar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
        /// <value>GrupoEmailContenidoDataContracts</value>
        GrupoEmailContenidoDataContracts Load(int idGrupoEmail, string codigoRelacion);
		
		/// <summary>
        /// interface para eliminar un GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(GrupoEmailContenidoDataContracts oGrupoEmailContenido);

        /// <summary>
        /// Interface para actualiza un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(GrupoEmailContenidoDataContracts oGrupoEmailContenido);
		
        /// <summary>
        /// Inteface para Insertar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(GrupoEmailContenidoDataContracts oGrupoEmailContenido);

        /// <summary>
        /// Interface para  rertornar objeto GrupoEmailContenidoDataContracts
		/// </summary>
        /// <value>GrupoEmailContenidoDataContracts</value>
        GrupoEmailContenidoDataContracts GetGrupoEmailContenido(int idGrupoEmail, string codigoRelacion);
		
		/// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailContenidoDataContracts
		/// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailContenidoDataContracts>]]></value>
        List<GrupoEmailContenidoDataContracts> GetAllGrupoEmailContenido();

        /// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailContenidoDataContracts>]]></value>
        List<GrupoEmailContenidoDataContracts> GetAllGrupoEmailContenidoByIdGrupoEmail(int idGrupoEmail);
        

	}
}
