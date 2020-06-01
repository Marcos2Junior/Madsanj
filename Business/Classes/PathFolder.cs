using Business.Classes;
using Business.Classes.Criptografia;
using Data.Enum;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Business
{
    public class PathFolder
    {
        private TipoPath TipoPath { get; set; }
        private string Conteudo { get; set; }
        private string NomeDocumento { get; set; }
        public string Senha { get; set; }

        //gerar novo arquivo
        public PathFolder(TipoPath tipoPath, string conteudo)
        {
            TipoPath = tipoPath;
            Conteudo = conteudo;
        }

        #region Senha

        /// <summary>
        /// Para ler arquivo senha
        /// </summary>
        /// <param name="nomeDocumento"></param>
        /// <param name="senha"></param>
        public PathFolder(string nomeDocumento, string senha)
        {
            TipoPath = TipoPath.Senha;
            NomeDocumento = nomeDocumento;
            Senha = senha;
        }


        private async void Encrypt()
        {
            string PublicKey = SelecionaDiretorio().FullName + @"Keys\G424UG284234G2834BVFWAQ320934UQFLWKF23";

            string OutputFile = SelecionaDiretorio().FullName + NomeDocumento;
            string InputFile = OutputFile + ".temp";

            using (StreamWriter sw = File.CreateText(InputFile))
            {
                await sw.WriteLineAsync(Conteudo);
            }

            PGPEncryptDecrypt.EncryptFile(InputFile, OutputFile, PublicKey, false, false);

            File.Delete(InputFile);
        }

        public async Task<string> ReadDocumentSenha()
        {
            string keyPrivate = SelecionaDiretorio().FullName + @"Keys\532A8A73D8C7D8703478055A97B25834BD6B060D.asc";

            string filename = SelecionaDiretorio().FullName + NomeDocumento;

            string filenametemp = filename + ".temp";

            PGPEncryptDecrypt.Decrypt(filename, keyPrivate, Senha, filenametemp);

            string[] resultRead = await File.ReadAllLinesAsync(filenametemp);

            File.Delete(filenametemp);

            string result = string.Empty;
            for (int i = 0; i < resultRead.Length; i++)
                result += resultRead[i];

            return result;
        }

        #endregion

        public void NewDocument()//Criar uma classe de retorno de metodos status false e msg
        {
            Password password = new Password();
            while (true)
            {
                NomeDocumento = password.NewPassword(30, false, true, false);

                if (!VerificaExistencia())
                    break;
            }

            switch (TipoPath)
            {
                case TipoPath.Senha:
                    Encrypt();
                    break;

                case TipoPath.Imagem:
                    break;
            }
        }

        private DirectoryInfo SelecionaDiretorio()
        {
            return Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory())
                + $@"\Data\Documents\{TipoPath}\");
        }

        private bool VerificaExistencia()
        {
            return File.Exists(SelecionaDiretorio().FullName + NomeDocumento);
        }
    }
}
