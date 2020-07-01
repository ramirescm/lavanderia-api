- Baixar o projeto
- Instalar o Postegres
- Criar o banco lavanderia 
	- configurações de conexões ficam no appsettings.json lá você pode editar as configurações de conexão com o banco

```
CREATE DATABASE lavanderia

INSERT INTO public.usuarios(
	id, login, senha)
	VALUES (1, 'admin@gmail.com', '123');
INSERT INTO public.usuarios(
	id, login, senha)
	VALUES (2, 'manager@gmail.com', '123');	
	
```

- Em Package Manager Console -> selecionar o projeto Lavanderia.Infra e executar o update-database

Referência via linha de comando para restaurar os pacotes
https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-restore