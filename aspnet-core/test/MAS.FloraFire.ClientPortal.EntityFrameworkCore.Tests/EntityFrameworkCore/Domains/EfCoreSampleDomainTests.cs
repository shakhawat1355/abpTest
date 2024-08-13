using MAS.FloraFire.ClientPortal.Samples;
using Xunit;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore.Domains;

[Collection(ClientPortalTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ClientPortalEntityFrameworkCoreTestModule>
{

}
