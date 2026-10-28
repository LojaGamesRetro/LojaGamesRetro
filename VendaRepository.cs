
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LojaGamesRetro;

public static class VendaRepository
{
    private static readonly string pastaDados =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData
            ),
            "LojaGamesRetro"
        );
    private static readonly string caminhoArquivo =
        Path.Combine(pastaDados, "vendas.json");

    public static List<Venda> Listar()
    {
        if (!File.Exists(caminhoArquivo))
        {
            return new List<Venda>();
        }

        string json = File.ReadAllText(caminhoArquivo);

        List<Venda>? vendas =
            JsonSerializer.Deserialize<List<Venda>>(json);

        return vendas ?? new List<Venda>();
    }

    public static void Salvar(Venda venda)
    {
        List<Venda> vendas = Listar();

        vendas.Add(venda);

        Directory.CreateDirectory(pastaDados);

        string json = JsonSerializer.Serialize(
            vendas,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText(caminhoArquivo, json);
    }
}
