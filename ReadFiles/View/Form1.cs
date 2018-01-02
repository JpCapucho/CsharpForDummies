using ReadFiles.Business;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string arquivo { get; set; }

        private void btbLerArquivo_Click(object sender, EventArgs e)
        {
            resetarBotoes();

            //Abre caisa de dialago e seleciona o arquivo
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Cursor Files|*.csv";
            openFile.Title = "Selecione o arquivo!";
            

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtMsg.Text = openFile.FileName;
                arquivo = openFile.FileName;
            }

            //Se o arquivo é valido, habilita o botão ler

            var prod = new SgvProdutosBusiness();
            var produto = prod.validarProduto(arquivo);

            var oper = new SgvOperadoraBusiness();
            var operadora = oper.validarOperadora(arquivo);

            var _cobrado = new SgvCobradosBusiness();
            var cobrado = _cobrado.validarCobrado((string)arquivo);

            if (produto == true)
            {
                btbLerProduto.Enabled = true;
            }
            else if (operadora == true){
                btbLerOperadora.Enabled = true;
            }
            else if (cobrado == true)
            {
                btCobrado.Enabled = true;
            }

        }

        private void btbLerProduto_Click(object sender, EventArgs e)
        {
            //Ler o arquivo
            var buss = new Business.SgvProdutosBusiness();
            var result = buss.ConverterArquivo(arquivo);

            //Grava o conteudo do arquivo no Banco de Dados
            buss.inserirOuAtualizar(result);
            //1,45s
            MessageBox.Show("Processo finalizado!");  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btbBuscar_Click(object sender, EventArgs e)
        {
            SgvProdutosBusiness buscar = new SgvProdutosBusiness();
            var retorno = buscar.obterPeloId(123);

            SgvOperadoraBusiness search = new SgvOperadoraBusiness();
            var re = search.obterPeloId(121);
        }

        private void btbDeletar_Click(object sender, EventArgs e)
        {
            SgvProdutosBusiness deletar = new SgvProdutosBusiness();
            var produto = deletar.deletarProdutoId(123);

            if (!produto)
            {
                MessageBox.Show("Um erro ocorreu, contate o administrador para abter ajuda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SgvOperadoraBusiness delOperadora = new SgvOperadoraBusiness();
            var operadora = delOperadora.deletarOperadoraId(121);

            if (!operadora){
                MessageBox.Show("Um erro ocorreu, contate o administrador para obter ajuda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btbAtualizar_Click(object sender, EventArgs e)
        {
            SgvProdutosBusiness atualizar = new SgvProdutosBusiness();

            AxFiscalDOcumentLine prod = new AxFiscalDOcumentLine();
            prod.produto_id = 18439999;
            prod.operadora_id = 350;
            prod.valor_face = 20;
            prod.nome_produto = "Agora Vai manow";
            prod.negociavel = 1;
            prod.valor_minimo = 20;
            prod.valor_maximo = 200;
            var retorno = atualizar.atualizarProduto(prod);
        }

        private void btbInserir_Click(object sender, EventArgs e)
        {
            SgvProdutosBusiness inserir = new SgvProdutosBusiness();

            AxFiscalDOcumentLine prod = new AxFiscalDOcumentLine();
            prod.produto_id = 58975;
            prod.operadora_id = 350;
            prod.valor_face = 35;
            prod.nome_produto = "CHIP CHIP";
            prod.negociavel = 3;
            prod.valor_minimo = 3;
            prod.valor_maximo = 350;
            var retorno = inserir.inserirProduto(prod);          
        }

        private void btbLerOperadora_Click(object sender, EventArgs e)
        {
            //Ler o arquivo
            var buss = new SgvOperadoraBusiness();
            var result = buss.ConverterArquivo(arquivo);

            //Grava o conteudo do arquivo no Banco de Dados
            buss.inserirOuAtualizar(result);
            MessageBox.Show("Processo finalizado!");
        }

        private void comboSelecionarArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resetarBotoes()
        {
            btCobrado.Enabled = false;
            btbLerOperadora.Enabled = false;
            btbLerProduto.Enabled = false;
            btGerarNfe.Enabled = false;
        }

        private void btCobrado_Click(object sender, EventArgs e)
        {
            var buss = new SgvCobradosBusiness();
            var result = buss.ConverterArquivo((string)arquivo);

            buss.inserirOuAtualizar(result);
            MessageBox.Show("Processo finalizado!");
        }

        private void btGerarNfe_Click(object sender, EventArgs e)
        {

        }

        private void btVerificarNfeProduto_Click(object sender, EventArgs e)
        {
            var verificarNumeroNotaProduto = txtNfProduto.Text;
            MessageBox.Show("Numero da Nf: " + verificarNumeroNotaProduto);
            var nota_produto = new SgvNfeProdutoBusiness();
            var result = nota_produto.obterNfePeloNumero(verificarNumeroNotaProduto);
            MessageBox.Show("Processo Finalizado!");

            //SgvNfeProdutoBusiness nfe = new SgvNfeProdutoBusiness();
            //var num_nfe = nfe.validaNfeProduto(result);
            //if (num_nfe == true)
            //{
            //    btGerarNfe.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Nota Fiscal não encontrada!");
            //}
        }
    }
}