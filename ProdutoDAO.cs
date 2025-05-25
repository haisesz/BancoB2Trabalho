using BancoB2Trabalho;
using Npgsql;
using System;
using System.Collections.Generic;

namespace BancoB2Trabalho
{
    public class ProdutoDAO
    {
        public void AdicionarProduto(Produto produto)
        {
            using var conn = new NpgsqlConnection(Conexao.StringConexao);
            conn.Open();

            var cmd = new NpgsqlCommand("INSERT INTO produto (nome, preco) VALUES (@nome, @preco)", conn);
            cmd.Parameters.AddWithValue("nome", produto.Nome);
            cmd.Parameters.AddWithValue("preco", produto.Preco);

            cmd.ExecuteNonQuery();
        }

        public List<Produto> BuscarTodos()
        {
            var lista = new List<Produto>();

            using var conn = new NpgsqlConnection(Conexao.StringConexao);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT id, nome, preco FROM produto", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Produto
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Preco = reader.GetDecimal(2)
                });
            }

            return lista;
        }

        public void ExcluirProduto(int id)
        {
            using var conn = new NpgsqlConnection(Conexao.StringConexao);
            conn.Open();

            var cmd = new NpgsqlCommand("DELETE FROM produto WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
