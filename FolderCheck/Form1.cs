using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btVerificar_Click(object sender, EventArgs e)
        {
            resetarControles();
            var ftp = new FtpFolderUtil();

            var nome = comboBox1.SelectedItem;

            if (nome != null)
            {
                ftp = new FtpFolderUtil(nome.ToString());
            }

            if (ftp.cabtel(dtPicker.Value)) lbl21cabtelOK.Visible = true;
            else lbl21cabitelNOK.Visible = true;

            if (ftp.drj108(dtPicker.Value)) lbl108drjOK.Visible = true;
            else lbl108drjNOK.Visible = true;

            if (ftp.rdc171(dtPicker.Value)) lbl171rdcOK.Visible = true;
            else lbl171rdcNOK.Visible = true;

            if (ftp.r2x181(dtPicker.Value)) lbl181r2xOK.Visible = true;
            else lbl181r2xNOK.Visible = true;

            if (ftp.logsp183(dtPicker.Value)) lbl183logspOK.Visible = true;
            else lbl183logspNOK.Visible = true;

            if (ftp.log2185(dtPicker.Value)) lbl185log2OK.Visible = true;
            else lbl185log2NOK.Visible = true;

            if (ftp.logma186(dtPicker.Value)) lbl186logmaOK.Visible = true;
            else lbl186logmaNOK.Visible = true;

            if (ftp.rdc11186(dtPicker.Value)) lbl186rdc11OK.Visible = true;
            else lbl186rdc11NOK.Visible = true;

            if (ftp.logsp2228(dtPicker.Value)) lbl228logsp2OK.Visible = true;
            else lbl228logsp2NOK.Visible = true;

            if (ftp.drj21e291(dtPicker.Value)) lbl291drj21eOK.Visible = true;
            else lbl291drj21eNOK.Visible = true;

            if (ftp.rdc11346(dtPicker.Value)) lbl346rdc11OK.Visible = true;
            else lbl346rdc11NOK.Visible = true;

        }

        private void resetarControles()
        {
            lbl21cabtelOK.Visible = false;
            lbl21cabitelNOK.Visible = false;

            lbl108drjOK.Visible = false;
            lbl108drjNOK.Visible = false;

            lbl171rdcOK.Visible = false;
            lbl171rdcNOK.Visible = false;

            lbl181r2xOK.Visible = false;
            lbl181r2xNOK.Visible = false;

            lbl183logspOK.Visible = false;
            lbl183logspNOK.Visible = false;

            lbl185log2OK.Visible = false;
            lbl185log2NOK.Visible = false;

            lbl186logmaOK.Visible = false;
            lbl186logmaNOK.Visible = false;

            lbl186rdc11OK.Visible = false;
            lbl186rdc11NOK.Visible = false;

            lbl228logsp2OK.Visible = false;
            lbl228logsp2NOK.Visible = false;

            lbl291drj21eOK.Visible = false;
            lbl291drj21eNOK.Visible = false;

            lbl346rdc11OK.Visible = false;
            lbl346rdc11NOK.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
