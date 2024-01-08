-- Inserção de dados na tabela Cliente
INSERT INTO Cliente (ID, CPF, CNPJ, Nome, Telefone, Email, Endereco)
VALUES
    (1, '12345678901', NULL, 'Cliente 1', '123456789', 'cliente1@email.com', 'Rua Cliente 1'),
    (2, NULL, '98765432101', 'Cliente 2', '987654321', 'cliente2@email.com', 'Rua Cliente 2');

-- Inserção de dados na tabela Tecnico
INSERT INTO Tecnico (ID, Nome, Especialidade, Telefone, Email)
VALUES
    (1, 'Tecnico 1', 'Especialidade 1', '111222333', 'tecnico1@email.com'),
    (2, 'Tecnico 2', 'Especialidade 2', '444555666', 'tecnico2@email.com');

-- Inserção de dados na tabela Equipamento
INSERT INTO Equipamento (ID, Tipo, Marca, Modelo, DadosAdicionais, DefeitoDeclarado, Solucao)
VALUES
    (1, 'Tipo 1', 'Marca 1', 'Modelo 1', 'Dados 1', 'Defeito 1', 'Solucao 1'),
    (2, 'Tipo 2', 'Marca 2', 'Modelo 2', 'Dados 2', 'Defeito 2', 'Solucao 2');

-- Inserção de dados na tabela Servico
INSERT INTO Servico (ID, Data, Descricao, Valor)
VALUES
    (1, '2024-01-01', 'Servico 1', 100.00),
    (2, '2024-01-02', 'Servico 2', 150.00);

-- Inserção de dados na tabela Ocorrencia
INSERT INTO Ocorrencia (ID, Descricao, Situacao, DataHora)
VALUES
    (1, 'Ocorrencia 1', 'Situacao 1', '2024-01-01 10:00:00'),
    (2, 'Ocorrencia 2', 'Situacao 2', '2024-01-02 12:00:00');

-- Inserção de dados na tabela Peca
INSERT INTO Peca (ID, Tipo, Descricao, Valor)
VALUES
    (1, 'Tipo 1', 'Descricao 1', 50.00),
    (2, 'Tipo 2', 'Descricao 2', 75.00);

-- Inserção de dados na tabela Finalizacao
INSERT INTO Finalizacao (ID, DataFinalizacao, Comentario)
VALUES
    (1, '2024-01-03', 'Comentario 1'),
    (2, '2024-01-04', 'Comentario 2');

-- Inserção de dados na tabela OrdemServico
INSERT INTO OrdemServico (ID, DataAbertura, Prazo, FormaPagamento, Status, ClienteID, TecnicoID, FinalizacaoID)
VALUES
    (1, '2024-01-01', '2024-01-10', 'Pagamento 1', 'Aberto', 1, 1, 1),
    (2, '2024-01-02', '2024-01-12', 'Pagamento 2', 'Fechado', 2, 2, 2);

-- Inserção de dados na tabela OrdemServicoEquipamento
INSERT INTO OrdemServicoEquipamento (OrdemServicoID, EquipamentoID)
VALUES
    (1, 1),
    (2, 2);

-- Inserção de dados na tabela OrdemServicoServico
INSERT INTO OrdemServicoServico (OrdemServicoID, ServicoID)
VALUES
    (1, 1),
    (2, 2);

-- Inserção de dados na tabela OrdemServicoOcorrencia
INSERT INTO OrdemServicoOcorrencia (OrdemServicoID, OcorrenciaID)
VALUES
    (1, 1),
    (2, 2);

-- Inserção de dados na tabela OrdemServicoPeca
INSERT INTO OrdemServicoPeca (OrdemServicoID, PecaID)
VALUES
    (1, 1),
    (2, 2);
