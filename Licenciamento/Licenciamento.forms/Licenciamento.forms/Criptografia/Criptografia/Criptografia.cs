namespace Licenciamento.forms
{
    public class Criptografia
    {
        private static readonly string vsChaveCrip = "gwsta!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierodlskajsçew124jfur9485juapr02a!KSA;D%v72qweuidaICdj54fksierodlskagestjsçew124jfur9485juapr02a!KSA;D%v72qweuidICdj54fksierjessodlskajsçew124jfur9485juapr02aa!KSA;D%v72qweuidICdj5";

        public static string DecodificaSenha(string vsSenha)
        {
            if (string.IsNullOrEmpty(vsSenha))
                return string.Empty;

            if (vsSenha.EndsWith("@BI@"))
                vsSenha = vsSenha.Replace("@BI@", " ");

            byte[] vsSaida = stringToByte(vsSenha);
            byte[] vbChave = stringToByte(vsChaveCrip);
            byte[] vbSenhaAux = stringToByte(vsSenha);

            for (int i = 0; i < vbSenhaAux.Length; i++)
            {
                int viCod = vbSenhaAux[i] - ((i >= vbChave.Length) ? 0 : vbChave[i]);
                if ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod + 126;
                }
                while ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod - vbChave[i];
                    if ((viCod > 126) || (viCod < 32))
                    {
                        viCod = viCod + 126;
                    }
                }
                vsSaida[i] = (byte)(viCod);
            }
            return ByteTostring(vsSaida);
        }

        public static string CodificaSenha(string vsSenha)
        {
            if (string.IsNullOrEmpty(vsSenha))
                return string.Empty;

            byte[] vbSaida = stringToByte(vsSenha);
            byte[] vbChave = stringToByte(vsChaveCrip);
            byte[] vbChaveAux = stringToByte(vsSenha);
            for (int i = 0; i < vbSaida.Length; i++)
            {
                int viCod = vbSaida[i] + ((i >= vbChave.Length) ? 0 : vbChave[i]);
                if ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod - 126;
                }
                while ((viCod > 126) || (viCod < 32))
                {
                    viCod = viCod + vbChave[i];
                    if ((viCod > 126) || (viCod < 32))
                    {
                        viCod = viCod - 126;
                    }
                }
                vbChaveAux[i] = (byte)(viCod);
            }
            return ByteTostring(vbChaveAux);
        }

        public static byte[] stringToByte(string Instring)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(Instring);
        }

        public static string ByteTostring(byte[] Bytes)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(Bytes);
        }
    }
}
