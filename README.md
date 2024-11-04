# StylistPro.Compra.API

## Integrantes
- RM98695  - Breno Giacoppini Câmara   
- RM551744 - Jaqueline Martins dos Santos   
- RM97510  - Mariana Bastos Esteves   
- RM551155 - Matheus Oliveira Macedo   
- RM99982  - Victor Freitas Silva   

## Visão Geral
Esta API foi desenvolvida utilizando uma arquitetura de microservices e segue os princípios de um sistema escalável e modular. As principais funcionalidades são a implementação de operações CRUD (Create, Read, Update e Delete) utilizando o banco de dados ORACLE e a documentação da API configurada com OpenAPI. O padrão de design Singleton também foi aplicado para controlar instâncias específicas durante a execução.

## Estrutura de Camadas

- **Presentation Layer (Camada de Apresentação)**: Essa camada lida com a comunicação entre o cliente e a aplicação. Utilizamos o framework ASP.NET Core para gerenciar os endpoints da API.
- **Application Layer (Camada de Aplicação)**: Contém a lógica de negócios de alto nível, coordenando operações entre a camada de domínio e a camada de apresentação.
- **Domain Layer (Camada de Domínio)**: Define as entidades de domínio e as regras de negócios centrais.
- **Infrastructure Layer (Camada de Infraestrutura)**: Lida com tecnologias externas como acesso ao banco de dados.
- **Test Layer (Camada de Testes)**: Inclui testes unitários e de integração utilizando xUnit para garantir o comportamento correto da aplicação

## Funcionalidades

### ObterTodos: Retorna todos os registros do banco de dados.
- Entrada: Requisição para listar compras.
- Processo: Recuperação dos dados das compras do banco de dados.
- Saída: Lista de compras com detalhes.

### ObterPorId: Retorna um registro específico com base no Id fornecido.
- Entrada: Id da compra a ser listada.
- Processo: Recuperação dos dados da compra do banco de dados.
- Saída: Lista os detalhes da compra localizada pelo Id.

### SalvarDados: Insere um novo registro no banco de dados.
- Entrada: Data da Compra e status da compra.
- Processo: Validação e armazenamento no banco de dados.
- Saída: Confirmação da criação da compra.

### EditarDados: Atualiza um registro existente.
- Entrada: Id da compra e dados atualizados.
- Processo: Validação e atualização da compra no banco de dados.
- Saída: Confirmação da atualização.

### DeletarDados: Remove um registro com base no Id.
- Entrada: Id da compra a ser excluída.
- Processo: Remoção da compra no banco de dados.
- Saída: Confirmação da exclusão.

## Design Patterns Utilizados

### 1. Singleton
O padrão Singleton foi utilizado para garantir que algumas classes críticas tenham apenas uma instância ao longo da execução da aplicação, evitando a criação desnecessária de múltiplos objetos e promovendo a eficiência de recursos. Este padrão foi aplicado, por exemplo, no gerenciamento de conexões com o banco de dados.

- **Uma única instância:** A classe Singleton cria apenas uma instância de si mesma.
- **Construtor privado:** Para impedir que outras classes criem novas instâncias.
- **Ponto de acesso global:** Através de um método estático que retorna a única instância criada.

### 2. Microservices
A API foi desenvolvida seguindo a **arquitetura de microservices**, o que permite que cada serviço seja independente e escalável de forma autônoma. Cada serviço é focado em uma funcionalidade específica e opera de forma autônoma, o que oferece várias vantagens, como:
- **Escalabilidade**
- **Modularidade**
- **Resiliência**
- **Facilidade de Manutenção e Atualização**
- **Agilidade**

## Arquitetura

A arquitetura apresentada para o projeto **StylistPro** segue os princípios da **Onion Architecture**, utilizada para construir sistemas com alta desacoplagem entre camadas. 

### 1. **Mobile Client**
   - Ponto de entrada do sistema, representando o cliente móvel que acessa o serviço **StylistPro**.

### 2. **API Gateway**
   - Atua como ponto central de entrada para todas as requisições, direcionando-as para as APIs correspondentes de **Compra**, **Feedback** ou **Produto**.

