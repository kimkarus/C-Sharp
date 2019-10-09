using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace NalogUser.Classes
{
    public class Encryption
    {
        string encryPass;
        string encryString;
        int defI = 10;
        int defJ = 3;
 
        public string Encryptor()
        {
            encryPass = CreSap();
            return encryPass;
        }
        public string Encryptor(string encrStr)
        {
            encryPass= CreSap();
            encryString = Encrypt(encrStr);
            return encryString;
        }
        public string EncryptorSha(string encrStr)
        {
            encryString = EncryptSha(encrStr);
            return encryString;
        }
        public string Decryptor(string str_cry)
        {
            encryPass = CreSap();
            encryString = Decrypt(str_cry);
            return encryString;
        }
        public string EncryptStr
        {
            get { return encryString; }
            set { encryString = Encrypt(value); }
             
        }
    
        double SimAlgEncry(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return SimAlgEncry(n - 1) + SimAlgEncry(n - 2);
                }
            }
        }
        string CreSap()
        {
            return Math.Pow(SimAlgEncry(10),3).ToString();
        }
        /// <summary>
        /// Encrypt string
        /// </summary>
        /// <param name="source_str"></param>
        /// <returns></returns>
        string Encrypt(string source_str)
        {
            // Получаем из строки набор байт, которые будем шифровать
            byte[] source_data = Encoding.UTF8.GetBytes(source_str);
            // Алгоритм 
            SymmetricAlgorithm sa_in = Rijndael.Create();
            // Объект для преобразования данных
            ICryptoTransform ct_in = sa_in.CreateEncryptor(
                (new PasswordDeriveBytes(encryPass, null)).GetBytes(16), new byte[16]);
            // Поток
            MemoryStream ms_in = new MemoryStream();
            // Шифровальщик потока
            CryptoStream cs_in = new CryptoStream(ms_in, ct_in, CryptoStreamMode.Write);
            // Записываем шифрованные данные в поток
            cs_in.Write(source_data, 0, source_data.Length);
            cs_in.FlushFinalBlock();
            // Создаем строку
            return  Convert.ToBase64String(ms_in.ToArray());
            // Выводим зашифрованную строку
 
        }
        /// <summary>
        /// Decrypt string
        /// </summary>
        /// <param name="crypt_str"></param>
        /// <returns></returns>
        string Decrypt(string crypt_str)
        {
            string source_out = "";
            try
            {
                byte[] crypt_data = crypt_data = Convert.FromBase64String(crypt_str);
                // Алгоритм 
                SymmetricAlgorithm sa_out = Rijndael.Create();
                // Объект для преобразования данных
                ICryptoTransform ct_out = sa_out.CreateDecryptor(
                    (new PasswordDeriveBytes(encryPass, null)).GetBytes(16),
                    new byte[16]);
                // Поток
                MemoryStream ms_out = new MemoryStream(crypt_data);
                // Расшифровываем поток
                CryptoStream cs_out = new CryptoStream(ms_out, ct_out, CryptoStreamMode.Read);
                // Создаем строку
                StreamReader sr_out = new StreamReader(cs_out);

                source_out = sr_out.ReadToEnd();
            }
            catch (System.Exception err)
            {
                source_out = "error";
            }
            return source_out;
        }
        string EncryptSha(string source_str)
        {
            string enc = "";
            byte[] data = Encoding.Unicode.GetBytes(source_str);
            enc = BitConverter.ToString(new SHA256CryptoServiceProvider().ComputeHash(data));
            enc = enc.Replace("-", "");
            enc = enc.ToLower();
            return enc;
        }
    }
}
