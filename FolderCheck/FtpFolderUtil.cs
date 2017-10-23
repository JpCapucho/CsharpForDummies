using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderCheck
{
    public class FtpFolderUtil
    {
        internal string arquivo;


        public FtpFolderUtil()
        {
            arquivo = "sgv_vendascompos30.csv";
        }

        public FtpFolderUtil(string nome)
        {
            arquivo = nome;
        }

        /// <summary>
        /// Retorna o path para uma determinada data
        /// </summary>
        /// <param name="data">data a qual se pretende obter o path</param>
        /// <returns>string com o caminho da pasta/dia</returns>
        private string pathDay(DateTime data)
        {
            var pathDay = $"{data.Year.ToString("d4")}\\{data.Month.ToString("d2")}\\{data.Day.ToString("d2")}";
            return pathDay;
         }


        /// <summary>
        /// Verifica se a pasta cabtel está completa
        /// </summary>
        /// <returns>true se o arquivo de vendas existir</returns>
        public bool cabtel(DateTime data)
        {
            //o caminho da pasta cabtel
            var path = "H:\\FTP\\TENDENCIA\\21-CABTEL";
            //verifica se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool drj108(DateTime data)
        {
            //caminha da pasta 108-DRJ
            var path = @"H:\FTP\TENDENCIA\108-DRJ";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool rdc171(DateTime data)
        {
            //caminha da pasta 171-RDC
            var path = @"H:\FTP\TENDENCIA\171-RDC";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool r2x181(DateTime data)
        {
            //caminha da pasta 181-R2X
            var path = @"H:\FTP\TENDENCIA\181-R2X";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool logsp183(DateTime data)
        {
            //caminha da pasta 183-LOGSP
            var path = @"H:\FTP\TENDENCIA\183-LOGSP";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool log2185(DateTime data)
        {
            //caminha da pasta 185-LOG2
            var path = @"H:\FTP\TENDENCIA\185-LOG2";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool logma186(DateTime data)
        {
            //caminha da pasta 186-LOGMA
            var path = @"H:\FTP\TENDENCIA\186-LOGMA";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool rdc11186(DateTime data)
        {
            //caminha da pasta 186-RDC11
            var path = @"H:\FTP\TENDENCIA\186-RDC11";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool logsp2228(DateTime data)
        {
            //caminha da pasta 228-LOGSP2
            var path = @"H:\FTP\TENDENCIA\228-LOGSP2";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool drj21e291(DateTime data)
        {
            //caminha da pasta 291-DRJ21e
            var path = @"H:\FTP\TENDENCIA\291-DRJ21e";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }

        public bool rdc11346(DateTime data)
        {
            //caminha da pasta 346-RDC11
            var path = @"H:\FTP\TENDENCIA\346-RDC11";
            //verificar se existe ou não o arquivo de vendas
            return File.Exists($"{path}\\{pathDay(data)}\\{arquivo}");
        }


    }
}
