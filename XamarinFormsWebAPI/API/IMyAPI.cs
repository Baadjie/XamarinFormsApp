using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsWebAPI.Model;

namespace XamarinFormsWebAPI.API
{
    interface IMyAPI
    {

        [Get("/Api/Register")]
        Task<string> getOTP([Body] Client user);

        [Post("/Api/Signi")]
        Task<string> LoginUser([Body] tblUser user);

        [Post("/Api/Register")]
        Task<string> RegisterUser([Body] tblUser user);

        [Put("/Api/Register")]
        Task<string> ResertPass([Body] Client user);

        [Put("/Api/UpdateUsername")]
        Task<string> ResertUser([Body] Client user);

    }
}
