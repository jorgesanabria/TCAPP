using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentRelationTypes;

namespace TCAPP.Business.TypeData.ContentRelationTypes
{
    public class UpdateContentRelationTypeStrategy : IAsyncUpdateStrategy<ContentRelationType, UpdateContentRelationTypeInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentRelationTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentRelationType> UpdateAsync(UpdateContentRelationTypeInput input)
        {
            var entity = await _context.ContentRelationTypes.FindAsync(input.Id);
            entity.Updated = DateTime.Now;
            entity.Title = input.Title ?? entity.Title;
            entity.Enabled = input.Enabled ?? entity.Enabled;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
