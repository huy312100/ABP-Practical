using Demo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Demo.Permissions;

public class DemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DemoPermissions.GroupName);

        var employeesPermission = myGroup.AddPermission(DemoPermissions.Employees.Default, L("Permission:Employees"));
        employeesPermission.AddChild(DemoPermissions.Employees.Create, L("Permission:Employees.Create"));
        employeesPermission.AddChild(DemoPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        employeesPermission.AddChild(DemoPermissions.Employees.Delete, L("Permission:Employees.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DemoResource>(name);
    }
}
