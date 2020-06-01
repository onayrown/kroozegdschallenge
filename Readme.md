# Desafio TDD - Felipe Machado
A proposta desse desafio era poder desenvolver os métodos e funcionalidades desse sistema a partir dos testes unitários. 
Semelhante à forma que é feita usando TDD (Test-driven development)

## Instruções de instalação e execução
1. Primeiro baixe e compile todos os projetos.
2. O projeto Krooze.EntranceTest.Web pode ser executado através da linha de commando: dotnet run
3. Caso deseje executar a aplicação em container execute os seguintes comandos:
    docker build -t aspnetapp .
    docker run -d -p 8080:80 --name myapp aspnetapp

## Descrição do projeto prático.
- Primeira Etapa:
  - Todos os testes foram validados (Projeto Krooze.EntranceTest.Tests)
  - Toda implementação está no projeto Krooze.EntranceTest.WriteHere, ou referenciado a partir dele
- Segunda Etapa:
  - Foi criado um endpoint pra cada método feito nos testes da primeira etapa, no projeto Krooze.EntranceTest.Web, no total 7 endpoints
  - Segue a lista dos endpoints:
  - A porta padrão HTTPS foi mantida a 44308. Dessa formao endereço padrão é : 
  - https://localhost:44308
  - E cada Endpoint possui o seguinte sufixo:
  - /api/tests/Movies
  - /api/tests/Director
  - /api/tests/TranslateXML
  - /api/tests/OtherTaxes
  - /api/tests/Discount
  - /api/tests/Installments/{fullPrice}
  - /api/tests/Cruises
  - A documentação do Swagger foi implementada e está disponivel através do seguinte endpoint:
  - https://localhost:44308/swagger
  - Todos os endpoints estão disponíveis através da documentação do Swagger

## Requerimentos Técnicos
 - [.NET Core 2.2](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral)
 - [.NET Core 2.0](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral)
 - [Visual Studio 2017 ou 2019](https://visualstudio.microsoft.com/pt-br/downloads/)
