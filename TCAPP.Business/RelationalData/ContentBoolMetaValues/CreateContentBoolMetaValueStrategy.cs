using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentBoolMetaValues
{
    public class CreateContentBoolMetaValueStrategy : IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentBoolMetaValueStrategy(TCAPPContext context)
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
