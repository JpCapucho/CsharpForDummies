using ReadFiles.DAO;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.Business
{
    public class SgvNfeProdutoBusiness
    {
        public SgvNfeProduto obterNfePeloNumero(string numero_nf)
        {
            SgvNfeProdutoDAO dao = new SgvNfeProdutoDAO();
            return dao.ObterNfeProduto(numero_nf);
        }

        public SgvNfeProduto obterNfePeloNumero(SgvNfeProduto obj)
        {
            return obterNfePeloNumero((string)obj.numero_nf);
        }

        public bool validaNfeProduto(SgvNfeProduto num_nfe)
        {
            if (num_nfe == null)
            {
            return false;
            }
            else
            {
                return true;
            }
        }
    }
}
