using Dapper;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.DAO
{
    internal class AxFiscalDocumentLineDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AX"].ToString();

        internal List<AxFiscalDocumentLine> DocumentLine(long numero_nf)
        {
            var query = (@"SELECT FL.ITEMID AS [ITEM LONGO]
		,FL.[DESCRIPTION] AS [DESCRICAO]
		,CONVERT(FLOAT,FL.QUANTITY, 2) AS [QUANTIDADE]
		,CONVERT(FLOAT,FL.LINEAMOUNT, 2) AS [VALOR]

  FROM [DynamicsAX_PRD].[dbo].[FISCALDOCUMENTLINE_BR] FL
  INNER JOIN [DynamicsAX_PRD].[dbo].[FISCALDOCUMENT_BR] FD ON (FL.FISCALDOCUMENT = FD.RECID)
    INNER JOIN [DynamicsAX_PRD].[dbo].[VENDINVOICEJOUR] V ON (FD.REFRECID = V.RECID)
  INNER JOIN [DynamicsAX_PRD].[dbo].[PURCHTABLE] P ON (V.PURCHID = P.PURCHID)
  INNER JOIN [DynamicsAX_PRD].[dbo].[INVENTLOCATION] I ON (P.INVENTLOCATIONID = I.INVENTLOCATIONID AND
  I.[INVENTLOCATIONID] IN ('ENANG_ESTR'
							,'ENCV_ESTR'
							,'VOUCH_DRJ'
							,'ENBEB_ESTR'
							,'ENBRA_ESTR'
							,'ENCAR_ESTR'
							,'ENFER_ESTR'
							,'ENLOR_ESTR'
							,'ENMOG_ESTR'
							,'ENSJC_ESTR'
							,'ENSRP_ESTR'
							,'VOUCH_LOG'
							,'ENARA_ESTR'
							,'ENFCA_ESTR'
							,'ENRAO_ESTR'
							,'ENSPO_ESTR'
							,'VOUCH_RDC'))

  WHERE FD.DIRECTION = 1 
  AND FD.FISCALDOCUMENTNUMBER @NF_Numero
  GROUP BY FL.ITEMID, FL.[DESCRIPTION], FL.QUANTITY, FL.LINEAMOUNT");



            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var Line = conn.Query<AxFiscalDocumentLine>(query, new { NF_Numero = numero_nf });
                    return Line.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
