### 🦷 **Sistema de Gestão Odontológica - B.I.N.**

## 📌 **Sobre o Projeto**  
Este projeto foi desenvolvido como parte da disciplina **ADVANCED BUSINESS DEVELOPMENT WITH .NET** pela equipe **B.I.N.**, composta por:

👥 **Integrantes**  
- 🏆 **Igor Gabriel Marcondes** - RM553544  
- 🏆 **Maria Beatriz Fogolin** - RM552669  
- 🏆 **Nicholas Barbosa Lima** - RM552744  

🎯 **Objetivo**  
O sistema foi desenvolvido em **ASP.NET Core C#** para fornecer um **backend escalável** para a **gestão de dentistas e clientes**. Ele permite:  
✔️ **Cadastro, atualização, consulta e exclusão** de clientes e funcionários.  
✔️ Integração com um **banco de dados Oracle SQL**.  
✔️ Uso de **inteligência artificial** para análise de dados coletados.

---

## 🏗️ **Arquitetura do Projeto**  
O projeto utiliza uma **arquitetura monolítica**, pois:  
🔹 Proporciona **implementação mais rápida** e facilita a integração com o banco de dados Oracle.  
🔹 **Não há necessidade de microservices** devido à escala do sistema.

---

## 🛠️ **Tecnologias Utilizadas**  
🔹 **Framework:** ASP.NET Core Web API  
🔹 **Banco de Dados:** Oracle SQL  
🔹 **ORM:** Entity Framework Core  
🔹 **Ferramentas de Teste:** Swagger / Postman  
🔹 **Padrão de Criação:** Singleton (`IConfiguracaoService`)

---

## ⚙️ **Requisitos do Sistema**  
Para rodar o projeto, é necessário:  
✅ **.NET SDK 7.0+**  
✅ **Banco de Dados Oracle** configurado  
✅ **Visual Studio / VS Code** (recomendado)  
✅ **Docker** (opcional, para rodar o banco de dados em container)

---

## 🚀 **Rodando o Projeto**  
Após clonar o repositório, execute:  
```sh
dotnet restore   # Restaura as dependências  
dotnet build     # Compila o projeto  
dotnet run       # Inicia a API  
```  
A API estará disponível em **https://localhost:7214/index.html**.

🛠️ **Para testar via Swagger:**  
Acesse **https://localhost:7214/swagger** no navegador.

---

## 📡 **Lista de Endpoints**

### 📌 **ClienteController (API de Clientes)**  
| Método HTTP | Endpoint                 | Descrição                      |
|------------|--------------------------|--------------------------------|
| GET        | `/api/cliente`           | Retorna todos os clientes      |
| GET        | `/api/cliente/{id}`      | Retorna um cliente específico  |
| POST       | `/api/cliente`           | Cria um novo cliente           |
| PUT        | `/api/cliente/{id}`      | Edita um cliente existente     |
| DELETE     | `/api/cliente/{id}`      | Exclui um cliente              |

### 📌 **FuncionarioController (API de Funcionários)**  
| Método HTTP | Endpoint                 | Descrição                        |
|------------|--------------------------|----------------------------------|
| GET        | `/api/funcionario`       | Retorna todos os funcionários   |
| GET        | `/api/funcionario/{id}`  | Retorna um funcionário específico |
| POST       | `/api/funcionario`       | Cria um novo funcionário         |
| PUT        | `/api/funcionario/{id}`  | Edita um funcionário existente  |
| DELETE     | `/api/funcionario/{id}`  | Exclui um funcionário            |

### 📌 **HomeController (API de Configurações - Singleton)**  
| Método HTTP | Endpoint                          | Descrição                                  |
|------------|-----------------------------------|--------------------------------------------|
| GET        | `/api/home`                      | Verifica se a API está rodando            |
| GET        | `/api/home/configuracao/{chave}` | Obtém valores do Singleton `IConfiguracaoService` |

✅ **Exemplo de chamada ao Singleton:**  
```
GET /api/home/configuracao/AppNome
```
📥 **Resposta esperada:**  
```json
{
  "chave": "AppNome",
  "valor": "Sistema de Gestão Odontológica B.I.N."
}
```

---

## 🏗️ **Padrão de Criação Utilizado - Singleton**  
Este projeto implementa o padrão **Singleton** para gerenciamento de configurações globais.

🔹 Mantém **configurações globais** durante toda a execução da API.  
🔹 **Evita múltiplas instâncias desnecessárias** de configurações.  
🔹 Registrado no **Program.cs** como um **Singleton**:  
```csharp
builder.Services.AddSingleton<IConfiguracaoService, ConfiguracaoService>();
```
🔹 Pode ser acessado via API no `/api/home/configuracao/{chave}`.

---

## 📌 **Exemplos de JSON para Teste**

### 📂 **Criar Cliente**  
```json
{
  "clienteID": 0,
  "nome": "Carlos Oliveira",
  "cpf": "510.654.194-81",
  "dataNascimento": "1990-06-15",
  "email": "carlos.oliveira@email.com"
}
```

### 📂 **Criar Funcionário**  
```json
{
  "funcionarioID": 0,
  "nome": "Mariana Souza",
  "cpf": "347.846.832-91",
  "cargo": "Analista de Dados",
  "salario": 6200.00,
  "dataContratacao": "2024-02-20"
}
```

---

## 🧪 **Testes da API**  
### 🚀 **Testando com Postman**  
1. **Baixe e abra o Postman**.  
2. **Crie uma nova requisição** para `https://localhost:7214/api/cliente`.  
3. **Envie um `POST` com o JSON de exemplo acima**.  
4. **Confira a resposta e valide os dados**.

### 🚀 **Testando com Curl**  
Você pode testar a API diretamente no terminal:  
```sh
curl -X GET https://localhost:7214/api/cliente
```

---

## 🌟 **Conclusão**  
✔️ **API desenvolvida com arquitetura monolítica** para gestão odontológica.  
✔️ **Uso do padrão Singleton** para configuração global.  
✔️ **Banco de Dados Oracle SQL** integrado ao sistema.  
✔️ **Endpoints documentados e testáveis via Postman, Swagger e Curl**.  
