using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{

	/// <summary>
	/// Interface para manejar la entidad EmpresaLivianoDataContracts(DB_LISDERO.dbo.TBL_EmpresaLiviano)
	/// </summary>
	public interface IEmpresaLivianoService
	{
		/// <summary>
		/// Interface para retornar un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>EmpresaLivianoDataContracts</value>
		EmpresaLivianoDataContracts Load(int id);
		
		/// <summary>
		/// interface para eliminar un EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Delete(EmpresaLivianoDataContracts oEmpresaLiviano);

        /// <summary>
		/// Interface para actualiza un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Update(EmpresaLivianoDataContracts oEmpresaLiviano);
		
        /// <summary>
		/// Inteface para Insertar un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		void Insert(EmpresaLivianoDataContracts oEmpresaLiviano);

        /// <summary>
		/// Interface para  rertornar objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>EmpresaLivianoDataContracts</value>
	    EmpresaLivianoDataContracts GetEmpresaLiviano(int id);
		
		/// <summary>
		/// Interface para  rertornar una lista de objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>ListList<![CDATA[<EmpresaLivianoDataContracts>]]></value>
		List<EmpresaLivianoDataContracts> GetAllEmpresaLivianos();
	}
}