### 3. **APIs (Compra, Feedback, Produto)**
   - APIs responsáveis por funcionalidades específicas de cada domínio, seguindo o padrão **Onion Architecture**, promovendo a separação de responsabilidades e inversão de dependências.

### 4. **Banco de Dados (Oracle)**
   - Cada API está conectada a um banco de dados Oracle dedicado para armazenar dados de compras, feedback e produtos.

### 5. **Onion Architecture**
   - Promove a separação em camadas (domínio, aplicação, infraestrutura) e o princípio da inversão de dependências.

## Clean Code 

- **Clean Code** é um conjunto de boas práticas e princípios para escrever códigos legíveis, simples, e fáceis de manter facilitando a manutenção e evolução do sistema. Alguns dos princípios básicos incluem:
- **Nomes significativos**: Os nomes de variáveis, métodos, classes e outros elementos do código devem ser descritivos e deixar claro seu propósito.
- **Funções pequenas e de única responsabilidade**: Funções devem ser curtas e fazer apenas uma coisa. Elas devem ser simples de entender e ter um único propósito.
- **Remoção de código Morto**: Código não utilizado ou comentado deve ser removido para evitar confusão e manter o código limpo. 
- **Tratamento de erros claro**: Exceções e validações ajudam a evitar comportamentos inesperados e facilitam a identificação de problemas.
- **Evite Dependências Ocultas**: O código deve ser claro sobre quais dados ele precisa. Depender de variáveis globais ou de comportamentos que não são explícitos pode gerar bugs difíceis de identificar. 

## SOLID
  
- **SRP (Single Responsibility Principle)**: Cada classe tem uma única responsabilidade.
- **OCP (Open/Closed Principle)**: Módulos são abertos para extensão e fechados para modificação.
- **LSP (Liskov Substitution Principle)**: Classe e interface específica para casos de uso.
- **ISP (Dependency Inversion Principle)**: Princípio da segregação de interfaces.
- **DIP (Dependency Inversion Principle)**: Inversão de dependências torna o sistema mais modular.
 
## Testes Unitários
- Testes unitários foram implementados nas camadas `ApplicationService` e `Repository` para verificar o funcionamento correto e a integridade dos dados, aumentando a robustez e confiabilidade da API.

## Tecnologias Utilizadas
- **Oracle Database: Utilizado para operações CRUD.**
- **ASP.NET Core: Framework utilizado para o desenvolvimento da API.**
- **OpenAPI/Swagger: Configurado para gerar a documentação da API.**
- **xUnit**: para testes automatizados

## Requisitos
- **.NET SDK 8.0**
- **Visual Studio 2022 ou Visual Studio Code**
- **Oracle Database (com conexão configurada)**

## Instruções para Executar a API

### 1. Clone o repositório:
```
git clone <link-do-repositorio>
```

### 2. Navegue até a pasta do projeto:
```
cd StylistPro.Compra.API
```

### 3. Restaure os pacotes NuGet:
```
dotnet restore
```

### 4. Configure a string de conexão com o banco de dados ORACLE no arquivo appsettings.json:
```
"ConnectionStrings": {
  "Oracle": "Data Source=<oracle-db-url>;User Id=<username>;Password=<password>;"
}
```

### 5. Execute a aplicação:
```
dotnet run
```

### 6. Acesse a documentação da API gerada pelo Swagger:
```
Após executar a API, navegue até http://localhost:<porta>/swagger para visualizar e interagir com a documentação.
```

### 7. No caso de erro no banco de dados: Se houver inconsistências entre o código e o banco de dados, você pode gerar e aplicar migrations para corrigir a estrutura do banco.
```
Remove-Migration
```
```
Add-Migration <nome-da-migração>
```
```
Update-Database
```

## Testando a API
A **StylistPro** utiliza o Swagger para expor os endpoints de forma interativa. Abra a URL fornecida após executar a API e você verá a documentação da API com opções para testar cada endpoint.

## Contato
Para qualquer dúvida ou sugestão, entre em contato com victor.fsilva45@gmail.com

