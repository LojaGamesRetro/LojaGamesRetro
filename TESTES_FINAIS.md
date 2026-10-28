# Testes Finais — Loja Games Retrô

**Checkpoint 3 — C# Development**  
**Curso:** Engenharia de Software — FIAP  
**Turma:** 3ESPS

## 1. Objetivo

Validar o funcionamento das funcionalidades implementadas no sistema Loja Games Retrô, garantindo que as telas, os pedidos, os cálculos e o armazenamento das vendas estejam funcionando corretamente.

## 2. Ambiente de Testes

- Linguagem: C#
- Framework: .NET 8
- Interface: Windows Forms
- IDE: Visual Studio 2026
- Sistema operacional: Windows
- Persistência: JSON

## 3. Testes Realizados

### 3.1. Tela Splash

- [x] A aplicação inicia pela tela Splash.
- [x] A barra de progresso funciona corretamente.
- [x] O carregamento chega a 100%.
- [x] O Menu Principal abre automaticamente.

### 3.2. Menu Principal

- [x] O botão Catálogo de Jogos abre a tela correta.
- [x] O botão Relatório de Vendas abre a tela correta.
- [x] O botão Sair encerra a aplicação.
- [x] É possível retornar ao menu após fechar as outras telas.

### 3.3. Catálogo de Jogos

- [x] Os oito jogos cadastrados são exibidos.
- [x] Cada card apresenta nome, console e preço.
- [x] O botão Adicionar ao Carrinho funciona.
- [x] A lista de jogos permite rolagem.

### 3.4. Carrinho de Compras

- [x] É possível adicionar diferentes jogos.
- [x] Adicionar o mesmo jogo aumenta sua quantidade.
- [x] O subtotal dos produtos é calculado corretamente.
- [x] O valor total do carrinho é atualizado automaticamente.
- [x] É possível remover itens do carrinho.
- [x] O sistema impede a finalização de um carrinho vazio.

### 3.5. Finalização de Pedidos

- [x] O sistema solicita confirmação antes de finalizar.
- [x] A compra recebe um identificador único.
- [x] Os dados da venda são salvos em JSON.
- [x] O carrinho é limpo após o salvamento.
- [x] As vendas anteriores são preservadas.
- [x] Os pedidos continuam disponíveis após reiniciar a aplicação.

### 3.6. Relatório de Vendas

- [x] Os pedidos salvos são exibidos na tabela.
- [x] Cada pedido apresenta código, data, jogos e total.
- [x] O indicador de pedidos mostra o valor correto.
- [x] A quantidade de jogos vendidos é calculada corretamente.
- [x] O faturamento total é calculado corretamente.
- [x] A pesquisa por jogo funciona.
- [x] A pesquisa por código do pedido funciona.
- [x] Os filtros por período funcionam.
- [x] O botão Atualizar recarrega os dados.

## 4. Teste de Integração

Fluxo completo da aplicação:

1. Iniciar a aplicação.
2. Aguardar o carregamento da Splash.
3. Abrir o Catálogo de Jogos.
4. Adicionar jogos ao carrinho.
5. Conferir o valor total.
6. Finalizar o pedido.
7. Voltar ao Menu Principal.
8. Abrir o Relatório de Vendas.
9. Verificar o pedido registrado.
10. Fechar e reabrir a aplicação para confirmar a persistência.

**Resultado:** Pendente de validação final.

## 5. Compilação

Comando utilizado:

`dotnet build`

**Resultado:** Pendente de confirmação.

## 6. Conclusão

O sistema será considerado validado quando todos os testes obrigatórios forem aprovados e a compilação ocorrer sem erros.

**Situação final:** Pendente de validação.