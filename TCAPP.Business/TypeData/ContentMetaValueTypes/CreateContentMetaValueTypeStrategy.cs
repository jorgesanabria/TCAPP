using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentMetaValueTypes;

namespace TCAPP.Business.TypeData.ContentMetaValueTypes
{
    public class CreateContentMetaValueTypeStrategy : IAsyncCreateStrategy<MetaValueType, CreateContentMetaValueTypeInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentMetaValueTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<MetaValueType> CreateAsync(CreateContentMetaValueTypeInput input)
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