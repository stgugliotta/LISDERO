using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad EmailDataContracts(DB_LISDERO.dbo.TBL_Email)
	/// </summary>
	public interface IEmailService
	{
		/// <summary>
		/// Interface para retornar un objeto EmailDataContracts
		/// </summary>
		/// <value>EmailDataContracts</value>
		EmailDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un EmailDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(EmailDataContracts oEmail);

        /// <summary>
		/// Interface para actualiza un objeto EmailDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(EmailDataContracts oEmail);
		
        /// <summary>
		/// Inteface para Insertar un objeto EmailDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(EmailDataContracts oEmail);

        /// <summary>
		/// Interface para  rertornar objeto EmailDataContracts
		/// </summary>
		/// <value>EmailDataContracts</value>
	    EmailDataContracts GetEmail(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto EmailDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<EmailDataContracts>]]></value>
		List<EmailDataContracts> GetAllEmails();
	}
}
