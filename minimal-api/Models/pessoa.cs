// O C# 9 introduziu um novo tipo para estruturas de dados, chamado Record, que permite ter recursos de objetos em estruturas mais simples.

public record pessoa(Guid Id, string Nome, string Profissao, bool Ativo);