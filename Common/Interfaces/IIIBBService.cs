using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad IIBBDataContracts(DB_LISDERO.dbo.TBL_IIBB)
	/// </summary>
	public interface IIIBBService
	{
		/// <summary>
		/// Interface para retornar un objeto IIBBDataContracts
		/// </summary>
		/// <value>IIBBDataContracts</value>
		IIBBDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(IIBBDataContracts oIIBB);

        /// <summary>
		/// Interface para actualiza un objeto IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(IIBBDataContracts oIIBB);
		
        /// <summary>
		/// Inteface para Insertar un objeto IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(IIBBDataContracts oIIBB);

        /// <summary>
		/// Interface para  rertornar objeto IIBBDataContracts
		/// </summary>
		/// <value>IIBBDataContracts</value>
	    IIBBDataContracts GetIIBB(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto IIBBDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<IIBBDataContracts>]]></value>
		List<IIBBDataContracts> GetAllIIBBs();
	}
}
