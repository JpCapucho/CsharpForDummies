﻿using System;
using System.Collections.Generic;

namespace ReadFiles.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class SgvNfeProduto
    {
        public SgvNfeProduto() { }

        public string filial { get; set; }

        public string numero_nf { get; set; }

        public string serie_nf { get; set; }

        public string tipo_nf { get; set; }

        public DateTime data_nf { get; set; }

        public string tipo_pedido { get; set; }

        public string numero_pedido { get; set; }

        public long numero_linha { get; set; }

        public string razao_social_fornecedor { get; set; }

        public string cnpj_fornecedor { get; set; }

        public long item_curto { get; set; }

        public long item_longo { get; set; }

        public long cod_item_sgv { get; set; }

        public string descricao { get; set; }

        public long quantidade { get; set; }

        public decimal valor { get; set; }

        public long empresa_id_sgv { get; set; }

        public long num_pedido_sgv { get; set; }

        public string tipo_pedido_sgv { get; set; }

        private List<AxFiscalDOcumentLine> linhaSgvProduto;

        public List<AxFiscalDOcumentLine> ListSgvProduto
        {
            get
            {
                if (linhaSgvProduto == null) linhaSgvProduto = new List<AxFiscalDOcumentLine>();
                return linhaSgvProduto;
            }
            set { linhaSgvProduto = value; }
        }
    }
}
