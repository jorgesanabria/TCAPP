using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentRelationTypes;

namespace TCAPP.Business.TypeData.ContentRelationTypes
{
    public class CreateContentRelatonTypeStrategy : IAsyncCreateStrategy<ContentRelationType, CreateContentRelationTypeInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentRelatonTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentRelationType> CreateAsync(CreateContentRelationTypeInput input)
        {
            var contentRelationType = new ContentRelationType
            {
                Id = input.Id,
                Title = input.Title,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Enabled = input.Enabled
            };
            _context.ContentRelationTypes.Add(contentRelationType);
            await _context.SaveChangesAsync();
            return contentRelationType;
        }
    }
}
