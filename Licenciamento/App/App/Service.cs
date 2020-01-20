using RestSharp;
using Retrofit.Net;

namespace App
{
    public static class Service
    {
        public static bool MachineIsRegistered2()
        {
            RestAdapter adapter = new RestAdapter("http://localhost:5400/api/v1/machine");
            IMachine service = adapter.Create<IMachine>();
            RestResponse<Machine> machineResponse = service.AutenticateMachine(service.GetMachineIdLocal());
            Machine machine = machineResponse.Data;

            return false;
        }

        
    }
}
