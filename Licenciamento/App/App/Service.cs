using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class Service
    {
        public static string ID_MAQUINA = "";
        public static bool MachineIsRegistered2()
        {
            RestAdapter adapter = new RestAdapter("http://localhost:5400/api/v1/machine");
            IMachine service = adapter.Create<IMachine>();
            RestResponse<Machine> machineResponse = service.GetMachineId(ID_MAQUINA);
            Machine machine = machineResponse.Data;

            return false;
        }

        
    }
}
