using Dapper;
using ReadFiles.Entity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace ReadFiles.DAO
{

    /// <summary>
    /// Centraliza o acesso a dados do tipo <see cref="AxFiscalDOcumentLine"/>
    /// </summary>
    internal class SgvProdutosDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DCI_Core"].ToString();

        internal AxFiscalDOcumentLine InserirProduto(AxFiscalDOcumentLine obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"insert into [DCI_Core].[dbo].[sgv_produtos]
                            (obj.produto_id, obj.operadora_id, obj.valor_face, obj.nome_produto, obj.negociavel, obj.valor_maximo, obj.valor_minimo)
                            values (@ProdutoId, @OperadoraId, @ValorFace, @NomeProduto, @Negociavel, @ValorMaximo, @ValorMinimo)");

                    var retorno = conn.Execute(query,
                    new
                    {
                        @ProdutoId = obj.produto_id,
                        @OperadoraId = obj.operadora_id,
                        @ValorFace = obj.valor_face,
                        @NomeProduto = obj.nome_produto,
                        @Negociavel = obj.negociavel,
                        @ValorMaximo = obj.valor_maximo,
                        @ValorMinimo = obj.valor_minimo
                    });

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        internal AxFiscalDOcumentLine ObterProduto(long produto_id)
        {
            var query = @"select * from [DCI_Core].[dbo].[sgv_produtos] where produto_id = @ProdutoId";

            using (var conn = new SqlConnection(ConnectionString))
            {

                var produto = conn.Query<AxFiscalDOcumentLine>(query, new { ProdutoId = produto_id }).FirstOrDefault();

                return produto;
            }

        }


        internal AxFiscalDOcumentLine ObterProduto(AxFiscalDOcumentLine obj)
        {
            return ObterProduto((long)obj.produto_id);
        }


        internal bool DeletarProduto(long produto_id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = conn.Execute(@"delete from [DCI_Core].[dbo].[sgv_produtos] 
                                                where produto_id = @ProdutoId",
                                                new { ProdutoId = produto_id });
                    if (result > 0)
                    {
                        return true;
                    }
                    
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao tentar excluir o registro {produto_id}, detalhes: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return false;
            }
        }

        internal AxFiscalDOcumentLine AtualizarProduto(AxFiscalDOcumentLine obj)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var query = (@"update [DCI_Core].[dbo].[sgv_produtos]
                                    set 
                                        operadora_id = @OperadoraId,
                                        valor_face = @ValorFace,
                                        nome_produto = @NomeProduto,
                                        negociavel =  @Negociavel,
                                        valor_minimo = @ValorMinimo,
                                        valor_maximo = @ValorMaximo
                                    where produto_id = @ProdutoId");

                    var produto = conn.Execute(query,
                    new
                    {
                        @ProdutoId = obj.produto_id,
                        @OperadoraId = obj.operadora_id,
                        @ValorFace = obj.valor_face,
                        @NomeProduto = obj.nome_produto,
                        @Negociavel = obj.negociavel,
                        @ValorMaximo = obj.valor_maximo,
                        @ValorMinimo = obj.valor_minimo
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
