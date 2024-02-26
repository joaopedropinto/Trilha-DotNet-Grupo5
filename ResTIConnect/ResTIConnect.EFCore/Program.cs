using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;

namespace ResTIConnect.EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new ResTIConnectContext();
            var crudService = new CrudService(context);
            
            // Deletar todos os registros do banco de dados
            context.Usuarios.RemoveRange(context.Usuarios);
            context.Perfis.RemoveRange(context.Perfis);
            context.Enderecos.RemoveRange(context.Enderecos);
            context.Sistemas.RemoveRange(context.Sistemas);
            context.Eventos.RemoveRange(context.Eventos);
            context.SaveChanges();

            // Criar novos registros no banco de dados
            RunUserOperations(crudService);
            RunEventOperations(crudService);
            RunSystemOperations(crudService);
        }

        private static void RunSystemOperations(CrudService crudService)
        {
            Console.WriteLine("\nCriando um novo sistema no banco de dados...");

            var sistema1 = new Sistema
            {
                Descricao = "Sistema de Teste",
                Tipo = "Sistema de Teste",
                EnderecoEntrada = "http://localhost:5000",
                EnderecoSaida = "http://localhost:5000",
                Protocolo = "http",
                DataHoraInicioIntegracao = DateTimeOffset.Now,
                Status = "Ativo"
            };

            var usuario = crudService.GetByFilter<Usuario>(u => u.Nome == "Maria da Silva");

            sistema1.Usuarios.Add(usuario);


            var usuario2 = new Usuario
            {
                Nome = "Romario Fernandes",
                Apelido = "Romario",
                Email = "romario@email.com",
                Senha = "123456",
                Telefone = "999999999",
                Endereco = new Endereco
                {
                    Logradouro = "Rua dos Novos",
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
                            Descricao = "Usuário2",
                            Permissoes = "Usuário2"
                        }
                    }

            };

            crudService.Create(usuario2);

            var evento1 = crudService.GetByFilter<Evento>(e => e.Tipo == "Evento de Teste 2");

            sistema1.Eventos.Add(evento1);


            var sistema2 = new Sistema
            {
                Descricao = "Sistema de Teste 2",
                Tipo = "Sistema de Teste 2",
                EnderecoEntrada = "http://localhost:5000",
                EnderecoSaida = "http://localhost:5000",
                Protocolo = "http",
                DataHoraInicioIntegracao = DateTimeOffset.Now,
                Status = "Ativo"
            };

            var usuario3 = crudService.GetByFilter<Usuario>(u => u.Nome == "Romario Fernandes");

            sistema2.Usuarios.Add(usuario3);

            crudService.Create(sistema1);
            crudService.Create(sistema2);

            Console.WriteLine("Sistema criado com sucesso!");

            Console.WriteLine("Listando todos os sistemas do banco de dados...");

            var sistemas = crudService.GetAll<Sistema>();

            foreach (var sistema in sistemas)
            {
                Console.WriteLine($"Sistema: {sistema.Descricao}");
                Console.WriteLine($"Tipo: {sistema.Tipo}");
                Console.WriteLine($"Endereço de Entrada: {sistema.EnderecoEntrada}");
                Console.WriteLine($"Endereço de Saída: {sistema.EnderecoSaida}");
                Console.WriteLine($"Protocolo: {sistema.Protocolo}");
                Console.WriteLine($"Data e Hora de Início da Integração: {sistema.DataHoraInicioIntegracao}");
                Console.WriteLine($"Status: {sistema.Status}");
                if (sistema.Usuarios.Any())
                {
                    Console.WriteLine($"Usuários: {sistema.Usuarios.Select(u => u.Nome).Aggregate((u1, u2) => $"{u1}, {u2}")}");
                }
                else
                {
                    Console.WriteLine("Usuários: Nenhum usuário associado.");
                }
                if (sistema.Eventos.Any())
                {
                    Console.WriteLine($"Eventos: {sistema.Eventos.Select(e => e.Tipo).Aggregate((e1, e2) => $"{e1}, {e2}")}");
                }
                else
                {
                    Console.WriteLine("Eventos: Nenhum evento associado.");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Listagem concluída!");

            Console.WriteLine("Atualizando o sistema criado...");

            sistema1.Descricao = "Sistema de Teste Atualizado";

            crudService.Update(sistema1);

            Console.WriteLine("Verificando se o sistema foi atualizado...");

            var sistemaAtualizado = crudService.GetByFilter<Sistema>(s => s.Descricao == "Sistema de Teste Atualizado");

            if (sistemaAtualizado != null)
            {
                Console.WriteLine($"Sistema atualizado: {sistemaAtualizado.Descricao}");
            }
            else
            {
                Console.WriteLine("Sistema não foi atualizado!");
            }

            Console.WriteLine("Deletando o sistema criado...");

            crudService.Delete(sistema1);

            Console.WriteLine("Verificando se o sistema foi deletado...");

            var sistemaDeletado = crudService.GetByFilter<Sistema>(s => s.Descricao == "Sistema de Teste Atualizado");

            if (sistemaDeletado != null)
            {
                Console.WriteLine("Sistema não foi deletado!");
            }
            else
            {
                Console.WriteLine($"Sistema deletado com sucesso!");
            }
        }

        private static void RunEventOperations(CrudService crudService)
        {
            Console.WriteLine("\nCriando um novo evento no banco de dados...");
            var evento1 = new Evento
            {
                Tipo = "Evento de Teste",
                Descricao = "Evento de Teste",
                Codigo = "123456",
                Conteudo = "Conteúdo do Evento de Teste",
                DataHoraOcorrencia = DateTimeOffset.Now
            };

            var evento2 = new Evento
            {
                Tipo = "Evento de Teste 2",
                Descricao = "Evento de Teste 2",
                Codigo = "123456",
                Conteudo = "Conteúdo do Evento de Teste 2",
                DataHoraOcorrencia = DateTimeOffset.Now
            };

            crudService.Create(evento1);
            crudService.Create(evento2);

            Console.WriteLine("Eventos criados com sucesso!");

            Console.WriteLine("Listando todos os eventos do banco de dados...");

            var eventos = crudService.GetAll<Evento>();

            foreach (var evento in eventos)
            {
                Console.WriteLine($"Evento: {evento.Tipo}");
                Console.WriteLine($"Descrição: {evento.Descricao}");
                Console.WriteLine($"Código: {evento.Codigo}");
                Console.WriteLine($"Conteúdo: {evento.Conteudo}");
                Console.WriteLine($"Data e Hora de Ocorrência: {evento.DataHoraOcorrencia}");
                Console.WriteLine();
            }

            Console.WriteLine("Listagem concluída!");

            Console.WriteLine("Atualizando o evento criado...");

            evento1.Tipo = "Evento de Teste Atualizado";

            crudService.Update(evento1);

            Console.WriteLine("Verificando se o evento foi atualizado...");

            var eventoAtualizado = crudService.GetByFilter<Evento>(e => e.Tipo == "Evento de Teste Atualizado");

            if (eventoAtualizado != null)
            {
                Console.WriteLine($"Evento atualizado: {eventoAtualizado.Tipo}");
            }
            else
            {
                Console.WriteLine("Evento não foi atualizado!");
            }

            Console.WriteLine("Deletando o evento criado...");

            crudService.Delete(evento1);

            Console.WriteLine("Verificando se o evento foi deletado...");

            var eventoDeletado = crudService.GetByFilter<Evento>(e => e.Tipo == "Evento de Teste Atualizado");

            if (eventoDeletado != null)
            {
                Console.WriteLine("Evento não foi deletado!");
            }
            else
            {
                Console.WriteLine($"Evento deletado com sucesso!");
            }
        }

        private static void RunUserOperations(CrudService crudService)
        {

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

            var usuario2 = new Usuario
            {
                Nome = "Maria da Silva",
                Apelido = "Maria",
                Email = "maria@email.com",
                Senha = "123456",
                Telefone = "999999999",
                Endereco = new Endereco
                {
                    Logradouro = "Rua dos Espertos",
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
                            Descricao = "Usuário",
                            Permissoes = "Usuário"
                        }
                    }

            };

            crudService.Create(usuario1);
            crudService.Create(usuario2);

            Console.WriteLine("Usuários criados com sucesso!");

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
