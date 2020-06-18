using Microsoft.EntityFrameworkCore;
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

            //TODO: reemplazar los auto_increment de todo el proyecto por valores calculados por programación en los casos de inserción de content
            //TODO: reemplazar todos los auto_increment de todo el proyecto por valores generados a mano y montados en constantes de código

            _context.Entry(content).State = EntityState.Detached;

            if (input.Children != null && input.Children.Any())
            {
                foreach (var child in input.Children)
                {
                    var childContent = await CreateAsync(child);
                    //var idChild = childContent.Id;
                    //_context.Entry(childContent).State = EntityState.Detached;
                    content.ParentContents.Add(new ParentContent { Content = childContent, Parent = content });

                    await _context.SaveChangesAsync();
                }
            }

            return content;
        }
    }
}
