using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Test
{
    public class TestQueries
    {
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Content> GetContents([Service] TCAPPContext context)
        {
            return context.Contents;
        }
    }
}
