﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;
using System.Threading;
using System.Globalization;
using System.Data.OleDb;
using System.Data;

namespace Interfaces.Parsers
{
    abstract class FacturaOledbExcelParser : Parser
    {

        protected CultureInfo cultureEsAR = new CultureInfo("es-AR");
        protected int _linesNotReaded = 0;

        private string getColumnValue(Property propiedad, System.Data.DataTable excel, int rCnt)
        {

            string input = null;
            //input = (propiedad.col != null ? excel.Read(range, rCnt, Int32.Parse(propiedad.col)) : "");
            input = (propiedad.col != null ? excel.Rows[rCnt][Int32.Parse(propiedad.col) - 1].ToString() : "");
            return input;
        }

        public string getColumnValue(System.Data.DataTable excel, int rCnt, int cCnt)
        {

            string input = null;
            input = excel.Rows[rCnt][cCnt-1].ToString();
//            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        public abstract Boolean passesRow(System.Data.DataTable excel, int rCnt);

        public virtual Boolean shouldProcessRow(System.Data.DataTable excel, int rCnt)
        {
            return true;
        }

        public virtual Boolean shouldContinueReading()
        {
            return !(_linesNotReaded >= 2);
        }

        public override List<FacturaDTO> parse(string fileFullName, ClienteInterfaz cliente)
        {
            LineaFactura lineaFactura = cliente.lineaFactura;
            FacturaDTO facturaDTO = null;

            Property id_deudor = lineaFactura.findPropertyByName("id_deudor");
            Property id_tipo_comprobante = lineaFactura.findPropertyByName("id_tipo_comprobante");
            Property letra = lineaFactura.findPropertyByName("letra");
            Property emision = lineaFactura.findPropertyByName("emision");
            Property nro_comprobante = lineaFactura.findPropertyByName("nro_comprobante");
            Property importe = lineaFactura.findPropertyByName("importe");
            Property saldo = lineaFactura.findPropertyByName("saldo");
            Property importe_moneda_local = lineaFactura.findPropertyByName("importe_moneda_local");
            Property id_moneda = lineaFactura.findPropertyByName("id_moneda");
            Property fecha_emision = lineaFactura.findPropertyByName("fecha_emision");
            Property fecha_vencimiento = lineaFactura.findPropertyByName("fecha_vencimiento");
            Property observaciones = lineaFactura.findPropertyByName("observaciones");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            try
            {

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileFullName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\""); // este va OK

                con.Open();
                System.Data.DataTable metaDataTable = null;
                metaDataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = null;
                if (metaDataTable.Rows.Count >= 1 && metaDataTable.Rows[0].ItemArray.Length > 3 ) {
                    if (metaDataTable.Rows[0][3].ToString().Trim().Equals("TABLE") ) {
                        sheetName = metaDataTable.Rows[0][2].ToString().Trim().Replace("$", "").Replace("'", "");
                    }
                }


                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + cliente.sheetName + "$]", con);
                
                System.Data.DataTable dtExcel = new System.Data.DataTable();
                try
                {
                    da.Fill(dtExcel);
                }
                catch (Exception ex) {
                    da = new OleDbDataAdapter("select * from [" + sheetName + "$]", con);
                    da.Fill(dtExcel);
                }

                
                //System.Collections.IEnumerator enumRows = hoja.QueryTables.GetEnumerator();

                List<FacturaDTO> listaFacturasDTO = new List<FacturaDTO>();
                long row = 0;
                string input;
                int rCnt = 0;
                StringBuilder _inputParameters = new StringBuilder(); 

                for (rCnt = (getOffset()); rCnt <= dtExcel.Rows.Count; rCnt++)
                {
                    if (! shouldContinueReading()) {
                        break;
                    }

                    if (shouldProcessRow(dtExcel, rCnt))
                    {
                        facturaDTO = new FacturaDTO();
                        facturaDTO.idCliente = Int16.Parse(cliente.id);


                        // id_deudor
                        input = getColumnValue(id_deudor, dtExcel, rCnt);
                        if (id_deudor.from != null && id_deudor.defaultValue == null && input != null && !"".Equals(input))
                        {
                            if (input.Length >= (Int16.Parse(id_deudor.from) + Int16.Parse(id_deudor.len)))
                            {
                                facturaDTO.idDeudor = input.Substring(Int16.Parse(id_deudor.from), Int16.Parse(id_deudor.len));
                            }
                            else 
                            {
                                //facturaDTO.idDeudor = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna idDeudor,");
                            }

                        }
                        else if (id_deudor.defaultValue != null)
                        {

                            facturaDTO.idDeudor = id_deudor.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idDeudor = input;
                        }


                        // id_tipo_comprobante
                        input = getColumnValue(id_tipo_comprobante, dtExcel, rCnt);
                        if (id_tipo_comprobante.from != null && id_tipo_comprobante.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(id_tipo_comprobante.from) + Int16.Parse(id_tipo_comprobante.len)))
                            {
                                facturaDTO.idTipoComprobante = input.Substring(Int16.Parse(id_tipo_comprobante.from), Int16.Parse(id_tipo_comprobante.len));
                            }
                            else
                            {
                                facturaDTO.idTipoComprobante = input;
                            }

                        }
                        else if (id_tipo_comprobante.defaultValue != null)
                        {

                            facturaDTO.idTipoComprobante = id_tipo_comprobante.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idTipoComprobante = input;
                        }

                        // letra
                        input = getColumnValue(letra, dtExcel, rCnt);
                        if (letra.from != null && letra.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(letra.from) + Int16.Parse(letra.len)))
                            {
                                facturaDTO.letra = input.Substring(Int16.Parse(letra.from), Int16.Parse(letra.len));
                            }
                            else 
                            {
                                //facturaDTO.letra = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna letra.");
                            }
                           

                        }
                        else if (letra.defaultValue != null)
                        {

                            facturaDTO.letra = letra.defaultValue;

                        }
                        else
                        {
                            facturaDTO.letra = input;
                        }

