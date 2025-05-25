using BancoB2Trabalho;
using System;

class Program
{
    static void Main()
    {
        var produtoDAO = new ProdutoDAO();

        var novoProduto = new Produto
        {
            Nome = "Maçã",
            Preco = 2.50m
        };
        produtoDAO.AdicionarProduto(novoProduto);
        Console.WriteLine("Produto adicionado!");

        var lista = produtoDAO.BuscarTodos();
        Console.WriteLine("Produtos no banco:");
        foreach (var p in lista)
        {
            Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Preço: {p.Preco:C}");
        }

        if (lista.Count > 0)
        {
            int idParaExcluir = lista[lista.Count - 1].Id;
            produtoDAO.ExcluirProduto(idParaExcluir);
            Console.WriteLine($"Produto com ID {idParaExcluir} excluído!");
        }
        else
        {
            Console.WriteLine("Nenhum produto para excluir.");
        }
    }
}
