using ContactBook.Domain.Interfaces;

namespace ContactBook.Strategy.Strategies.Common;

public interface IExport
{
    void ExportAgenda(IAgenda agenda);
}