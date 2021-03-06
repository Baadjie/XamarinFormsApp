﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using Refit;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsWebAPI.Model;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace XamarinFormsWebAPI.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

namespace XamarinFormsWebAPI.API
{
    using XamarinFormsWebAPI.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIMyAPI : IMyAPI
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIMyAPI(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<string> IMyAPI.getOTP(Client user)
        {
            var arguments = new object[] { user };
            var func = requestBuilder.BuildRestResultFuncForMethod("getOTP", new Type[] { typeof(Client) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.LoginUser(tblUser user)
        {
            var arguments = new object[] { user };
            var func = requestBuilder.BuildRestResultFuncForMethod("LoginUser", new Type[] { typeof(tblUser) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.RegisterUser(tblUser user)
        {
            var arguments = new object[] { user };
            var func = requestBuilder.BuildRestResultFuncForMethod("RegisterUser", new Type[] { typeof(tblUser) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.ResertPass(Client user)
        {
            var arguments = new object[] { user };
            var func = requestBuilder.BuildRestResultFuncForMethod("ResertPass", new Type[] { typeof(Client) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.ResertUser(Client user)
        {
            var arguments = new object[] { user };
            var func = requestBuilder.BuildRestResultFuncForMethod("ResertUser", new Type[] { typeof(Client) });
            return (Task<string>)func(Client, arguments);
        }
    }
}
