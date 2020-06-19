using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateContentStrategy
    {
        private readonly TCAPPContext _context;
        public UpdateContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<Content> CreateAsync(UpdateContentInput input)
        {
            var content = await _context.Contents.FindAsync(input.Id);
            input.Content = content;
            content = DoUpdate(input);
            await _context.SaveChangesAsync();
            return content;
        }

        private Content DoUpdate(UpdateContentInput input)
        {
            var content = input.Content;
            content.Title = input.Title ?? content.Title;
            content.IdContentType = input.IdContentType ?? content.IdContentType;
            content.Updated = DateTime.Now;
            content.Enabled = input.Enabled ?? content.Enabled;

            return content;
        }
    }
}
