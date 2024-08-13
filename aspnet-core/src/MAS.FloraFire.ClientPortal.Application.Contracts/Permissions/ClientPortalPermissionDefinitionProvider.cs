using MAS.FloraFire.ClientPortal.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MAS.FloraFire.ClientPortal.Permissions;

public class ClientPortalPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var clientProtalGroup = context.AddGroup(ClientPortalPermissions.GroupName, L("Permission:ClientProtal"));
        var valueTypesPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.ValueTypes.Default, L("Permission:ValueTypes"));
        valueTypesPermission.AddChild(ClientPortalPermissions.ValueTypes.Create, L("Permission:ValueTypes.Create"));
        valueTypesPermission.AddChild(ClientPortalPermissions.ValueTypes.Edit, L("Permission:ValueTypes.Edit"));
        valueTypesPermission.AddChild(ClientPortalPermissions.ValueTypes.Delete, L("Permission:ValueTypes.Delete"));

        var commentsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.CustomerComments.Default, L("Permission:CustomerComments"));
        commentsPermission.AddChild(ClientPortalPermissions.CustomerComments.Create, L("Permission:CustomerComments.Create"));
        commentsPermission.AddChild(ClientPortalPermissions.CustomerComments.Edit, L("Permission:CustomerComments.Edit"));
        commentsPermission.AddChild(ClientPortalPermissions.CustomerComments.Delete, L("Permission:CustomerComments.Delete"));

        var valuePermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Values.Default, L("Permission:Values"));
        valuePermission.AddChild(ClientPortalPermissions.Values.Create, L("Permission:Values.Create"));
        valuePermission.AddChild(ClientPortalPermissions.Values.Edit, L("Permission:Values.Edit"));
        valuePermission.AddChild(ClientPortalPermissions.Values.Delete, L("Permission:Values.Delete"));

        var customersPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(ClientPortalPermissions.Customers.Create, L("Permission:Customers.Create"));
        customersPermission.AddChild(ClientPortalPermissions.Customers.Edit, L("Permission:Customers.Edit"));
        customersPermission.AddChild(ClientPortalPermissions.Customers.Delete, L("Permission:Customers.Delete"));

        //EmailDirectory permission definition
        var emailDirectoryPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.EmailDirectory.Default, L("Permission:EmailDirectory"));
        emailDirectoryPermission.AddChild(ClientPortalPermissions.EmailDirectory.Create, L("Permission:EmailDirectory.Create"));
        emailDirectoryPermission.AddChild(ClientPortalPermissions.EmailDirectory.Edit, L("Permission:EmailDirectory.Edit"));
        emailDirectoryPermission.AddChild(ClientPortalPermissions.EmailDirectory.Delete, L("Permission:EmailDirectory.Delete"));

        //PhoneDirectory permission definition
        var PhoneDirectoryPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.PhoneDirectory.Default, L("Permission:PhoneDirectory"));
        PhoneDirectoryPermission.AddChild(ClientPortalPermissions.PhoneDirectory.Create, L("Permission:PhoneDirectory.Create"));
        PhoneDirectoryPermission.AddChild(ClientPortalPermissions.PhoneDirectory.Edit, L("Permission:PhoneDirectory.Edit"));
        PhoneDirectoryPermission.AddChild(ClientPortalPermissions.PhoneDirectory.Delete, L("Permission:PhoneDirectory.Delete"));
        
        var corporateSettingsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.CorporateSettings.Default, L("Permission:CorporateSettings"));
        corporateSettingsPermission.AddChild(ClientPortalPermissions.CorporateSettings.Create, L("Permission:CorporateSettings.Create"));
        corporateSettingsPermission.AddChild(ClientPortalPermissions.CorporateSettings.Edit, L("Permission:CorporateSettings.Edit"));
        corporateSettingsPermission.AddChild(ClientPortalPermissions.CorporateSettings.Delete, L("Permission:CorporateSettings.Delete"));

        var valueTypeSettingsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.ValueTypeSettings.Default, L("Permission:ValueTypeSettings"));
        valueTypeSettingsPermission.AddChild(ClientPortalPermissions.ValueTypeSettings.Create, L("Permission:ValueTypeSettings.Create"));
        valueTypeSettingsPermission.AddChild(ClientPortalPermissions.ValueTypeSettings.Edit, L("Permission:ValueTypeSettings.Edit"));
        valueTypeSettingsPermission.AddChild(ClientPortalPermissions.ValueTypeSettings.Delete, L("Permission:ValueTypeSettings.Delete"));

        var vehiclesPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Vehicles.Default, L("Permission:Vehicles"));
        vehiclesPermission.AddChild(ClientPortalPermissions.Vehicles.Create, L("Permission:Vehicles.Create"));
        vehiclesPermission.AddChild(ClientPortalPermissions.Vehicles.Edit, L("Permission:Vehicles.Edit"));
        vehiclesPermission.AddChild(ClientPortalPermissions.Vehicles.Delete, L("Permission:Vehicles.Delete"));

        var shopsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Shops.Default, L("Permission:Shops"));
        shopsPermission.AddChild(ClientPortalPermissions.Shops.Create, L("Permission:Shops.Create"));
        shopsPermission.AddChild(ClientPortalPermissions.Shops.Edit, L("Permission:Shops.Edit"));
        shopsPermission.AddChild(ClientPortalPermissions.Shops.Delete, L("Permission:Shops.Delete"));

        var storesPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Stores.Default, L("Permission:Stores"));
        storesPermission.AddChild(ClientPortalPermissions.Stores.Create, L("Permission:Stores.Create"));
        storesPermission.AddChild(ClientPortalPermissions.Stores.Edit, L("Permission:Stores.Edit"));
        storesPermission.AddChild(ClientPortalPermissions.Stores.Delete, L("Permission:Stores.Delete"));

        var creditCardSettingsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.CreditCardSettings.Default, L("Permission:CreditCardSettings"));
        creditCardSettingsPermission.AddChild(ClientPortalPermissions.CreditCardSettings.Update, L("Permission:CreditCardSettings.Update"));

        var logsPermission = clientProtalGroup.AddPermission(ClientPortalPermissions.Logs.Default, L("Permission:Logs"));
        logsPermission.AddChild(ClientPortalPermissions.Logs.Create, L("Permission:Logs.Create"));
        logsPermission.AddChild(ClientPortalPermissions.Logs.Edit, L("Permission:Logs.Edit"));
        logsPermission.AddChild(ClientPortalPermissions.Logs.Delete, L("Permission:Logs.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClientPortalResource>(name);
    }
}
