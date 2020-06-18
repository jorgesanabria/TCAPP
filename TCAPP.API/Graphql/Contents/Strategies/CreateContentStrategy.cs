using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            var content = DoCreate(input);
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();
            return content;
        }

        private Content DoCreate(CreateContentInput input)
        {
            var content = new Content { Id = Guid.NewGuid(), Title = input.Title, IdContentType = input.IdContentType, Created = input.Created, Updated = input.Updated };

            if (input.Parents != null && input.Parents.Any())
            {
                content.ParentContents = input.Parents.Select(x => new ParentContent { IdParentContent = x.IdParent, IdContent = content.Id }).ToList();
            }

            if (input.Texts != null && input.Texts.Any())
            {
                content.ContentTextMetaValues = input.Texts.Select(x => new ContentTextMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, IdContent = content.Id }).ToList();
            }

            if (input.Strings != null && input.Strings.Any())
            {
                content.ContentStringMetaValues = input.Strings.Select(x => new ContentStringMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, IdContent = content.Id }).ToList();
            }

            if (input.Floats != null && input.Floats.Any())
            {
                content.ContentFloatMetaValues = input.Floats.Select(x => new ContentFloatMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, IdContent = content.Id }).ToList();
            }

            if (input.Bools != null && input.Bools.Any())
            {
                content.ContentBoolMetaValues = input.Bools.Select(x => new ContentBoolMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, IdContent = content.Id }).ToList();
            }


            if (input.Children != null && input.Children.Any())
            {
                foreach (var child in input.Children)
                {
                    var childContent = DoCreate(child);
                    content.ChildrenContents.Add(new ParentContent { Parent = content, Content = childContent });
                }
            }

            return content;
        }
    }
}
