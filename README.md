 # Projeto MetaCash - Target

Este repositório contém a solução desenvolvida para o técnico da **Target**. A aplicação foi construída em **C# (.NET 8)** utilizando o formato de Console Application e segue os princípios de separação de responsabilidades e boas práticas de código.

## Tecnologias Utilizadas
- **C# / .NET 8:** Plataforma principal de desenvolvimento.
- **System.Text.Json:** Para leitura e desserialização nativa e eficiente dos dados.
- **Git:** Para versionamento de código estruturado (commits semânticos).

## Arquitetura e Estrutura do Projeto
O projeto foi dividido em camadas lógicas para facilitar a manutenção e leitura:
- `/Data`: Contém os arquivos `.json` fornecidos no escopo.
- `/Models`: Classes de domínio (POCOs) mapeando a estrutura dos dados (Venda, Produto).
- `/Services`: Classes de serviço contendo estritamente as regras de negócio.

## Implementados

### Cálculo de Comissões
Processamento de um arquivo JSON contendo registros de vendas, agrupando os dados por vendedor e aplicando a seguinte regra de negócios:
- Vendas < R$100,00: Sem comissão.
- Vendas entre R$100,00 e R$499,99: 1% de comissão.
- Vendas >= R$500,00: 5% de comissão.

### Movimentação de Estoque
Leitura do inventário inicial via JSON com simulação de entradas e saídas.
- Geração de um ID único para cada transação (Guid).
- Bloqueio de saída de produtos caso não haja saldo suficiente no estoque.
- Atualização em tempo de execução da quantidade final.

### Cálculo de Juros por Atraso
Algoritmo que avalia a data de vencimento em relação à data atual (DateTime).
- Se estiver no prazo, isenta de multas.
- Se houver atraso, aplica-se juros simples de 2,5% ao dia sobre o valor original.

## Como Executar
1. Certifique-se de ter o [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone o repositório:
   ```bash
   git clone [https://github.com/Karinepego/MetaCash.git](https://github.com/Karinepego/MetaCash.git)