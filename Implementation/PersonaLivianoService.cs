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
	/// Creado		: 2013-05-29
	/// Accion		: Implementacion de la Interface de la Entidad PersonaLiviano
	/// Objeto		: DB_LISDERO.dbo.tbl_personaliviano
	/// Descripcion	: 
	/// </summary>
	public class PersonaLivianoService: IPersonaLivianoService
	{
		#region IPersonaLivianoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>PersonaLivianoDataContracts</value>
		public PersonaLivianoDataContracts Load(int id)
		 {
			 try
            {
			    PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                return (PersonaLivianoDataContracts)personalivianoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(PersonaLivianoDataContracts oPersonaLiviano)
		{
            try
            {
                PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                	personalivianoAdmin.Delete((PersonaLiviano)oPersonaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(PersonaLivianoDataContracts oPersonaLiviano)
		{
            try
            {
                PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                	personalivianoAdmin.Update((PersonaLiviano)oPersonaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(PersonaLivianoDataContracts oPersonaLiviano)
		{
			try
            {
                PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                	personalivianoAdmin.Insert((PersonaLiviano) oPersonaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public PersonaLivianoDataContracts GetPersonaLiviano(int id)
		 {
			 try
            {
			    PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                return (PersonaLivianoDataContracts)personalivianoAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPersonaLiviano : PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos PersonaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<PersonaLivianoDataContracts> GetAllPersonaLivianos()
		 {
			 try
            {
                PersonaLivianoAdmin personalivianoAdmin = new PersonaLivianoAdmin();
                 List<PersonaLiviano> resultList = personalivianoAdmin.GetAllPersonaLivianos();

                return resultList.ConvertAll<PersonaLivianoDataContracts>(
                    delegate(PersonaLiviano tempPersonaLiviano) { return (PersonaLivianoDataContracts)tempPersonaLiviano; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllPersonaLivianos : PersonaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}