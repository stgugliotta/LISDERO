using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad PersonaLivianoDataContracts(DB_LISDERO.dbo.TBL_PersonaLiviano)
	/// </summary>
	public interface IPersonaLivianoService
	{
		/// <summary>
		/// Interface para retornar un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>PersonaLivianoDataContracts</value>
		PersonaLivianoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(PersonaLivianoDataContracts oPersonaLiviano);

        /// <summary>
		/// Interface para actualiza un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(PersonaLivianoDataContracts oPersonaLiviano);
		
        /// <summary>
		/// Inteface para Insertar un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(PersonaLivianoDataContracts oPersonaLiviano);

        /// <summary>
		/// Interface para  rertornar objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>PersonaLivianoDataContracts</value>
	    PersonaLivianoDataContracts GetPersonaLiviano(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<PersonaLivianoDataContracts>]]></value>
		List<PersonaLivianoDataContracts> GetAllPersonaLivianos();
	}
}
