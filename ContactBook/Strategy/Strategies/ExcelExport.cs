using ContactBook.Domain.Interfaces;
using ContactBook.Strategy.Strategies.Common;

namespace ContactBook.Strategy.Strategies;

public class ExcelExport : IExport, IExcelExport
{
    public void ExportAgenda(IAgenda agenda)
    {
        throw new NotImplementedException();
    }
}

public interface IExcelExport
{
}