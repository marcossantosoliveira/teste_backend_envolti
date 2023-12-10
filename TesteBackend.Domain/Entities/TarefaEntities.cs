using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackend.Domain.Entities
{
    public class TarefaEntities
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
