
namespace LojaGamesRetro;

public class ItemVenda
{
    public string Nome { get; set; } = "";

    public string Console { get; set; } = "";

    public decimal PrecoUnitario { get; set; }

    public int Quantidade { get; set; }

    public decimal Subtotal
    {
        get
        {
            return PrecoUnitario * Quantidade;
        }
    }
}
