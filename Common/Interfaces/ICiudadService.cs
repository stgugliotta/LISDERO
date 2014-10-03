using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad CiudadDataContracts(DB_LISDERO.dbo.TBL_Ciudad)
	/// </summary>
	public interface ICiudadService
	{
		/// <summary>
		/// Interface para retornar un objeto CiudadDataContracts
		/// </summary>
		/// <value>CiudadDataContracts</value>
		CiudadDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(CiudadDataContracts oCiudad);

        /// <summary>
		/// Interface para actualiza un objeto CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(CiudadDataContracts oCiudad);
		
        /// <summary>
		/// Inteface para Insertar un objeto CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(CiudadDataContracts oCiudad);

        /// <summary>
		/// Interface para  rertornar objeto CiudadDataContracts
		/// </summary>
		/// <value>CiudadDataContracts</value>
	    CiudadDataContracts GetCiudad(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto CiudadDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<CiudadDataContracts>]]></value>
		List<CiudadDataContracts> GetAllCiudads();

        List<CiudadDataContracts> GetAllCiudadesPorIdProvincia(int idProvincia);
	}
}
