<p align="center">
  <img src="https://www.paschoalotto.com.br/wp-content/themes/paschoalotto/img/institucional/logo/logo-np.webp" alt="Descrição da Imagem" width="200"/>
</p>
<p align="center" style="font-weight: bold; font-size: 1.5em">
Random User API Consumer <br/> Teste Técnico
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white" alt="DOTNET"/>
  <img src="https://img.shields.io/badge/angular-%23DD0031.svg?style=flat&logo=angular&logoColor=white" alt="Angular"/>
  <img src="https://img.shields.io/badge/NPM-%23CB3837.svg?style=flat&logo=npm&logoColor=white" alt="NPM"/>
  <img src="https://img.shields.io/badge/typescript-%23007ACC.svg?style=flat&logo=typescript&logoColor=white" alt="TypeScript"/>
  <img src="https://img.shields.io/badge/SASS-hotpink.svg?style=flat&logo=SASS&logoColor=white" alt="SASS"/>
  <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=csharp&logoColor=white" alt="CSHARP"/>
  <img src="https://img.shields.io/badge/postgres-%23316192.svg?style=flat&logo=postgresql&logoColor=white" alt="POSTGRES"/>
  <img src="https://img.shields.io/badge/AWS-%23FF9900.svg?style=flat&logo=amazon-aws&logoColor=white" alt="POSTGRES"/>
</p>

<p align="center" style="font-size: small">Eduardo Valencio Santos</p>

---

[Applicação](http://paschoalotto.eduardovalencio.site:4200) foi hospeada na AWS e esta a disposição para testes.
[http://paschoalotto.eduardovalencio.site:4200](http://paschoalotto.eduardovalencio.site:4200)

---

* [Versões e Apontamentos](#versões-e-apontamentos)
* [Arquiteture](#arquitetura)
    * [DataAnnotation e Templete](#data-anotation-template)
    * [Modelo Frontend](#modelo-frontend)
    * [Entidades no Banco de Dados](#entidades-no-banco-de-dados)
* [FrontEnd Preview](#preview-e-navegação-pelo-front-end)
* [Observações](#observações)


---

## Versões e Apontamentos
Para o desenvolvimento do Backend seguindo o case foi selecionado o `.NET 6` por ser uma versão LTS sendo utilizada em projetos mais recentes. No FrontEnd foi selecionado o `Angular 18` seguindo a descrição da vaga de `Desenvolvedor Full-Stack C# .NET Angular` 

Seguindo o case encaminhado a aplicação tem as seguintes funções:
- Utilizar Banco de Dados PostgreSQL (REQUESITO)
- Mapear Tabela Usuario
- Consumir API Random User (https://randomuser.me/api/)
- Gerar novos usuários
- Armazenar usuário na base
- Relatório de Usuário
- Listar todos os usuários no Banco
- Front-End 
- Exibir dados da tabela
- Editar dados

---

## Arquitetura
A arquitetura do projeto segue o modelo de CLEAN ARCHITECTURE separando a aplicação em projetos relevantes por responsabilidade, Domain, Application, Infrastructure, API, Communication etc...

### Data Anotation, Template
Para o projeto Backend não foi utilizado o minimal API para demonstrar de forma verbosa o dominio do framework com Dependency Injection sem utilizando de Data Annotation somente com configuração por Fluent API para o ORM.
Os dois templates utilizados para Aplicação foram WEB API MVC e CLASSLIB.

### Modelo Frontend
Para o Frontend foi utilizado a arquitetura padrão seguindo modules mesmo que para a versão 18 do Angular tenha a implementação de standalones, a arquitetura geral do projeto foi mantida, core para bibliotecas essenciais, shared para bibliotecas compartilhadas e feature para armazenar as paginas e componentes de cada module.
Durante o desenvolvimento do Front-End foi cogitado utilizar variáveis globais de contexto porém para os requisitos da aplicação não foi necessário a implementação.

### Entidades no banco de dados
As entidades foram criadas por meio migrations com EF

<img src="./assets/db_entities.png">

---

## Preview e Navegação pelo Front End
<div style="display: grid; grid-template-columns: 1fr 1fr; gap: 10px">
    <img src="./assets/user_table_list.png" alt="SASS"/>
    <img src="./assets/user_table_list_delete_confirmation.png" alt="SASS"/>
    <img src="./assets/user_detail.png" alt="SASS"/>
    <img src="./assets/user_update_form.png" alt="SASS"/>
    <img style="grid-column: span 2" src="./assets/user_report_list.png" alt="SASS"/>
    <img style="grid-column: span 2" src="./assets/user_report_print.png" alt="SASS"/>
</div>

---

## Observações
Apesar de tentar se aproximar de um projeto real seguindo boas práticas quanto a arquitetura e fluxo de desenvolvimento os projetos não foram configurados para tal; contendo commits com arquivos de acesso como .env e outras configurações de CORS e segurança que em produção não deviam ser expostos.



