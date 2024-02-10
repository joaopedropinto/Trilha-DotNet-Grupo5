## Projeto de Gestão de Ordem de Serviço

O objetivo deste projeto é implementar um sistema de Gestão de Ordem de Serviço para uma assistência técnica especializada em reparos de hardware. A abrangência inclui serviços para placa mãe, placa de vídeo, computadores, notebooks e vídeo games.

### Motivação

A escolha desse tema é fundamentada na crescente demanda por serviços de reparo técnico nesses dispositivos. A eficiente administração desses serviços é crucial para a eficácia operacional da assistência, proporcionando uma gestão mais eficaz e melhorando a experiência do cliente.

### Relevância do Projeto

A implementação deste sistema visa otimizar os processos internos da assistência técnica, proporcionando uma administração mais eficiente dos serviços prestados. Desta forma, o projeto busca atender às necessidades do mercado, promovendo a excelência na prestação de serviços de reparo e manutenção.

### Endpoints do Projeto

Endpoints iniciais que compõem este sistema de Gestão de Ordem de Serviço.


1. **Ordem de Serviço (OS):**
   - `GET /ordens-servico`: Lista todas as ordens de serviço.
   - `GET /ordens-servico/{id}`: Retorna os detalhes de uma ordem de serviço específica.
   - `POST /ordens-servico`: Cria uma nova ordem de serviço.
   - `PUT /ordens-servico/{id}`: Atualiza uma ordem de serviço existente.
   - `DELETE /ordens-servico/{id}`: Exclui uma ordem de serviço.
   - `GET /ordens-servico/{id}/ocorrencias`: Lista as ocorrências associadas a uma ordem de serviço.
   - `POST /ordens-servico/{id}/ocorrencias`: Adiciona uma nova ocorrência à ordem de serviço.
   - `PUT /ordens-servico/{id}/ocorrencias/{ocorrenciaId}`: Atualiza uma ocorrência específica.
   - `DELETE /ordens-servico/{id}/ocorrencias/{ocorrenciaId}`: Exclui uma ocorrência específica.
   - `GET /ordens-servico/{id}/pecas`: Lista as peças associadas a uma ordem de serviço.
   - `POST /ordens-servico/{id}/pecas`: Adiciona uma nova peça à ordem de serviço.
   - `PUT /ordens-servico/{id}/pecas/{pecaId}`: Atualiza uma peça específica.
   - `DELETE /ordens-servico/{id}/pecas/{pecaId}`: Exclui uma peça específica.
   - `GET /ordens-servico/{id}/finalizacao`: Retorna os detalhes da finalização, se existir, de uma ordem de serviço.
   - `POST /ordens-servico/{id}/finalizacao`: Adiciona uma finalização à ordem de serviço, se aplicável.
   - `PUT /ordens-servico/{id}/finalizacao`: Atualiza os detalhes da finalização, se existir.
   - `DELETE /ordens-servico/{id}/finalizacao`: Remove a finalização associada, se existir.

2. **Cliente:**
   - `GET /clientes`: Lista todos os clientes.
   - `GET /clientes/{id}`: Retorna os detalhes de um cliente específico.
   - `POST /clientes`: Cria um novo cliente.
   - `PUT /clientes/{id}`: Atualiza um cliente existente.
   - `DELETE /clientes/{id}`: Exclui um cliente.

3. **Técnico:**
   - `GET /tecnicos`: Lista todos os técnicos.
   - `GET /tecnicos/{id}`: Retorna os detalhes de um técnico específico.
   - `POST /tecnicos`: Cria um novo técnico.
   - `PUT /tecnicos/{id}`: Atualiza um técnico existente.
   - `DELETE /tecnicos/{id}`: Exclui um técnico.

4. **Equipamento:**
   - `GET /equipamentos`: Lista todos os equipamentos.
   - `GET /equipamentos/{id}`: Retorna os detalhes de um equipamento específico.
   - `POST /equipamentos`: Adiciona um novo equipamento.
   - `PUT /equipamentos/{id}`: Atualiza um equipamento existente.
   - `DELETE /equipamentos/{id}`: Exclui um equipamento.

5. **Serviço:**
   - `GET /servicos`: Lista todos os serviços disponíveis.
   - `GET /servicos/{id}`: Retorna os detalhes de um serviço específico.
   - `POST /servicos`: Cria um novo serviço.
   - `PUT /servicos/{id}`: Atualiza um serviço existente.
   - `DELETE /servicos/{id}`: Exclui um serviço.

### Autores

| [<img src="https://avatars.githubusercontent.com/u/84890636?v=4" width=115><br><sub>Daniel Penedo</sub>](https://github.com/DanielPenedo97?tab=repositories) |  [<img src="https://avatars.githubusercontent.com/u/32523778?v=4" width=115><br><sub>João Pedro</sub>](https://github.com/joaopedropinto) |  [<img src="https://avatars.githubusercontent.com/u/76014751?v=4" width=115><br><sub>Kayque Piton</sub>](https://github.com/kayquepiton) | [<img src="https://avatars.githubusercontent.com/u/34558728?v=4" width=115><br><sub>Jhonata Araújo</sub>](https://github.com/DStalkerBR) | [<img src="https://avatars.githubusercontent.com/u/32984720?v=4" width=115><br><sub>Valber Francisco dos Santos</sub>](https://github.com/ValberF) |
| :---: | :---: | :---: | :---: | :---: |
