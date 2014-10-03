using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    public class PersonaHistoricoService:IPersonaHistoricoService
    {
        #region IPersonaHistoricoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto PersonaDataContracts
        /// </summary>
        /// <value>PersonaDataContracts</value>
        public PersonaHistoricoDataContracts Load(int id)
        {
            try
            {
                PersonaHistoricoAdmin personaAdmin = new PersonaHistoricoAdmin();
                return (PersonaHistoricoDataContracts)personaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: PersonaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(PersonaHistoricoDataContracts oPersona)
        {
            try
            {
                PersonaHistoricoAdmin personaAdmin = new PersonaHistoricoAdmin();
                personaAdmin.Delete((PersonaHistorico)oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : PersonaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(PersonaHistoricoDataContracts oPersona)
        {
            try
            {
                PersonaHistoricoAdmin personaAdmin = new PersonaHistoricoAdmin();
                personaAdmin.Update((PersonaHistorico)oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : PersonaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void Insert(PersonaHistoricoDataContracts oPersona)
        {
            try
            {
                PersonaHistoricoAdmin personaAdmin = new PersonaHistoricoAdmin();
                personaAdmin.Insert((PersonaHistorico)oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : PersonaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto PersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public PersonaHistoricoDataContracts GetPersona(int id)
        {
            try
            {
                PersonaHistoricoAdmin personaAdmin = new PersonaHistoricoAdmin();
                return (PersonaHistoricoDataContracts)personaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPersona : PersonaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion
    }
}
