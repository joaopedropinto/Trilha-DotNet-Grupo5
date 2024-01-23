using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Domain;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new OrdemServicoContext())
        {
            // Create
            var newCliente = new Cliente
            {
                CPF = "12345678901",
                Nome = "Nome do Cliente",
                Telefone = "123456789",
                Email = "cliente@email.com",
                Endereco = "Rua do Cliente, 123"
            };

            context.Cliente.Add(newCliente);
            context.SaveChanges();

            // Read
            var cliente = context.Cliente.FirstOrDefault(c => c.ClienteID == newCliente.ClienteID);
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nome}");
            }

            // Update
            if (cliente != null)
            {
                cliente.Nome = "Novo Nome do Cliente";
                context.SaveChanges();
                Console.WriteLine($"Cliente atualizado: {cliente.Nome}");
            }

            // Delete
            if (cliente != null)
            {
                context.Cliente.Remove(cliente);
                context.SaveChanges();
                Console.WriteLine("Cliente removido");
            }
            // Create
            var newEquipamento = new Equipamento
            {
                Tipo = "Computador",
                Marca = "Marca",
                Modelo = "Modelo",
                DadosAdicionais = "Dados Adicionais",
                DefeitoDeclarado = "Defeito",
                Solucao = "Solução"
            };

            context.Equipamento.Add(newEquipamento);
            context.SaveChanges();

            // Read
            var equipamento = context.Equipamento.FirstOrDefault(e => e.EquipamentoID == newEquipamento.EquipamentoID);
            if (equipamento != null)
            {
                Console.WriteLine($"Equipamento encontrado: {equipamento.Tipo}");
            }

            // Update
            if (equipamento != null)
            {
                equipamento.Tipo = "Novo Tipo";
                context.SaveChanges();
                Console.WriteLine($"Equipamento atualizado: {equipamento.Tipo}");
            }

            // Delete
            if (equipamento != null)
            {
                context.Equipamento.Remove(equipamento);
                context.SaveChanges();
                Console.WriteLine("Equipamento removido");
            }
            // Create
            var newFinalizacao = new Finalizacao
            {
                DataFinalizacao = DateTime.Now,
                Comentario = "Comentário da Finalização"
            };

            context.Finalizacao.Add(newFinalizacao);
            context.SaveChanges();

            // Read
            var finalizacao = context.Finalizacao.FirstOrDefault(f => f.FinalizacaoID == newFinalizacao.FinalizacaoID);
            if (finalizacao != null)
            {
                Console.WriteLine($"Finalização encontrada: {finalizacao.Comentario}");
            }

            // Update
            if (finalizacao != null)
            {
                finalizacao.Comentario = "Novo Comentário";
                context.SaveChanges();
                Console.WriteLine($"Finalização atualizada: {finalizacao.Comentario}");
            }

            // Delete
            if (finalizacao != null)
            {
                context.Finalizacao.Remove(finalizacao);
                context.SaveChanges();
                Console.WriteLine("Finalização removida");
            }
            // Create
            var novaOcorrencia = new Ocorrencia
            {
                Descricao = "Descrição da Ocorrência",
                Situacao = "Situação",
                DataHora = DateTime.Now
            };

            context.Ocorrencia.Add(novaOcorrencia);
            context.SaveChanges();

            // Read
            var ocorrencia = context.Ocorrencia.FirstOrDefault(o => o.OcorrenciaID == novaOcorrencia.OcorrenciaID);
            if (ocorrencia != null)
            {
                Console.WriteLine($"Ocorrência encontrada: {ocorrencia.Descricao}");
            }

            // Update
            if (ocorrencia != null)
            {
                ocorrencia.Descricao = "Nova Descrição";
                context.SaveChanges();
                Console.WriteLine($"Ocorrência atualizada: {ocorrencia.Descricao}");
            }

            // Delete
            if (ocorrencia != null)
            {
                context.Ocorrencia.Remove(ocorrencia);
                context.SaveChanges();
                Console.WriteLine("Ocorrência removida");
            }
            // Create
            var novaOrdemServico = new OrdemServico
            {
                DataAbertura = DateTime.Now,
                Prazo = DateTime.Now.AddDays(7),
                FormaPagamento = "Cartão de Crédito",
                Status = "Em Andamento",
                ClienteID = 1, // Substitua pelo ID do cliente real
                TecnicoID = 1 // Substitua pelo ID do técnico real
            };

            context.OrdemServico.Add(novaOrdemServico);
            context.SaveChanges();

            // Read
            var ordemServico = context.OrdemServico.FirstOrDefault(o => o.OrdemServicoID == novaOrdemServico.OrdemServicoID);
            if (ordemServico != null)
            {
                Console.WriteLine($"Ordem de Serviço encontrada: {ordemServico.Status}");
            }

            // Update
            if (ordemServico != null)
            {
                ordemServico.Status = "Concluído";
                context.SaveChanges();
                Console.WriteLine($"Ordem de Serviço atualizada: {ordemServico.Status}");
            }

            // Delete
            if (ordemServico != null)
            {
                context.OrdemServico.Remove(ordemServico);
                context.SaveChanges();
                Console.WriteLine("Ordem de Serviço removida");
            }
            // Create
            var novoServico = new Servico
            {
                Data = DateTime.Now,
                Descricao = "Descrição do Serviço",
                Valor = 100.00
            };

            context.Servico.Add(novoServico);
            context.SaveChanges();

            // Read
            var servico = context.Servico.FirstOrDefault(s => s.ServicoID == novoServico.ServicoID);
            if (servico != null)
            {
                Console.WriteLine($"Serviço encontrado: {servico.Descricao}");
            }

            // Update
            if (servico != null)
            {
                servico.Descricao = "Nova Descrição do Serviço";
                context.SaveChanges();
                Console.WriteLine($"Serviço atualizado: {servico.Descricao}");
            }

            // Delete
            if (servico != null)
            {
                context.Servico.Remove(servico);
                context.SaveChanges();
                Console.WriteLine("Serviço removido");
            }
            // Create
            var novaPeca = new Peca
            {
                Tipo = "Tipo da Peça",
                Descrição = "Descrição da Peça",
                Valor = 50.00
            };

            context.Peca.Add(novaPeca);
            context.SaveChanges();

            // Read
            var peca = context.Peca.FirstOrDefault(p => p.PecaID == novaPeca.PecaID);
            if (peca != null)
            {
                Console.WriteLine($"Peça encontrada: {peca.Descrição}");
            }

            // Update
            if (peca != null)
            {
                peca.Descrição = "Nova Descrição da Peça";
                context.SaveChanges();
                Console.WriteLine($"Peça atualizada: {peca.Descrição}");
            }

            // Delete
            if (peca != null)
            {
                context.Peca.Remove(peca);
                context.SaveChanges();
                Console.WriteLine("Peça removida");
            }
            // Create
            var novoTecnico = new Tecnico
            {
                Nome = "Nome do Técnico",
                Especialidade = "Especialidade",
                Telefone = "123456789",
                Email = "tecnico@email.com"
            };

            context.Tecnico.Add(novoTecnico);
            context.SaveChanges();

            // Read
            var tecnico = context.Tecnico.FirstOrDefault(t => t.TecnicoID == novoTecnico.TecnicoID);
            if (tecnico != null)
            {
                Console.WriteLine($"Técnico encontrado: {tecnico.Nome}");
            }

            // Update
            if (tecnico != null)
            {
                tecnico.Nome = "Novo Nome do Técnico";
                context.SaveChanges();
                Console.WriteLine($"Técnico atualizado: {tecnico.Nome}");
            }

            // Delete
            if (tecnico != null)
            {
                context.Tecnico.Remove(tecnico);
                context.SaveChanges();
                Console.WriteLine("Técnico removido");
            }
        }

    }
}

