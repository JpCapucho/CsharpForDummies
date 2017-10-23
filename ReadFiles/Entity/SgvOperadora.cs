using Dapper.SimpleSave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("sgv_operadora")]
    public class SgvOperadora
    {
        public long? operadora_id { get; set; }

        public string nome_operadora { get; set; }

        public long dci_id { get; set; }

        public string dci_empresa { get; set; }

        public DateTime dci_data_importacao { get; set; }

        public string dci_machine { get; set; }
    }
}
