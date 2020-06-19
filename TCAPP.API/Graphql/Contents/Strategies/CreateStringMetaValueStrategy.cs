using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateStringMetaValueStrategy : IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateStringMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentStringMetaValue> CreateAsync(CreateStringMetaValueInput input)
        {
            var metaValue = new ContentTextMetaValue
            {
                IdContent = input.IdContent,
                IdMetaValueType = input.IdMetaValueType,
                Created = input.Created,
                Updated = input.Updated,
                Enabled = input.Enabled,
                Value = input.Value
            };
            _context.ContentTextMetaValues.Add(metaValue);
            await _context.SaveChangesAsync();
            return await _context.ContentStringMetaValues.FindAsync(metaValue.IdContent, metaValue.IdMetaValueType);
        }
    }
}
