using System;
using DAL_QLCD;
using DTO_QLCD;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class RelationshipBUS
    {
        private readonly RelationshipDAL _relationshipDAL;

        public RelationshipBUS(string uri, string user, string password)
        {
            _relationshipDAL = new RelationshipDAL(uri, user, password);
        }
        public async Task<List<RelationshipDTO>> GetAllRelationshipsAsync()
        {
            return await _relationshipDAL.GetAllRelationshipsAsync();
        }
        public async Task AddRelationshipAsync(string entityA, string relationshipType, string entityB)
        {
            await _relationshipDAL.AddRelationshipAsync(entityA, relationshipType, entityB);
        }
        public async Task DeleteRelationshipAsync(string entityA, string relationshipType, string entityB)
        {
            await _relationshipDAL.DeleteRelationshipAsync(entityA, relationshipType, entityB);
        }
        public async Task<List<string>> GetFilteredEntitiesAsync(string entityType)
        {
            return await _relationshipDAL.GetFilteredEntitiesAsync(entityType);
        }
    }
}
