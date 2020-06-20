using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.DTO.TypeData.ContentTypes;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.TypeData.ContentTypes
{
    public class UpdateContentTypeStrategy : IAsyncUpdateStrategy<ContentType, UpdateContentTypeInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentType> UpdateAsync(UpdateContentTypeInput input)
        {
            var contentType = await _context.ContentTypes.FindAsync(input.Id);
            contentType.Title = input.Title ?? contentType.Title;
            contentType.Description = input.Description ?? contentType.Description;
            contentType.Updated = DateTime.Now;
            contentType.Enabled = input.Enabled ?? contentType.Enabled;
            await _context.SaveChangesAsync();
            return contentType;
        }
    }
}
