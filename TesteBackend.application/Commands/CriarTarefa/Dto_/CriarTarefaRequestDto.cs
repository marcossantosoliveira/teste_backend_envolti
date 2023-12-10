using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackend.Application.Commands.CriarTarefa.Dto_
{
    public class CriarTarefaRequestDto : IRequest<CriarTarefaResponseDto>
    {  
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
