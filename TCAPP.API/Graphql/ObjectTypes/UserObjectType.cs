using HotChocolate.Types;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.ObjectTypes
{
    [ExtendObjectType(Name = "Type")]
    public class UserObjectType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name(new HotChocolate.NameString(nameof(User)));
            descriptor.Field(x => x.Id).Type<NonNullType<UuidType>>();
            descriptor.Field(x => x.Name).Type<NonNullType<StringType>>();
            descriptor.Field(x => x.Email).Type<NonNullType<StringType>>();
            descriptor.Field(x => x.Enabled).Type<NonNullType<BooleanType>>();
            descriptor.Field(x => x.Created).Type<NonNullType<DateTimeType>>();
            descriptor.Field(x => x.Updated).Type<NonNullType<DateTimeType>>();
            descriptor.Field(x => x.UserContents).Resolver(ctx =>
            {
                //TODO: ver como hacer que no estropee el funcionamiento de PlayGround. Mientras tanto volver a usar atributos
                var id = ctx.Parent<User>().Id;
                return ctx.Service<TCAPPContext>().UserContents.Where(x => x.IdUser == id);
            });
            descriptor.Field(x => x.Password).Ignore();
        }
    }
}
