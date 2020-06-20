using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.MetaValueTypes;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateMetaValueTypeStrategy : IAsyncUpdateStrategy<MetaValueType, UpdateMetaValueTypeInput>
    {
        private readonly TCAPPContext _context;
        public UpdateMetaValueTypeStrategy (TCAPPContext context)
        {
            _context = context;
        }
        public async Task<MetaValueType> UpdateAsync(UpdateMetaValueTypeInput input)
        {
            var metaValueType = await _context.MetaValueTypes.FindAsync(input.Id);
            metaValueType.Title = input.Title ?? metaValueType.Title;
            metaValueType.Updated = DateTime.Now;
            metaValueType.Enabled = input.Enabled ?? metaValueType.Enabled;
            await _context.SaveChangesAsync();
            return metaValueType;
        }
    }
}
