## Como usar
Baixe o NpgSQL via NuGet

Configure seu banco de dados via PostgreSQL e use o script em `criar_tabela_produto.sql` para criar a table produto


Para configurar a string de conexão abra o arquivo `Conexao.cs` e altere a propriedade `StringConexao` para corresponder às configurações do seu banco PostgreSQL:

```csharp
public static string StringConexao => "Host=localhost;Port=sua_porta;Database=seu_database;User ID=seu_usuario;Password=sua_senha";
