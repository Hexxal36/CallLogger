// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CallLogger.Client.Shared.Forms
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
#line 1 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Shared\Forms\ContactForm.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Shared\Forms\ContactForm.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Shared\Forms\ContactForm.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class ContactForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\1\source\repos\CallLogger\CallLogger\Client\Shared\Forms\ContactForm.razor"
       
    [Parameter]
    public Contact Contact { get; set; }

    private Contact _contact = new();

    [Parameter]
    public string Method { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override void OnParametersSet()
    {
        if (Contact != null && Method == "Put")
        {
            _contact = Contact;
        }
    }

    private async Task Submit()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        _contact.User = authState.User.Identity.Name;

        var content = JsonSerializer.Serialize(_contact);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");


        var postResult = new HttpResponseMessage();
        switch (Method)
        {
            case "Post":
                postResult = await _client.PostAsync("https://localhost:44375/contact", bodyContent);
                break;
            case "Put":
                postResult = await _client.PutAsync($"https://localhost:44375/contact/{_contact.Id}", bodyContent);
                break;
            default:
                break;
        }
        var postContent = await postResult.Content.ReadAsStringAsync();
        if (!postResult.IsSuccessStatusCode)
        {
            throw new ApplicationException(postContent);
        }

        NavManager.NavigateTo("/contacts");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _client { get; set; }
    }
}
#pragma warning restore 1591