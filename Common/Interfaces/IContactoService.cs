using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad ContactoDataContracts(DB_LISDERO.dbo.TBL_Contacto)
	/// </summary>
	public interface IContactoService
	{
		/// <summary>
		/// Interface para retornar un objeto ContactoDataContracts
		/// </summary>
		/// <value>ContactoDataContracts</value>
		ContactoDataContracts Load(int codigo);
		
		/// <summary>
		/// interface para eliminar un ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ContactoDataContracts oContacto);

        /// <summary>
		/// Interface para actualiza un objeto ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ContactoDataContracts oContacto);
		
        /// <summary>
		/// Inteface para Insertar un objeto ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ContactoDataContracts oContacto);

        /// <summary>
		/// Interface para  rertornar objeto ContactoDataContracts
		/// </summary>
		/// <value>ContactoDataContracts</value>
	    ContactoDataContracts GetContacto(int codigo);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ContactoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ContactoDataContracts>]]></value>
		List<ContactoDataContracts> GetAllContactos();
	}
}
