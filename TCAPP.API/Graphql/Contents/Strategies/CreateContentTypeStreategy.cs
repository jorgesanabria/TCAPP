using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.ContentTypes;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateContentTypeStreategy : IAsyncCreateStrategy<ContentType, CreateContentTypeInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentTypeStreategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentType> CreateAsync(CreateContentTypeInput input)
        {
            var contentType = new ContentType
            {
                Id = input.Id,
                Title = input.Title,
                Description = input.Description,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Enabled = input.Enabled
            };
            _context.ContentTypes.Add(contentType);
            await _context.SaveChangesAsync();
            return contentType;
        }
    }
}
