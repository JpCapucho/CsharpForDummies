using ReadFiles.DAO;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ReadFiles.Business
{
    public class SgvNfeProdutoBusiness
    {
        public List<SgvNfeProduto> obterNfePeloNumero(string numero_nf)
        {
            SgvNfeProdutoDAO dao = new SgvNfeProdutoDAO();
            return dao.ObterNfeProduto(numero_nf);
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

        string pathXml = @"C:\Users\joao.goncalves\Desktop\XML\";
        string nameXml;

        public List<SgvNfeProduto> listNfe(List<SgvNfeProduto> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var nameSgvNfeProduto = new SgvNfeProduto();
                nameXml = list[i].numero_nf.ToString() + ".xml";
            }
                try
                {
                    using (var writer = new StreamWriter(pathXml + nameXml))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(List<SgvNfeProduto>));
                        xml.Serialize(writer, list);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return list;
        }
    }
}
