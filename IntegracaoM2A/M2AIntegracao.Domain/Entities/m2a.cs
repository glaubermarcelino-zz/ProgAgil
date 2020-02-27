public class Modalidade
{
    public int codigo { get; set; }
    public string descricao { get; set; }
}

public class Classificacao
{
    public int codigo { get; set; }
    public string descricao { get; set; }
}

public class CriterioJulgamento
{
    public int codigo { get; set; }
    public string descricao { get; set; }
}

public class TipoApuracao
{
    public int codigo { get; set; }
    public string descricao { get; set; }
}

public class Vigencia
{
    public string tipo { get; set; }
    public int prazo { get; set; }
}

public class UnidadesFornecimento
{
    public int codigo { get; set; }
    public string unidade_medida { get; set; }
    public string sigla { get; set; }
    public double capacidade { get; set; }
}

public class Iten
{
    public int sequencial { get; set; }
    public int codigo { get; set; }
    public string descricao { get; set; }
    public string especificacao { get; set; }
    public UnidadesFornecimento unidades_fornecimento { get; set; }
    public double quantidade { get; set; }
    public double valor_estimado { get; set; }
}

public class LicitacaoM2A
{
    public string cnpj { get; set; }
    public string orgao_gerenciador { get; set; }
    public string numero_licitacao { get; set; }
    public string numero_processo_administrativo { get; set; }
    public string objeto { get; set; }
    public Modalidade modalidade { get; set; }
    public string fundamentacao_legal { get; set; }
    public Classificacao classificacao { get; set; }
    public CriterioJulgamento criterio_julgamento { get; set; }
    public TipoApuracao tipo_apuracao { get; set; }
    public DateTime data_autuacao { get; set; }
    public string codigo_comissao { get; set; }
    public string nome_resp_parecer { get; set; }
    public DateTime data_abertura { get; set; }
    public string hora_abertura { get; set; }
    public object data_adjudicacao { get; set; }
    public object data_homologacao { get; set; }
    public bool registro_preco { get; set; }
    public object data_encerramento_pregao { get; set; }
    public Vigencia vigencia { get; set; }
    public DateTime data_publicacao { get; set; }
    public List<object> veiculo_publicacao { get; set; }
    public object recibo_publicacao { get; set; }
    public object edital { get; set; }
    public double valor_licitacao { get; set; }
    public DateTime data_ratificacao { get; set; }
    public List<Iten> itens { get; set; }
}