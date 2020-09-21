using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Author.Models
{
    public class EducationDegree
    {
        public int EducationDegreeId { get; set; }
        public string Name { get; set; }
        public string SchoolName { get; set; }
        public DateTime? GraduationDate { get; set; }
        public int AuthorId { get; set; }
        public Author AuthorLibro { get; set;  }
        public Guid Id { get; set; }
    }
}
