using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;

namespace Common.Interfaces
{
    public interface IPersonaHistoricoService
    {
        /// <summary>
        /// Interface para retornar un objeto PersonaDataContracts
        /// </summary>
        /// <value>PersonaDataContracts</value>
        PersonaHistoricoDataContracts Load(int id);

        /// <summary>
        /// interface para eliminar un PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Delete(PersonaHistoricoDataContracts oPersona);

        /// <summary>
        /// Interface para actualiza un objeto PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Update(PersonaHistoricoDataContracts oPersona);

        /// <summary>
        /// Inteface para Insertar un objeto PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        void Insert(PersonaHistoricoDataContracts oPersona);

        /// <summary>
        /// Interface para  rertornar objeto PersonaDataContracts
        /// </summary>
        /// <value>PersonaDataContracts</value>
        PersonaHistoricoDataContracts GetPersona(int id);
       
    }
}
