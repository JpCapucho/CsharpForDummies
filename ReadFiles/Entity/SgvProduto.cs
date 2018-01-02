using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.Entity
{
    /// <summary>
    /// Representa o arquivo sgv_produtos
    /// </summary>
    public class AxFiscalDOcumentLine
    {
        public long? produto_id { get; set; }

        public long? operadora_id { get; set; }

        public decimal? valor_face { get; set; }

        public string nome_produto { get; set; }

        public long? negociavel { get; set; }

        public decimal? valor_minimo { get; set; }

        public decimal? valor_maximo { get; set; }

        public long dci_id { get; set; }

        public DateTime dci_data_importacao { get; set; }

        public string dci_machine { get; set; }
    }
}
