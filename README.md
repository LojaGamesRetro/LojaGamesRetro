# 🎮 Loja Games Retrô

**Checkpoint 3 — C# Development**

**Curso:** Engenharia de Software — FIAP  
**Turma:** 3ESPS  
**Professor:** Wellington Cidade Silva

## 📌 Sobre o Projeto

A **Loja Games Retrô** é um sistema desktop desenvolvido em C# utilizando Windows Forms e .NET.

O objetivo é simular o funcionamento de uma loja de jogos clássicos, permitindo visualizar produtos, adicionar jogos ao carrinho, finalizar pedidos e consultar relatórios de vendas.

O projeto foi desenvolvido como atividade individual para o Checkpoint 3 da disciplina de C# Development.

## 🛠️ Tecnologias Utilizadas

- C#
- .NET 8
- Windows Forms
- Visual Studio 2026
- JSON para persistência de dados
- Git e GitHub para versionamento

## 🚀 Funcionalidades

### 1. Tela Splash

- Tela de abertura da aplicação.
- Barra de progresso automática.
- Carregamento utilizando Timer.
- Navegação automática para o Menu Principal.

### 2. Menu Principal

- Interface de navegação.
- Acesso ao Catálogo de Jogos.
- Acesso ao Relatório de Vendas.
- Botão para encerrar a aplicação.

### 3. Catálogo de Jogos

- Exibição dos jogos em cards.
- Informações de nome, console e preço.
- Carrinho de compras.
- Adição e remoção de produtos.
- Controle de quantidade de itens.
- Cálculo automático de subtotais e valor total.
- Confirmação e finalização de pedidos.

### 4. Relatório de Vendas

- Histórico de pedidos realizados.
- Visualização de jogos vendidos e valores.
- Quantidade total de pedidos.
- Quantidade de jogos vendidos.
- Faturamento total.
- Pesquisa por nome do jogo ou código do pedido.
- Filtros por período.
- Atualização dos dados.

## 💾 Armazenamento de Dados

As vendas são armazenadas em um arquivo JSON, permitindo que os pedidos continuem disponíveis após o fechamento da aplicação.

Cada venda contém:

- Identificador único.
- Data e horário.
- Jogos comprados.
- Quantidade de cada produto.
- Preço unitário.
- Valor total do pedido.

O arquivo de vendas é salvo na pasta de dados locais do usuário, em `AppData\Local\LojaGamesRetro\vendas.json`.

## ▶️ Como Executar

**Pré-requisitos:**

- Windows.
- Visual Studio com suporte ao desenvolvimento desktop .NET.
- SDK .NET 8.

**Passos:**

1. Clone ou baixe este repositório.
2. Abra o arquivo `LojaGamesRetro.slnx` no Visual Studio.
3. Aguarde o carregamento da solução.
4. Compile o projeto.
5. Pressione **F5** para executar.

A aplicação iniciará pela tela Splash e abrirá automaticamente o Menu Principal.

## 🌿 Organização do Git

O projeto utiliza as seguintes branches:

- `main` — Versão final do projeto.
- `dev` — Integração das funcionalidades.
- `feature/splash` — Desenvolvimento da tela Splash.
- `feature/menu` — Desenvolvimento do Menu Principal.
- `feature/catalogo` — Desenvolvimento do catálogo e pedidos.
- `feature/relatorio` — Desenvolvimento do relatório.
- `feature/entrega` — Documentação final.

O desenvolvimento utiliza commits semânticos e Pull Requests para integração das funcionalidades.

## 👨‍💻 Autor

**Nome:** Musashi Mabuti
**RM:** 559444

Projeto acadêmico desenvolvido para a FIAP — Engenharia de Software.