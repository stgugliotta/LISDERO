using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;
using Common.DataContracts;
using System.Data.OleDb;
using System.Data;



namespace Interfaces.Parsers
{
    class DeudorSinGestionExcelParser
    {
        private string getColumnValue(Property propiedad, System.Data.DataTable excel, int rCnt)
        {

            string input = null;
            //input = (propiedad.col != null ? excel.Read(range, rCnt, Int32.Parse(propiedad.col)) : "");
            input = (propiedad.col != null ? excel.Rows[rCnt][Int32.Parse(propiedad.col) - 1].ToString() : "");
            return input;
        }

        public string getColumnValue(int cCnt, System.Data.DataTable excel, int rCnt)
        {

            string input = null;
            input = excel.Rows[rCnt][cCnt - 1].ToString();
            //            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        public Dictionary<string, List<ItemHojaDSGDataContracts>> parse(string fileFullName)
        {

            Dictionary<string, List<ItemHojaDSGDataContracts>> mapResultado = new Dictionary<string, List<ItemHojaDSGDataContracts>>();

            ItemHojaDSGDataContracts deudorDTO = null;
            List<ItemHojaDSGDataContracts> listaDeudoresDTO = new List<ItemHojaDSGDataContracts>();
            List<ItemHojaDSGDataContracts> listaDeudoresErrorDTO = new List<ItemHojaDSGDataContracts>();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileFullName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\""); // este va OK

                con.Open();
                System.Data.DataTable metaDataTable = null;
                metaDataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = null;
                if (metaDataTable.Rows.Count >= 1 && metaDataTable.Rows[0].ItemArray.Length > 3)
                {
                    if (metaDataTable.Rows[0][3].ToString().Trim().Equals("TABLE"))
                    {
                        sheetName = metaDataTable.Rows[0][2].ToString().Trim().Replace("$", "").Replace("'", "");
                    }
                }


                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Deudores$]", con);

                System.Data.DataTable dtExcel = new System.Data.DataTable();
                try
                {
                    da.Fill(dtExcel);
                }
                catch (Exception ex)
                {
                    da = new OleDbDataAdapter("select * from [" + sheetName + "$]", con);
                    da.Fill(dtExcel);
                }


                //System.Collections.IEnumerator enumRows = hoja.QueryTables.GetEnumerator();


                long row = 0;
                string input;
                int rCnt = 0;
                
                for (rCnt = (0); rCnt < dtExcel.Rows.Count; rCnt++)
                {

                    try
                    {
                        deudorDTO = new ItemHojaDSGDataContracts();
                        int i = 1;

                        // idCliente
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.IdCliente = decimal.Parse(input);


                        // idDeudor
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.IdDeudor = input;

                        

                        // Razon Social
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.DeudorRazonSocial = input; 

                        // Domicilio
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.DeudorDomicilio = input;

                        // Localidad
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.DeudorLocalidad = input;

                        // Dia de pago
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.DeudorDia = input;

                        // Horario de pago
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.DeudorHorario = input;

                        // Observaciones
                        input = getColumnValue(i++, dtExcel, rCnt);
                        deudorDTO.Observaciones = input;

                        listaDeudoresDTO.Add(deudorDTO);
                    }
                    catch (Exception e)
                    {
                        deudorDTO.error = e.Message;
                        listaDeudoresErrorDTO.Add(deudorDTO);
                    }
                }


                mapResultado.Add("listaDeudoresDTO", listaDeudoresDTO);
                mapResultado.Add("listaDeudoresErrorDTO", listaDeudoresErrorDTO);

                return mapResultado;
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
