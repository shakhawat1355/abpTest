using System;
using System.Collections.Generic;
using System.Text;
using MAS.FloraFire.ClientPortal.Localization;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal;

/* Inherit your application services from this class.
 */
public abstract class ClientPortalAppService : ApplicationService
{
    protected ClientPortalAppService()
    {
        LocalizationResource = typeof(ClientPortalResource);
    }
}
