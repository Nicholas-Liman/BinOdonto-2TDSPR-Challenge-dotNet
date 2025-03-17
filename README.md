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
