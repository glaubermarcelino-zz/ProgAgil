using RestSharp;
using Retrofit.Net;
using System;
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
            Machine machine = new Machine();
            txtMachineId.Text = machine.GetMachineIdLocal();

            //if(Service.MachineIsRegistered2()) 
            //{ 
            
            //}
            //else 
            //{
            //    MessageBox.Show("Não foi posível validar a licença para este computador");
            //    Application.Exit();
            //}
        }
    }
}
