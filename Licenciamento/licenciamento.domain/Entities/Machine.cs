using System;

namespace licenciamento.domain
{
    public class Machine
    {
        public int  MachineId { get; set; }

        public string Name { get; set; }
        public string MachineUniqueIdentifier { get; set; }

        public DateTime DateActivation{get;set;}
        public DateTime DateUpdate{get;set;}
        public DateTime? DateLastValidate{get;set;}
        public DateTime? DateNextValidate { get; set; }
        public bool MachineActive { get; set; }
    }
}
