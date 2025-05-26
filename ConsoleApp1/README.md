# Sistema de Triagem e Atendimento Hospitalar

Este projeto em C# simula o fluxo de atendimento de um hospital, com pacientes passando pelas etapas de cadastro, triagem e consulta médica. O sistema utiliza uma Queue para organizar os pacientes aguardando triagem, uma PriorityQueue para a triagem (com base nos dados de saúde) e uma Stack para o histórico de atendimentos médicos. Ele possui um menu interativo via terminal, com uso de cores para tornar a visualização mais clara e agradável.

## Instalação

1. Clone o repositório para sua máquina local:

```bash
  git clone https://github.com/itswayron/ed0605
```

2. Abra o projeto em sua IDE preferida (Visual Studio, Rider, VS Code com extensão C#).
3. Compile o projeto para garantir que não há erros.
4. Execute o projeto diretamente pela IDE ou no terminal, usando o comando:
```bash
  dotnet run
```

## Pré-requisitos de Execução
- .NET SDK instalado (versão 8.0 ou superior recomendada).
- Console/terminal com suporte a sequências ANSI para cores (a maioria dos terminais modernos suporta, como Windows Terminal, PowerShell, Linux terminal e macOS Terminal).
- Ambiente de desenvolvimento C# (Visual Studio, VS Code, Rider, ou apenas linha de comando).

## Exemplos de Uso

Ao iniciar o programa, o menu principal é exibido:
``` markdown
Bem vindo ao hospital Santa Cruz.

Atendimento: [Lista de pacientes aguardando triagem]
Triagem: [Lista de pacientes na triagem com prioridade]

======= MENU =======
1. Cadastrar paciente no atendimento.
2. Chamar paciente para a triagem.
3. Chamar o paciente para o atendimento.
4. Mostrar histórico de atendimentos clínicos.
5. Mostrar histórico de atendimentos com os dados de saúde.
6. Cadastrar vários usuários na triagem.
```

Fluxo sugerido de uso:

1. Cadastre um paciente.
2. Faça a triagem (onde serão coletados dados clínicos).
3. O médico chama o paciente com maior prioridade.
4. Visualize o histórico de atendimentos.

## Estrutura do Menu e Comandos Disponíveis

### Menu Inicial

0.	Sair do sistema.
1.	Cadastrar paciente no atendimento (adiciona à fila de triagem).
2.	Chamar paciente para a triagem (coleta dados clínicos e prioriza).
3.	Chamar o paciente para o atendimento (consulta médica).
4.	Mostrar histórico de atendimentos (nomes).
5.	Mostrar histórico com dados clínicos (pressão, temperatura etc.).
6.	Cadastrar vários pacientes automaticamente para testes.

## Lógica de Prioridade na Triagem

A prioridade dos pacientes é calculada com base nos seguintes critérios:

- Pressão > 18 → +1 ponto
- Temperatura > 39.0°C → +1 ponto
- Oxigenação < 90% → +1 ponto

### Conversão da pontuação:

| Pontos | 	Prioridade | 	Cor      |
|--------|-------------|-----------|
| 3      | 	Máxima     | 	Vermelha |
| 2      | 	Média      | 	Amarela  |
| 0-1    | 	Normal     | 	Verde    |
