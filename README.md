# TurismoApp 🌍

Sistema web desenvolvido em ASP.NET Core Razor Pages semdo parte da atividade proposta na matéria **Desenvolvimento Web com .NET e Bases de Dados** para gerenciar clientes, pacotes turísticos, reservas, cidades e países de destino.

## 🏗️ Tecnologias Utilizadas

- ASP.NET Core 9.0
- Entity Framework Core (EF Core)
- Razor Pages
- C#
- SQL Lite (via EF Core)

## 🎯 Funcionalidades Implementadas

✔️ CRUD completo para:
- **Clientes** (com exclusão lógica via campo `IsDeleted`)
- **Pacotes Turísticos**
- **Reservas**
- **Cidades de Destino**
- **Países de Destino**

✔️ Relacionamentos:
- Cliente 1:N Reserva
- PacoteTuristico 1:N Reserva
- PacoteTuristico N:M CidadeDestino
- CidadeDestino N:1 PaisDestino

✔️ Eventos:
- Disparo de evento `CapacityReached` ao atingir a capacidade máxima de um pacote.

✔️ Lógica de negócios:
- Cálculo automático do valor da reserva via `Func` e delegate de desconto.
- Exclusão lógica no Cliente (filtro aplicado no contexto via `HasQueryFilter`).

✔️ Validações:
- Data Annotations aplicadas nas entidades (`[Required]`, `[MinLength]`, `[Range]` etc.).
- Mensagens de validação exibidas no front via Razor.

✔️ Autenticação:
- Sistema simples de login hardcoded com controle de acesso via `[Authorize]`.
- Middleware de autenticação configurado no `Program.cs`.

