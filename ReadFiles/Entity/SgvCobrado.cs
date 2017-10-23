using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.Entity
{
    public class SgvCobrado
    {
        public string numero_serie { get; set; }

        public long? cliente_id { get; set; }

        public string registro_venda { get; set; }

        public decimal comissao { get; set; }

        public string pin_number { get; set; }

        public long? cobranca_id { get; set; }

        public long? tipo_registro { get; set; }

        public long? tipo_recarga { get; set; }

        public long? produto_id { get; set; }

        public long? quantidade { get; set; }

        public long? dci_id { get; set; }

        public string dci_empresa { get; set; }

        public string dci_machine { get; set; }

        public DateTime dci_data_importacao { get; set; }
    }
}
