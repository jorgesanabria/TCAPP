﻿using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.ContentRelationTypes;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateContentRelationTypeStrategy : IAsyncUpdate<ContentRelationType, UpdateContentRelationTypeInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentRelationTypeStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentRelationType> UpdateAsync(UpdateContentRelationTypeInput input)
        {
            var entity = await _context.ContentRelationTypes.FindAsync(input.Id);
            entity.Updated = DateTime.Now;
            entity.Title = input.Title ?? entity.Title;
            entity.Enabled = input.Enabled ?? entity.Enabled;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}