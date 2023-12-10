using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Entities;
using TesteBackend.Domain.Interfaces.Repository;
using TesteBackend.Infra.Context;

namespace TesteBackend.Infra.Repository
{
    public class TarefaRepository : ITarefaDomainRepository
    {

        private readonly BdContexto _tarefaContext;

        public TarefaRepository(BdContexto tarefaContext)
        {
            _tarefaContext = tarefaContext;
        }

        public async Task<List<TarefaEntities>> BuscarTarefasAsync()
        {
            var tarefas = await _tarefaContext.Tarefas.ToListAsync();

            return tarefas;
        }

        public async Task<TarefaEntities> BuscarTarefasPorIdAsync(int id)
        {
            var tarefa = await _tarefaContext.Tarefas.SingleOrDefaultAsync(t => t.Id == id);

            return tarefa;
        }

        public async Task<int> CriarTarefaAsync(TarefaEntities tarefa)
        {
            await _tarefaContext.Tarefas.AddAsync(tarefa);
            await _tarefaContext.SaveChangesAsync();

            return tarefa.Id;
        }

        public async Task<TarefaEntities> EditarTarefaAsync(int id, TarefaEntities tarefa)
        {
            tarefa = await BuscarTarefasPorIdAsync(id);


            _tarefaContext.Tarefas.Update(tarefa);
            _tarefaContext.SaveChanges();

            return tarefa;

        }

        public async Task<bool> ExcluirTarefaAsync(int id)
        {
            var excluirTarefa = await BuscarTarefasPorIdAsync(id);

            if (excluirTarefa != null)
            {
                _tarefaContext.Tarefas.Remove(excluirTarefa);
                _tarefaContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
