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
	/// Accion		: Implementacion de la Interface de la Entidad IIBB
	/// Objeto		: DB_LISDERO.dbo.tbl_iibb
	/// Descripcion	: 
	/// </summary>
	public class IIBBService: IIIBBService
	{
		#region IIIBBService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto IIBBDataContracts
		/// </summary>
		/// <value>IIBBDataContracts</value>
		public IIBBDataContracts Load(int id)
		 {
			 try
            {
			    IIBBAdmin iibbAdmin = new IIBBAdmin();
                return (IIBBDataContracts)iibbAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(IIBBDataContracts oIIBB)
		{
            try
            {
                IIBBAdmin iibbAdmin = new IIBBAdmin();
                	iibbAdmin.Delete((IIBB)oIIBB);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(IIBBDataContracts oIIBB)
		{
            try
            {
                IIBBAdmin iibbAdmin = new IIBBAdmin();
                	iibbAdmin.Update((IIBB)oIIBB);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(IIBBDataContracts oIIBB)
		{
			try
            {
                IIBBAdmin iibbAdmin = new IIBBAdmin();
                	iibbAdmin.Insert((IIBB) oIIBB);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		public IIBBDataContracts GetIIBB(int id)
		 {
			 try
            {
			    IIBBAdmin iibbAdmin = new IIBBAdmin();
                return (IIBBDataContracts)iibbAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetIIBB : IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos IIBBDataContracts
		/// </summary>
		/// <value>void</value>
		public List<IIBBDataContracts> GetAllIIBBs()
		 {
			 try
            {
                IIBBAdmin iibbAdmin = new IIBBAdmin();
                 List<IIBB> resultList = iibbAdmin.GetAllIIBBs();

                return resultList.ConvertAll<IIBBDataContracts>(
                    delegate(IIBB tempIIBB) { return (IIBBDataContracts)tempIIBB; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllIIBBs : IIBBService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}