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
    class SgvNfeProdutoDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AX"].ToString();
        internal SgvNfeProduto ObterNfeProduto(string numero_nf)
        {
            var query = (@"SELECT FD.FISCALDOCUMENTNUMBER AS numero_nf
        , FD.FISCALDOCUMENTSERIES AS serie_nf
         ,tipo_nf = CASE

        WHEN FD.SPECIE = 0 THEN 'NFF'

        WHEN FD.SPECIE = 1 THEN 'NF'

        WHEN FD.SPECIE = 3 THEN 'CF'

        END
		,CONVERT(CHAR, FD.FISCALDOCUMENTDATE, 103) AS data_nf
		,V.VENDGROUP AS tipo_pedido
        , V.PURCHID AS numero_pedido
         , CONVERT(FLOAT, FL.LINENUM, 2) AS numero_linha
		,FD.THIRDPARTYNAME AS razao_social_fornecedor
        , FD.THIRDPARTYCNPJCPF AS cnpj_fornecedor
         , FL.ITEMID AS item_longo
          , FL.[DESCRIPTION] AS descricao
		,CONVERT(FLOAT, FL.QUANTITY, 2) AS quantidade
		,CONVERT(FLOAT, FL.LINEAMOUNT, 2) AS valor

   FROM[DynamicsAX_PRD].[dbo].[FISCALDOCUMENT_BR]
        FD
INNER JOIN[DynamicsAX_PRD].[dbo].[FISCALDOCUMENTLINE_BR]
        FL ON(FL.FISCALDOCUMENT = FD.RECID)
  INNER JOIN[DynamicsAX_PRD].[dbo].[VENDINVOICEJOUR]
        V ON(FD.REFRECID = V.RECID)
  INNER JOIN[DynamicsAX_PRD].[dbo].[PURCHTABLE]
        P ON(V.PURCHID = P.PURCHID)
  INNER JOIN[DynamicsAX_PRD].[dbo].[INVENTLOCATION]
        I ON(P.INVENTLOCATIONID = I.INVENTLOCATIONID AND
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
  AND nf_numero = @Nf_Numero
  GROUP BY FD.FISCALDOCUMENTNUMBER, FD.FISCALDOCUMENTSERIES, FD.SPECIE, FD.FISCALDOCUMENTDATE, V.VENDGROUP, V.PURCHID
  , FL.LINENUM, FD.THIRDPARTYNAME, FD.THIRDPARTYCNPJCPF, FL.ITEMID, FL.[DESCRIPTION], FL.QUANTITY, FL.LINEAMOUNT");

            using (var conn = new SqlConnection(ConnectionString))
            {
                var nf = conn.Query<SgvNfeProduto>(query, new { @Nf_Numero = numero_nf }).FirstOrDefault();
                return nf;
            }
        }
    }
}
