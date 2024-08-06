using Demo.Books;
using Xunit;

namespace Demo.EntityFrameworkCore.Applications.Books;

[Collection(DemoTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<DemoEntityFrameworkCoreTestModule>
{

}