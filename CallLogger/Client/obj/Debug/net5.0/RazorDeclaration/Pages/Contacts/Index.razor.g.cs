// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CallLogger.Client.Pages.Contacts
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using CallLogger.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using CallLogger.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using CallLogger.Client.Shared.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\_Imports.razor"
using CallLogger.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Pages\Contacts\Index.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Pages\Contacts\Index.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Pages\Contacts\Index.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/contacts")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 106 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Pages\Contacts\Index.razor"
       
    private List<Contact> _contacts = new();

    private AuthenticationState _authState;

    protected override async Task OnInitializedAsync()
    {
        await GetContactListAsync();
    }

    private async Task GetContactListAsync()
    {
        _authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        Console.WriteLine(_authState.User.Identity.Name);
        _contacts = await _client.GetFromJsonAsync<List<Contact>>($"/contact?user={_authState.User.Identity.Name}");
    }

    private async Task OnDeletedAsync(int id)
    {
        await _client.DeleteAsync($"/contact/{id}");
        await GetContactListAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _client { get; set; }
    }
}
#pragma warning restore 1591
