using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SysBasicClass
{
    /// <summary>
    /// DES加密解密类
    /// </summary>
    public class DESEncrypt
    {

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            return Encrypt(str, "Luxshare");
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="p">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string str, string key)
        {
            if (str.Length>0 && key.Length>0)
            {
                try
                {
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] inputByteArray = Encoding.Default.GetBytes(str);
                    des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    StringBuilder ret = new StringBuilder();
                    foreach (byte b in ms.ToArray())
                    {
                        ret.AppendFormat("{0:X2}", b);
                    }
                    ret.ToString();
                    return ret.ToString();
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <returns></returns>
        public static string Decrypt(string str)
        {
            return Decrypt(str, "Luxshare");
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="p">密钥</param>
        /// <returns></returns>
        public  static string Decrypt(string str, string key)
        {
            if (str.Length>0 && key.Length>0)
            {
                try
                {
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] inputByteArray = new byte[str.Length / 2];
                    for (int x = 0; x < str.Length/2; x++)
                    {
                        int i = Convert.ToInt32(str.Substring(x * 2, 2), 16);
                        inputByteArray[x] = (byte)i;
                    }
                    des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.FlushFinalBlock();
                    StringBuilder ret = new StringBuilder();
                    return System.Text.Encoding.Default.GetString(ms.ToArray());
                }
                catch (Exception)
                {
                    
                    return null;
                }
            }
            return null;
        }


        public static string GetLoginKey(string UserName)
        {
            string key = "t=" + DateTime.Now.ToString() + "&&a=" + UserName + "&&y=128";
            return Encrypt(key, "Cn8mrI*4");
        }
    }
}
