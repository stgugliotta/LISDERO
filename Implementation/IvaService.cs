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
	/// Creado		: 2013-06-22
	/// Accion		: Implementacion de la Interface de la Entidad Iva
	/// Objeto		: DB_LISDERO.dbo.tbl_iva
	/// Descripcion	: 
	/// </summary>
	public class IvaService: IIvaService
	{
		#region IIvaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto IvaDataContracts
		/// </summary>
		/// <value>IvaDataContracts</value>
		public IvaDataContracts Load(int id)
		 {
			 try
            {
			    IvaAdmin ivaAdmin = new IvaAdmin();
                return (IvaDataContracts)ivaAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un IvaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(IvaDataContracts oIva)
		{
            try
            {
                IvaAdmin ivaAdmin = new IvaAdmin();
                	ivaAdmin.Delete((Iva)oIva);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto IvaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(IvaDataContracts oIva)
		{
            try
            {
                IvaAdmin ivaAdmin = new IvaAdmin();
                	ivaAdmin.Update((Iva)oIva);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto IvaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(IvaDataContracts oIva)
		{
			try
            {
                IvaAdmin ivaAdmin = new IvaAdmin();
                	ivaAdmin.Insert((Iva) oIva);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto IvaDataContracts
		/// </summary>
		/// <value>void</value>
		public IvaDataContracts GetIva(int id)
		 {
			 try
            {
			    IvaAdmin ivaAdmin = new IvaAdmin();
                return (IvaDataContracts)ivaAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetIva : IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos IvaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<IvaDataContracts> GetAllIvas()
		 {
			 try
            {
                IvaAdmin ivaAdmin = new IvaAdmin();
                 List<Iva> resultList = ivaAdmin.GetAllIvas();

                return resultList.ConvertAll<IvaDataContracts>(
                    delegate(Iva tempIva) { return (IvaDataContracts)tempIva; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllIvas : IvaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}