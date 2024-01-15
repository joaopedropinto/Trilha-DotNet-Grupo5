using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTNET_P002
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var kayqueReport = Kayque.View();
            var joaoReport = Joao.View();
            var valberReport = Valber.View();
            var jhonataReport = Jhonata.View();
            var danielReport = Daniel.View();

            app.MapGet("/", () => View());
            app.MapGet("/valber/", () => Valber.View());
            app.MapGet("/jhonata/", () => Jhonata.View());
            app.MapGet("/joao/", () => Joao.View());
            app.MapGet("/kayque/", () => Kayque.View());
            app.MapGet("/daniel/", () => Daniel.View());
            app.Run();
        }

        public static string View()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Resumo das Habilidades da Equipe:\n");
            sb.AppendLine(Kayque.View());
            sb.AppendLine(Joao.View());
            sb.AppendLine(Valber.View());
            sb.AppendLine(Jhonata.View());
            sb.AppendLine(Daniel.View());

            var totalStars = Kayque.Skills.Sum(skill => skill.Item2) +
                             Joao.Skills.Sum(skill => skill.Item2) +
                             Valber.Skills.Sum(skill => skill.Item2) +
                             Jhonata.Skills.Sum(skill => skill.Item2)+
                             Daniel.Skills.Sum(skill => skill.Item2);

            sb.AppendLine($"\nTotal de estrelas da equipe: {totalStars}\n");

            return sb.ToString();
        }
    }
}