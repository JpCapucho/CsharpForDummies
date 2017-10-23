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
        public SgvNfeProduto obterNfePeloNumero(string nfe_numero)
        {
            SgvNfeProdutoDAO dao = new SgvNfeProdutoDAO();
            return dao.ObterNfeProduto(nfe_numero);
        }
    }
}
