using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.TypeData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Taxonomies
{
    [ExtendObjectType(Name = "Mutation")]
    public class TaxonomyMutation
    {
        public async Task<Taxonomy> CreeateTaxonomy(
            [Service] IAsyncCreateStrategy<Taxonomy, CreateTaxonomyInput> strategy,
            CreateTaxonomyInput taxonomy
        ) => await strategy.CreateAsync(taxonomy);
        public async Task<Taxonomy> UpdateTaxonomy(
            [Service] IAsyncUpdateStrategy<Taxonomy, UpdateTaxonomyInput> strategy,
            UpdateTaxonomyInput taxonomy
        ) => await strategy.UpdateAsync(taxonomy);
    }
}
