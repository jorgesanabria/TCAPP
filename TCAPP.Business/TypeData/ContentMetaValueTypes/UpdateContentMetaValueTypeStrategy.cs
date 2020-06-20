using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentMetaValueTypes;

namespace TCAPP.Business.TypeData.ContentMetaValueTypes
{
    public class UpdateContentMetaValueTypeStrategy : IAsyncUpdateStrategy<MetaValueType, UpdateContentMetaValueTypeInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentMetaValueTypeStrategy (TCAPPContext context)
        {
            _context = context;
        }
        public async Task<MetaValueType> UpdateAsync(UpdateContentMetaValueTypeInput input)
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
