using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IMachine
    {

            [Get("machine/{id}")]
            RestResponse<Machine> GetMachineId([Path("id")] string id);

            [Get("machine/{id}")]
            RestResponse<Machine> GetMachinePermission([Path("id")] int id, [Query("limit")] int limit, [Query("test")] string test);
    }
}
