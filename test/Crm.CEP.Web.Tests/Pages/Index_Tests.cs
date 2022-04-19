using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Crm.CEP.Pages;

public class Index_Tests : CEPWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
