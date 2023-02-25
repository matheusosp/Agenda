using ContactBook.Domain.Interfaces;
using ContactBook.Strategy.Strategies.Common;

namespace ContactBook.Strategy;

public class ExportContext : IExportContext
{
    private IExport? _export;
    
    public void SetExportService(IExport? export)
    {
        _export = export;
    }

    public void ExportFile(IAgenda agenda)
    {
        _export?.ExportAgenda(agenda);
    }
}