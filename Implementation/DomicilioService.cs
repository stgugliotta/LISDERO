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
	/// Accion		: Implementacion de la Interface de la Entidad Domicilio
	/// Objeto		: DB_LISDERO.dbo.tbl_domicilio
	/// Descripcion	: 
	/// </summary>
	public class DomicilioService: IDomicilioService
	{
		#region IDomicilioService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto DomicilioDataContracts
		/// </summary>
		/// <value>DomicilioDataContracts</value>
		public DomicilioDataContracts Load(int id)
		 {
			 try
            {
			    DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                return (DomicilioDataContracts)domicilioAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(DomicilioDataContracts oDomicilio)
		{
            try
            {
                DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                	domicilioAdmin.Delete((Domicilio)oDomicilio);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(DomicilioDataContracts oDomicilio)
		{
            try
            {
                DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                	domicilioAdmin.Update((Domicilio)oDomicilio);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(DomicilioDataContracts oDomicilio)
		{
			try
            {
                DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                	domicilioAdmin.Insert((Domicilio) oDomicilio);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		public DomicilioDataContracts GetDomicilio(int id)
		 {
			 try
            {
			    DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                return (DomicilioDataContracts)domicilioAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetDomicilio : DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos DomicilioDataContracts
		/// </summary>
		/// <value>void</value>
		public List<DomicilioDataContracts> GetAllDomicilios()
		 {
			 try
            {
                DomicilioAdmin domicilioAdmin = new DomicilioAdmin();
                 List<Domicilio> resultList = domicilioAdmin.GetAllDomicilios();

                return resultList.ConvertAll<DomicilioDataContracts>(
                    delegate(Domicilio tempDomicilio) { return (DomicilioDataContracts)tempDomicilio; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllDomicilios : DomicilioService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}