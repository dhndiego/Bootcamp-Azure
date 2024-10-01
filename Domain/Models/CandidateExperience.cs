using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CandidateExperience
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
