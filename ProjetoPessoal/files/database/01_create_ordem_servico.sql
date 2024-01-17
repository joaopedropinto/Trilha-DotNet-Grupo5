CREATE TABLE OrdemServico (
    ID INT PRIMARY KEY,
    DataAbertura DATE,
    Prazo DATE,
    FormaPagamento VARCHAR(255),
    Status VARCHAR(255),
    ClienteID INT,
    TecnicoID INT,
    FinalizacaoID INT
);