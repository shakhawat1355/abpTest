using MAS.FloraFire.ClientPortal.Samples;
using Xunit;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore.Applications;

[Collection(ClientPortalTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ClientPortalEntityFrameworkCoreTestModule>
{

}
