using MAS.FloraFire.ClientPortal.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MAS.FloraFire.ClientPortal.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ClientPortalController : AbpControllerBase
{
    protected ClientPortalController()
    {
        LocalizationResource = typeof(ClientPortalResource);
    }
}
