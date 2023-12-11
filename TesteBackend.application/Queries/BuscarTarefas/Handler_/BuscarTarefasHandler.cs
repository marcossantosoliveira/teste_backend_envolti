using MediatR;
using TesteBackend.Application.Queries.BuscarTarefas.Dto_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Interfaces.Services;

namespace TesteBackend.Application.Queries.BuscarTarefas.Handler_
{
    public class BuscarTarefasHandler : IRequestHandler<BuscarTarefasRequestDto, List<BuscarTarefasResponseDto>>
    {

        private readonly ITarefaDomainService _tarefaService;

        public BuscarTarefasHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<List<BuscarTarefasResponseDto>> Handle(BuscarTarefasRequestDto request, CancellationToken cancellationToken)
        {

            var tarefasResponse = new List<BuscarTarefasResponseDto>();
            var tarefaRetornoService = await _tarefaService.BuscarTarefasAsync();

            foreach (var itemRetorno in tarefaRetornoService)
            {
                var tarefaItem = new BuscarTarefasResponseDto
                {
                    Id = itemRetorno.Id,
                    Titulo = itemRetorno.Titulo,
                    Concluida = itemRetorno.Concluida
                };

                tarefasResponse.Add(tarefaItem);
            }

            return tarefasResponse;
        }
    }
}
