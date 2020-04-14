namespace Licenciamento.forms
{
    public class CriptografiaMD5
    {
        private static readonly string vsChaveCrip = "gwsta!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidaICdj54fksierodlskagestjsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierjessodlskajsçew124jfur9485juapr02aa!KSA;D%v72qweuidICdj5";

        public static string Codifica(string Senha)
        {
            DemoEncryption Demo = new DemoEncryption(vsChaveCrip);
            return Demo.EncryptUsernamePassword(Senha);
        }

        public static string Decodifica(string Senha)
        {
            DemoEncryption Demo = new DemoEncryption(vsChaveCrip);
            return Demo.DecryptUsernamePassword(Senha);
        }
    }
}
