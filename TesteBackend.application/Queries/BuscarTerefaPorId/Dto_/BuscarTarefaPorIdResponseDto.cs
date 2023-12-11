using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackend.Application.Queries.BuscarTerefaPorId.Dto_
{
    public class BuscarTarefaPorIdResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
        public string Mensagem { get; set; }
    }
}
