# Projeto do Senac Jovem Programador
Este projeto foi desenvolvido como parte do curso Jovem Programador do Senac, uma iniciativa que visa capacitar jovens programadores nas melhores práticas de desenvolvimento de software. O projeto se concentra na criação de uma API em C# usando o framework ASP.NET Core.

## Objetivo do Projeto
O objetivo principal deste projeto é proporcionar aos participantes do curso uma experiência prática na construção de uma API funcional. A API desenvolvida neste exercício permite o acesso e a manipulação de dados relacionados a alunos e usuários, demonstrando os princípios de criação de endpoints HTTP, persistência de dados em um banco de dados e documentação de API.

## Aprendizado
Ao trabalhar neste projeto, os participantes do curso podem adquirir conhecimentos e habilidades valiosos, incluindo:

- Desenvolvimento de API em C# usando ASP.NET Core.
- Estruturação de uma aplicação com pastas organizadas para manter a modularidade e a manutenibilidade do código.
- Utilização de um banco de dados com o Entity Framework Core.
- Implementação de operações CRUD (Criar, Ler, Atualizar, Excluir) em uma API.
- Utilização de enums para representar estados ou categorias.
- Implementação de documentação de API com o Swagger.
- Entendimento de boas práticas de desenvolvimento de software.


O projeto do Senac Jovem Programador proporciona uma oportunidade prática de desenvolver habilidades relevantes para o mercado de trabalho e é um passo importante para a construção de uma carreira em desenvolvimento de software.

### Estrutura do Projeto
A estrutura do projeto consiste nas seguintes pastas:

- **Controller**: A pasta "Web API" é o coração da sua aplicação, contendo os controladores **AlunoController** e **UsuarioController**. Esses controladores definem os endpoints HTTP que os clientes podem acessar para interagir com a API. Por exemplo, eles podem oferecer endpoints para criar, ler, atualizar ou excluir registros de alunos e usuários. Essa pasta é onde a lógica de gerenciamento das solicitações HTTP é implementada.

- **Data**:A pasta "Data" abriga o **AlunoDbContext**, que é o contexto do banco de dados. Ele é fundamental para a camada de persistência da aplicação. O contexto define os modelos de dados, as tabelas do banco de dados e suas relações. Ele permite que você crie, leia, atualize e exclua registros no banco de dados de acordo com as regras definidas nos modelos.


- **Enum**: A pasta "Enum" contém o arquivo StatusAluno.cs, que define enumerações para os possíveis estados de um aluno, como "Ativo," "Desistência" e "Concluído". Isso ajuda a padronizar os estados possíveis e torna o código mais legível ao usar essas enumerações ao invés de valores literais.

- **Migrations**: A pasta "Migrations" é essencial para gerenciar as mudanças no esquema do banco de dados ao longo do tempo. As migrações são scripts que descrevem como o banco de dados deve ser alterado quando há modificações nos modelos de dados. Isso permite manter o banco de dados atualizado de forma controlada e consistente.

- **Migrations**: A pasta "Migrations" é essencial para gerenciar as mudanças no esquema do banco de dados ao longo do tempo. As migrações são scripts que descrevem como o banco de dados deve ser alterado quando há modificações nos modelos de dados.

- **Models**: A pasta "Models" contém as classes que representam os modelos de dados, incluindo as classes **AlunoModel**, **ErroDetails**, e **UsuarioModel**.

- **Repositorio**: A pasta "Repositorio" contém as classes **AlunoRepositorio** e **UsuarioRepositorio**. Esses repositórios são responsáveis por abstrair o acesso ao banco de dados. Eles encapsulam a lógica de busca, inserção, atualização e exclusão de dados, fornecendo uma camada de abstração entre a lógica de negócios da aplicação (controladores) e o banco de dados. Isso facilita a manutenção e a reutilização de código, uma vez que a lógica de acesso ao banco está centralizada nesses repositórios.

- **Interfaces**: A pasta "Interfaces" contém as interfaces **IAlunoRepositorio**,  **IRepositorio**, **UnitOfWork** e **IUsuarioRepositorio**. Elas definem os contratos que os repositórios concretos devem seguir. Isso permite que a aplicação adote o princípio da inversão de controle (IoC) e da injeção de dependência. As interfaces estabelecem um conjunto de métodos que os repositórios concretos devem implementar, garantindo que todos eles ofereçam funcionalidades consistentes e facilitando a troca de implementações, o que é útil para testes unitários e extensibilidade futura.

- **Program.cs**: A classe Program é o ponto de entrada da aplicação, onde o aplicativo da web é configurado e inicializado.

Essa estrutura modular e organizada torna o projeto mais escalável, flexível e fácil de manter, seguindo as melhores práticas de desenvolvimento de software. Cada pasta desempenha um papel específico no projeto, permitindo a separação de responsabilidades e a criação de uma arquitetura modular que promove a reutilização de funcionalidades, a integração com terceiros, a segurança e o controle do acesso, e a escalabilidade da aplicação.

## Introdução
Uma API (Application Programming Interface) é uma parte fundamental de qualquer aplicação moderna, permitindo que diferentes sistemas se comuniquem de forma eficaz. Neste exercício, criamos uma API em C# usando o framework ASP.NET Core, que fornece um conjunto de endpoints para acessar e manipular dados relacionados a alunos e usuários. Uma API serve como uma ponte de comunicação entre o cliente e o servidor, tornando possível que aplicativos façam solicitações e recebam respostas de maneira padronizada.

### Benefícios de uma API
As APIs oferecem diversos benefícios para o desenvolvimento de aplicativos, incluindo:

- **Reutilização de Funcionalidades**: As APIs permitem que você reutilize funcionalidades existentes em diferentes partes de um aplicativo ou mesmo em aplicativos diferentes.

- **Integração com Terceiros**: É possível fornecer acesso controlado a terceiros, permitindo integrações com serviços e sistemas externos.

- **Arquitetura Modular**: Uma API bem projetada segue princípios de arquitetura modular, o que facilita a manutenção e a expansão do sistema.

- **Segurança e Controle**: É possível aplicar autenticação e autorização para controlar quem pode acessar a API e quais operações são permitidas.

- **Escalabilidade**: As APIs são escaláveis, o que significa que podem atender a um grande número de solicitações simultâneas.

## Utilização do Swagger
O Swagger é uma ferramenta que auxilia na documentação e teste de APIs. Neste exercício, utilizamos o Swagger para criar uma interface interativa que permite explorar os endpoints da API, entender seus parâmetros e testar as solicitações diretamente a partir do navegador. Isso torna mais fácil para os desenvolvedores e os usuários finais entenderem como a API funciona e como interagir com ela.

## Conclusão
Este exercício de criação de uma API em C# demonstra a importância e a utilidade das APIs no desenvolvimento de aplicativos. Além disso, enfatiza a necessidade de documentar e fornecer ferramentas como o Swagger para simplificar a integração e o uso da API. As APIs desempenham um papel fundamental na construção de aplicativos modernos, promovendo a reutilização de recursos, a integração com outros sistemas e a manutenção de uma arquitetura modular e escalável. Este exercício é um ponto de partida valioso para entender como criar, documentar e usar APIs em seus próprios projetos.
 
![imagem da logo jovem programador](https://www.jovemprogramador.com.br/images/jovem_social.jpg)