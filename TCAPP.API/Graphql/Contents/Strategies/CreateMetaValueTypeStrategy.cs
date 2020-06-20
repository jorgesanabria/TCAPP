using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.MetaValueTypes;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateMetaValueTypeStrategy : IAsyncCreateStrategy<MetaValueType, CreateMetaValueTypeInput>
    {
        private readonly TCAPPContext _context;
        public CreateMetaValueTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<MetaValueType> CreateAsync(CreateMetaValueTypeInput input)
        {
            var metaValueType = new MetaValueType
            {
                Id = input.Id,
                Title = input.Title,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Enabled = input.Enabled
            };
            _context.MetaValueTypes.Add(metaValueType);
            await _context.SaveChangesAsync();
            return metaValueType;
        }
    }
}