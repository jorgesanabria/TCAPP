using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateFloatMetaVaueStrategy : IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateFloatMetaVaueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentFloatMetaValue> CreateAsync(CreateFloatMetaValueInput input)
        {
            var metaValue = new ContentFloatMetaValue
            {
                IdContent = input.IdContent,
                IdMetaValueType = input.IdMetaValueType,
                Created = input.Created,
                Updated = input.Updated,
                Enabled = input.Enabled,
                Value = input.Value
            };
            _context.ContentFloatMetaValues.Add(metaValue);
            await _context.SaveChangesAsync();
            return await _context.ContentFloatMetaValues.FindAsync(metaValue.IdContent, metaValue.IdMetaValueType);
        }
    }
}
