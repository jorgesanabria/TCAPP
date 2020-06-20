using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentStringMetaValues
{
    public class CreateContentStringMetaValueStrategy : IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentStringMetaValueStrategy(TCAPPContext context)
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
