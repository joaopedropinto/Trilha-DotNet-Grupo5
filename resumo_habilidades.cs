using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

public static class Equipe
{
    public static List<(string, int)> ObterHabilidadesDaEquipe()
    {
        // Lista para armazenar as habilidades de todos os membros
        var habilidadesTotais = new List<(string, int)>();

        // Obter todos os arquivos no diretório com extensão .cs
        var arquivosMembros = Directory.GetFiles(".", "*.cs");

        // Para cada arquivo de membro, obter suas habilidades e adicionar à lista total
        foreach (var arquivoMembro in arquivosMembros)
        {
            var habilidadesMembro = ObterHabilidadesDoMembro(arquivoMembro);
            habilidadesTotais.AddRange(habilidadesMembro);
        }

        return habilidadesTotais;
    }

    public static string ResumoDaEquipe()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Resumo das Habilidades da Equipe:");

        // Obter as habilidades da equipe
        var habilidadesTotais = ObterHabilidadesDaEquipe();

        // Exibir o resumo para cada habilidade
        foreach (var habilidade in habilidadesTotais)
        {
            sb.AppendLine($"\t{habilidade.Item1} - {habilidade.Item2} estrelas");
        }

        // Calcular a soma total de estrelas da equipe
        var somaTotal = habilidadesTotais.Sum(x => x.Item2);
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas da equipe: {somaTotal}");

        return sb.ToString();
    }

    private static List<(string, int)> ObterHabilidadesDoMembro(string caminhoArquivo)
    {
        // Lógica para ler o arquivo e extrair habilidades
        var conteudoArquivo = File.ReadAllText(caminhoArquivo);

        // Obtém o nome do membro a partir do nome do arquivo (remove a extensão .cs)
        var nomeMembro = Path.GetFileNameWithoutExtension(caminhoArquivo);

        // Usa reflection para chamar dinamicamente o método View do membro
        var tipoMembro = Type.GetType(nomeMembro);
        var metodoView = tipoMembro?.GetMethod("View");
        var habilidades = metodoView?.Invoke(null, null) as string;

        // Implemente a lógica para extrair habilidades do conteúdo do arquivo
        // Exemplo: var habilidades = ExtrairHabilidades(conteudoArquivo);

        // Retorne a lista de habilidades do membro
        // return habilidades;

        // Observação: Certifique-se de implementar a lógica adequada para o seu cenário real
        return new List<(string, int)>();
    }
}
