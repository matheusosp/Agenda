# Agenda de Contatos

## Features:
- ALterar idioma da aplicação em tempo de execução(sem necessidade de build) para pt-BR e en-US através da cultura da Thread
- Internacionalização (Apenas o Menu principal esta com suporte a 2 idiomas por falta de tempo para implementar nas outras partes do sistema, mas a estrutura esta pronta bastando colocar a chave e valor para pt-BR e en-US e chamar via Language.Prop que vai funcionar)
- Adicionar Pessoa
- Remover Pessoa
- Listar Pessoas cadastradas

## Features não implementadas:
- Relatorio em PDF

# Como rodar uma Console Application no Linux e Windows com .NET 7

## Pré-requisitos

Para seguir este tutorial, você precisará ter instalado o seguinte:

- .NET 7 SDK
  https://dotnet.microsoft.com/en-us/download/dotnet/7.0
## Passo a Passo

### 1. Acessar o diretório do projeto

Abra o terminal e navegue até o diretório da aplicação de console existente.(Pasta \ContactBook\ContactBook)

### 2. Restaurar as dependências

Execute o seguinte comando para restaurar as dependências do projeto:

```dotnet restore```

### 3. Compilar o projeto

Execute o seguinte comando para compilar o projeto:

```dotnet build```

### 4. Rodar a aplicação

Para executar a aplicação, execute o seguinte comando:

```dotnet run```

A aplicação de console será executada no terminal.

Para rodar no VSCODE é preciso:
- Extensão C# para o Visual Studio Code
- .NET 7 SDK