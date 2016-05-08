﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Models;

namespace OpenIddict {
    public class OpenIddictContext<TUser, TApplication, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TApplication : Application<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey> {
        protected OpenIddictContext() { }

        public OpenIddictContext(DbContextOptions options)
            : base(options) { }

        public DbSet<TApplication> Applications { get; set; }
    }

    public class OpenIddictContext<TUser> : OpenIddictContext<TUser, Application, IdentityRole, string> where TUser : IdentityUser {
        protected OpenIddictContext() { }

        public OpenIddictContext(DbContextOptions options)
            : base(options) { }
    }

    public class OpenIddictContext : OpenIddictContext<IdentityUser> {
        protected OpenIddictContext() { }

        public OpenIddictContext(DbContextOptions options)
            : base(options) { }
    }
}