using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad RelacionDataContracts(DB_LISDERO.dbo.TBL_Relacion)
	/// </summary>
	public interface IRelacionService
	{
		/// <summary>
		/// Interface para retornar un objeto RelacionDataContracts
		/// </summary>
        /// <value>RelacionDataContracts</value>
        RelacionDataContracts Load(int codigo1, int codigo2);
		
		/// <summary>
        /// interface para eliminar un RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        void Delete(RelacionDataContracts oRelacion);

        /// <summary>
        /// Interface para actualiza un objeto RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        void Update(RelacionDataContracts oRelacion);
		
        /// <summary>
        /// Inteface para Insertar un objeto RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        void Insert(RelacionDataContracts oRelacion);

        /// <summary>
        /// Interface para  rertornar objeto RelacionDataContracts
		/// </summary>
        /// <value>RelacionDataContracts</value>
        RelacionDataContracts GetRelacion(int codigo1, int codigo2);
		
		/// <summary>
        /// Interface para  rertornar una lista de objeto RelacionDataContracts
		/// </summary>
        /// <value>ListList<![CDATA[<RelacionDataContracts>]]></value>
        List<RelacionDataContracts> GetAllRelaciones();
	}
}
