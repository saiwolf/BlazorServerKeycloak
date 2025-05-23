﻿using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace BlazorServerKeycloak.Components.Shared;

public class RedirectToSignin : ComponentBase
{
    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    [Inject]
    protected IHttpContextAccessor? Context { get; set; }

    protected override void OnInitialized()
    {
        if (Context?.HttpContext?.User.Identity?.IsAuthenticated != true)
        {
            var challengeUri = "./signin?redirectUrl=" + 
                               WebUtility.UrlEncode(NavigationManager?.Uri);
            NavigationManager?.NavigateTo(challengeUri, true);
        }
    }
}
