using ReadFiles.DAO;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadFiles.Business
{
    class SgvCobradosBusiness
    {
        public SgvCobradosBusiness()
        {

        }

        private readonly string arquivo_cobrado = @"sgv_cobrados.csv";

        public List<SgvCobrado> ConverterArquivo(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                var lista = new List<SgvCobrado>();

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
            else
            {
                throw new FileNotFoundException($"O arquivo {arquivo} não existe!");
            }
        }

        public SgvCobrado Converter(string linha)
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

            var cobrado = new SgvCobrado();

            try
            {
                cobrado.numero_serie = array[0].ToString();
                cobrado.cliente_id = long.Parse(array[1].ToString());
                cobrado.registro_venda = array[2].ToString().Replace("\"", "");
                cobrado.comissao = decimal.Parse(array[3].ToString(), NumberFormatInfo.InvariantInfo);
                cobrado.pin_number = array[4].ToString();
                cobrado.cobranca_id = long.Parse(array[5].ToString());
                cobrado.tipo_registro = long.Parse(array[6].ToString());
                cobrado.tipo_recarga = long.Parse(array[7].ToString());
                cobrado.produto_id = long.Parse(array[8].ToString());
                cobrado.quantidade = long.Parse(array[9].ToString());
                cobrado.dci_machine = System.Environment.UserName;
                cobrado.dci_data_importacao = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cobrado;
        }

        public bool validarCobrado(string arquivo)
        {
            if (arquivo.Contains(arquivo_cobrado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SgvCobrado obterPeloNumeroSerie(string serie)
        {
            SgvCobradoDAO dao = new SgvCobradoDAO();
            return dao.ObterCobrado(serie);
        }

        public SgvCobrado obterPeloNumeroSerie(SgvCobrado obj)
        {
            return obterPeloNumeroSerie((string)obj.numero_serie);
        }

        public bool deletarCobradoPorNumeroSerie(string serie)
        {
            SgvCobradoDAO dao = new SgvCobradoDAO();
            return dao.DeletarCobrado(serie);
        }

        public SgvCobrado atualizarCobrado(SgvCobrado obj)
        {
            SgvCobradoDAO dao = new SgvCobradoDAO();
            return dao.AtualizarCobrado(obj);
        }

        public SgvCobrado inserirCobrado(SgvCobrado obj)
        {
            SgvCobradoDAO dao = new SgvCobradoDAO();
            return dao.InserirCobrado(obj);
        }

        public void inserirCobrado(List<SgvCobrado> list)
        {
            foreach (SgvCobrado cobrado in list)
            {
                var retorno = atualizarCobrado(cobrado);
            }
        }

        public void inserirOuAtualizar(List<SgvCobrado> list)
        {
            foreach (var item in list)
            {
                var result = obterPeloNumeroSerie(item);
                if (result != null)
                {
                    atualizarCobrado(item);
                }
                else
                {
                    inserirCobrado(item);
                }
            }
        }
    }
}
