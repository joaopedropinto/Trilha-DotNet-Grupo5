No sistema de Ordem de Serviço, temos as seguintes entidades iniciais que representam as partes envolvidas e os detalhes do processo.

## Entidades
- **Ordem de Serviço (OS):**    
    - Cada OS é única, com informações como data de abertura, prazo, forma de pagamento e status.
    - Cada ordem está vinculada a um cliente e a um técnico que executará o serviço.
    - Pode envolver vários equipamentos, serviços, ocorrências, e pode ter uma finalização.

- **Cliente:**    
    - Representa o cliente solicitante do serviço, com detalhes como nome, CPF, CNPJ, telefone, email e endereço.

- **Técnico:**    
    - Descreve o técnico encarregado, com nome, especialidade, telefone e email.

- **Equipamento:**    
    - Cada equipamento relaciona-se a uma ou mais ordens de serviço, com detalhes sobre tipo, marca, modelo, defeito declarado e solução.

- **Serviço:**    
    - Descreve os serviços a serem realizados, incluindo data, descrição e valor.

- **Ocorrência:**    
    - Representa eventos ou situações relacionados a uma ordem de serviço, com descrição, situação e data/hora.

- **Peça:**    
    - Descreve as peças que podem ser utilizadas em uma ordem de serviço, com informações como tipo, descrição e valor.

- **Finalização:**    
    - Opcionalmente, uma ordem de serviço pode ter uma finalização, com data de finalização e um comentário.

### Relacionamentos
- Uma OS está ligada a um cliente e um técnico.
- Equipamentos, serviços, ocorrências e peças podem estar associados a uma ou mais ordens de serviço.
- A finalização é vinculada a uma ordem de serviço.