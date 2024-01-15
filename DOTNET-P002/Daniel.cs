using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DOTNET_P002;

public class Daniel{
 public static string Name => "Daniel Penedo";
      public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 4),
            ("Habilidades Gerais de Desenvolvimento",3) ,
            ("Fundamentos de Banco de Dados", 4),
            ("Fundamentos basicos de ASP.NET Core", 2),
            ("ORM", 2),
            ("Injeção de Dependencia", 0),
            ("Caching", 0),
            ("Log Frameworks", 0),
            ("Banco de Dados", 4),
            ("API Cliente e Comunicação", 1),
            ("Comunicação em tempo real", 1),
            ("Mapeamento de Objeto", 1),
            ("Marcação de tarefas", 1),
            ("Testagem", 1),
            ("Micro-Serviços", 0),
            ("CI/CD", 0),
            ("Design e Arquitetura de software", 2),
            ("Bibliotecas de cliente", 2),
            ("Engine de template", 1),
            ("Bibliotecas adicionais", 1)
         };
      public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach(var skill in Skills){
                  sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
            }
            var sum = Skills.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
      }
}