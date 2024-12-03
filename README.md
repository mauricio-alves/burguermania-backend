# Projeto Final (BackEnd) - Trilha Desenvolvimento FullStack ResTIC36

## Descrição do projeto

O objetivo é desenvolver o backend da aplicação fullstack final da trilha, utilizando o framework .NET e o Entity Framework. O projeto deve atender ao [modelo de dados fornecido](./Modelo-do-banco-de-dados.png), implementando uma API seguindo o padrão REST e a conectando ao frontend que se encontra [aqui](https://github.com/mauricio-alves/burguermania-frontend). 

## Instruções de como executar a aplicação

1. Primeiro, clone este repositório;
2. Abra com qualquer IDE;
3. Abra o terminal, navegue até a pasta do projeto e rode o comando `dotnet restore`;
4. Então, rode o comando `dotnet ef database update`;
5. Então, rode o comando `dotnet run`;
6. Em outro terminal, rode o comando `start http://localhost:5290/swagger`;
7. Uma janela abrirá no seu navegador e a aplicação será executada.

Ao executar o comando `dotnet ef database update`, o banco de dados será criado e populado automaticamente com dados iniciais nas tabelas, conforme especificado na classe [SeedData](./Models/SeedData.cs) e no [AppDbContext](./Context/AppDbContext.cs). Essa classe define registros pré-configurados para as entidades `Status`, `Users`, `Categories` e `Products`, garantindo que o banco de dados já esteja preenchido. Por exemplo, os status "Pendente", "Em Processamento" e "Finalizado", além de categorias e produtos detalhados com suas descrições e imagens, serão inseridos no banco durante a migração. Isso facilita a inicialização do sistema com dados prontos para testes e uso imediato. 

## Tecnologias utilizadas

- .NET;
- Entity Framework;
- PostgreSQL;
- Swagger.
