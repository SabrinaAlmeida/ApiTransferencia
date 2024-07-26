# ApiTransferencia
Case Api de Transferência


## Como utilizar a aplicação

1. Certifique-se de ter o .NET Core SDK (versão 8) instalado em sua máquina.

2. Clone este repositório para o seu ambiente local.

3. Abra o projeto em sua IDE, de preferência com o Visual Studio.

4. Restaure as dependências do projeto executando o seguinte comando no terminal:dotnet restore

5. Execute a aplicação utilizando o botão Run no Visul Studio ou executando o seguinte comando no terminal: dotnet run

6. A aplicação estará sendo executada em `http://localhost:5000`.

7. Você pode acessar as API utilizando as seguintes rotas:

   - `GET /v1/Cliente`: Retorna todos os clientes cadastrados.
   - `GET /v1/Cliente/{id}`: Retorna um cliente específico pelo seu ID.
   - `POST /v1/Cliente`: Cria um novo cliente.
   - `POST /v1/Transferencia`: Cria uma nova transferencia.
    - `GET /v1/Transferencia/{idConta}`: Retorna todas as transferencias realizadas ou não que estão associadas a conta.
     
	 
## Utilizando a aplicação com Docker

1. Certifique-se de ter o Docker instalado em sua máquina.

2. Clone este repositório para o seu ambiente local.

3. Abra o terminal e navegue até o diretório raiz do projeto.

4. Execute o seguinte comando para criar a imagem Docker da aplicação:
docker build -t <image-name> 

5. Após a criação da imagem, inicie um contêiner Docker com a aplicação.

6. A aplicação estará sendo executada em `http://localhost:5000`.

7. Você pode acessar a API utilizando as mesmas rotas mencionadas anteriormente.


## Para realizar os testes unitarios das APIs é necessário apenas acessar o caminho:

http://localhost:5000/TesteUnitario/Index

Será possível visualizar o resultado dos testes no console da aplicação.

