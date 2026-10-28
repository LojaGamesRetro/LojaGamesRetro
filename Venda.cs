
using System;
using System.Collections.Generic;

namespace LojaGamesRetro;

public class Venda
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Data { get; set; } = DateTime.Now;
    public List<ItemVenda> Itens { get; set; } = new();
    public decimal Total { get; set; }
}
