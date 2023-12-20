using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTNET_P002
{
    public static class Valber
    {
        public static string Name => "Valber Francisco dos Santos";
        public static List<(string, int)> Skills => new List<(string, int)>
        {
            ("Fundamentos de C#", 5),
            ("Habilidades Gerais de Desenvolvimento", 4),
            ("Fundamentos de Banco de Dados", 5),
            ("Fundamentos básicos de ASP.NET Core", 2),
            ("ORM", 2),
            ("Injeção de Dependência", 3),
            ("Caching", 1),
            ("Log Frameworks", 1),
            ("Banco de Dados", 4),
            ("API Cliente e Comunicação", 3),
            ("Comunicação em tempo real", 1),
            ("Mapeamento de Objeto", 1),
            ("Marcação de tarefas", 2),
            ("Testagem", 2),
            ("Micro-Serviços", 2),
            ("CI/CD", 2),
            ("Design e Arquitetura de software", 2),
            ("Bibliotecas de cliente", 3),
            ("Engine de template", 1),
            ("Bibliotecas adicionais", 3)
        };

        public static string View()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach (var skill in Skills)
            {
                sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
            }
            var sum = Skills.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
        }
    }
}
