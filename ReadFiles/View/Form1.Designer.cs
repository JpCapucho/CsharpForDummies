namespace ReadFiles
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btbLocalicarArquivo = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btbLerProduto = new System.Windows.Forms.Button();
            this.btbObterPorId = new System.Windows.Forms.Button();
            this.btbDeletar = new System.Windows.Forms.Button();
            this.btbAtualizar = new System.Windows.Forms.Button();
            this.btbInserir = new System.Windows.Forms.Button();
            this.btbLerOperadora = new System.Windows.Forms.Button();
            this.btCobrado = new System.Windows.Forms.Button();
            this.btGerarNfe = new System.Windows.Forms.Button();
            this.txtNfProduto = new System.Windows.Forms.TextBox();
            this.btVerificarNfeProduto = new System.Windows.Forms.Button();
            this.lblNfeProduto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btbLocalicarArquivo
            // 
            this.btbLocalicarArquivo.Location = new System.Drawing.Point(473, 12);
            this.btbLocalicarArquivo.Name = "btbLocalicarArquivo";
            this.btbLocalicarArquivo.Size = new System.Drawing.Size(105, 23);
            this.btbLocalicarArquivo.TabIndex = 0;
            this.btbLocalicarArquivo.Text = "Selecionar Arquivo";
            this.btbLocalicarArquivo.UseVisualStyleBackColor = true;
            this.btbLocalicarArquivo.Click += new System.EventHandler(this.btbLerArquivo_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(31, 12);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(436, 20);
            this.txtMsg.TabIndex = 1;
            this.txtMsg.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btbLerProduto
            // 
            this.btbLerProduto.Enabled = false;
            this.btbLerProduto.Location = new System.Drawing.Point(502, 319);
            this.btbLerProduto.Name = "btbLerProduto";
            this.btbLerProduto.Size = new System.Drawing.Size(75, 23);
            this.btbLerProduto.TabIndex = 3;
            this.btbLerProduto.Text = "Produto";
            this.btbLerProduto.UseVisualStyleBackColor = true;
            this.btbLerProduto.Click += new System.EventHandler(this.btbLerProduto_Click);
            // 
            // btbObterPorId
            // 
            this.btbObterPorId.Location = new System.Drawing.Point(12, 319);
            this.btbObterPorId.Name = "btbObterPorId";
            this.btbObterPorId.Size = new System.Drawing.Size(75, 23);
            this.btbObterPorId.TabIndex = 4;
            this.btbObterPorId.Text = "Pesquisar";
            this.btbObterPorId.UseVisualStyleBackColor = true;
            this.btbObterPorId.Click += new System.EventHandler(this.btbBuscar_Click);
            // 
            // btbDeletar
            // 
            this.btbDeletar.Location = new System.Drawing.Point(256, 319);
            this.btbDeletar.Name = "btbDeletar";
            this.btbDeletar.Size = new System.Drawing.Size(75, 23);
            this.btbDeletar.TabIndex = 5;
            this.btbDeletar.Text = "Deletar";
            this.btbDeletar.UseVisualStyleBackColor = true;
            this.btbDeletar.Click += new System.EventHandler(this.btbDeletar_Click);
            // 
            // btbAtualizar
            // 
            this.btbAtualizar.Location = new System.Drawing.Point(175, 319);
            this.btbAtualizar.Name = "btbAtualizar";
            this.btbAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btbAtualizar.TabIndex = 6;
            this.btbAtualizar.Text = "Atualizar";
            this.btbAtualizar.UseVisualStyleBackColor = true;
            this.btbAtualizar.Click += new System.EventHandler(this.btbAtualizar_Click);
            // 
            // btbInserir
            // 
            this.btbInserir.Location = new System.Drawing.Point(94, 319);
            this.btbInserir.Name = "btbInserir";
            this.btbInserir.Size = new System.Drawing.Size(75, 23);
            this.btbInserir.TabIndex = 7;
            this.btbInserir.Text = "Inserir";
            this.btbInserir.UseVisualStyleBackColor = true;
            this.btbInserir.Click += new System.EventHandler(this.btbInserir_Click);
            // 
            // btbLerOperadora
            // 
            this.btbLerOperadora.Enabled = false;
            this.btbLerOperadora.Location = new System.Drawing.Point(502, 290);
            this.btbLerOperadora.Name = "btbLerOperadora";
            this.btbLerOperadora.Size = new System.Drawing.Size(75, 23);
            this.btbLerOperadora.TabIndex = 8;
            this.btbLerOperadora.Text = "Operadora";
            this.btbLerOperadora.UseVisualStyleBackColor = true;
            this.btbLerOperadora.Click += new System.EventHandler(this.btbLerOperadora_Click);
            // 
            // btCobrado
            // 
            this.btCobrado.Enabled = false;
            this.btCobrado.Location = new System.Drawing.Point(502, 261);
            this.btCobrado.Name = "btCobrado";
            this.btCobrado.Size = new System.Drawing.Size(75, 23);
            this.btCobrado.TabIndex = 9;
            this.btCobrado.Text = "Cobrado";
            this.btCobrado.UseVisualStyleBackColor = true;
            this.btCobrado.Click += new System.EventHandler(this.btCobrado_Click);
            // 
            // btGerarNfe
            // 
            this.btGerarNfe.Enabled = false;
            this.btGerarNfe.Location = new System.Drawing.Point(31, 134);
            this.btGerarNfe.Name = "btGerarNfe";
            this.btGerarNfe.Size = new System.Drawing.Size(75, 23);
            this.btGerarNfe.TabIndex = 10;
            this.btGerarNfe.Text = "Gerar NFE";
            this.btGerarNfe.UseVisualStyleBackColor = true;
            this.btGerarNfe.Click += new System.EventHandler(this.btGerarNfe_Click);
            // 
            // txtNfProduto
            // 
            this.txtNfProduto.Location = new System.Drawing.Point(31, 108);
            this.txtNfProduto.Name = "txtNfProduto";
            this.txtNfProduto.Size = new System.Drawing.Size(114, 20);
            this.txtNfProduto.TabIndex = 11;
            // 
            // btVerificarNfeProduto
            // 
            this.btVerificarNfeProduto.Location = new System.Drawing.Point(151, 108);
            this.btVerificarNfeProduto.Name = "btVerificarNfeProduto";
            this.btVerificarNfeProduto.Size = new System.Drawing.Size(75, 20);
            this.btVerificarNfeProduto.TabIndex = 12;
            this.btVerificarNfeProduto.Text = "Verifica NFE";
            this.btVerificarNfeProduto.UseVisualStyleBackColor = true;
            this.btVerificarNfeProduto.Click += new System.EventHandler(this.btVerificarNfeProduto_Click);
            // 
            // lblNfeProduto
            // 
            this.lblNfeProduto.AutoSize = true;
            this.lblNfeProduto.Location = new System.Drawing.Point(31, 89);
            this.lblNfeProduto.Name = "lblNfeProduto";
            this.lblNfeProduto.Size = new System.Drawing.Size(114, 13);
            this.lblNfeProduto.TabIndex = 13;
            this.lblNfeProduto.Text = "Insira o número da Nfe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 354);
            this.Controls.Add(this.lblNfeProduto);
            this.Controls.Add(this.btVerificarNfeProduto);
            this.Controls.Add(this.txtNfProduto);
            this.Controls.Add(this.btGerarNfe);
            this.Controls.Add(this.btCobrado);
            this.Controls.Add(this.btbLerOperadora);
            this.Controls.Add(this.btbInserir);
            this.Controls.Add(this.btbAtualizar);
            this.Controls.Add(this.btbDeletar);
            this.Controls.Add(this.btbObterPorId);
            this.Controls.Add(this.btbLerProduto);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btbLocalicarArquivo);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Read Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btbLocalicarArquivo;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btbLerProduto;
        private System.Windows.Forms.Button btbObterPorId;
        private System.Windows.Forms.Button btbDeletar;
        private System.Windows.Forms.Button btbAtualizar;
        private System.Windows.Forms.Button btbInserir;
        private System.Windows.Forms.Button btbLerOperadora;
        private System.Windows.Forms.Button btCobrado;
        private System.Windows.Forms.Button btGerarNfe;
        private System.Windows.Forms.TextBox txtNfProduto;
        private System.Windows.Forms.Button btVerificarNfeProduto;
        private System.Windows.Forms.Label lblNfeProduto;
    }
}

