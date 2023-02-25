using ContactBook.Domain.Interfaces;
using ContactBook.Strategy.Strategies.Common;

namespace ContactBook.Strategy;

public interface IExportContext
{
    void SetExportService(IExport? export);
    void ExportFile(IAgenda agenda);
}