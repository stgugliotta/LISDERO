using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;

namespace EntidadesDAL
{
    public class DALEmpresaHistorico :AbstractMapper<EmpresaHistorico>
    {
        		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALEmpresaHistorico()
        {
            DBConnection oDbConnection  = DBConnection.Instancia;
            Db = oDbConnection.Db;
			ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		~DALEmpresaHistorico()
        {
            ObjConnection.Dispose();
        }

		public EmpresaHistorico Load(int id)
		{
            try
            {
				EmpresaHistorico oReturn = null;
				CommandText = "PA_MG_FRONT_EmpresaHistorico_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<EmpresaHistorico> empresas = AbstractFindAll(oParameters);
				if (empresas.Count > 0)
				{
					oReturn = empresas[0];
			    }
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		public void Delete(EmpresaHistorico oEmpresa)
		{
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaHistorico_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));																			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
        public void Update(EmpresaHistorico oEmpresa)
		{
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaHistorico_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));
				oParameters.Add(new DBParametro("@fecha_codigo", DbType.DateTime, oEmpresa.Fecha_Codigo));
				oParameters.Add(new DBParametro("@fecha_nombre", DbType.DateTime, oEmpresa.Fecha_Nombre));
				oParameters.Add(new DBParametro("@fecha_contacto", DbType.DateTime, oEmpresa.Fecha_Contacto));
				oParameters.Add(new DBParametro("@fecha_idtipocalificacion", DbType.DateTime, oEmpresa.Fecha_TipoCalificacion));
				oParameters.Add(new DBParametro("@fecha_idsector", DbType.DateTime, oEmpresa.Fecha_Sector));
				oParameters.Add(new DBParametro("@fecha_idsubsector", DbType.DateTime, oEmpresa.Fecha_SubSector));
				oParameters.Add(new DBParametro("@fecha_vinculo", DbType.DateTime, oEmpresa.Fecha_Vinculo));
				oParameters.Add(new DBParametro("@fecha_origencontacto", DbType.DateTime, oEmpresa.Fecha_OrigenContacto));
				oParameters.Add(new DBParametro("@fecha_idtratamiento", DbType.DateTime, oEmpresa.Fecha_Tratamiento));
				oParameters.Add(new DBParametro("@fecha_cuit", DbType.DateTime, oEmpresa.Fecha_Cuit));
				oParameters.Add(new DBParametro("@fecha_idcargo", DbType.DateTime, oEmpresa.Fecha_Cargo));
				oParameters.Add(new DBParametro("@fecha_idiibb", DbType.DateTime, oEmpresa.Fecha_IIBB));
				oParameters.Add(new DBParametro("@fecha_numeroinscripcion", DbType.DateTime, oEmpresa.Fecha_NroInscripcion));
				oParameters.Add(new DBParametro("@fecha_activo", DbType.DateTime, oEmpresa.Fecha_Activo));
				oParameters.Add(new DBParametro("@fecha_idiva", DbType.DateTime, oEmpresa.Fecha_IVA));
				oParameters.Add(new DBParametro("@fecha_web", DbType.DateTime, oEmpresa.Fecha_Web));
				oParameters.Add(new DBParametro("@fecha_horario", DbType.DateTime, oEmpresa.Fecha_Horario));
				oParameters.Add(new DBParametro("@fecha_notas", DbType.DateTime, oEmpresa.Fecha_Notas));
                oParameters.Add(new DBParametro("@fecha_domicilio", DbType.DateTime, oEmpresa.Fecha_Domicilios));
                oParameters.Add(new DBParametro("@fecha_telefono", DbType.DateTime, oEmpresa.Fecha_Telefonos)); 
                oParameters.Add(new DBParametro("@fecha_emails", DbType.DateTime,oEmpresa.Fecha_Emails));
				ExecuteNonQuery(oParameters);
 
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		public void Insert(EmpresaHistorico oEmpresa)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_EmpresaHistorico_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));
                oParameters.Add(new DBParametro("@fecha_codigo", DbType.DateTime, oEmpresa.Fecha_Codigo));
				oParameters.Add(new DBParametro("@fecha_nombre", DbType.DateTime, oEmpresa.Fecha_Nombre));
				oParameters.Add(new DBParametro("@fecha_contacto", DbType.DateTime, oEmpresa.Fecha_Contacto));
                oParameters.Add(new DBParametro("@fecha_idtipocalificacion", DbType.DateTime, oEmpresa.Fecha_TipoCalificacion));
                oParameters.Add(new DBParametro("@fecha_idsector", DbType.DateTime, oEmpresa.Fecha_Sector));
                oParameters.Add(new DBParametro("@fecha_idsubsector", DbType.DateTime, oEmpresa.Fecha_SubSector));
                oParameters.Add(new DBParametro("@fecha_vinculo", DbType.DateTime, oEmpresa.Fecha_Vinculo));
                oParameters.Add(new DBParametro("@fecha_origencontacto", DbType.DateTime, oEmpresa.Fecha_OrigenContacto));
                oParameters.Add(new DBParametro("@fecha_idtratamiento", DbType.DateTime, oEmpresa.Fecha_Tratamiento));
                oParameters.Add(new DBParametro("@fecha_cuit", DbType.DateTime, oEmpresa.Fecha_Cuit));
                oParameters.Add(new DBParametro("@fecha_idcargo", DbType.DateTime, oEmpresa.Fecha_Cargo));
                oParameters.Add(new DBParametro("@fecha_idiibb", DbType.DateTime, oEmpresa.Fecha_IIBB));
                oParameters.Add(new DBParametro("@fecha_numeroinscripcion", DbType.DateTime, oEmpresa.Fecha_NroInscripcion));
                oParameters.Add(new DBParametro("@fecha_activo", DbType.DateTime, oEmpresa.Fecha_Activo));
                oParameters.Add(new DBParametro("@fecha_idiva", DbType.DateTime, oEmpresa.Fecha_IVA));
                oParameters.Add(new DBParametro("@fecha_web", DbType.DateTime, oEmpresa.Fecha_Web));
                oParameters.Add(new DBParametro("@fecha_horario", DbType.DateTime, oEmpresa.Fecha_Horario));
                oParameters.Add(new DBParametro("@fecha_notas", DbType.DateTime, oEmpresa.Fecha_Notas));
                oParameters.Add(new DBParametro("@fecha_domicilio", DbType.DateTime, oEmpresa.Fecha_Domicilios));
                oParameters.Add(new DBParametro("@fecha_emails", DbType.DateTime, oEmpresa.Fecha_Emails));
                oParameters.Add(new DBParametro("@fecha_telefono", DbType.DateTime, oEmpresa.Fecha_Telefonos));
				
