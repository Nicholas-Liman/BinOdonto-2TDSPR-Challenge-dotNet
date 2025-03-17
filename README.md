# 🦷 Sistema de Gestão Odontológica - B.I.N.

## **🎯 Sobre o Projeto**
Este projeto foi desenvolvido como parte da entrega de **ADVANCED BUSINESS DEVELOPMENT WITH .NET** pela equipe **B.I.N.**, composta por:

- 🏆 **Igor Gabriel Marcondes** - RM553544  
- 🏆 **Maria Beatriz Fogolin** - RM552669  
- 🏆 **Nicholas Barbosa Lima** - RM552744  

### **📌 Objetivo**
Este sistema foi desenvolvido em **ASP.NET Core C#** com o objetivo de fornecer um backend escalável para **gestão de dentistas e clientes**. Ele permite o **cadastro, atualização, consulta e exclusão** de registros de clientes e funcionários.  

Os dados coletados pelo **aplicativo Kotlin** são **validados e armazenados** em um banco de dados **Oracle SQL**, permitindo que um **modelo de inteligência artificial analise os dados** posteriormente.

---

## **🛠 Tecnologias Utilizadas**
- **Framework:** ASP.NET Core Web API  
- **Banco de Dados:** Oracle SQL  
- **ORM:** Entity Framework Core  
- **Ferramenta de Teste:** Swagger / Postman  
- **Padrão de Criação Implementado:** Singleton (`IConfiguracaoService`)

---

## **⚙️ Requisitos do Sistema**
Para rodar este projeto, você precisará dos seguintes requisitos instalados:  

- ✅ **.NET SDK** 7.0+  
- ✅ **Banco de Dados Oracle** configurado  
- ✅ **Visual Studio / VS Code** (recomendado)  
- ✅ **Docker** (opcional, para rodar o banco de dados em container)  

---

## **Lista de Endpoints**

### **ClienteController (API de Clientes)**
| Método HTTP | Endpoint                 | Descrição                      |
|------------|--------------------------|--------------------------------|
| GET        | `/api/cliente`           | Retorna todos os clientes      |
| GET        | `/api/cliente/{id}`      | Retorna um cliente específico  |
| POST       | `/api/cliente`           | Cria um novo cliente           |
| PUT        | `/api/cliente/{id}`      | Edita um cliente existente     |
| DELETE     | `/api/cliente/{id}`      | Exclui um cliente              |

---

### **FuncionarioController (API de Funcionários)**
| Método HTTP | Endpoint                 | Descrição                        |
|------------|--------------------------|----------------------------------|
| GET        | `/api/funcionario`       | Retorna todos os funcionários   |
| GET        | `/api/funcionario/{id}`  | Retorna um funcionário específico |
| POST       | `/api/funcionario`       | Cria um novo funcionário         |
| PUT        | `/api/funcionario/{id}`  | Edita um funcionário existente  |
| DELETE     | `/api/funcionario/{id}`  | Exclui um funcionário            |

---

### **HomeController (API de Configurações - Singleton)**
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

## **📌 Padrão de Criação Utilizado - Singleton**
O projeto implementa o padrão **Singleton** para gerenciamento de configurações globais através do **`IConfiguracaoService`**.

### **🛠 Como funciona?**
- Ele mantém **configurações globais** durante toda a execução da API.
- **Evita criar múltiplas instâncias desnecessárias** de configurações.
- É registrado no **Program.cs** como um **Singleton**:
  ```csharp
  builder.Services.AddSingleton<IConfiguracaoService, ConfiguracaoService>();
  ```
- **Pode ser acessado via API no `/api/home/configuracao/{chave}`**.

---

## **Exemplos de JSON para Testar**

### **Cliente**
```json
{
  "clienteID": 0,
  "nome": "Carlos Oliveira",
  "cpf": "510.654.194-81",
  "dataNascimento": "1990-06-15",
  "email": "carlos.oliveira@email.com"
}
```

---

### **Funcionário**
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