                        // emision
                        input = getColumnValue(emision, dtExcel, rCnt);
                        if (emision.from != null && emision.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(emision.from) + Int16.Parse(emision.len)))
                            {
                                facturaDTO.emision = input.Substring(Int16.Parse(emision.from), Int16.Parse(emision.len));
                            }
                            else
                            {
                                //facturaDTO.emision = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna emisión");
                            }

                        }
                        else if (emision.defaultValue != null)
                        {

                            facturaDTO.emision = emision.defaultValue;

                        }
                        else
                        {
                            facturaDTO.emision = input;
                        }

                        // nro_comprobante
                        input = getColumnValue(nro_comprobante, dtExcel, rCnt);
                        if (nro_comprobante.from != null && nro_comprobante.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(nro_comprobante.from) + Int16.Parse(nro_comprobante.len)))
                            {
                                facturaDTO.nroComprobante = input.Substring(Int16.Parse(nro_comprobante.from), Int16.Parse(nro_comprobante.len));
                            }
                            else 
                            {
                                //facturaDTO.nroComprobante = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna nroComprobante");
                            }

                        }
                        else if (nro_comprobante.defaultValue != null)
                        {

                            facturaDTO.nroComprobante = nro_comprobante.defaultValue;

                        }
                        else
                        {
                            facturaDTO.nroComprobante = input;
                        }

                        // importe
                        input = getColumnValue(importe, dtExcel, rCnt);
                        if (importe.from != null && importe.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(importe.from) + Int16.Parse(importe.len)))
                            {
                                facturaDTO.importe = Double.Parse(input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Replace('.', ','), cultureEsAR);
                            }
                            else { 
                                try {
                                    facturaDTO.importe = Double.Parse(input.Replace('.', ','), cultureEsAR);
                                } catch (Exception ex) {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna importe.");
                                }
                            }

                        }
                        else if (importe.defaultValue != null)
                        {

                            facturaDTO.importe = double.Parse(importe.defaultValue, cultureEsAR);

                        }
                        else
                        {
                            facturaDTO.importe = double.Parse(input.Replace('.', ','), cultureEsAR);
                        }


                        // saldo
                        input = getColumnValue(saldo, dtExcel, rCnt);
                        if (saldo.from != null && saldo.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(saldo.from) + Int16.Parse(saldo.len)))
                            {
                                facturaDTO.saldo = Double.Parse(input.Substring(Int16.Parse(saldo.from), Int16.Parse(saldo.len)).Replace('.', ','), cultureEsAR);
                            }
                            else
                            {
                                try
                                {
                                    facturaDTO.saldo = Double.Parse(input.Replace('.', ','), cultureEsAR);
                                }
                                catch (Exception ex)
                                {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna saldo.");
                                }
                            }

                        }
                        else if (saldo.defaultValue != null)
                        {

                            facturaDTO.saldo = double.Parse(saldo.defaultValue, cultureEsAR);

                        }
                        else
                        {
                            facturaDTO.saldo = double.Parse(input.Replace('.', ','), cultureEsAR);
                        }


                        // importe moneda local
                        input = getColumnValue(importe_moneda_local, dtExcel, rCnt);
                        if (importe_moneda_local.from != null && importe_moneda_local.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(importe_moneda_local.from) + Int16.Parse(importe_moneda_local.len)))
                            {
                                facturaDTO.importeMonedaLocal = Double.Parse(input.Substring(Int16.Parse(importe_moneda_local.from), Int16.Parse(importe_moneda_local.len)).Replace('.', ','), cultureEsAR);
                            }
                            else
                            {
                                try
                                {
                                    facturaDTO.importeMonedaLocal = Double.Parse(input.Replace('.', ','), cultureEsAR);
                                }
                                catch (Exception ex)
                                {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna importe moneda local.");
                                }
                            }

                        }
                        else if (importe_moneda_local.defaultValue != null)
                        {

                            facturaDTO.importeMonedaLocal = double.Parse(importe_moneda_local.defaultValue, cultureEsAR);

                        }
                        else
                        {
                            facturaDTO.importeMonedaLocal = double.Parse(input.Replace('.', ','), cultureEsAR);
                        }


                        // id_moneda
                        input = getColumnValue(id_moneda, dtExcel, rCnt);
                        if (id_moneda.from != null && id_moneda.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(id_moneda.from) + Int16.Parse(id_moneda.len)))
                            {
                                facturaDTO.idMoneda = input.Substring(Int16.Parse(id_moneda.from), Int16.Parse(id_moneda.len));
                            } 
                            else
                            {
                                //facturaDTO.idMoneda = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna idMoneda");
                            }

                        }
                        else if (id_moneda.defaultValue != null)
                        {

                            facturaDTO.idMoneda = id_moneda.defaultValue;

                        }
                        else
                        {
                            facturaDTO.idMoneda = input;
                        }


                        // fecha_emision
                        input = getColumnValue(fecha_emision, dtExcel, rCnt);
                        if (fecha_emision.from != null && fecha_emision.defaultValue == null && input != null && !"".Equals(input))
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            if (input.Length >= (Int16.Parse(id_moneda.from) + Int16.Parse(id_moneda.len))) {
                                facturaDTO.fechaEmision = getDateTime(input.Substring(Int16.Parse(fecha_emision.from), Int16.Parse(fecha_emision.len)));
                            } 
                            else 
                            {
                                try {
                                    facturaDTO.fechaEmision = getDateTime(input);
                                } catch (Exception ex)
                                {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna fecha emisión.");
                                }
                            }

                        }
                        else if (fecha_emision.defaultValue != null)
                        {

                            facturaDTO.fechaEmision = System.DateTime.Parse(fecha_emision.defaultValue);

                        }
                        else
                        {
                            try
                            {
                                facturaDTO.fechaEmision = getDateTime(input);
                            }
                            catch (Exception ex)
                            {
                                if (input != null)
                                {
                                    try
                                    {
                                        DateTime dt = new DateTime(1900, 1, 1);
                                        dt = dt.AddDays(double.Parse(input, cultureEsAR) - 2);
                                        facturaDTO.fechaEmision = dt;
                                    }
                                    catch (Exception e)
                                    {
                                        _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna fech emisión.");
                                    }
                                }

                            }

                        }


                        // fecha_vencimiento
                        input = getColumnValue(fecha_vencimiento, dtExcel, rCnt);
                        if (fecha_vencimiento.from != null && fecha_vencimiento.defaultValue == null && input != null && !"".Equals(input))
                        {

                            //facturaDTO.fechaVencimiento = System.DateTime.Parse(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            if (input.Length >= (Int16.Parse(fecha_vencimiento.from) + Int16.Parse(fecha_vencimiento.len)))
                            {
                                facturaDTO.fechaVencimiento = getDateTime(input.Substring(Int16.Parse(fecha_vencimiento.from), Int16.Parse(fecha_vencimiento.len)));
                            } 
                            else 
                            {
                                try {
                                    facturaDTO.fechaVencimiento = getDateTime(input);
                                } catch (Exception ex)
                                {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna fecha vencimiento.");
                                }

                        }

                        }
                        else if (fecha_vencimiento.defaultValue != null)
                        {

                            facturaDTO.fechaVencimiento = System.DateTime.Parse(fecha_vencimiento.defaultValue);

                        }
                        else
                        {

                            try
                            {
                                facturaDTO.fechaVencimiento = getDateTime(input);
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    DateTime dt = new DateTime(1900, 1, 1);
                                    dt = dt.AddDays(double.Parse(input, cultureEsAR) - 2);
                                    facturaDTO.fechaVencimiento = dt;
                                }
                                catch (Exception e)
                                {
                                    _inputParameters.Append(" se ha generado el siguiente error: " + ex.Message + "al intentar recuperar la columna fecha vencimiento.");
                                }
                            }

                        }

                        // observaciones
                        input = getColumnValue(observaciones, dtExcel, rCnt);
                        if (observaciones.from != null && observaciones.defaultValue == null && input != null && !"".Equals(input))
                        {

                            if (input.Length >= (Int16.Parse(observaciones.from) + Int16.Parse(observaciones.len))) {
                                facturaDTO.observaciones = input.Substring(Int16.Parse(observaciones.from), Int16.Parse(observaciones.len));
                            } else {
                              //  facturaDTO.observaciones = input;
                                _inputParameters.Append(" El valor: " + input + " no es válido para la columna observaciones.");
                            }

                        }
                        else if (observaciones.defaultValue != null)
                        {

                            facturaDTO.observaciones = observaciones.defaultValue;

                        }
                        else
                        {
                            facturaDTO.observaciones = input;
                        }

                        applySpecificRules(facturaDTO);

                        if (passes(facturaDTO) && passesRow(dtExcel, rCnt))
                        {
                            listaFacturasDTO.Add(facturaDTO);
                        }
                    }

                }

                if (_inputParameters.Length > 0)
                    throw new Exception("En la lectura del archivo se han detectado los siguientes errores: Por favor verifiquelo nuevamente antes de volver a cargarlo: " + _inputParameters.ToString());

                return listaFacturasDTO;


            }
            catch (Exception e)
            {
                Console.Write(e);
                throw e;

            }

            return null;
        }
    }
}
