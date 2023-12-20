using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTNET_P002
{
    class Program
    {
        static void Main()
        {
            var kayqueReport = Kayque.View();
            var joaoReport = Joao.View();
            var valberReport = Valber.View();
            var jhonataReport = Jhonata.View();
            
            Console.WriteLine("Resumo das Habilidades da Equipe:\n");
            
            //Kayque Piton
            Console.WriteLine(kayqueReport);
            
            //João Pedro de Gois Pinto")
            Console.WriteLine(joaoReport);
            
            //Valber Francisco dos Santos"
            Console.WriteLine(valberReport);
            
            //Jhonata Araújo"
            Console.WriteLine(jhonataReport);

            var totalStars = Kayque.Skills.Sum(skill => skill.Item2) +
                             Joao.Skills.Sum(skill => skill.Item2) +
                             Valber.Skills.Sum(skill => skill.Item2) +
                             Jhonata.Skills.Sum(skill => skill.Item2);

            Console.WriteLine($"\nTotal de estrelas da equipe: {totalStars}\n");
        }
    }
}
