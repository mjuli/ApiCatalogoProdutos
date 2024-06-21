# ApiCatalogoProdutos

Este repositório contém uma API para o catálogo de produtos, que permite a criação, leitura, atualização e exclusão de categorias e produtos. A API foi desenvolvida utilizando Dotnet 8.0.

## Funcionalidades

### Categoria
- **Listar Categorias**: Obtenha uma lista de todas as categorias.
- **Listar Todos os Produtos de uma Categoria**: Obtenha uma lista de todos os produtos de uma categoria.
- **Adicionar Categoria**: Adicione uma nova categoria ao catálogo.
- **Atualizar Categoria**: Atualize os detalhes de uma categoria existente.
- **Excluir Categoria**: Remova uma categorria do catálogo.
- **Buscar Categoria**: Obtenha os detalhes de uma categoria específico.

### Produto
- **Listar Produtos**: Obtenha uma lista de todos os produtos.
- **Adicionar Produto**: Adicione um novo produto ao catálogo.
- **Atualizar Produto**: Atualize os detalhes de um produto existente.
- **Excluir Produto**: Remova um produto do catálogo.
- **Buscar Produto**: Obtenha os detalhes de um produto específico.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C# 
- **Framework**: .NET Core
- **Banco de Dados**: MySql
- **ORM**: Entity Framework Core
- **Outras tecnologias**: Swagger para documentação da API

## Instalação

Para executar este projeto localmente, siga os passos abaixo:

1. Clone o repositório:
    ```sh
    git clone https://github.com/mjuli/ApiCatalogoProdutos.git
    cd ApiCatalogoProdutos
    ```

2. Configure o banco de dados:
    - Crie um banco de dados MySql.
    - Atualize a string de conexão no arquivo `appsettings.json` com as credenciais do seu banco de dados.

3. Instale as dependências e atualize o banco de dados:
    ```sh
    dotnet restore
    dotnet ef database update
    ```

4. Execute a aplicação:
    ```sh
    dotnet run
    ```

A aplicação estará disponível em `http://localhost:5267`.

## Endpoints

- GET /produtos
- GET /produtos/{id}
- POST /produtos
- PUT /produtos/{id}
- DELETE /produtos/{id}
- GET /api/categorias
- GET /api/categorias/1
- GET /api/categorias/1/produtos
- POST /api/categorias
- PUT /api/categorias/1
- DELETE /api/categorias/1

