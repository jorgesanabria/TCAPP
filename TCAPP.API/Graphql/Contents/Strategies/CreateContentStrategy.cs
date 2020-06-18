using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateContentStrategy : ICreateContentStrategy
    {
        private readonly TCAPPContext _context;
        public CreateContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<Content> CreateAsync(CreateContentInput input)
        {
            var content = new Content { Title = input.Title, IdContentType = input.IdContentType, Created = input.Created, Updated = input.Updated };

            if (input.Parents != null && input.Parents.Any())
            {
                content.ParentContents = input.Parents.Select(x => new ParentContent { IdParentContent = x.IdParent }).ToList();
            }

            if (input.Texts != null && input.Texts.Any())
            {
                content.ContentTextMetaValues = input.Texts.Select(x => new ContentTextMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType }).ToList();
            }

            if (input.Strings != null && input.Strings.Any())
            {
                content.ContentStringMetaValues = input.Strings.Select(x => new ContentStringMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType }).ToList();
            }

            if (input.Floats != null && input.Floats.Any())
            {
                content.ContentFloatMetaValues = input.Floats.Select(x => new ContentFloatMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType }).ToList();
            }

            if (input.Bools != null && input.Bools.Any())
            {
                content.ContentBoolMetaValues = input.Bools.Select(x => new ContentBoolMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType }).ToList();
            }

            _context.Entry(content).State = EntityState.Added;

            //_context.Contents.Add(content);
            await _context.SaveChangesAsync();

            if (input.Children != null && input.Children.Any())
            {
                foreach (var child in input.Children)
                {
                    var childContent = await CreateAsync(child);
                    _context.ParentContents.Add(new ParentContent { IdParentContent = content.Id, IdContent = childContent.Id });
                    await _context.SaveChangesAsync();
                }
            }

            return await _context.Contents.FindAsync(content.Id);
        }
    }
}
