using MediatR;

namespace TesteBackend.Application.Queries.BuscarTerefaPorId.Dto_
{
    public class BuscarTarefaPorIdRequestDto : IRequest<BuscarTarefaPorIdResponseDto>
    {
        public int Id { get; set; }
        
    }
}
