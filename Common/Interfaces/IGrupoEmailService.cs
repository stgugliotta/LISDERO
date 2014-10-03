using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad GrupoEmailDataContracts(DB_LISDERO.dbo.TBL_GrupoEmail)
	/// </summary>
    public interface IGrupoEmailService
	{
		/// <summary>
		/// Interface para retornar un objeto GrupoEmailDataContracts
		/// </summary>
        /// <value>GrupoEmailDataContracts</value>
        GrupoEmailDataContracts Load(int id);
		
		/// <summary>
        /// interface para eliminar un GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(GrupoEmailDataContracts oGrupoEmail);

        /// <summary>
        /// Interface para actualiza un objeto GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(GrupoEmailDataContracts oGrupoEmail);
		
        /// <summary>
        /// Inteface para Insertar un objeto GrupoEmailDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(GrupoEmailDataContracts oGrupoEmail);

        /// <summary>
        /// Interface para  rertornar objeto GrupoEmailDataContracts
		/// </summary>
        /// <value>GrupoEmailDataContracts</value>
        GrupoEmailDataContracts GetGrupoEmail(int id);
		
		/// <summary>
        /// Interface para  rertornar una lista de objeto GrupoEmailDataContracts
		/// </summary>
        /// <value>ListList<![CDATA[<GrupoEmailDataContracts>]]></value>
        List<GrupoEmailDataContracts> GetAllGrupoEmails();
	}
}
