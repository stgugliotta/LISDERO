using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;


namespace Common.Interfaces
{
    /// <summary>
    /// Interface para manejar la entidad EmpresaPersonaDataContracts(EMACSA_NUCLEO.dbo.TBL_EmpresaPersona)
    /// </summary>
    public interface IEmpresaPersonaService
    {
        /// <summary>
        /// Interface para retornar un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>EmpresaPersonaDataContracts</value>
        EmpresaPersonaDataContracts Load(int idEmpresaPersona);

        /// <summary>
        /// interface para eliminar un EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(EmpresaPersonaDataContracts oEmpresaPersona);

        /// <summary>
        /// Interface para actualiza un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(EmpresaPersonaDataContracts oEmpresaPersona);

        /// <summary>
        /// Inteface para Insertar un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(EmpresaPersonaDataContracts oEmpresaPersona);

        /// <summary>
        /// Interface para  rertornar objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>EmpresaPersonaDataContracts</value>
        EmpresaPersonaDataContracts GetEmpresaPersona(int idEmpresaPersona);

        /// <summary>
        /// Interface para  rertornar una lista de objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>ListList<![CDATA[<EmpresaPersonaDataContracts>]]></value>
        List<EmpresaPersonaDataContracts> GetAllEmpresaPersonas();

        List<EmpresaPersonaDataContracts> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc);
        List<EmpresaPersonaDataContracts> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado);

        EmpresaPersonaDataContracts GetLastActionByIdFactura(int idFactura);

        List<EmpresaPersonaDataContracts> GetAllEmpresaPersonaPorCantidad(int cantidadDeRegistros, string cadena);
        List<EmpresaPersonaDataContracts> GetAllEmpresaPersonaRelaciones(string codigo);
    }
}
