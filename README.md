# EclipeWorksTaskManager

Este projeto é um sistema de gerenciamento de tarefas desenvolvido em **.NET Core 8.0** que inclui funcionalidades de gerenciamento de projetos, tarefas, comentários e usuários. A aplicação segue uma arquitetura de camadas, utilizando ASP.NET Core para a camada de serviços e repositórios, e é testada com xUnit para garantir alta cobertura de testes.

## Estrutura do Projeto

O projeto foi estruturado em diferentes camadas para promover uma separação clara de responsabilidades:

### 1. **Domain**
- Contém os modelos (`Models`) e as interfaces de repositório (`Interfaces`) que representam as entidades e a lógica de negócios da aplicação.
- **Principais componentes:**
   - `CommentModel`, `ProjectModel`, `TaskModel`, `UserModel`: Modelos que representam os dados da aplicação.
   - `ICommentRepository`, `IProjectRepository`, `ITaskRepository`, `IUserRepository`: Interfaces que definem os contratos para acesso ao banco de dados.

### 2. **Services**
- Implementa a lógica de negócios e contém as interfaces que fornecem métodos para manipulação e consulta de dados.
- **Principais componentes:**
   - `ICommentService`, `IProjectService`, `ITaskService`, `IUserService`: Interfaces que definem a lógica de negócios e comunicação entre a camada de domínio e o cliente.
   - As interfaces da camada de serviços também contêm métodos de manipulação de dados (CRUD) e fornecem relatórios de desempenho.

### 3. **Data**
- Contém a implementação dos repositórios (`Repositories`) que realizam a interação direta com o banco de dados usando Entity Framework.
- Implementa o padrão de repositório para fornecer uma camada de abstração sobre as operações de dados.

### 4. **Tests**
- Um projeto de testes utilizando xUnit e Moq para realizar testes unitários em todas as interfaces de serviços e repositórios.
- Cada camada de teste foi projetada para cobrir mais de 80% do código, garantindo confiabilidade e estabilidade da aplicação.

---

## Tecnologias Utilizadas

- **.NET Core 8.0**: Framework principal utilizado para o desenvolvimento da aplicação.
- **Entity Framework Core**: Utilizado como ORM para interação com o banco de dados.
- **xUnit**: Framework de testes unitários.
- **Moq**: Biblioteca para criação de mocks durante os testes.
- **Banco de Dados**: Banco de dados utilizado para armazenamento de dados.
- **Docker**: Para facilitar a execução da aplicação em diferentes ambientes.

---
Executando a Aplicação

Executando com Docker
Para executar o projeto em um ambiente fora do Visual Studio, como em um servidor ou outro ambiente de desenvolvimento, você precisará do Docker instalado.

Certifique-se de que o Docker está instalado e em execução em seu ambiente.
No diretório raiz do projeto, execute o comando:
bash
Copy code
docker-compose up
Este comando criará e iniciará os contêineres necessários para a aplicação (incluindo o contêiner do Banco de Dados).

Após, abra o seu navegador de preferencia e abra o seguinte endereço: https://localhost:8080/swagger/

Para parar e remover os contêineres, execute:
bash
Copy code
docker-compose down
Executando em Ambiente de Desenvolvimento
Se estiver utilizando o Visual Studio, você pode simplesmente pressionar F5 para iniciar a aplicação em modo de depuração.

Testes

Ferramentas Utilizadas
xUnit: Framework de testes escolhido para realizar testes unitários.
Moq: Utilizado para criar mocks das interfaces durante os testes.
Como Executar os Testes
Abra o Test Explorer no Visual Studio (Test > Test Explorer) ou use o seguinte comando para executar os testes via CLI:
bash
Copy code
dotnet test
Cobertura de Testes
O projeto foi configurado para atingir mais de 80% de cobertura de código. Para verificar a cobertura, use o comando abaixo após a execução dos testes:

bash
Copy code
dotnet test --collect:"XPlat Code Coverage"
Use o plugin ReportGenerator para gerar relatórios legíveis de cobertura.

bash
Copy code
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator "-reports:**/coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:Html

**Questões ao Product Owner**

Ao planejar futuras implementações e refinamentos, aqui estão algumas perguntas que faríamos ao PO:

*Integrações:* Há a necessidade de integrar a aplicação com outras ferramentas (ex: Trello, Jira, Slack)?

*Notificações:* Deve haver um sistema de notificações para usuários sobre mudanças nas tarefas ou comentários?

*Permissões de Usuários:* Quais outras regras de acesso precisam ser aplicadas, além do papel de "gerente"?

*Relatórios:* Quais outros tipos de relatórios de desempenho são esperados? Há interesse em métricas específicas?

*Filtragem e Pesquisa:* A aplicação deve fornecer funcionalidades avançadas de filtragem e pesquisa de projetos, tarefas e comentários?

*Anexos:* As tarefas ou comentários devem permitir anexos de arquivos?

*Localização e Idiomas:* Há a necessidade de suporte para múltiplos idiomas na aplicação?

*Escalabilidade:* A aplicação deve estar preparada para grandes volumes de usuários e tarefas? Se sim, qual é a expectativa de crescimento?

**Melhorias Propostas para o Projeto**

Durante a análise, identificamos algumas áreas que poderiam ser aprimoradas:

1. Padrões de Projeto
   Implementar CQRS (Command Query Responsibility Segregation) para separar responsabilidades de leitura e escrita na aplicação.
   Utilizar o Padrão de Repositório Genérico para reduzir a repetição de código em repositórios.
2. Desempenho e Escalabilidade
   Adicionar Caching para endpoints que não mudam frequentemente, melhorando o desempenho da aplicação.
   Utilizar um CDN (Content Delivery Network) para entregar arquivos estáticos mais rapidamente aos usuários.
3. Monitoramento e Logs
   Integrar ferramentas de monitoramento como Serilog para gerenciamento de logs e Application Insights para rastrear a performance e erros em tempo real.
4. Nuvem e Infraestrutura
   Dockerizar toda a aplicação e adicionar suporte para orquestração de contêineres com Kubernetes, tornando o projeto mais facilmente implantável em ambientes de nuvem.
   Implementar CI/CD (Continuous Integration/Continuous Deployment) com GitHub Actions ou Azure DevOps para automação de testes e implantação.
5. Segurança
   Adicionar autenticação e autorização com o OAuth 2.0 ou OpenID Connect, permitindo login via provedores de identidade como Google e Microsoft.
   Implementar a criptografia de dados sensíveis em repouso e em trânsito.
6. Documentação e API
   Adicionar Swagger para documentar a API e permitir que os desenvolvedores interajam com os endpoints de maneira mais fácil.

**Considerações Finais**

Este projeto é uma aplicação completa de gerenciamento de tarefas que utiliza as melhores práticas de desenvolvimento em .NET Core, como separação por camadas, uso de Entity Framework Core para acesso a dados, e testes unitários extensivos com xUnit e Moq.

Se tiver dúvidas ou sugestões, fique à vontade para entrar em contato!