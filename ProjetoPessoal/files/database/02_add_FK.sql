ALTER TABLE OrdemServico
ADD CONSTRAINT FK_OrdemServico_Cliente
FOREIGN KEY (ClienteID) REFERENCES Cliente(ID);

ALTER TABLE OrdemServico
ADD CONSTRAINT FK_OrdemServico_Tecnico
FOREIGN KEY (TecnicoID) REFERENCES Tecnico(ID);

ALTER TABLE OrdemServico
ADD CONSTRAINT FK_OrdemServico_Finalizacao
FOREIGN KEY (FinalizacaoID) REFERENCES Finalizacao(ID);

ALTER TABLE OrdemServicoEquipamento
ADD CONSTRAINT FK_OrdemServicoEquipamento_OrdemServico
FOREIGN KEY (OrdemServicoID) REFERENCES OrdemServico(ID);

ALTER TABLE OrdemServicoEquipamento
ADD CONSTRAINT FK_OrdemServicoEquipamento_Equipamento
FOREIGN KEY (EquipamentoID) REFERENCES Equipamento(ID);

ALTER TABLE OrdemServicoServico
ADD CONSTRAINT FK_OrdemServicoServico_OrdemServico
FOREIGN KEY (OrdemServicoID) REFERENCES OrdemServico(ID);

ALTER TABLE OrdemServicoServico
ADD CONSTRAINT FK_OrdemServicoServico_Servico
FOREIGN KEY (ServicoID) REFERENCES Servico(ID);

ALTER TABLE OrdemServicoOcorrencia
ADD CONSTRAINT FK_OrdemServicoOcorrencia_OrdemServico
FOREIGN KEY (OrdemServicoID) REFERENCES OrdemServico(ID);

ALTER TABLE OrdemServicoOcorrencia
ADD CONSTRAINT FK_OrdemServicoOcorrencia_Ocorrencia
FOREIGN KEY (OcorrenciaID) REFERENCES Ocorrencia(ID);

ALTER TABLE OrdemServicoPeca
ADD CONSTRAINT FK_OrdemServicoPeca_OrdemServico
FOREIGN KEY (OrdemServicoID) REFERENCES OrdemServico(ID);

ALTER TABLE OrdemServicoPeca
ADD CONSTRAINT FK_OrdemServicoPeca_Peca
FOREIGN KEY (PecaID) REFERENCES Peca(ID);