# 🚀 Projeto Hackathon – API de Telemetria e Gestão

Aqui está a implementação de uma API de simulação de Crédito em .NET desenvolvida durante o hackathon, seguindo boas práticas de arquitetura em camadas (Domain, Application, Infra, Interfaces e API) para garantir escalabilidade, manutenibilidade e clareza na separação de responsabilidades.

# 📌 Sumário

- [Tecnologias Utilizadas](#️-tecnologias-utilizadas)
- [Execução do Projeto](#️-execução-do-projeto)
- [Exemplos de Uso](#-exemplos-de-uso)
- [Validações](#-validações)
- [Telemetria e Métricas](#-telemetria-e-métricas)

# ⚙️ Tecnologias Utilizadas

- .NET 8
- Entity Framework Core – Acesso ao SQL Server (interno e externo)
- MongoDB Driver – Controle de métricas em NoSQL
- FluentValidation – Validação de DTOs
- Serilog - Logs detalhados das requisições da API
- Docker & Docker Compose – Configuração de ambiente

# ▶️ Execução do Projeto

Suba os containers:

docker-compose up --build

A API ficará disponível em:
👉 http://127.0.0.1:8080

# 📚 Exemplos de Uso
## Criar Simulação de Crédito
#### POST | http://127.0.0.1:8080/api/simulacoes
- JSON body:
```
{
  "valorDesejado": 900,
  "prazo": 5 
}
```

## Obter Simulações de Crédito
#### GET | http://127.0.0.1:8080/api/simulacoes?page=1&pageSize=10

## Obter Simulações de Crédito por Produto
#### GET | http://127.0.0.1:8080/api/simulacoes/por-produto

## Obter Dados de Telemetria por Serviço
#### GET | http://127.0.0.1:8080/api/telemetrias?dataReferencia=2025-07-30
- Data referência sendo opcional (caso não passada retorna os dados do dia atual)


# ✅ Validações

Os DTOs são validados via FluentValidation.
Exemplo de regra:
- Campos decimal devem ser positivos
- Campos short devem ser maiores que 0

# 📊 Telemetria e Métricas

Para aumentar a performance e reduzir a carga no SQL Server, a API utiliza o MongoDB como repositório de telemetria.

Cada requisição gera métricas como:
- Endpoint acessado
- Método HTTP
- Status da resposta (HTTP status code)
- Duração da requisição

Com essa abordagem, mantemos o SQL Server voltado apenas às operações de negócio, enquanto o MongoDB garante consultas rápidas e eficientes para relatórios de telemetria.