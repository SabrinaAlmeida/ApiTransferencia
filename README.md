

## Como utilizar a aplica��o

1. Certifique-se de ter o .NET Core SDK (vers�o 8) instalado em sua m�quina.

2. Clone este reposit�rio para o seu ambiente local.

3. Abra o projeto em sua IDE, de prefer�ncia com o Visual Studio.

4. Restaure as depend�ncias do projeto executando o seguinte comando no terminal:dotnet restore

5. Execute a aplica��o utilizando o bot�o Run no Visul Studio ou executando o seguinte comando no terminal: dotnet run

6. A aplica��o estar� sendo executada em `http://localhost:5000`.

7. Voc� pode acessar as API utilizando as seguintes rotas:

   - `GET /v1/Cliente`: Retorna todos os clientes cadastrados.
   - `GET /v1/Cliente/{id}`: Retorna um cliente espec�fico pelo seu ID.
   - `POST /v1/Cliente`: Cria um novo cliente.
   - `POST /v1/Transferencia`: Cria uma nova transferencia.
    - `GET /v1/Transferencia/{idConta}`: Retorna todas as transferencias realizadas ou n�o que est�o associadas a conta.
     
	 
## Utilizando a aplica��o com Docker

1. Certifique-se de ter o Docker instalado em sua m�quina.

2. Clone este reposit�rio para o seu ambiente local.

3. Abra o terminal e navegue at� o diret�rio raiz do projeto.

4. Execute o seguinte comando para criar a imagem Docker da aplica��o:
docker build -t <image-name> 

5. Ap�s a cria��o da imagem, inicie um cont�iner Docker com a aplica��o.

6. A aplica��o estar� sendo executada em `http://localhost:5000`.

7. Voc� pode acessar a API utilizando as mesmas rotas mencionadas anteriormente.


## Para realizar os testes unitarios das APIs � necess�rio apenas acessar o caminho:

http://localhost:5000/TesteUnitario/Index

Ser� poss�vel visualizar o resultado dos testes no console da aplica��o.
