# Agenda de Contatos

## Features:
- Alterar idioma da aplicação em tempo de execução(sem necessidade de build) para pt-BR e en-US através da cultura da Thread
- Relatorio em PDF (que fica na na pasta Reports do Projeto quando exportado)
- Relatorio em PDF em portugues e ingles (vai ser de acordo com o idioma selecionado no menu)
- Adicionar Pessoa
- Remover Pessoa
- Listar Pessoas cadastradas
- Criação de 4 Pessoas Fakes para teste

## Padrões e Principios inplementados:
- Princípio da Inversão de Dependência (DIP)
- Princípio da Segregação da Interface (ISP)
- Princípio da Responsabilidade Única (SRP)
- Inversão de Controle (IoC)
- Design Pattern Strategy
- Design Pattern Façade

### Foi utilizado o pacote iTextSharp para gerar o Relatorio em PDF(https://www.nuget.org/packages/iTextSharp)

# Como rodar uma Console Application no Linux e Windows com .NET 7

## Pré-requisitos

Para seguir este tutorial, você precisará ter instalado o seguinte:

- .NET 7 SDK
  https://dotnet.microsoft.com/en-us/download/dotnet/7.0
- Posssiveis comandos para instalar o dotnet 7 no ubuntu 22
```
wget https://packages.microsoft.com/config/ubuntu/22.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-7.0
```
- Comando para checkar a instalaçao do .NET dotnet --list-sdks
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

Pode ser executada pelo Visual Studio tambem, basta abrir o .csproj ou .sln (não tem Visual Studio para o Linux)
https://visualstudio.microsoft.com/pt-br/downloads/
