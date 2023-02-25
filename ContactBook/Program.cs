using System.Globalization;
using System.Reflection;
using System.Text;
using ContactBook.Resources;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StrategyLibrary.SortingExample;
using static System.Int32;

namespace ContactBook
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var ci = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            StartApp();
        }

        private static void StartApp()
        {
            ChangeLanguage();
            var agenda = new Agenda();
            var quit = false;

            do
            {
                Console.WriteLine(Language.SelectTheAction);
                Console.WriteLine("1 - " + Language.AddPersons);
                Console.WriteLine("2 - " + Language.RemovePersons);
                Console.WriteLine("3 - " + Language.ListPersons);
                Console.WriteLine("4 - " + Language.UpdateLanguageString);
                Console.WriteLine("5 - " + Language.ExportPdf);
                Console.WriteLine("6 - " + Language.CloseApplication);
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPersons(agenda);
                        break;
                    case "2":
                        RemovePersons(agenda);
                        break;
                    case "3":
                        Console.WriteLine(Language.StarList);
                        agenda.ListPersons();
                        break;
                    case "4":
                        ChangeLanguage();
                        break;   
                    case "5":
                        ExportPdf(agenda);
                        break;
                    case "6":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine(Language.InvalidOption);
                        break;
                }
            } while (quit == false);
        }

        private static void ExportPdf(Agenda agenda)
        {
            var document = new Document();
            try
            {
                var folderPath =  Path.Combine(
                    Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? 
                    AppDomain.CurrentDomain.BaseDirectory,"Reports");
                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var filePath = Path.Combine(folderPath, $"agenda{DateTime.Now:dd-MM-yyyy HH-m-s}.pdf");
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                // Abre o documento para escrita
                document.Open();

                // Configura o layout do PDF
                ConfigurePdfLayout(document);

                // Adiciona o conteúdo da agenda no PDF
                AddAgendaContent(document, agenda);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Fecha o documento
                document.Close();
            }
        }
        private static void AddHeader(IElementListener document)
        {
            // Define o título da agenda e a data atual
            var header = new PdfPTable(1);
            header.WidthPercentage = 50;

            // Adiciona uma célula que ocupa toda a largura da tabela
            var title = new PdfPCell(new Phrase($"{Language.ContactsDirectoryDate} {DateTime.Now.ToString(Language.Date)}"));
            title.HorizontalAlignment = Element.ALIGN_CENTER;
            title.BorderWidth = 1f;
            title.BorderColor = BaseColor.BLACK;

            // Adiciona a célula à tabela
            header.AddCell(title);
            
            // Adiciona a tabela ao documento
            document.Add(header);
        }
        private static void AddFooter(IElementListener document, int qtdContacts)
        {
            var body = new PdfPTable(1);
            body.WidthPercentage = 50;
            // Adiciona o número total de contatos
            var totalContacts = $"{Language.TotalContacts}: {qtdContacts}";
            var totalContactsParagraph = new PdfPCell(new Phrase(totalContacts))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidth = 1f,
                BorderColorBottom = BaseColor.BLACK
            };
            body.AddCell(totalContactsParagraph);
            document.Add(body);
        }
        private static void AddBody(IElementListener document, Agenda agenda)
        {
            var body = new PdfPTable(1);
            body.WidthPercentage = 50;
            agenda.AddPerson(new Person("matheus","matheus","matheus hasbfyusafyuhf"));
            agenda.AddPerson(new Person("matheus","matheus","matheus hasbfyusafyuhf"));
            agenda.AddPerson(new Person("matheus","matheus","matheus hasbfyusafyuhf"));
            agenda.AddPerson(new Person("matheus","matheus","matheus hasbfyusafyuhf"));
            // Adiciona as células com o conteúdo da agenda
            foreach (var contact in agenda.GetContacts())
            {
                var stringBuilder = new StringBuilder(4);
                stringBuilder.Append("#" + contact.Id);
                stringBuilder.Append($"\n {Language.Name}: {contact.Name}");
                stringBuilder.Append($"\n Email: {contact.Email}");
                stringBuilder.Append($"\n {Language.Address}: {contact.Endereco}");
                
                var nomeCell = new PdfPCell(new Phrase(stringBuilder.ToString()))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    BorderWidth = 1f,
                    BorderColorBottom = BaseColor.BLACK
                };

                body.AddCell(nomeCell);
            }

            // Adiciona a tabela ao documento
            document.Add(body);
        }
        private static void ConfigurePdfLayout(IDocListener document)
        {
            // Define as margens do documento
            document.SetMargins(20f, 20f, 20f, 20f);

            // Define o tamanho da página como A4
            document.SetPageSize(PageSize.A4);

            // Cria uma nova página
            document.NewPage();
        }
        private static void AddAgendaContent(IElementListener document, Agenda agenda)
        {
            AddHeader(document);
            AddBody(document,agenda);
            AddFooter(document,agenda.GetQtdContacts());
        }

        private static void ChangeLanguage()
        {
            Console.WriteLine(Language.SelectLanguage);
            var option = Console.ReadLine();
            var ci = new CultureInfo("pt-BR");
            if (option == "2")
                ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private static void RemovePersons(Agenda agenda)
        {
            Console.WriteLine(Language.HowManyPeople);
            var parseInput = TryParse(Console.ReadLine(), out var qtd);
            while (parseInput && qtd > agenda.GetQtdContacts())
            {
                Console.WriteLine(Language.NumberOfPeopleToRemove);
                parseInput = TryParse(Console.ReadLine(), out qtd);
            }

            for (var i = 0; i < qtd; i++)
            {
                Console.WriteLine(Language.EnterIdOfThePersonToRemoveFromSchedule);
                TryParse(Console.ReadLine(), out var id);
                var remove =agenda.RemovePerson(id);
                if (remove == false)
                    i--;
            }
        }

        private static void AddPersons(Agenda agenda)
        {
            bool parse;
            int qtd;
            do
            {
                Console.WriteLine(Language.HowManyPeopleAddToTheList);
                parse = TryParse(Console.ReadLine(), out qtd);
            } while (parse == false);
            
            for (var i = 0; i < qtd; i++)
            {
                var name = GetNameInput(i);
                var endereco = GetAddressInput(i);
                var email = GetEmailInput(i);
                var person = new Person(name!,endereco!,email!);
                agenda.AddPerson(person);
            }
        }

        private static string? GetEmailInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonEmail} : ");
            var email = Console.ReadLine();
            return email;
        }

        private static string? GetAddressInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonAddress } : ");
            var endereco = Console.ReadLine();
            return endereco;
        }

        private static string? GetNameInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonName} : ");
            var name = Console.ReadLine();
            return name;
        }
    }
}