namespace M2AIntegracao.Domain.Entities
{
    public class Grupo
    {
        public int GrupoId{get;set;}
        public int CdGrupo{get;set;}
        public int GrupoSuperior{get;set;}
        public string DescricaoGrupo{get;set;}
        public int CdGrupoExportacao{get;set;}
    }
}