using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad DomicilioDataContracts(DB_LISDERO.dbo.TBL_Domicilio)
	/// </summary>
	public interface IDomicilioService
	{
		/// <summary>
		/// Interface para retornar un objeto DomicilioDataContracts
		/// </summary>
		/// <value>DomicilioDataContracts</value>
		DomicilioDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(DomicilioDataContracts oDomicilio);

        /// <summary>
		/// Interface para actualiza un objeto DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(DomicilioDataContracts oDomicilio);
		
        /// <summary>
		/// Inteface para Insertar un objeto DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(DomicilioDataContracts oDomicilio);

        /// <summary>
		/// Interface para  rertornar objeto DomicilioDataContracts
		/// </summary>
		/// <value>DomicilioDataContracts</value>
	    DomicilioDataContracts GetDomicilio(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto DomicilioDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<DomicilioDataContracts>]]></value>
		List<DomicilioDataContracts> GetAllDomicilios();
	}
}
