using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackend.Application.Commands.EditarTarefa.Dto_
{
    public class EditarTarefaRequestDto : IRequest<EditarTarefaResponseDto>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
