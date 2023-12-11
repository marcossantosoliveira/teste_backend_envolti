using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Domain.Dto_;

namespace TesteBackend.Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        Task<List<TarefaResponseDto>> BuscarTarefasAsync();
        Task<TarefaResponseDto> BuscarTarefasPorIdAsync(int id);
        Task<int> CriarTarefaAsync(TarefaDto tarefa);
        Task<bool> EditarTarefaAsync(int id, TarefaDto tarefa);
        Task<bool> ExcluirTarefaAsync(int id);

    }
}
