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
	/// Accion		: Implementacion de la Interface de la Entidad Empresa
	/// Objeto		: DB_LISDERO.dbo.tbl_empresa
	/// Descripcion	: 
	/// </summary>
	public class EmpresaService: IEmpresaService
	{
		#region IEmpresaService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto EmpresaDataContracts
		/// </summary>
		/// <value>EmpresaDataContracts</value>
		public EmpresaDataContracts Load(int id)
		 {
			 try
            {
			    EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                return (EmpresaDataContracts)empresaAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(EmpresaDataContracts oEmpresa)
		{
            try
            {
                EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                	empresaAdmin.Delete((Empresa)oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(EmpresaDataContracts oEmpresa)
		{
            try
            {
                EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                	empresaAdmin.Update((Empresa)oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(EmpresaDataContracts oEmpresa)
		{
			try
            {
                EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                	empresaAdmin.Insert((Empresa) oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

        public EmpresaDataContracts GetEmpresaByCodigo(int codigo)
        {
            try
            {
                EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                return (EmpresaDataContracts)empresaAdmin.GetEmpresaByCodigo(codigo);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetPersona : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		public EmpresaDataContracts GetEmpresa(int id)
		 {
			 try
            {
			    EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                return (EmpresaDataContracts)empresaAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEmpresa : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos EmpresaDataContracts
		/// </summary>
		/// <value>void</value>
		public List<EmpresaDataContracts> GetAllEmpresas()
		 {
			 try
            {
                EmpresaAdmin empresaAdmin = new EmpresaAdmin();
                 List<Empresa> resultList = empresaAdmin.GetAllEmpresas();

                return resultList.ConvertAll<EmpresaDataContracts>(
                    delegate(Empresa tempEmpresa) { return (EmpresaDataContracts)tempEmpresa; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresas : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}