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

[JsonObject("Licitacao")]
public class LicitacaoM2A
{
    public string cnpj { get; set; }
    [JsonProperty("orgao_gerenciador")]
    public string orgao_gerenciador { get; set; }
    [JsonProperty("numero_licitacao")]
    public string nu_licitacao { get; set; }
    [JsonProperty("numero_processo_administrativo")]
    public string nu_processo { get; set; }
    [JsonProperty("numero_processo_administrativo")]
    public string ds_objeto { get; set; }
    public Modalidade modalidade { get; set; }
    [JsonProperty("fundamentacao_legal")]
    public string fundamentacao_legal { get; set; }
    public Classificacao classificacao { get; set; }
    [JsonProperty("criterio_julgamento")]
    public CriterioJulgamento criterio_julgamento { get; set; }
    public TipoApuracao tipo_apuracao { get; set; }
    [JsonProperty("data_autuacao")]
    public DateTime dt_autuacao { get; set; }
    [JsonProperty("codigo_comissao")]
    public string sq_comissao { get; set; }
    [JsonProperty("nome_resp_parecer")]
    public string nm_responsavel { get; set; }
    [JsonProperty("data_abertura")]
    public DateTime dt_abertura { get; set; }
    [JsonProperty("hora_abertura")]
    public string hora_abertura { get; set; }
    [JsonProperty("data_adjudicacao")]
    public object dt_adjudicacao { get; set; }
    [JsonProperty("data_homologacao")]
    public object dt_homologacao { get; set; }
    [JsonProperty("registro_preco")]
    public bool fl_registroPreco { get; set; }
    [JsonProperty("data_encerramento_pregao")]
    public object dt_encerramento { get; set; }
    public Vigencia vigencia { get; set; }
    [JsonProperty("data_publicacao")]
    public DateTime dt_publicacao { get; set; }
    public List<object> veiculo_publicacao { get; set; }
    [JsonProperty("recibo_publicacao")]
    public object recibo_publicacao { get; set; }
    [JsonProperty("edital")]
    public object edital { get; set; }
    [JsonProperty("valor_licitacao")]
    public double vl_licitacao { get; set; }
    [JsonProperty("data_ratificacao")]
    public DateTime dt_ratificacao { get; set; }
    public List<Iten> itens { get; set; }
}