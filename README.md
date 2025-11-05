
# Orbit Ops — Base Project (Next.js + .NET 8 + PostgreSQL)

Estrutura inicial do projeto Orbit Ops com:
- Frontend: Next.js (TypeScript, App Router)
- Backend: ASP.NET Core 8 Web API (C#)
- Banco: PostgreSQL
- Autenticação: JWT (roles: Admin, Dev, Comercial)
- Infra: Docker + docker-compose
- CI: GitHub Actions (workflow exemplo incluso)

⚠️ Este é um *starter kit* — contém a estrutura, código base e exemplos. Ajuste segredos e variáveis no `.env` antes de rodar.

## Como rodar (local com Docker)
1. Copie `.env.example` para `.env` e ajuste variáveis.
2. `docker-compose up --build`
3. Frontend em http://localhost:3000
4. Backend em http://localhost:5000 (API)

## auxilio e reajustes
O backend usa EF Core + Npgsql; o template cria o banco automaticamente via EnsureCreated() (starter approach). Para produção, troque por migrations e estratégia adequada.

JWT está configurado de forma básica — troque JWT_SECRET no .env antes de usar.

Arquivos de build (dotnet, npm) não foram executados aqui — você precisa rodar docker-compose up --build no seu ambiente com Docker instalado.

O frontend faz rewrites para NEXT_PUBLIC_API_URL/api/* — ajuste se necessário.

# orbit-ops-starter
