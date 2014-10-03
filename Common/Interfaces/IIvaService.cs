using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad IvaDataContracts(DB_LISDERO.dbo.TBL_IVA)
	/// </summary>
	public interface IIvaService
	{
		/// <summary>
		/// Interface para retornar un objeto IvaDataContracts
		/// </summary>
		/// <value>IvaDataContracts</value>
		IvaDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un IvaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(IvaDataContracts oIva);

        /// <summary>
		/// Interface para actualiza un objeto IvaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(IvaDataContracts oIva);
		
        /// <summary>
		/// Inteface para Insertar un objeto IvaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(IvaDataContracts oIva);

        /// <summary>
		/// Interface para  rertornar objeto IvaDataContracts
		/// </summary>
		/// <value>IvaDataContracts</value>
	    IvaDataContracts GetIva(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto IvaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<IvaDataContracts>]]></value>
		List<IvaDataContracts> GetAllIvas();
	}
}
