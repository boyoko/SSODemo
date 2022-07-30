// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identityserver
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My Api")
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
            {
                ClientId = "Client",

                //没有交互式的用户，使用客户端/机密 来进行认证
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                //用于加密的密码
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                //定义客户端可以访问的API Scope
                AllowedScopes = { "api1" }
            }
            };
    }
}