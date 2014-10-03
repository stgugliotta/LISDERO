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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_EmpresaPersona
    /// </summary>
    public class DALEmpresaPersona : AbstractMapper<EmpresaPersona>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALEmpresaPersona()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

       

        /// <summary>
        /// M?todo que retorna solo un objeto  EmpresaPersona
        /// </summary>
        /// <param name="idEmpresaPersona"></param>        
        /// <returns></returns>
        public EmpresaPersona Load(int idEmpresaPersona)
        {
            try
            {
                EmpresaPersona oReturn = null;
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, idEmpresaPersona));

                List<EmpresaPersona> accions = AbstractFindAll(oParameters);
                if (accions.Count > 0)
                {
                    oReturn = accions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public EmpresaPersona GetLastActionByIdFactura(int idFactura)
        {
            try
            {
                EmpresaPersona oReturn = null;
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT_byIdFactura";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idFactura", DbType.Int32, idFactura));

                List<EmpresaPersona> accions = AbstractFindAll(oParameters);
                if (accions.Count > 0)
                {
                    oReturn = accions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        public void Delete(EmpresaPersona oEmpresaPersona)
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_EmpresaPersona_DELETE";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();

            //    oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oEmpresaPersona.IdEmpresaPersona));

            //    ExecuteNonQuery(oParameters);
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, Delete", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        public void Update(EmpresaPersona oEmpresaPersona)
        {
        //    try
        //    {
        //        CommandText = "PA_MG_FRONT_EmpresaPersona_UPDATE";
        //        CommandType = CommandType.StoredProcedure;
        //        ArrayList oParameters = new ArrayList();

        //        oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oEmpresaPersona.IdEmpresaPersona));
        //        oParameters.Add(new DBParametro("@usuario", DbType.String, oEmpresaPersona.Usuario));
        //        oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oEmpresaPersona.FechaEmpresaPersona));
        //        oParameters.Add(new DBParametro("@idestado", DbType.Int32, oEmpresaPersona.IdEstado));
        //        oParameters.Add(new DBParametro("@observacion", DbType.String, oEmpresaPersona.Observacion));
        //        oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oEmpresaPersona.InformacionComplementaria));
        //        oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oEmpresaPersona.IdFactura));
        //        oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oEmpresaPersona.IdDeudor));
        //        oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oEmpresaPersona.IdCliente));
        //        oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oEmpresaPersona.FechaVencimiento));
        //        oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32 , oEmpresaPersona.IdDomicilioAlternativo));
        //        ExecuteNonQuery(oParameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, Update", ex.Message);

        //        throw new GobbiTechnicalException(
        //            string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
        //    }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        public void Insert(EmpresaPersona oEmpresaPersona)
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_EmpresaPersona_INSERT";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();

            //    oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oEmpresaPersona.IdEmpresaPersona));
            //    oParameters.Add(new DBParametro("@usuario", DbType.String, oEmpresaPersona.Usuario));
            //    oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oEmpresaPersona.FechaEmpresaPersona));
            //    oParameters.Add(new DBParametro("@idestado", DbType.Int32, oEmpresaPersona.IdEstado));
            //    oParameters.Add(new DBParametro("@observacion", DbType.String, oEmpresaPersona.Observacion));
            //    oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oEmpresaPersona.InformacionComplementaria));
            //    oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oEmpresaPersona.IdFactura));
            //    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oEmpresaPersona.IdDeudor));
            //    oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oEmpresaPersona.IdCliente));
            //    oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oEmpresaPersona.FechaVencimiento));
            //    oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oEmpresaPersona.ProximaGestion));
            //    if (oEmpresaPersona.IdDomicilioAlternativo == 0)
            //    {
            //        oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, null));
            //    }
            //    else
            //    {
            //        oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, oEmpresaPersona.IdDomicilioAlternativo));
            //    }

            //    ExecuteNonQuery(oParameters);
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, Insert", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}
        }

        public void InsertComplementario(EmpresaPersona oEmpresaPersona)
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_EmpresaPersona_Complementaria_INSERT";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();

            //    oParameters.Add(new DBParametro("@idaccion", DbType.Int32, oEmpresaPersona.IdEmpresaPersona));
            //    oParameters.Add(new DBParametro("@usuario", DbType.String, oEmpresaPersona.Usuario));
            //    oParameters.Add(new DBParametro("@fechaaccion", DbType.DateTime, oEmpresaPersona.FechaEmpresaPersona));
            //    oParameters.Add(new DBParametro("@idestado", DbType.Int32, oEmpresaPersona.IdEstado));
            //    oParameters.Add(new DBParametro("@observacion", DbType.String, oEmpresaPersona.Observacion));
            //    oParameters.Add(new DBParametro("@informacioncomplementaria", DbType.String, oEmpresaPersona.InformacionComplementaria));
            //    oParameters.Add(new DBParametro("@idfactura", DbType.Int32, oEmpresaPersona.IdFactura));
            //    oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, oEmpresaPersona.IdDeudor));
            //    oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, oEmpresaPersona.IdCliente));
            //    oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, oEmpresaPersona.FechaVencimiento));
            //    oParameters.Add(new DBParametro("@proxima_gestion", DbType.DateTime, oEmpresaPersona.ProximaGestion));
            //    oParameters.Add(new DBParametro("@saldoFactura", DbType.Decimal , oEmpresaPersona.Saldo));
            //    oParameters.Add(new DBParametro("@montoImputacion", DbType.Decimal, oEmpresaPersona.MontoImputacion));
            //   // oParameters.Add(new DBParametro("@idDomicilioAlternativo", DbType.Int32, oEmpresaPersona.IdDomicilioAlternativo));

            //    ExecuteNonQuery(oParameters);
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, InsertComplementario", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// EmpresaPersona de la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        /// 


        public List<EmpresaPersona> GetAllEmpresaPersonaRelaciones(string codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT_RelacionesPorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, int.Parse(codigo)));
                List<EmpresaPersona> empresaPersonas = AbstractFindAll(oParameters);

                return empresaPersonas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        } 

        public List<EmpresaPersona> GetAllEmpresaPersonaPorCantidad(int cantidadDeRegistros, string cadena)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT_ByCantidadDeRegistros";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@cantidad", DbType.Int32, cantidadDeRegistros));
                oParameters.Add(new DBParametro("@cadena", DbType.String, cadena));
                List<EmpresaPersona> empresaPersonas = AbstractFindAll(oParameters);

                return empresaPersonas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public List<EmpresaPersona> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT_ByIdFacturaIdClienteFechaVenc";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, idFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, fechaVenc));
                List<EmpresaPersona> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

       


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// EmpresaPersona de la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        public List<EmpresaPersona> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECT_ByIdFacturaIdClienteFechaVencIdEstado";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idfactura", DbType.Int32, idFactura));
                oParameters.Add(new DBParametro("@id_cliente", DbType.Int32, idCliente));
                oParameters.Add(new DBParametro("@fecha_venc", DbType.DateTime, fechaVenc));
                oParameters.Add(new DBParametro("@idestado", DbType.Int32, idEstado));
                List<EmpresaPersona> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<EmpresaPersona> GetAllEmpresaPersonas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_EmpresaPersona_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<EmpresaPersona> accions = AbstractFindAll(oParameters);

                return accions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto EmpresaPersona de la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        /// <returns></returns>
        public override EmpresaPersona DoLoad(IDataReader registros)
        {
            try
            {
                var accion = new EmpresaPersona {Nombre = registros.GetString(0), Tipo = registros.GetString(1)};
                try
                {
                    accion.Codigo = registros.GetInt32(2).ToString();
                }
                catch (Exception)
                {

                    accion.Codigo = string.Empty;
                }
                
                return accion;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaPersona, getEmpresaPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override EmpresaPersona DoLoad(IDataReader registros, EmpresaPersona ent)
        {
            throw new NotImplementedException();
        }
    }
}
