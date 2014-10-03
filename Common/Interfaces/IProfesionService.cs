using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad ProfesionDataContracts(DB_LISDERO.dbo.TBL_Profesion)
	/// </summary>
	public interface IProfesionService
	{
		/// <summary>
		/// Interface para retornar un objeto ProfesionDataContracts
		/// </summary>
		/// <value>ProfesionDataContracts</value>
		ProfesionDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(ProfesionDataContracts oProfesion);

        /// <summary>
		/// Interface para actualiza un objeto ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(ProfesionDataContracts oProfesion);
		
        /// <summary>
		/// Inteface para Insertar un objeto ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(ProfesionDataContracts oProfesion);

        /// <summary>
		/// Interface para  rertornar objeto ProfesionDataContracts
		/// </summary>
		/// <value>ProfesionDataContracts</value>
	    ProfesionDataContracts GetProfesion(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto ProfesionDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<ProfesionDataContracts>]]></value>
		List<ProfesionDataContracts> GetAllProfesions();
	}
}
