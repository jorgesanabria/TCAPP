using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateContentStrategy : IAsyncUpdate<Content, UpdateContentInput>
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
