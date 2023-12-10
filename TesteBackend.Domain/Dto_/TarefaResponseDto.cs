using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackend.Domain.Dto_
{
    public class TarefaResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
