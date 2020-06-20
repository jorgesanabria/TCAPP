using System;
using System.Linq;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.ConcreteData.Contents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.ConcreteData.Contents
{
    public class CreateContentStrategy : IAsyncCreateStrategy<Content, CreateContentInput>
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
            return await _context.Contents.FindAsync(content.Id);
        }

        private Content DoCreate(CreateContentInput input)
        {
            var created = input.Created ?? DateTime.Now;
            var content = new Content { Id = Guid.NewGuid(), Title = input.Title, IdContentType = input.IdContentType, Created = created, Updated = created, Enabled = input.Enabled };

            if (input.UserContents != null && input.UserContents.Any())
            {
                content.UserContents = input.UserContents.Select(x => new UserContent { Content = content, IdUser = x.IdUser, IdContentRelationType = x.IdContentRelationType }).ToList();
            }

            if (input.Parents != null && input.Parents.Any())
            {
                content.ParentContents = input.Parents.Select(x => new ParentContent { IdParentContent = x.IdParent, Content = content }).ToList();
            }

            if (input.Texts != null && input.Texts.Any())
            {
                content.ContentTextMetaValues = input.Texts.Select(x => new ContentTextMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, Content = content, Enabled = x.Enabled, Created = content.Created, Updated = content.Updated }).ToList();
            }

            if (input.Strings != null && input.Strings.Any())
            {
                content.ContentStringMetaValues = input.Strings.Select(x => new ContentStringMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, Content = content, Enabled = x.Enabled, Created = content.Created, Updated = content.Updated }).ToList();
            }

            if (input.Floats != null && input.Floats.Any())
            {
                content.ContentFloatMetaValues = input.Floats.Select(x => new ContentFloatMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, Content = content, Enabled = x.Enabled, Created = content.Created, Updated = content.Updated }).ToList();
            }

            if (input.Bools != null && input.Bools.Any())
            {
                content.ContentBoolMetaValues = input.Bools.Select(x => new ContentBoolMetaValue { Value = x.Value, IdMetaValueType = x.IdMetaValueType, Content = content, Enabled = x.Enabled, Created = content.Created, Updated = content.Updated }).ToList();
            }

            if (input.ContentTaxonomies != null && input.ContentTaxonomies.Any())
            {
                content.ContentTaxonomies = input.ContentTaxonomies.Select(x => new ContentTaxonomy { IdTaxonomy = x.IdTaxonomy, Content = content }).ToList();
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
