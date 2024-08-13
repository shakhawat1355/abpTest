using Xunit;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore;

[CollectionDefinition(ClientPortalTestConsts.CollectionDefinitionName)]
public class ClientPortalEntityFrameworkCoreCollection : ICollectionFixture<ClientPortalEntityFrameworkCoreFixture>
{

}
