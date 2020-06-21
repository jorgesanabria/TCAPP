using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Taxonomies.ParentTaxonomies
{
    [ExtendObjectType(Name = "Mutation")]
    public class ParentTaxonomyMutation
    {
        public async Task<ParentTaxonomy> CreateParentTaxonomy(
            [Service] IAsyncCreateStrategy<ParentTaxonomy, CreateOrDeleteParentTaxonomyInput> strategy,
            CreateOrDeleteParentTaxonomyInput parentTaxonomy
        ) => await strategy.CreateAsync(parentTaxonomy);
        public async Task<bool> DeleteParentTaxonomy(
            [Service] IAsyncDeleteStrategy<CreateOrDeleteParentTaxonomyInput> strategy,
            CreateOrDeleteParentTaxonomyInput parentTaxonomy
        )
        {
            await strategy.DeleteAsync(parentTaxonomy);
            return true;
        }
    }
}
