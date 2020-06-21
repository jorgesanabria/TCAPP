using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTaxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentTaxonomies
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentTaxonomyMutation
    {
        public async Task<ContentTaxonomy> CreateContentTaxonomy(
            [Service] IAsyncCreateStrategy<ContentTaxonomy, CreateOrDeleteContentTaxonomyInput> strategy,
            CreateOrDeleteContentTaxonomyInput contentTaxonomy
        ) => await strategy.CreateAsync(contentTaxonomy);
        public async Task<bool> DeleteContentTaxonomy(
            [Service] IAsyncDeleteStrategy<CreateOrDeleteContentTaxonomyInput> strategy,
            CreateOrDeleteContentTaxonomyInput contentTaxonomy
        )
        {
            await strategy.DeleteAsync(contentTaxonomy);
            return true;
        }
    }
}
