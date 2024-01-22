using ResTIConnect.Domain;
using ResTIConnect.Infra;

namespace ResTIConnect.EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new ResTIConnectContext();
            var crudService  = new CrudService(context);

            Console.WriteLine("Criando um novo usuário no banco de dados...");
            var usuario1 = new Usuario
            {
                Nome = "João da Silva",
                Apelido = "João",
                Email = "joao@email.com",
                Senha = "123456",
                Telefone = "999999999",
                Endereco = new Endereco
                {
                    Logradouro = "Rua dos Bobos",
                    Numero = 0,
                    Cidade = "São Paulo",
                    Complemento = "Apto 123",
                    Bairro = "Vila do Chaves",
                    Estado = "SP",
                    Cep = "00000-000",
                    Pais = "Brasil"
                },
                Perfis = new List<Perfil>
                    {
                        new Perfil
                        {
                            Descricao = "Administrador",
                            Permissoes = "Administrador"
                        }
                    }
            };

            crudService.Create(usuario1);

            Console.WriteLine("Usuário criado com sucesso!");

            Console.WriteLine("Listando todos os usuários do banco de dados...");

            var usuarios = crudService.GetAll<Usuario>();            

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Usuário: {usuario.Nome}");
                Console.WriteLine($"Apelido: {usuario.Apelido}");
                Console.WriteLine($"Email: {usuario.Email}");
                Console.WriteLine($"Senha: {usuario.Senha}");
                Console.WriteLine($"Telefone: {usuario.Telefone}");
                Console.WriteLine($"Endereço: {usuario.Endereco.Logradouro}, {usuario.Endereco.Numero}");
                Console.WriteLine($"Cidade: {usuario.Endereco.Cidade}");
                Console.WriteLine($"Complemento: {usuario.Endereco.Complemento}");
                Console.WriteLine($"Bairro: {usuario.Endereco.Bairro}");
                Console.WriteLine($"Estado: {usuario.Endereco.Estado}");
                Console.WriteLine($"CEP: {usuario.Endereco.Cep}");
                Console.WriteLine($"País: {usuario.Endereco.Pais}");
                Console.WriteLine($"Perfis: {usuario.Perfis.Select(p => p.Descricao).Aggregate((p1, p2) => $"{p1}, {p2}")}");
                Console.WriteLine();
            }

            Console.WriteLine("Listagem concluída!");

            Console.WriteLine("Atualizando o usuário criado...");

            usuario1.Nome = "João da Silva Santos";

            crudService.Update(usuario1);

            Console.WriteLine("Verificando se o usuário foi atualizado...");

            var usuarioAtualizado = crudService.GetByFilter<Usuario>(u => u.Nome == "João da Silva Santos");

            if (usuarioAtualizado != null)
            {
                Console.WriteLine($"Usuário atualizado: {usuarioAtualizado.Nome}");
            }
            else
            {
                Console.WriteLine("Usuário não foi atualizado!");
            }


            Console.WriteLine("Deletando o usuário criado...");

            crudService.Delete(usuario1);

            Console.WriteLine("Verificando se o usuário foi deletado...");

            var usuarioDeletado = crudService.GetByFilter<Usuario>(u => u.Nome == "João da Silva Santos");

            if (usuarioDeletado != null)
            {
                Console.WriteLine("Usuário não foi deletado!");
            }
            else
            {
                Console.WriteLine($"Usuário deletado com sucesso!");
            }

        }
    }
}
