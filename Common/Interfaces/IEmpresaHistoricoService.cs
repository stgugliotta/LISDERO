using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;

namespace Common.Interfaces
{
    public interface IEmpresaHistoricoService
    {
        /// <summary>
        /// Interface para retornar un objeto EmpresaDataContracts
        /// </summary>
        /// <value>EmpresaDataContracts</value>
        EmpresaHistoricoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(EmpresaHistoricoDataContracts oEmpresa);

        /// <summary>
        /// Interface para actualiza un objeto EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(EmpresaHistoricoDataContracts oEmpresa);
        

        void Insert(EmpresaHistoricoDataContracts oEmpresa);

        EmpresaHistoricoDataContracts GetEmpresa(int id);
       

    
    }
}
