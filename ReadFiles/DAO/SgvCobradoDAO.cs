using Dapper;
using ReadFiles.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFiles.DAO
{
    class SgvCobradoDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DCI_Core"].ToString();

        internal SgvCobrado InserirCobrado(SgvCobrado obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"insert into [DCI_Core].[dbo].[sgv_cobrados]
                                (obj.numero_serie, obj.cliente_id, obj.registro_venda, obj.comissao, obj.pin_number, obj.cobranca_id, obj.tipo_registro, obj.tipo_recarga, obj.produto_id, obj.quantidade, obj.dci_machine, obj.dci_data_importacao)
                                values (@Numero_Serie, @Cliente_Id, @Registro_Venda, @Comissao, @Pin_Number, @Cobranca_Id, @Tipo_Registro, @Tipo_Recarga, @Produto_Id, @Quantidade, @Dci_Machine, @Dci_Data_Importacao)");

                    var retorno = conn.Execute(query,
                        new {

                        @Numero_Serie = obj.numero_serie,
                        @Cliente_Id = obj.cliente_id,
                        @Registro_Venda = obj.registro_venda,
                        @Comissao = obj.comissao,
                        @Pin_Number = obj.pin_number,
                        @Cobranca_Id = obj.cobranca_id,
                        @Tipo_Registro = obj.tipo_registro,
                        @Tipo_Recarga = obj.tipo_recarga,
                        @Produto_Id = obj.produto_id,
                        @Quantidade = obj.quantidade,
                        @Dci_Machine = obj.dci_machine,
                        @Dci_Data_Importacao = obj.dci_data_importacao
                        });
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal SgvCobrado ObterCobrado (string numero_serie)
        {
            var query = @"select * from [DCI_Core].[dbo].[sgv_cobrados] where numero_serie = @Numero_Serie";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var cobrado = conn.Query<SgvCobrado>(query, new { Numero_Serie = numero_serie }).FirstOrDefault();

                return cobrado;
            }
        }

        internal SgvCobrado ObterCobrado (SgvCobrado obj)
        {
            return ObterCobrado((string)obj.numero_serie);
        }

        internal bool DeletarCobrado (string numero_serie)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = conn.Execute(@"delete from [DCI_Core].[dbo].[sgv_cobrados]
                                                where numero_serie = @Numero_Serie",
                                                new { Numero_Serie = numero_serie });
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao tentar excluir o registro {numero_serie}, detalhes: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return false;
            }
        }

        internal SgvCobrado AtualizarCobrado(SgvCobrado obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"update [DCI_Core].[dbo].[sgv_cobrados]
                                    set cliente_id = @Cliente_Id,
                                        registro_venda = @Registro_Venda,
                                        comissao = @Comissao,
                                        pin_number = @Pin_Number,
                                        cobranca_id = @Cobranca_Id,
                                        tipo_registro = @Tipo_Registro,
                                        tipo_recarga = @Tipo_Recarga,
                                        produto_id = @Produto_Id,
                                        quantidade = @Quantidade,
                                        dci_machine = @Dci_Machine,
                                        dci_data_importacao = @Dci_Data_Importacao
                                       where numero_serie = @Numero_Serie ");

                    var retorno = conn.Execute(query,
                        new
                        {

                            @Numero_Serie = obj.numero_serie,
                            @Cliente_Id = obj.cliente_id,
                            @Registro_Venda = obj.registro_venda,
                            @Comissao = obj.comissao,
                            @Pin_Number = obj.pin_number,
                            @Cobranca_Id = obj.cobranca_id,
                            @Tipo_Registro = obj.tipo_registro,
                            @Tipo_Recarga = obj.tipo_recarga,
                            @Produto_Id = obj.produto_id,
                            @Quantidade = obj.quantidade,
                            @Dci_Machine = obj.dci_machine,
                            @Dci_Data_Importacao = obj.dci_data_importacao
                        });
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
