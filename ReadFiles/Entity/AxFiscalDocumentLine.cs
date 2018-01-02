using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.Entity
{
    class AxFiscalDocumentLine
    {
        public string ItemLongo { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public List<SgvNfeProduto> SgvNfeProdutoList;
    }
}
