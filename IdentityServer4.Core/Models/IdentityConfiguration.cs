﻿using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer4.Core.Models
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
  new List<TestUser>
  {
        new TestUser
        {
            SubjectId = "123",
            Username = "Jayam",
            Password = "Test@123",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "Jayamoorthi P"),
                new Claim(JwtClaimTypes.GivenName, "Jayamoorthi"),
                new Claim(JwtClaimTypes.FamilyName, "Parasuraman"),
                new Claim(JwtClaimTypes.WebSite, "https://gowthamcbe.com/"),
            }
        }
    };
        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        };
        public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
        new ApiScope("api.read"),
        new ApiScope("api.write"),
    };

        public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
    {
        new ApiResource("myApi")
        {
            Scopes = new List<string>{ "api.read", "api.write" },
            ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
        }
    };

        public static IEnumerable<Client> Clients =>
    new Client[]
    {
        new Client
        {
            ClientId = "client",
            ClientName = "Client Credentials Client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "api.read" }
        },
    };
    }
}
