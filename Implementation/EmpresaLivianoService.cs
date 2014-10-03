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
	/// Creado		: 2013-06-23
	/// Accion		: Implementacion de la Interface de la Entidad EmpresaLiviano
	/// Objeto		: DB_LISDERO.dbo.tbl_empresaliviano
	/// Descripcion	: 
	/// </summary>
	public class EmpresaLivianoService: IEmpresaLivianoService
	{
		#region IEmpresaLivianoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>EmpresaLivianoDataContracts</value>
		public EmpresaLivianoDataContracts Load(int id)
		 {
			 try
            {
			    EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                return (EmpresaLivianoDataContracts)empresalivianoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(EmpresaLivianoDataContracts oEmpresaLiviano)
		{
            try
            {
                EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                	empresalivianoAdmin.Delete((EmpresaLiviano)oEmpresaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(EmpresaLivianoDataContracts oEmpresaLiviano)
		{
            try
            {
                EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                	empresalivianoAdmin.Update((EmpresaLiviano)oEmpresaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(EmpresaLivianoDataContracts oEmpresaLiviano)
		{
			try
            {
                EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                	empresalivianoAdmin.Insert((EmpresaLiviano) oEmpresaLiviano);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public EmpresaLivianoDataContracts GetEmpresaLiviano(int id)
		 {
			 try
            {
			    EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                return (EmpresaLivianoDataContracts)empresalivianoAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEmpresaLiviano : EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos EmpresaLivianoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<EmpresaLivianoDataContracts> GetAllEmpresaLivianos()
		 {
			 try
            {
                EmpresaLivianoAdmin empresalivianoAdmin = new EmpresaLivianoAdmin();
                 List<EmpresaLiviano> resultList = empresalivianoAdmin.GetAllEmpresaLivianos();

                return resultList.ConvertAll<EmpresaLivianoDataContracts>(
                    delegate(EmpresaLiviano tempEmpresaLiviano) { return (EmpresaLivianoDataContracts)tempEmpresaLiviano; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaLivianos : EmpresaLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion

        #region IEmpresaLivianoService Members


        public List<EmpresaLivianoDataContracts> GetAllEmpresaLivianosPorCantidad(int cantidad)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}