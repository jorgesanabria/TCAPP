using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Contents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.ConcreteData.Contents
{
    public class UpdateContentStrategy : IAsyncUpdateStrategy<Content, UpdateContentInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<Content> UpdateAsync(UpdateContentInput input)
        {
            var content = await _context.Contents.FindAsync(input.Id);
            content.Title = input.Title ?? content.Title;
            content.IdContentType = input.IdContentType ?? content.IdContentType;
            content.Updated = DateTime.Now;
            content.Enabled = input.Enabled ?? content.Enabled;
            await _context.SaveChangesAsync();
            return content;
        }
    }
}
