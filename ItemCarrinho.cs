
namespace LojaGamesRetro;

public class ItemCarrinho
{
    public Jogo Jogo { get; set; }

    public int Quantidade { get; set; }

    public decimal Subtotal
    {
        get
        {
            return Jogo.Preco * Quantidade;
        }
    }

    public ItemCarrinho(Jogo jogo)
    {
        Jogo = jogo;
        Quantidade = 1;
    }
}
