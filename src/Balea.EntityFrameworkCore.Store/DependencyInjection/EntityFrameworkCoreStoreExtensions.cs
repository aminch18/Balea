﻿using System;
using Balea.Abstractions;
using Balea.EntityFrameworkCore.Store;
using Balea.EntityFrameworkCore.Store.DbContexts;
using Balea.EntityFrameworkCore.Store.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkCoreStoreExtensions
    {
        public static  IBaleaBuilder AddEntityFrameworkCoreStore(this IBaleaBuilder builder, Action<StoreOptions> configurer = null)
        {
            var options = new StoreOptions();
            configurer?.Invoke(options);

            builder.Services.AddDbContext<StoreDbContext>(optionsAction => options.ConfigureDbContext?.Invoke(optionsAction));

            builder.Services.AddScoped<IRuntimeAuthorizationServerStore, EntityFrameworkCoreRuntimeAuthorizationServerStore>();

            return builder;
        }
    }
}