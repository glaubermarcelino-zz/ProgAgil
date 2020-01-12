using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MachineIsRegistered()) { }
            else {
                MessageBox.Show("Não foi posível validar a licença para este computador");
                Application.Exit();
            }
        }

        public static string ID_MAQUINA = "";
        public static bool MachineIsRegistered()
        {
            RestAdapter adapter = new RestAdapter("http://localhost:5400/api/v1/machine");
            IMachine service = adapter.Create<IMachine>();
            RestResponse<Machine> machineResponse = service.GetMachineId(ID_MAQUINA);
            Machine machine = machineResponse.Data;

            return false;
        }
    }
}
