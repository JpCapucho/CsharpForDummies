using ReadFiles.DAO;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadFiles.Business
{
    public class SgvOperadoraBusiness
    {
        private readonly string arquivo_operadora = @"sgv_operadoras.csv";
        public List<Entity.SgvOperadora> ConverterArquivo(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                var lista = new List<Entity.SgvOperadora>();
                using (var leitor = new StreamReader(arquivo))
                {
                    String linha;
                    while ((linha = leitor.ReadLine()) != null)
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

        public Entity.SgvOperadora Converter(string linha)
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

            var operadora = new Entity.SgvOperadora();

            operadora.operadora_id = long.Parse(array[0].ToString());
            operadora.nome_operadora = array[1].ToString().Replace("\"", "");
            operadora.dci_data_importacao = DateTime.Now;

            return operadora;
        }
        public bool validarOperadora(string arquivo)
        {
            if (arquivo.Contains(arquivo_operadora))
            {
                return true;
            }
            return false;
        }
        public SgvOperadora obterPeloId(long id)
        {
            SgvOperadoraDAO dao = new SgvOperadoraDAO();
            return dao.ObterOperadora(id);
        }

        public SgvOperadora obterPeloId(SgvOperadora obj)
        {
            return obterPeloId((long)obj.operadora_id);
        }

        public bool deletarOperadoraId(long id)
        {
            SgvOperadoraDAO dao = new SgvOperadoraDAO();
            return dao.DeletarOperadora(id);
        }

        public SgvOperadora atualizarOperadora(SgvOperadora id)
        {
            SgvOperadoraDAO dao = new SgvOperadoraDAO();
            return dao.AtualizaOperadora(id);
        }

        public SgvOperadora inserirOperadora(SgvOperadora id)
        {
            SgvOperadoraDAO dao = new SgvOperadoraDAO();
            return dao.InserirOperadora(id);
        }

        public void inserirOperadora(List<SgvOperadora> list)
        {
            foreach (SgvOperadora operadora in list)
            {
                var retorno = atualizarOperadora(operadora);
            }
        }

        public void inserirOuAtualizar(List<SgvOperadora> list)
        {
            foreach (var item in list)
            {
                var result = obterPeloId(item);
                if (result != null)
                {
                    atualizarOperadora(item);
                }
                else
                {
                    inserirOperadora(item);
                }
            }
        }
    }
}
