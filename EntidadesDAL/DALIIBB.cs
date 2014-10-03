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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_IIBB
	/// </summary>
    public class DALIIBB : AbstractMapper<IIBB>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALIIBB()
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
		~DALIIBB()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  IIBB
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public IIBB Load(int id)
		{
            try
            {
				IIBB oReturn = null;
				CommandText = "PA_MG_FRONT_IIBB_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<IIBB> iibbs = AbstractFindAll(oParameters);
				if (iibbs.Count > 0)
				{
					oReturn = iibbs[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_IIBB
		/// </summary>
		/// <param name="oIIBB"></param>
		/// <returns></returns>
		public void Delete(IIBB oIIBB)
		{
            try
            {
                CommandText = "PA_MG_FRONT_IIBB_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIIBB.Id));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_IIBB
		/// </summary>
		/// <param name="oIIBB"></param>
		/// <returns></returns>
		public void Update(IIBB oIIBB)
		{
            try
            {
                CommandText = "PA_MG_FRONT_IIBB_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIIBB.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oIIBB.Descripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oIIBB.Activo));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_IIBB
		/// </summary>
		/// <param name="oIIBB"></param>
		/// <returns></returns>
		public void Insert(IIBB oIIBB)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_IIBB_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIIBB.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String , oIIBB.Descripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oIIBB.Activo));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// IIBB de la tabla dbo.TBL_IIBB
		/// </summary>
		/// <param name="oIIBB"></param>
		/// <returns></returns>
		public List<IIBB> GetAllIIBBs()
		{
            try
            {
				CommandText = "PA_MG_FRONT_IIBB_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<IIBB> iibbs = AbstractFindAll(oParameters);
				
				return iibbs;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, getIIBBs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto IIBB de la tabla dbo.TBL_IIBB
		/// </summary>
		/// <param name="oIIBB"></param>
		/// <returns></returns>
		public override IIBB DoLoad(IDataReader registros)
        {
            try
            {
				IIBB iibb = new IIBB();
				iibb.Id = registros.GetInt32(0);
				iibb.Descripcion = registros.GetString(1);
				iibb.Activo = registros.GetBoolean(2);
			
				return iibb;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIIBB, getIIBBs", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override IIBB DoLoad(IDataReader registros, IIBB ent)
        {
            throw new NotImplementedException();
        }
    }
}
