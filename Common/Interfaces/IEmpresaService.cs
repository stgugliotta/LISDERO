using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad EmpresaDataContracts(DB_LISDERO.dbo.TBL_Empresa)
	/// </summary>
	public interface IEmpresaService
	{
		/// <summary>
		/// Interface para retornar un objeto EmpresaDataContracts
		/// </summary>
		/// <value>EmpresaDataContracts</value>
		EmpresaDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(EmpresaDataContracts oEmpresa);

        /// <summary>
		/// Interface para actualiza un objeto EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(EmpresaDataContracts oEmpresa);
        EmpresaDataContracts GetEmpresaByCodigo(int codigo);
        /// <summary>
		/// Inteface para Insertar un objeto EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(EmpresaDataContracts oEmpresa);

        /// <summary>
		/// Interface para  rertornar objeto EmpresaDataContracts
		/// </summary>
		/// <value>EmpresaDataContracts</value>
	    EmpresaDataContracts GetEmpresa(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto EmpresaDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<EmpresaDataContracts>]]></value>
		List<EmpresaDataContracts> GetAllEmpresas();
	}
}
