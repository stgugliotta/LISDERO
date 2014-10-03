using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;

namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad PersonaDataContracts(DB_LISDERO.dbo.TBL_Persona)
	/// </summary>
	public interface IPersonaService
	{
		/// <summary>
		/// Interface para retornar un objeto PersonaDataContracts
		/// </summary>
		/// <value>PersonaDataContracts</value>
		PersonaDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(PersonaDataContracts oPersona);

        /// <summary>
		/// Interface para actualiza un objeto PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(PersonaDataContracts oPersona);
		
        /// <summary>
		/// Inteface para Insertar un objeto PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(PersonaDataContracts oPersona);

        /// <summary>
		/// Interface para  rertornar objeto PersonaDataContracts
		/// </summary>
		/// <value>PersonaDataContracts</value>
	    PersonaDataContracts GetPersona(int id);
        PersonaDataContracts GetPersonaByCodigo(int codigo);
		/// <summary>
		/// Interface para  rertornar una lista de objeto PersonaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<PersonaDataContracts>]]></value>
		List<PersonaDataContracts> GetAllPersonas();
	}
}
