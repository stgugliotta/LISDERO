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
	/// <summary>
	/// Creado		: 2013-05-16
	/// Accion		: Implementacion de la Interface de la Entidad Persona
	/// Objeto		: DB_LISDERO.dbo.tbl_persona
	/// Descripcion	: 
	/// </summary>
	public class PersonaService: IPersonaService
	{
		#region IPersonaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto PersonaDataContracts
		/// </summary>
		/// <value>PersonaDataContracts</value>
		public PersonaDataContracts Load(int id)
		 {
			 try
            {
			    PersonaAdmin personaAdmin = new PersonaAdmin();
                return (PersonaDataContracts)personaAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(PersonaDataContracts oPersona)
		{
            try
            {
                PersonaAdmin personaAdmin = new PersonaAdmin();
                	personaAdmin.Delete((Persona)oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(PersonaDataContracts oPersona)
		{
            try
            {
                PersonaAdmin personaAdmin = new PersonaAdmin();
                	personaAdmin.Update((Persona)oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(PersonaDataContracts oPersona)
		{
			try
            {
                PersonaAdmin personaAdmin = new PersonaAdmin();
                	personaAdmin.Insert((Persona) oPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		public PersonaDataContracts GetPersona(int id)
		 {
			 try
            {
			    PersonaAdmin personaAdmin = new PersonaAdmin();
                return (PersonaDataContracts)personaAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPersona : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos PersonaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<PersonaDataContracts> GetAllPersonas()
		 {
			 try
            {
                PersonaAdmin personaAdmin = new PersonaAdmin();
                 List<Persona> resultList = personaAdmin.GetAllPersonas();

                return resultList.ConvertAll<PersonaDataContracts>(
                    delegate(Persona tempPersona) { return (PersonaDataContracts)tempPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllPersonas : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion

        #region IPersonaService Members


        public PersonaDataContracts GetPersonaByCodigo(int codigo)
        {
            try
            {
                PersonaAdmin personaAdmin = new PersonaAdmin();
                return (PersonaDataContracts)personaAdmin.GetPersonaByCodigo(codigo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPersona : PersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}