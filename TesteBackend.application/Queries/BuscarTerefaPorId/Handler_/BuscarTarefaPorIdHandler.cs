using MediatR;
using TesteBackend.Application.Queries.BuscarTerefaPorId.Dto_;
using TesteBackend.Domain.Interfaces.Services;

namespace TesteBackend.Application.Queries.BuscarTarefaPorId.Handler_
{
    public class BuscarTarefaPorIdHandler : IRequestHandler<BuscarTarefaPorIdRequestDto, BuscarTarefaPorIdResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public BuscarTarefaPorIdHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<BuscarTarefaPorIdResponseDto> Handle(BuscarTarefaPorIdRequestDto request, CancellationToken cancellationToken)
        {       
         
            var tarefaResponse = new BuscarTarefaPorIdResponseDto();

            if (request == null)
            {
                tarefaResponse.Mensagem = "Todos os campos são obrigatório";

                return tarefaResponse;
            }                        
      
            var tarefaRetornoService = await _tarefaService.BuscarTarefasPorIdAsync(request.Id);

            tarefaResponse.Id = tarefaRetornoService.Id;
            tarefaResponse.Titulo = tarefaRetornoService.Titulo;
            tarefaResponse.Concluida = tarefaRetornoService.Concluida;

            if (tarefaRetornoService == null)
            {
                tarefaResponse.Mensagem = "Tarefa não encontrada";

                return tarefaResponse;
            }            
           
            return tarefaResponse;
        }
    }
}
