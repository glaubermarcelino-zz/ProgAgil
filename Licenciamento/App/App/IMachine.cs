using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;

namespace App
{
    public interface IMachine
    {

        [Get("machine/{id}")]
        RestResponse<Machine> GetMachineId([Path("id")] string id);

        [Get("machine/{id}")]
        RestResponse<Machine> GetMachinePermission([Path("id")] int id, [Query("limit")] int limit, [Query("test")] string test);

        string GetMachineIdLocal();
        [Get("machine")]
        RestResponse<Machine> AutenticateMachine(string MachineId);
    }
}
