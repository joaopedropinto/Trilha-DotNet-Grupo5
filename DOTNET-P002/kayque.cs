using System.Text;

namespace DOTNET_P112;
public static class Kayque{
      public static string Name => "Kayque Piton";
      public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 4),
            ("Habilidades Gerais de Desenvolvimento",4) ,
            ("Fundamentos de Banco de Dados", 4),
            ("Fundamentos basicos de ASP.NET Core", 2),
            ("ORM", 2),
            ("Injeção de Dependencia", 1),
            ("Caching", 1),
            ("Log Frameworks", 1),
            ("Banco de Dados", 3),
            ("API Cliente e Comunicação", 1),
            ("Comunicação em tempo real", 1),
            ("Mapeamento de Objeto", 1),
            ("Marcação de tarefas", 1),
            ("Testagem", 2),
            ("Micro-Serviços", 1),
            ("CI/CD", 1),
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