using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace TCAPP.API.Graphql.Test
{
    public class TestQueryType : ObjectType<TestQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<TestQueries> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(f => f.GetContents(default));
        }
    }
}
