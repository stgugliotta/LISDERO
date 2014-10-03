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
	/// Accion		: Implementacion de la Interface de la Entidad Telefono
	/// Objeto		: DB_LISDERO.dbo.tbl_telefono
	/// Descripcion	: 
	/// </summary>
	public class TelefonoService: ITelefonoService
	{
		#region ITelefonoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto TelefonoDataContracts
		/// </summary>
		/// <value>TelefonoDataContracts</value>
		public TelefonoDataContracts Load(int id)
		 {
			 try
            {
			    TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                return (TelefonoDataContracts)telefonoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(TelefonoDataContracts oTelefono)
		{
            try
            {
                TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                	telefonoAdmin.Delete((Telefono)oTelefono);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(TelefonoDataContracts oTelefono)
		{
            try
            {
                TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                	telefonoAdmin.Update((Telefono)oTelefono);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(TelefonoDataContracts oTelefono)
		{
			try
            {
                TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                	telefonoAdmin.Insert((Telefono) oTelefono);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		public TelefonoDataContracts GetTelefono(int id)
		 {
			 try
            {
			    TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                return (TelefonoDataContracts)telefonoAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetTelefono : TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos TelefonoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<TelefonoDataContracts> GetAllTelefonos()
		 {
			 try
            {
                TelefonoAdmin telefonoAdmin = new TelefonoAdmin();
                 List<Telefono> resultList = telefonoAdmin.GetAllTelefonos();

                return resultList.ConvertAll<TelefonoDataContracts>(
                    delegate(Telefono tempTelefono) { return (TelefonoDataContracts)tempTelefono; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllTelefonos : TelefonoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}