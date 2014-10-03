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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_EmpresaLiviano
	/// </summary>
    public class DALEmpresaLiviano : AbstractMapper<EmpresaLiviano>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALEmpresaLiviano()
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
		~DALEmpresaLiviano()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  EmpresaLiviano
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public EmpresaLiviano Load(int id)
		{
            try
            {
				EmpresaLiviano oReturn = null;
				CommandText = "PA_MG_FRONT_EmpresaLiviano_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<EmpresaLiviano> empresalivianos = AbstractFindAll(oParameters);
				if (empresalivianos.Count > 0)
				{
					oReturn = empresalivianos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_EmpresaLiviano
		/// </summary>
		/// <param name="oEmpresaLiviano"></param>
		/// <returns></returns>
		public void Delete(EmpresaLiviano oEmpresaLiviano)
		{
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaLiviano_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresaLiviano.Id));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_EmpresaLiviano
		/// </summary>
		/// <param name="oEmpresaLiviano"></param>
		/// <returns></returns>
		public void Update(EmpresaLiviano oEmpresaLiviano)
		{
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaLiviano_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresaLiviano.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oEmpresaLiviano.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oEmpresaLiviano.Nombre));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_EmpresaLiviano
		/// </summary>
		/// <param name="oEmpresaLiviano"></param>
		/// <returns></returns>
		public void Insert(EmpresaLiviano oEmpresaLiviano)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_EmpresaLiviano_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmpresaLiviano.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oEmpresaLiviano.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oEmpresaLiviano.Nombre));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// EmpresaLiviano de la tabla dbo.TBL_EmpresaLiviano
		/// </summary>
		/// <param name="oEmpresaLiviano"></param>
		/// <returns></returns>
		public List<EmpresaLiviano> GetAllEmpresaLivianos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_EmpresaLiviano_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<EmpresaLiviano> empresalivianos = AbstractFindAll(oParameters);
				
				return empresalivianos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, getEmpresaLivianos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto EmpresaLiviano de la tabla dbo.TBL_EmpresaLiviano
		/// </summary>
		/// <param name="oEmpresaLiviano"></param>
		/// <returns></returns>
		public override EmpresaLiviano DoLoad(IDataReader registros)
        {
            try
            {
				EmpresaLiviano empresaliviano = new EmpresaLiviano();
				empresaliviano.Id = registros.GetInt32(0);
				empresaliviano.Codigo = registros.GetInt32(1).ToString();
				empresaliviano.Nombre = registros.GetString(2);
			
				return empresaliviano;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaLiviano, getEmpresaLivianos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override EmpresaLiviano DoLoad(IDataReader registros, EmpresaLiviano ent)
        {
            throw new NotImplementedException();
        }
    }
}
