using ReadFiles.DAO;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ReadFiles.Business
{
    /// <summary>
    /// Concentra as regras de negocio do tipo <see cref="SgvProdutos"/>
    /// </summary>
    public class SgvProdutosBusiness
    {
        public SgvProdutosBusiness()
        {

        }

        private readonly string arquivo_produto = @"sgv_produtos.csv";

        public List<Entity.SgvProduto> ConverterArquivo(string arquivo)
        {
            //verifica se o arquivo existe
            if (File.Exists(arquivo))
            {
                var lista = new List<Entity.SgvProduto>();

                using (var writer = new StreamReader(arquivo))
                {
                    String linha;
                    while ((linha = writer.ReadLine()) != null)
                    {
                        var result = Converter(linha);
                        lista.Add(result);
                    }
                }

                return lista;
            }
            //se nao existir o arquivo
            else
            {
                //lança exception   
                throw new FileNotFoundException($"O arquivo {arquivo} nao existe!");
            }
        }

        public Entity.SgvProduto Converter(string linha)
        {
            //verificar o digito delimitador
            var ler = linha.Contains(';');

            //expressão regular que le o arquivo
            var array = Regex.Split(linha, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", RegexOptions.Compiled);

            //se o delimitador for ;
            if (ler == true)
            {
                //cria o array delimitando por ;
                array = linha.Split(';');
            }
            else 
            {
                //cria o array delimitando pela expressão regular, ignorando qualquer caracter dentro de ""
                array = Regex.Split(linha, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", RegexOptions.Compiled);
            }


            var produto = new Entity.SgvProduto();

            produto.produto_id = long.Parse(array[0].ToString());
            produto.operadora_id = long.Parse(array[1].ToString());
            produto.valor_face = string.IsNullOrEmpty(array[2]) ? (decimal?)null : decimal.Parse(array[2].ToString(), NumberFormatInfo.InvariantInfo);
            produto.nome_produto = array[3].ToString().Replace("\"", "");
            produto.negociavel = long.Parse(array[4].ToString());
            produto.valor_minimo = string.IsNullOrEmpty(array[5]) ? (decimal?)null : decimal.Parse(array[5].ToString(), NumberFormatInfo.InvariantInfo);
            //produto.valorMaximo = string.IsNullOrEmpty(array[6]) ? (decimal?)null : decimal.Parse(array[6].ToString());

            produto.dci_data_importacao = DateTime.Now;

            if (!string.IsNullOrEmpty(array[6]))
            {
                produto.valor_maximo = decimal.Parse(array[6].ToString(), NumberFormatInfo.InvariantInfo);
            }

            return produto;
        }

        public bool validarProduto(string arquivo)
        {
            if (arquivo.Contains(arquivo_produto))
            {
                return true;
            }
            return false;
        }

        public SgvProduto obterPeloId(long id)
        {
            SgvProdutosDAO dao = new SgvProdutosDAO();
            return dao.ObterProduto(id);

        }

        public SgvProduto obterPeloId(SgvProduto obj)
        {
            return obterPeloId((long)obj.produto_id);
        }

        public bool deletarProdutoId(long id)
        {
            SgvProdutosDAO dao = new SgvProdutosDAO();
            return dao.DeletarProduto(id);
        }

        public SgvProduto atualizarProduto(SgvProduto id)
        {
            SgvProdutosDAO dao = new SgvProdutosDAO();

            return dao.AtualizarProduto(id);
        }

        public SgvProduto inserirProduto(SgvProduto id)
        {
            SgvProdutosDAO dao = new SgvProdutosDAO();
            return dao.InserirProduto(id);
        }

        public void inserirProduto(List<SgvProduto> list)
        {
            foreach (SgvProduto produto in list)
            {
                var retorno = atualizarProduto(produto);
            }
        }

        public void inserirOuAtualizar(List<SgvProduto> list)
        {
            foreach (var item in list)
            {
                var result = obterPeloId(item);
                if (result != null)
                {
                    atualizarProduto(item);
                }
                else
                {
                    inserirProduto(item);
                }
            }
        }
    }
}
