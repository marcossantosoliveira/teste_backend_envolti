
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Entities;

namespace TesteBackend.Domain.Interfaces.Repository
{
    public interface ITarefaDomainRepository
    {
        Task<List<TarefaEntities>> BuscarTarefasAsync();
        Task<TarefaEntities> BuscarTarefasPorIdAsync(int id);
        Task<int> CriarTarefaAsync(TarefaEntities tarefa);
        Task<TarefaEntities> EditarTarefaAsync(int id, TarefaEntities tarefa);
        Task<bool> ExcluirTarefaAsync(int id);

    }
}
