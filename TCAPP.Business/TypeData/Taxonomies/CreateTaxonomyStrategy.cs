using System;
using System.Linq;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.Domain.TypeData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.TypeData.Taxonomies
{
    public class CreateTaxonomyStrategy : IAsyncCreateStrategy<Taxonomy, CreateTaxonomyInput>
    {
        private readonly TCAPPContext _context;
        public CreateTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<Taxonomy> CreateAsync(CreateTaxonomyInput input)
        {
            var taxonomy = DoCreate(input);
            _context.Taxonomies.Add(taxonomy);
            await _context.SaveChangesAsync();
            return _context.Taxonomies.Find(taxonomy.Id);
        }
        private static Taxonomy DoCreate(CreateTaxonomyInput input)
        {
            var taxonomy = new Taxonomy
            {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Enabled = input.Enabled,
                Multiple = input.Multiple
            };

            if (input.ParentTaxonomies != null && input.ParentTaxonomies.Any())
            {
                foreach (var parent in input.ParentTaxonomies)
                {
                    taxonomy.ParentTaxonomies.Add(new ParentTaxonomy { IdParentTaxonomy = parent.Id, IdTaxonomy = taxonomy.Id });
                }
            }
            if (input.ChildrenTaxonomies != null && input.ChildrenTaxonomies.Any())
            {
                foreach (var child in input.ChildrenTaxonomies)
                {
                    var childTaxonomy = DoCreate(child);
                    taxonomy.ChildrenTaxonomies.Add(new ParentTaxonomy { Parent = taxonomy, Taxonomy = childTaxonomy });
                }
            }
            return taxonomy;
        }
    }
}
