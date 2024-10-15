using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLCD
{
    public class RelationshipDTO
    {
        public string EntityA { get; set; }
        public string RelationshipType { get; set; }
        public string EntityB { get; set; }

        public RelationshipDTO(string entityA, string relationshipType, string entityB)
        {
            EntityA = entityA;
            RelationshipType = relationshipType;
            EntityB = entityB;
        }
    }
}
