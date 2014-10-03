using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad TratamientoDataContracts(DB_LISDERO.dbo.TBL_Tratamiento)
	/// </summary>
	public interface ITratamientoService
	{
		/// <summary>
		/// Interface para retornar un objeto TratamientoDataContracts
		/// </summary>
		/// <value>TratamientoDataContracts</value>
		TratamientoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(TratamientoDataContracts oTratamiento);

        /// <summary>
		/// Interface para actualiza un objeto TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(TratamientoDataContracts oTratamiento);
		
        /// <summary>
		/// Inteface para Insertar un objeto TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(TratamientoDataContracts oTratamiento);

        /// <summary>
		/// Interface para  rertornar objeto TratamientoDataContracts
		/// </summary>
		/// <value>TratamientoDataContracts</value>
	    TratamientoDataContracts GetTratamiento(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto TratamientoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<TratamientoDataContracts>]]></value>
		List<TratamientoDataContracts> GetAllTratamientos();
	}
}
