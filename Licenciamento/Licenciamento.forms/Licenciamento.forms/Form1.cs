using Licenciamento.forms.Entities;
using Licenciamento.forms.Interfaces;
using Licenciamento.forms.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenciamento.forms
{
    public partial class Form1 : Form
    {
        public string machineCode = string.Empty;
        public IMachine machine =  new MachineRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            machineCode = machine.GetMachineIdLocal();
            lblSerialEstacao.Text = machineCode;


            //Autenticou a maquinia
            
            var machineReturn = await machine.AutenticateMachine(machineCode);

            if (machineReturn.chave_mach!=null && machineReturn.status_mach ==true)
            {
                lblSerialEstacao.Text += " Estação Liberada";
                //Maquinia autenticada, aqui vai gravar a data da autenticação
            }
            //Maquinia não esta liberada ou autorizada para uso do sistema
            else
            {
                MessageBox.Show("Estação não liberada, a aplicação ira fechar em 15 segundos");
                await Task.Delay(TimeSpan.FromSeconds(15));
                Application.Exit();
            }
        }

        private async void btnAtivar_Click(object sender, EventArgs e)
        {
            //Ativar estação bloqueada
            var machineUpdate = await machine.GetMachineId(this.machineCode);
            if (machineUpdate != null)
            {
                machineUpdate.status_mach = true;
                await machine.UpdateMachine(machineUpdate,this.machineCode);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Cadastrar uma nova estação
            Machine NewMachine = new Machine()
            {
                chave_mach      = this.machineCode,
                dprox_vald_mach = null,
                dtatc_mach      = DateTime.Now,
                dtult_vald_mach = null,
                dtupd_mach      = DateTime.Now,
                nome_mach       = "Nome do Cliente",
                status_mach     = false,
                unc_mach        = this.machineCode
            };

            var retorno = machine.RegisterMachine(NewMachine);
            if (retorno != null)
            {
                MessageBox.Show("Registro efetuado com sucesso!");
            }
        }

        private async void btnBloquear_Click(object sender, EventArgs e)
        {

            //Bloquear
            var machineUpdate = await machine.GetMachineId(this.machineCode);
            machineUpdate.status_mach = false;
            if (machineUpdate != null)
            {
                var retorno =  await machine.UpdateMachine(machineUpdate, this.machineCode);
                if (retorno !=null)
                {
                    MessageBox.Show("Bloqueio efetuado com sucesso");
                }
            }
        }

        private async void btnStatus_Click(object sender, EventArgs e)
        {
            //Verificar o status
            var statusMachine = await machine.GetMachineId(this.machineCode);
            MessageBox.Show(string.Format("Status: {0}",statusMachine.status_mach ==false? "Inativo" : "Ativo"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetNetworkTime().ToString());
        }

        public static DateTime GetNetworkTime()
        {
            try
            {
                //Servidor nacional para melhor latência
                const string ntpServer = "a.ntp.br";
                // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
                var ntpData = new byte[48];
                //Indicador de Leap (ver RFC), Versão e Modo
                ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)
                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
                //123 é a porta padrão do NTP
                var ipEndPoint = new IPEndPoint(addresses[0], 123);
                //NTP usa UDP
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Connect(ipEndPoint);
                //Caso NTP esteja bloqueado, ao menos nao trava o app
                socket.ReceiveTimeout = 3000;
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
                //Offset para chegar no campo "Transmit Timestamp" (que é
                //o do momento da saída do servidor, em formato 64-bit timestamp
                const byte serverReplyTime = 40;
                //Pegando os segundos
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
                //e a fração de segundos
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
                //Passando de big-endian pra little-endian
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);
                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                //Tempo em **UTC**
                var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
                return networkDateTime.ToLocalTime();
            }
            catch
            {
                return default;
            }
        }
        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
    }
}
