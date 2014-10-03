using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    public interface IGrupoEmailContenidoLivianoService
    {

        		/// <summary>
		/// Interface para retornar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
        /// <value>GrupoEmailContenidoDataContracts</value>
        GrupoEmailContenidoLivianoDataContracts Load(int idGrupoEmail, string codigoRelacion);
		
		/// <summary>
        /// interface para eliminar un GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido);

        /// <summary>
        /// Interface para actualiza un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido);
		
        /// <summary>
        /// Inteface para Insertar un objeto GrupoEmailContenidoDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido);

	    /// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailContenidoDataContracts>]]></value>
        List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int idGrupoEmail);

        /// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailContenidoDataContracts>]]></value>
        List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(int idGrupoEmail);

        /// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailContenidoDataContracts>]]></value>
        List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoLivianoByEmail(int idGrupoEmail, string idCodigoRelacion);

        void Combinar(int id_GrupoEmailNuevo, int id_GrupoEmailViejo, string id_CodigoRelacion);
		
    }
}
