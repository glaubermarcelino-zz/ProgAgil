using System;
namespace M2AIntegracao.Domain.Entities
{
    public class produto
    {
        string nu_cnpj { get; set; }
        int sq_produto { get; set; }
        int sq_produtoExportacao { get; set; }
        string nm_produto { get; set; }
        string ds_produto { get; set; }
        string cd_grupo { get; set; }
        string sg_unidade { get; set; }
        DateTime dt_alteracao { get; set; }
        DateTime dt_desativacao { get; set; }
        bool fl_migracao { get; set; }
        int sq_unidade { get; set; }
        DateTime dt_cadastro { get; set; }
        bool fl_generico { get; set; }
    }
}