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
	/// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Empresa
	/// </summary>
    public class DALEmpresa : AbstractMapper<Empresa>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALEmpresa()
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
		~DALEmpresa()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Empresa
		/// </summary>
		/// <param name="id"></param>                   
		/// <returns></returns>
		public Empresa Load(int id)
		{
            try
            {
				Empresa oReturn = null;
				CommandText = "PA_MG_FRONT_Empresa_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Empresa> empresas = AbstractFindAll(oParameters);
				if (empresas.Count > 0)
				{
					oReturn = empresas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Empresa
		/// </summary>
		/// <param name="oEmpresa"></param>
		/// <returns></returns>
		public void Delete(Empresa oEmpresa)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Empresa_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));																			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Empresa
		/// </summary>
		/// <param name="oEmpresa"></param>
		/// <returns></returns>
		public void Update(Empresa oEmpresa)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Empresa_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oEmpresa.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oEmpresa.Nombre));
				oParameters.Add(new DBParametro("@contacto", DbType.String, oEmpresa.Contacto));
				oParameters.Add(new DBParametro("@idtipocalificacion", DbType.Int32, oEmpresa.IdTipoCalificacion));
				oParameters.Add(new DBParametro("@idsector", DbType.Int32, oEmpresa.IdSector));
				oParameters.Add(new DBParametro("@idsubsector", DbType.Int32, oEmpresa.IdSubSector));
				oParameters.Add(new DBParametro("@vinculo", DbType.String, oEmpresa.Vinculo));
				oParameters.Add(new DBParametro("@origencontacto", DbType.String, oEmpresa.OrigenContacto));
				oParameters.Add(new DBParametro("@idtratamiento", DbType.Int32, oEmpresa.IdTratamiento));
				oParameters.Add(new DBParametro("@cuit", DbType.String, oEmpresa.Cuit));
				oParameters.Add(new DBParametro("@idcargo", DbType.Int32, oEmpresa.IdCargo));
				oParameters.Add(new DBParametro("@idiibb", DbType.Int32, oEmpresa.IdIIBB));
				oParameters.Add(new DBParametro("@numeroinscripcion", DbType.String, oEmpresa.NumeroInscripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oEmpresa.Activo));
				oParameters.Add(new DBParametro("@idiva", DbType.Int32, oEmpresa.IdIVA));
				oParameters.Add(new DBParametro("@web", DbType.String, oEmpresa.Web));
				oParameters.Add(new DBParametro("@horario", DbType.String, oEmpresa.Horario));
				oParameters.Add(new DBParametro("@notas", DbType.String, oEmpresa.Notas));
				
				ExecuteNonQuery(oParameters);


                if (oEmpresa.Domicilios.Count > 0)
                {
                    DALDomicilio dalDomicilio = new DALDomicilio();
                    dalDomicilio.DeletePorCodigo(oEmpresa.Codigo);
                    foreach (var item in oEmpresa.Domicilios)
                    {
                        item.Codigo = oEmpresa.Codigo.ToString();
                        dalDomicilio.Insert(item);
                    }
                }

                if (oEmpresa.Telefonos.Count > 0)
                {
                    DALTelefono dalTelefono = new DALTelefono();
                    dalTelefono.DeletePorCodigo(oEmpresa.Codigo);
                    foreach (var item in oEmpresa.Telefonos)
                    {
                        item.Codigo = oEmpresa.Codigo;
                        dalTelefono.Insert(item);
                    }
                }
                if (oEmpresa.Emails.Count > 0)
                {
                    DALEmail dalEmail = new DALEmail();
                    dalEmail.DeletePorCodigo(oEmpresa.Codigo);
                    foreach (var item in oEmpresa.Emails)
                    {
                        item.IdRelacion = oEmpresa.Codigo;
                        dalEmail.Insert(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Empresa
		/// </summary>
		/// <param name="oEmpresa"></param>
		/// <returns></returns>
		public void Insert(Empresa oEmpresa)
		{
			 try
            {
                DALContacto dalContacto = new DALContacto();
                string codigo = dalContacto.GenerarCodigo().ToString();
                Contacto contacto = new Contacto();
                contacto.Codigo = int.Parse(codigo);
                contacto.IdTipoContacto = 2;
                dalContacto.Insert(contacto);

                CommandText = "PA_MG_FRONT_Empresa_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresa.Id));
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oEmpresa.Nombre));
				oParameters.Add(new DBParametro("@contacto", DbType.String, oEmpresa.Contacto));
				oParameters.Add(new DBParametro("@idtipocalificacion", DbType.Int32, oEmpresa.IdTipoCalificacion));
				oParameters.Add(new DBParametro("@idsector", DbType.Int32, oEmpresa.IdSector));
				oParameters.Add(new DBParametro("@idsubsector", DbType.Int32, oEmpresa.IdSubSector));
				oParameters.Add(new DBParametro("@vinculo", DbType.String, oEmpresa.Vinculo));
				oParameters.Add(new DBParametro("@origencontacto", DbType.String, oEmpresa.OrigenContacto));
				oParameters.Add(new DBParametro("@idtratamiento", DbType.Int32, oEmpresa.IdTratamiento));
				oParameters.Add(new DBParametro("@cuit", DbType.String, oEmpresa.Cuit));
				oParameters.Add(new DBParametro("@idcargo", DbType.Int32, oEmpresa.IdCargo));
				oParameters.Add(new DBParametro("@idiibb", DbType.Int32, oEmpresa.IdIIBB));
				oParameters.Add(new DBParametro("@numeroinscripcion", DbType.String, oEmpresa.NumeroInscripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oEmpresa.Activo));
				oParameters.Add(new DBParametro("@idiva", DbType.Int32, oEmpresa.IdIVA));
				oParameters.Add(new DBParametro("@web", DbType.String, oEmpresa.Web));
				oParameters.Add(new DBParametro("@horario", DbType.String, oEmpresa.Horario));
				oParameters.Add(new DBParametro("@notas", DbType.String, oEmpresa.Notas));
				
				object idEmpresa = ExecuteScalar(oParameters);
                contacto.IdContacto = int.Parse(idEmpresa.ToString());
                dalContacto.Update(contacto);

                if (oEmpresa.Domicilios.Count > 0)
                {
                    foreach (var item in oEmpresa.Domicilios)
                    {
                        DALDomicilio dalDomicilio = new DALDomicilio();
                        item.Codigo = codigo;
                        dalDomicilio.Insert(item);
                    }
                }

                if (oEmpresa.Telefonos.Count > 0)
                {
                    foreach (var item in oEmpresa.Telefonos)
                    {
                        DALTelefono dalTelefono = new DALTelefono();
                        item.Codigo = int.Parse(codigo);
                        dalTelefono.Insert(item);
                    }
                }
                if (oEmpresa.Emails.Count > 0)
                {
                    foreach (var item in oEmpresa.Emails)
                    {
                        DALEmail dalEmail = new DALEmail();
                        item.IdRelacion = int.Parse(codigo);
                        dalEmail.Insert(item);
                    }
                }
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Empresa de la tabla dbo.TBL_Empresa
		/// </summary>
		/// <param name="oEmpresa"></param>
		/// <returns></returns>
        /// 

        public Empresa GetEmpresaByCodigo(int codigo)
        {
            try
            {
                Empresa oReturn = null;
                CommandText = "PA_MG_FRONT_Empresa_SELECT_PorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));

                List<Empresa> empresas = AbstractFindAll(oParameters);
                if (empresas.Count > 0)
                {
                    oReturn = empresas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		public List<Empresa> GetAllEmpresas()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Empresa_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Empresa> empresas = AbstractFindAll(oParameters);
				
				return empresas;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, getEmpresas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Empresa de la tabla dbo.TBL_Empresa
		/// </summary>
		/// <param name="oEmpresa"></param>
		/// <returns></returns>
		public override Empresa DoLoad(IDataReader registros)
        {
            try
            {
				Empresa empresa = new Empresa();
				empresa.Id = registros.GetInt32(0);
				empresa.Codigo = registros.GetInt32(1);
				empresa.Nombre = registros.GetString(2);
                try
                {
                    empresa.Contacto = registros.GetString(3);
                }
                catch (Exception)
                {

                    empresa.Contacto = string.Empty;
                }

                try
                {
                    empresa.IdTipoCalificacion = registros.GetInt32(4);
                }
                catch (Exception)
                {

                    empresa.IdTipoCalificacion = 0;
                }

                try
                {
                    empresa.IdSector = registros.GetInt32(5);
                }
                catch (Exception)
                {

                    empresa.IdSector = 0;
                }

                try
                {
                    empresa.IdSubSector = registros.GetInt32(6);
                }
                catch (Exception)
                {

                    empresa.IdSubSector = 0;
                }

                try
                {
                    empresa.Vinculo = registros.GetString(7);
                }
                catch (Exception)
                {

                    empresa.Vinculo = string.Empty;
                }

                try
                {
                    empresa.OrigenContacto = registros.GetString(8);
                }
                catch (Exception)
                {

                    empresa.OrigenContacto = string.Empty;
                }

                try
                {
                    empresa.IdTratamiento = registros.GetInt32(9);
                }
                catch (Exception)
                {

                    empresa.IdTratamiento = 0;
                }
                try
                {
                    empresa.Cuit = registros.GetString(10);
                }
                catch (Exception)
                {

                    empresa.Cuit = string.Empty;
                }

                try
                {
                    empresa.IdCargo = registros.GetInt32(11);
                }
                catch (Exception)
                {

                    empresa.IdCargo = 0;
                }

                try
                {
                    empresa.IdIIBB = registros.GetInt32(12);
                }
                catch (Exception)
                {

                    empresa.IdIIBB = 0;
                }

                try
                {
                    empresa.NumeroInscripcion = registros.GetString(13);
                }
                catch (Exception)
                {

                    empresa.NumeroInscripcion = string.Empty;
                }

                try
                {
                    empresa.Activo = registros.GetBoolean(14);
                }
                catch (Exception)
                {

                    empresa.Activo = false;
                }
                try
                {
                    empresa.IdIVA = registros.GetInt32(15);
                }
                catch (Exception)
                {

                    empresa.IdIVA = 0;
                }

                try
                {
                    empresa.Web = registros.GetString(16);
                }
                catch (Exception)
                {

                    empresa.Web = string.Empty;
                }

                try
                {
                    empresa.Horario = registros.GetString(17);
                }
                catch (Exception)
                {

                    empresa.Horario = string.Empty;
                }
                try
                {
                    empresa.Notas = registros.GetString(18);
                }
                catch (Exception)
                {

                    empresa.Notas = string.Empty;
                }
				return empresa;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresa, getEmpresas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Empresa DoLoad(IDataReader registros, Empresa ent)
        {
            throw new NotImplementedException();
        }
    }
}
