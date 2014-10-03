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
	/// Accion		: Implementacion de la Interface de la Entidad Cargo
	/// Objeto		: DB_LISDERO.dbo.tbl_calificacion
	/// Descripcion	: 
	/// </summary>
	public class CargoService: ICargoService
	{
		#region ICargoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto CargoDataContracts
		/// </summary>
		/// <value>CargoDataContracts</value>
		public CargoDataContracts Load(int id)
		 {
			 try
            {
			    CargoAdmin calificacionAdmin = new CargoAdmin();
                return (CargoDataContracts)calificacionAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un CargoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(CargoDataContracts oCargo)
		{
            try
            {
                CargoAdmin calificacionAdmin = new CargoAdmin();
                	calificacionAdmin.Delete((Cargo)oCargo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto CargoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(CargoDataContracts oCargo)
		{
            try
            {
                CargoAdmin calificacionAdmin = new CargoAdmin();
                	calificacionAdmin.Update((Cargo)oCargo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto CargoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(CargoDataContracts oCargo)
		{
			try
            {
                CargoAdmin calificacionAdmin = new CargoAdmin();
                	calificacionAdmin.Insert((Cargo) oCargo);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto CargoDataContracts
		/// </summary>
		/// <value>void</value>
		public CargoDataContracts GetCargo(int id)
		 {
			 try
            {
			    CargoAdmin calificacionAdmin = new CargoAdmin();
                return (CargoDataContracts)calificacionAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCargo : CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos CargoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<CargoDataContracts> GetAllCargos()
		 {
			 try
            {
                CargoAdmin calificacionAdmin = new CargoAdmin();
                 List<Cargo> resultList = calificacionAdmin.GetAllCargos();

                return resultList.ConvertAll<CargoDataContracts>(
                    delegate(Cargo tempCargo) { return (CargoDataContracts)tempCargo; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCargos : CargoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}