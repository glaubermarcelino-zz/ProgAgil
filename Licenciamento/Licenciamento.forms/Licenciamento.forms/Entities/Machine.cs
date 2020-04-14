using System;

namespace Licenciamento.forms.Entities
{
    public class Machine
    {
        public int id_mach { get; set; }//MachineId

        public string nome_mach { get; set; }//Name
        public string unc_mach { get; set; }//MachineUniqueIdentifier
        public DateTime dtatc_mach { get; set; }//DateActivation
        public DateTime dtupd_mach { get; set; }//DateUpdate
        public DateTime? dtult_vald_mach { get; set; }//DateLastValidate
        public DateTime? dprox_vald_mach { get; set; }//DateNextValidate
        public bool status_mach { get; set; }//MachineActive
        public string chave_mach { get; set; }//Chave
    }
}
