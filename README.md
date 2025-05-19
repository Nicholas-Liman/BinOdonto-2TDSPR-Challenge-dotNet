### 🦷 Sistema de Gestão Odontológica - B.I.N.

## 📌 Sobre o Projeto  
Este projeto foi desenvolvido como parte da disciplina **ADVANCED BUSINESS DEVELOPMENT WITH .NET** pela equipe **B.I.N.**, composta por:

👥 **Integrantes**  
- 🏆 **Igor Gabriel Marcondes** - RM553544  
- 🏆 **Maria Beatriz Fogolin** - RM552669  
- 🏆 **Nicholas Barbosa Lima** - RM552744  

🎯 **Objetivo**  
Desenvolver uma **API RESTful escalável** em **ASP.NET Core C#** para a **gestão de dentistas e clientes**, com:

- ✅ CRUD completo para clientes e funcionários  
- ✅ Integração com **ViaCEP** para busca automática de endereços  
- ✅ Recomendação inteligente de funcionários baseada em **ML.NET**  
- ✅ Documentação interativa com **Swagger**

---

## 🏗️ Arquitetura do Projeto  
O projeto segue uma **arquitetura monolítica em camadas**, composta por:

- 🧠 `Domain` – Entidades e interfaces  
- 📦 `Application` – DTOs, serviços de aplicação e ML  
- 🛠️ `Infrastructure` – Repositórios e acesso a dados  
- 🌐 `Presentation/API` – Controllers e configuração

> Ideal para ambientes educacionais e MVPs, sem necessidade de microservices.

---

## 🛠️ Tecnologias Utilizadas  
- **ASP.NET Core Web API**
- **Entity Framework Core + Oracle SQL**
- **ML.NET (modelo `.zip` treinado com dados reais)**
- **Swagger + Annotations**
- **XUnit + Moq para testes**
- **ViaCEP REST API**

---

## ⚙️ Requisitos do Sistema  
- [.NET SDK 7.0+](https://dotnet.microsoft.com/en-us/download)
- Oracle DB configurado (ou Docker opcional)
- Visual Studio ou VS Code (com suporte C#)

---

## 🚀 Rodando o Projeto  

```bash
dotnet restore   # Restaura dependências  
dotnet build     # Compila  
dotnet run       # Inicia API
````

🔗 Acesse em: `https://localhost:7214/swagger`

---

## 📡 Endpoints da API

### 📁 ClienteController

| Método | Rota                | Ação                      |
| ------ | ------------------- | ------------------------- |
| GET    | `/api/cliente`      | Lista todos os clientes   |
| GET    | `/api/cliente/{id}` | Retorna um cliente por ID |
| POST   | `/api/cliente`      | Cria novo cliente         |
| PUT    | `/api/cliente/{id}` | Edita um cliente          |
| DELETE | `/api/cliente/{id}` | Remove um cliente         |

### 📁 FuncionarioController

| Método | Rota                    | Ação                          |
| ------ | ----------------------- | ----------------------------- |
| GET    | `/api/funcionario`      | Lista todos os funcionários   |
| GET    | `/api/funcionario/{id}` | Retorna um funcionário por ID |
| POST   | `/api/funcionario`      | Cadastra novo funcionário     |
| PUT    | `/api/funcionario/{id}` | Edita um funcionário          |
| DELETE | `/api/funcionario/{id}` | Remove um funcionário         |

### 🤖 Recomendação por IA

| Método | Rota                              | Ação                                      |
| ------ | --------------------------------- | ----------------------------------------- |
| GET    | `/api/recomendacao?cep=08230-000` | Retorna o funcionário mais próximo via IA |

### ⚙️ Configurações Singleton

| Método | Rota                             | Ação                       |
| ------ | -------------------------------- | -------------------------- |
| GET    | `/api/home`                      | Verifica status da API     |
| GET    | `/api/home/configuracao/{chave}` | Acessa configuração global |

---

## 🧠 Recomendação Inteligente com ML.NET

Integração com modelo **treinado via Model Builder**, que analisa:

* `cep_cliente`
* `cep_funcionario`
* `diferenca_ceps`
* `mesmo_prefixo`

E retorna o funcionário mais próximo com base em dados reais.

### 🔍 Exemplo de entrada para recomendação:

```
GET /api/recomendacao?cep=08230-000
```

✔️ O sistema responde com o funcionário mais próximo segundo o modelo `.zip`.

---

## 📂 Exemplo de JSON para Teste

### Criar Cliente

```json
{
  "clienteID": 0,
  "nome": "Carlos Oliveira",
  "cpf": "510.654.194-81",
  "dataNascimento": "1990-06-15",
  "email": "carlos@email.com",
  "cep": "08230000"
}
```

### Criar Funcionário

```json
{
  "funcionarioID": 0,
  "nome": "Mariana Souza",
  "cpf": "347.846.832-91",
  "cargo": "Ortodontista",
  "salario": 7000,
  "dataContratacao": "2025-05-19",
  "cep": "08110000"
}
```

---

## 🧪 Testes Automatizados

✔️ Implementados com `xUnit` e `Moq`
✔️ Testes de serviço, aplicação e validações
✔️ Banco de dados em memória para `ApplicationDbContext`

---

## 🌟 Conclusão

✅ Projeto finalizado com:

* Arquitetura clara e separada em camadas
* Integração real com IA via ML.NET
* Validações próprias para CPF, datas, etc
* API testável, escalável e pronta para deploy educacional

---

📦 **Desenvolvido por B.I.N.
