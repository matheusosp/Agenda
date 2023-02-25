using System.Text;
using ContactBook.Domain.Interfaces;
using ContactBook.Resources;
using ContactBook.Strategy.Strategies.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ContactBook.Strategy.Strategies;

public class PdfExport : IExport, IPdfExport
{
    private readonly Document _document;

    public PdfExport(Document document)
    {
        _document = document;
    }

    public void ExportAgenda(IAgenda agenda)
    {
        try
        {
            var folderPath = Path.Combine(
                Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ??
                AppDomain.CurrentDomain.BaseDirectory, "Reports");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Console.WriteLine($"{Language.SavingFileInDirectory}: {folderPath}" );
            var filePath = Path.Combine(folderPath, $"agenda{DateTime.Now:dd-MM-yyyy HH-m-s}.pdf");
            PdfWriter.GetInstance(_document, new FileStream(filePath, FileMode.Create));

            _document.Open();

            ConfigurePdfLayout();
            AddAgendaContent(agenda);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"PDF {Language.Saved}" );
            _document.Close();
        }
    }

    private void ConfigurePdfLayout()
    {
        _document.SetMargins(20f, 20f, 20f, 20f);
        _document.SetPageSize(PageSize.A4);
        _document.NewPage();
    }

    private void AddAgendaContent(IAgenda agenda)
    {
        AddHeader();
        AddBody(agenda);
        AddFooter(agenda.GetQtdContacts());
    }

    private void AddHeader()
    {
        var header = new PdfPTable(1);
        header.WidthPercentage = 50;

        var title = new PdfPCell(
            new Phrase($"{Language.ContactsDirectoryDate} {DateTime.Now.ToString(Language.Date)}"));
        title.HorizontalAlignment = Element.ALIGN_CENTER;
        title.BorderWidth = 1f;
        title.BorderColor = BaseColor.BLACK;

        header.AddCell(title);
        _document.Add(header);
    }

    private void AddBody(IAgenda agenda)
    {
        var body = new PdfPTable(1);
        body.WidthPercentage = 50;

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

        _document.Add(body);
    }

    private void AddFooter(int qtdContacts)
    {
        var body = new PdfPTable(1);
        body.WidthPercentage = 50;

        var totalContacts = $"{Language.TotalContacts}: {qtdContacts}";
        var totalContactsParagraph = new PdfPCell(new Phrase(totalContacts))
        {
            HorizontalAlignment = Element.ALIGN_LEFT,
            BorderWidth = 1f,
            BorderColorBottom = BaseColor.BLACK
        };
        body.AddCell(totalContactsParagraph);
        _document.Add(body);
    }
}

public interface IPdfExport
{
}