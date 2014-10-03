using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad TelefonoDataContracts(DB_LISDERO.dbo.TBL_Telefono)
	/// </summary>
	public interface ITelefonoService
	{
		/// <summary>
		/// Interface para retornar un objeto TelefonoDataContracts
		/// </summary>
		/// <value>TelefonoDataContracts</value>
		TelefonoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(TelefonoDataContracts oTelefono);

        /// <summary>
		/// Interface para actualiza un objeto TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(TelefonoDataContracts oTelefono);
		
        /// <summary>
		/// Inteface para Insertar un objeto TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(TelefonoDataContracts oTelefono);

        /// <summary>
		/// Interface para  rertornar objeto TelefonoDataContracts
		/// </summary>
		/// <value>TelefonoDataContracts</value>
	    TelefonoDataContracts GetTelefono(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto TelefonoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<TelefonoDataContracts>]]></value>
		List<TelefonoDataContracts> GetAllTelefonos();
	}
}
