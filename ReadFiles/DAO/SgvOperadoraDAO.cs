using Dapper;
using ReadFiles.Entity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace ReadFiles.DAO
{
    /// <summary>
    /// Centraliza o acesso a dados do tipo <see cref="SgvOperadora"/>
    /// </summary>
    internal class SgvOperadoraDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DCI_Core"].ToString();

        internal SgvOperadora InserirOperadora(SgvOperadora obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"insert into [DCI_Core].[dbo].[sgv_operadoras]
                        (obj.operadora_id, obj.nome_operadora)
                        values (@Operadora_id, @Nome_Operadora)");

                    var retorno = conn.Execute(query,
                    new
                    {
                        @Operadora_id = obj.operadora_id,
                        @Nome_operadora = obj.nome_operadora
                    });

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal SgvOperadora ObterOperadora(long operadora_id)
        {
            var query = @"select * from [DCI_Core].[dbo].[sgv_operadoras] where operadora_id = @Operadora_id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var operadora = conn.Query<SgvOperadora>(query, new { Operadora_id = operadora_id }).FirstOrDefault();

                return operadora;
            }
        }

        internal SgvOperadora ObterOperadora(SgvOperadora obj)
        {
            return ObterOperadora((long)obj.operadora_id);
        }

        internal bool DeletarOperadora(long operadora_id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = conn.Execute(@"delete from [DCI_Core].[dbo].[sgv_operadoras]
                                                where operadora_id = @Operadora_ID",
                                                new { Operadora_Id = operadora_id });
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao tentar exluir o registro {operadora_id}, detalhes : {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return false;
            }
        }

        internal SgvOperadora AtualizaOperadora(SgvOperadora obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"update [DCI_Core].[dbo].[sgv_operadoras]
                        set
                            nome_operadora = @Nome_Operadora
                            where operadora_id = @Operadora_ID");

                    var operadora = conn.Execute(query,
                        new
                        {
                            @Operadora_ID = obj.operadora_id,
                            @Nome_Operadora = obj.nome_operadora
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
