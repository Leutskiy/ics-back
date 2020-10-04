// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapWebApi.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using ICS.Domain.Registries;
using ICS.WebApp.Controllers;
using ICS.WebApp.DependencyResolution;
using ICS.WebApplication.Commands.Registries;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using StructureMap;

//[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ICS.WebApp.App_Start.StructuremapWebApi), "Start")]

namespace ICS.WebApp.App_Start {
    public static class StructuremapWebApi {
        public static IContainer Start(HttpConfiguration config) {
			var container = StructuremapMvc.StructureMapDependencyScope.Container;

            container.Configure(c => 
            {
                c.AddRegistry<AdapterRegistry>();
                c.AddRegistry<ServiceRegistry>();
                c.AddRegistry<CommandRegistry>();
                c.AddRegistry<RepositoryRegistry>();

                c.For<OAuthAuthorizationServerProvider>().Use<SimpleAuthorizationServerProvider>();

            });

            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);

            return container;
        }
    }
}