				object idEmpresa = ExecuteScalar(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}

        	 
		public override EmpresaHistorico DoLoad(IDataReader registros)
        {
            try
            {
				EmpresaHistorico empresa = new EmpresaHistorico();
				empresa.Id = registros.GetInt32(0);
                empresa.Fecha_Codigo = registros.GetDateTime(1);
				empresa.Fecha_Nombre = registros.GetDateTime(2);
                empresa.Fecha_Contacto = registros.GetDateTime(3);
                empresa.Fecha_TipoCalificacion = registros.GetDateTime(4);
                empresa.Fecha_Sector = registros.GetDateTime(5);
                empresa.Fecha_SubSector = registros.GetDateTime(6);              
                empresa.Fecha_Vinculo = registros.GetDateTime(7);
                empresa.Fecha_OrigenContacto = registros.GetDateTime(8);
                empresa.Fecha_Tratamiento = registros.GetDateTime(9);
                empresa.Fecha_Cuit = registros.GetDateTime(10);
                empresa.Fecha_Cargo = registros.GetDateTime(11);
                empresa.Fecha_IIBB = registros.GetDateTime(12);
                empresa.Fecha_NroInscripcion = registros.GetDateTime(13);
                empresa.Fecha_Activo = registros.GetDateTime(14);
                empresa.Fecha_IVA = registros.GetDateTime(15);
                empresa.Fecha_Web = registros.GetDateTime(16);
                empresa.Fecha_Horario = registros.GetDateTime(17);
                empresa.Fecha_Notas = registros.GetDateTime(18);
                empresa.Fecha_Domicilios=registros.GetDateTime(19);              
                empresa.Fecha_Emails = registros.GetDateTime(20);
                empresa.Fecha_Telefonos = registros.GetDateTime(21);
                return empresa;
		    }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, getEmpresas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override EmpresaHistorico DoLoad(IDataReader registros, EmpresaHistorico ent)
        {
            throw new NotImplementedException();
        }    

    }
}
