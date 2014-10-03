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
	/// Creado		: 2013-05-15
	/// Accion		: Implementacion de la Interface de la Entidad Contacto
	/// Objeto		: DB_LISDERO.dbo.tbl_contacto
	/// Descripcion	: 
	/// </summary>
	public class ContactoService: IContactoService
	{
		#region IContactoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ContactoDataContracts
		/// </summary>
		/// <value>ContactoDataContracts</value>
		public ContactoDataContracts Load(int codigo)
		 {
			 try
            {
			    ContactoAdmin contactoAdmin = new ContactoAdmin();
                return (ContactoDataContracts)contactoAdmin.Load( codigo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ContactoDataContracts oContacto)
		{
            try
            {
                ContactoAdmin contactoAdmin = new ContactoAdmin();
                	contactoAdmin.Delete((Contacto)oContacto);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ContactoDataContracts oContacto)
		{
            try
            {
                ContactoAdmin contactoAdmin = new ContactoAdmin();
                	contactoAdmin.Update((Contacto)oContacto);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ContactoDataContracts oContacto)
		{
			try
            {
                ContactoAdmin contactoAdmin = new ContactoAdmin();
                	contactoAdmin.Insert((Contacto) oContacto);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		public ContactoDataContracts GetContacto(int codigo)
		 {
			 try
            {
			    ContactoAdmin contactoAdmin = new ContactoAdmin();
                return (ContactoDataContracts)contactoAdmin.Load( codigo);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetContacto : ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ContactoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ContactoDataContracts> GetAllContactos()
		 {
			 try
            {
                ContactoAdmin contactoAdmin = new ContactoAdmin();
                 List<Contacto> resultList = contactoAdmin.GetAllContactos();

                return resultList.ConvertAll<ContactoDataContracts>(
                    delegate(Contacto tempContacto) { return (ContactoDataContracts)tempContacto; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllContactos : ContactoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}