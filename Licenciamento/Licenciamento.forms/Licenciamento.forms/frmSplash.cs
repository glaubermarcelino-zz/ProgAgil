using Licenciamento.forms.Entities;
using Licenciamento.forms.Interfaces;
using Licenciamento.forms.Repository;
using System;
using System.Windows.Forms;

namespace Licenciamento.forms
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        public Machine machine = null;
        public int Limberado;
        public async void VerificarcaoDeSeguraca()
        {
            lbStatus.Text = "Carregando Configurações...";
            lbStatus.Refresh();
            string machineCode = string.Empty;
            try
            {
                //Pegar os dados da maquina
                IMachine iMachine = new MachineRepository();
                machineCode = iMachine.GetMachineIdLocal();
                //Update na estação
                var machineUpdate = await iMachine.GetMachineId(machineCode);
                if (machineUpdate != null)
                {
                    machineUpdate.status_mach = true;
                    machineUpdate.dtult_vald_mach = DateTime.Now;
                    _ = iMachine.UpdateMachine(machineUpdate, machineCode);
                }
                //Carregar Entidade
                machine = await iMachine.AutenticateMachine(machineCode);
            }
            catch
            {
                //caso na tenha interent ou tenha algum problema na api retrona null
                machine = null;
            }
            if (machine != null)
            {
                if (machineCode != machine.chave_mach)
                {
                    //Sistema bloqueado
                    Limberado = 3;
                    Close(); return;
                }
                else if (DateTime.Now.Date < machine.dtult_vald_mach || DateTime.Now.Date > machine.dprox_vald_mach)
                {
                    //Sistema Esta com a data Vencinda
                    Limberado = 1;
                    Close(); return;
                }
            }
            else
            {
                // 1 - aqui é o problema se não tiver internte como vai ficar?
                // 2 - iMachine.GetMachineIdLocal() sempre pegar da maquina atual como vai ser tratado isso?
                return;
            }
            //se tudo der certo libera
            Limberado = 2;
            Close();
        }


        private void frmSplash_Shown(object sender, EventArgs e)
        {
            VerificarcaoDeSeguraca();
        }
    }
}
