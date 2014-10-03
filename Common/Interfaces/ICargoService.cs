using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad CargoDataContracts(DB_LISDERO.dbo.TBL_Cargo)
	/// </summary>
	public interface ICargoService
	{
		/// <summary>
		/// Interface para retornar un objeto CargoDataContracts
		/// </summary>
		/// <value>CargoDataContracts</value>
		CargoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un CargoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(CargoDataContracts oCargo);

        /// <summary>
		/// Interface para actualiza un objeto CargoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(CargoDataContracts oCargo);
		
        /// <summary>
		/// Inteface para Insertar un objeto CargoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(CargoDataContracts oCargo);

        /// <summary>
		/// Interface para  rertornar objeto CargoDataContracts
		/// </summary>
		/// <value>CargoDataContracts</value>
	    CargoDataContracts GetCargo(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto CargoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<CargoDataContracts>]]></value>
		List<CargoDataContracts> GetAllCargos();
	}
}
