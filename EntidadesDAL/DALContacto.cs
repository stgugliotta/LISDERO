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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Contacto
	/// </summary>
    public class DALContacto : AbstractMapper<Contacto>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALContacto()
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
		
		/// <summary>
        /// M?todo que retorna solo un objeto  Contacto
		/// </summary>
		/// <param name="codigo"></param>   
		/// <returns></returns>
		public Contacto Load(int codigo)
		{
            try
            {
				Contacto oReturn = null;
				CommandText = "PA_MG_FRONT_Contacto_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
				
				List<Contacto> contactos = AbstractFindAll(oParameters);
				if (contactos.Count > 0)
				{
					oReturn = contactos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}

        public string GenerarCodigo()
        {
            try
            {
                Contacto oReturn = null;
                CommandText = "PA_MG_FRONT_Contacto_Select_GenerarCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                string codigo=ExecuteScalar(oParameters).ToString();

                return codigo;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Contacto
		/// </summary>
		/// <param name="oContacto"></param>
		/// <returns></returns>
		public void Delete(Contacto oContacto)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Contacto_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oContacto.Codigo));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Contacto
		/// </summary>
		/// <param name="oContacto"></param>
		/// <returns></returns>
		public void Update(Contacto oContacto)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Contacto_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oContacto.Codigo));
				oParameters.Add(new DBParametro("@idtipocontacto", DbType.Int32, oContacto.IdTipoContacto));
				oParameters.Add(new DBParametro("@idcontacto", DbType.Int32, oContacto.IdContacto));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Contacto
		/// </summary>
		/// <param name="oContacto"></param>
		/// <returns></returns>
		public void Insert(Contacto oContacto)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Contacto_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oContacto.Codigo));
				oParameters.Add(new DBParametro("@idtipocontacto", DbType.Int32, oContacto.IdTipoContacto));
				oParameters.Add(new DBParametro("@idcontacto", DbType.Int32, oContacto.IdContacto));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Contacto de la tabla dbo.TBL_Contacto
		/// </summary>
		/// <param name="oContacto"></param>
		/// <returns></returns>
		public List<Contacto> GetAllContactos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Contacto_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Contacto> contactos = AbstractFindAll(oParameters);
				
				return contactos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, getContactos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Contacto de la tabla dbo.TBL_Contacto
		/// </summary>
		/// <param name="oContacto"></param>
		/// <returns></returns>
		public override Contacto DoLoad(IDataReader registros)
        {
            try
            {
				Contacto contacto = new Contacto();
				contacto.Codigo = registros.GetInt32(0);
				contacto.IdTipoContacto = registros.GetInt32(1);
				contacto.IdContacto = registros.GetInt32(2);
			
				return contacto;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALContacto, getContactos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Contacto DoLoad(IDataReader registros, Contacto ent)
        {
            throw new NotImplementedException();
        }
    }
}
