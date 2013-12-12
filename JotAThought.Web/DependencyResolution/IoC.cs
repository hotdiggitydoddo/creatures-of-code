// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
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


using JotAThought.Domain.Contracts;
using JotAThought.Domain.Services;
using JotAThought.Model;
using StructureMap;
using System.Data.Entity;
using JotAThought.DAL;
using SimpleCrypto;
namespace JotAThought.Web.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();
                            x.For<IRepository<Post>>().HttpContextScoped().Use<Repository<Post>>();
                            x.For<IPostService>().HttpContextScoped().Use<PostService>();
                            x.For<IFormsAuthentication>().HttpContextScoped().Use<JotAThought.Web.Services.FormsAuthService>();
                            x.For<IUserService>().HttpContextScoped().Use<UserService>();
                            x.For<DbContext>().Use<BlogDbContext>();
                            x.For<ICryptoService>().HttpContextScoped().Use<SimpleCrypto.PBKDF2>();
                            x.For<IRepository<User>>().HttpContextScoped().Use<Repository<User>>();
                        });
            return ObjectFactory.Container;
        }
    }
}