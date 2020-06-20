using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentTextMetaValues
{
    public class CreateContentTextMetaValueStrategy : IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentTextMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentTextMetaValue> CreateAsync(CreateTextMetaValueInput input)
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
            return await _context.ContentTextMetaValues.FindAsync(metaValue.IdContent, metaValue.IdMetaValueType);
        }
    }
}
