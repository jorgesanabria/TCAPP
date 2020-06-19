using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateBoolMetaValueStrategy : IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateBoolMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentBoolMetaValue> CreateAsync(CreateBoolMetaValueInput input)
        {
            var metaValue = new ContentBoolMetaValue
            {
                IdContent = input.IdContent,
                IdMetaValueType = input.IdMetaValueType,
                Created = input.Created,
                Updated = input.Updated,
                Enabled = input.Enabled,
                Value = input.Value
            };
            _context.ContentBoolMetaValues.Add(metaValue);
            await _context.SaveChangesAsync();
            return await _context.ContentBoolMetaValues.FindAsync(metaValue.IdContent, metaValue.IdMetaValueType);
        }
    }
}
