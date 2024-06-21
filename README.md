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

