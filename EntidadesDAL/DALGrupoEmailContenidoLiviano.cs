using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Entidades;
using Herramientas;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;

namespace EntidadesDAL
{
    public class DALGrupoEmailContenidoLiviano : AbstractMapper<GrupoEmailContenidoLiviano>
    {
                /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALGrupoEmailContenidoLiviano()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALGrupoEmailContenidoLiviano()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  GrupoEmailc
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public GrupoEmailContenidoLiviano Load(int idGrupoEmail, string codigoRelacion)
        {
            try
            {
                GrupoEmailContenidoLiviano oReturn = null;
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, codigoRelacion));
              
                
                List<GrupoEmailContenidoLiviano> grupoEmailContenido = AbstractFindAll(oParameters);
                if (grupoEmailContenido.Count > 0)
                {
                    oReturn = grupoEmailContenido[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        /// <returns></returns>
        public void Delete(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));

             
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        /// <returns></returns>
        public void Update(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoLiviano_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));
                oParameters.Add(new DBParametro("@cargo", DbType.String, oGrupoEmailContenido.Cargo));
                oParameters.Add(new DBParametro("@nombreempresa", DbType.String, oGrupoEmailContenido.NombreEmpresa));
                oParameters.Add(new DBParametro("@email", DbType.String, oGrupoEmailContenido.Email));
                oParameters.Add(new DBParametro("@nombrerelacion", DbType.String, oGrupoEmailContenido.NombreRelacion));
                oParameters.Add(new DBParametro("@campo1", DbType.String, oGrupoEmailContenido.Campo1));
                oParameters.Add(new DBParametro("@campo2", DbType.String, oGrupoEmailContenido.Campo2));
                oParameters.Add(new DBParametro("@campo3", DbType.String, oGrupoEmailContenido.Campo3));
                oParameters.Add(new DBParametro("@campo4", DbType.String, oGrupoEmailContenido.Campo4));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oGrupoEmailContenido.Observaciones));
                oParameters.Add(new DBParametro("@envioemail", DbType.Boolean, oGrupoEmailContenido.EnvioEmail));
                oParameters.Add(new DBParametro("@codigoemail", DbType.Int32, oGrupoEmailContenido.CodigoEmail));
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_GrupoEmail
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        /// <returns></returns>
        public void Insert(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));
                oParameters.Add(new DBParametro("@cargo", DbType.String, oGrupoEmailContenido.Cargo));
                oParameters.Add(new DBParametro("@nombreempresa", DbType.String, oGrupoEmailContenido.NombreEmpresa));
                oParameters.Add(new DBParametro("@email", DbType.String, oGrupoEmailContenido.Email));
                oParameters.Add(new DBParametro("@nombrerelacion", DbType.String, oGrupoEmailContenido.NombreRelacion));
                oParameters.Add(new DBParametro("@campo1", DbType.String, oGrupoEmailContenido.Campo1));
                oParameters.Add(new DBParametro("@campo2", DbType.String, oGrupoEmailContenido.Campo2));
                oParameters.Add(new DBParametro("@campo3", DbType.String, oGrupoEmailContenido.Campo3));
                oParameters.Add(new DBParametro("@campo4", DbType.String, oGrupoEmailContenido.Campo4));
                oParameters.Add(new DBParametro("@observaciones", DbType.String, oGrupoEmailContenido.Observaciones));
                oParameters.Add(new DBParametro("@envioemail", DbType.Boolean, oGrupoEmailContenido.EnvioEmail));
                oParameters.Add(new DBParametro("@codigoemail", DbType.Int32, oGrupoEmailContenido.CodigoEmail));
                ExecuteNonQuery(oParameters);
            }
           catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
             
   
        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_SelectALL_ByIdGrupoEmail";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));

                List<GrupoEmailContenidoLiviano> gruposEmailContenido = AbstractFindAll(oParameters);

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_SelectALL_ByIdGrupoEmail", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
               
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoLiviano_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32,  idGrupoEmail));

                List<GrupoEmailContenidoLiviano> gruposEmailContenido = AbstractFindAll(oParameters);               

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenidoLiviano, PA_MG_FRONT_GrupoEmail_ContenidoLivianoByIdGrupoEmail", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoLivianoByEmail(int idGrupoEmail,string idCodigoRelacion)
        {
            try
            {

                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoLivianoByEmail_Select";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, idCodigoRelacion));

                List<GrupoEmailContenidoLiviano> gruposEmailContenido = AbstractFindAll(oParameters);

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenidoLiviano, PA_MG_FRONT_GrupoEmail_ContenidoLivianoByIdGrupoEmail", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public void Combinar(int id_GrupoEmailNuevo, int id_GrupoEmailViejo, string id_CodigoRelacion)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoLiviano_COMBINAR";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_GrupoEmailNuevo", DbType.Int32, id_GrupoEmailNuevo));
                oParameters.Add(new DBParametro("@id_GrupoEmailViejo", DbType.Int32, id_GrupoEmailViejo));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, id_CodigoRelacion));             
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenidoLiviano, Combinar", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
             

      
        /// <summary>
        /// M?todo que crea un objeto GrupoEmailContenido de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        /// <returns></returns>
        public override GrupoEmailContenidoLiviano DoLoad(IDataReader registros)
        {
            try
            {
                GrupoEmailContenidoLiviano grupoEmailContenido = new GrupoEmailContenidoLiviano();
                grupoEmailContenido.IdGrupoEmail = registros.GetInt32(0);
                grupoEmailContenido.CodigoRelacion = registros.GetString(1);                
                grupoEmailContenido.Cargo= registros.GetString(2);      
		        grupoEmailContenido.NombreEmpresa  = registros.GetString(3);   
		        grupoEmailContenido.NombreRelacion= registros.GetString(4);
                grupoEmailContenido.Email = registros.GetString(5);  
                grupoEmailContenido.Campo1= registros.GetString(6);
                grupoEmailContenido.Campo2 = registros.GetString(7);
                grupoEmailContenido.Campo3 = registros.GetString(8);
                grupoEmailContenido.Campo4 = registros.GetString(9);
                grupoEmailContenido.Observaciones = registros.GetString(10);
                grupoEmailContenido.EnvioEmail = registros.GetBoolean(11);
                grupoEmailContenido.CodigoEmail = registros.GetInt32(12);


                return grupoEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, DoLoad", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override GrupoEmailContenidoLiviano DoLoad(IDataReader registros, GrupoEmailContenidoLiviano ent)
        {
            throw new NotImplementedException();
        }
    }   

 }

