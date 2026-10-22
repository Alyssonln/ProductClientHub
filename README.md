# ProductClientHub

API REST desenvolvida em **C# com ASP.NET Core** para gerenciar clientes e os produtos vinculados a cada um deles. Projeto criado durante meus estudos de .NET, com foco em organização de código, validação de dados e tratamento de erros.

## Tecnologias

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core 9
- SQLite
- FluentValidation
- Swagger (Swashbuckle)

## Estrutura da solução

```
ProductClientHub
├── ProductClientHub.API            → Controllers, entidades, use cases, filtros e acesso a dados
├── ProductClientHub.Communication  → Contratos de entrada e saída (Requests e Responses)
└── ProductClientHub.Exception      → Exceções personalizadas da aplicação
```

**Destaques da implementação:**

- **Use cases**: cada operação (cadastrar, atualizar, listar, buscar, excluir) tem sua própria classe, mantendo os controllers enxutos e as regras de negócio isoladas.
- **Validação com FluentValidation**: regras como nome e e-mail obrigatórios e preço maior que zero, com mensagens claras para o usuário.
- **Tratamento centralizado de erros**: um `ExceptionFilter` captura as exceções da aplicação e devolve o status HTTP correto (400, 404 ou 500) com uma lista padronizada de mensagens.
- **Relacionamento 1:N**: um cliente possui vários produtos, carregados com `Include` do Entity Framework na consulta por ID.

## Endpoints

### Clientes

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/clients` | Cadastra um cliente |
| `GET` | `/api/clients` | Lista todos os clientes |
| `GET` | `/api/clients/{id}` | Busca um cliente com seus produtos |
| `PUT` | `/api/clients/{id}` | Atualiza nome e e-mail de um cliente |
| `DELETE` | `/api/clients/{id}` | Exclui um cliente |

### Produtos

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/products/{clientId}` | Cadastra um produto para um cliente |
| `DELETE` | `/api/products/{id}` | Exclui um produto |

### Exemplos de requisição

Cadastro de cliente:

```json
{
  "name": "Maria Silva",
  "email": "maria@email.com"
}
```

Cadastro de produto:

```json
{
  "name": "Notebook",
  "brand": "Dell",
  "price": 3500.00
}
```

Resposta de erro (exemplo de validação):

```json
{
  "errors": [
    "O nome não pode ser vazio.",
    "O e-mail não pode ser vazio."
  ]
}
```

## Como executar

**Pré-requisito:** [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/Alyssonln/ProductClientHub.git
cd ProductClientHub/ProductClientHub.API
dotnet run
```

Com a aplicação rodando, acesse a documentação interativa no Swagger em `https://localhost:<porta>/swagger` (a porta aparece no terminal).

## Autor

**Alysson Nunes** · [GitHub](https://github.com/Alyssonln) · [LinkedIn](https://www.linkedin.com/in/alysson-nunes/?isSelfProfile=true)
