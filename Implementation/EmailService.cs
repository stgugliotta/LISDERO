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
	/// Creado		: 2013-05-17
	/// Accion		: Implementacion de la Interface de la Entidad Email
	/// Objeto		: DB_LISDERO.dbo.tbl_email
	/// Descripcion	: 
	/// </summary>
	public class EmailService: IEmailService
	{
		#region IEmailService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto EmailDataContracts
		/// </summary>
		/// <value>EmailDataContracts</value>
		public EmailDataContracts Load(int id)
		 {
			 try
            {
			    EmailAdmin emailAdmin = new EmailAdmin();
                return (EmailDataContracts)emailAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un EmailDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(EmailDataContracts oEmail)
		{
            try
            {
                EmailAdmin emailAdmin = new EmailAdmin();
                	emailAdmin.Delete((Email)oEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto EmailDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(EmailDataContracts oEmail)
		{
            try
            {
                EmailAdmin emailAdmin = new EmailAdmin();
                	emailAdmin.Update((Email)oEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto EmailDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(EmailDataContracts oEmail)
		{
			try
            {
                EmailAdmin emailAdmin = new EmailAdmin();
                	emailAdmin.Insert((Email) oEmail);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto EmailDataContracts
		/// </summary>
		/// <value>void</value>
		public EmailDataContracts GetEmail(int id)
		 {
			 try
            {
			    EmailAdmin emailAdmin = new EmailAdmin();
                return (EmailDataContracts)emailAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEmail : EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos EmailDataContracts
		/// </summary>
		/// <value>void</value>
		public List<EmailDataContracts> GetAllEmails()
		 {
			 try
            {
                EmailAdmin emailAdmin = new EmailAdmin();
                 List<Email> resultList = emailAdmin.GetAllEmails();

                return resultList.ConvertAll<EmailDataContracts>(
                    delegate(Email tempEmail) { return (EmailDataContracts)tempEmail; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmails : EmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}