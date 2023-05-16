using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Configuration;
using System.DirectoryServices;


namespace LDAPHelp
{

    public class LDAPHelper
    {
        private string userName;
        /**/
        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        /**/
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /**/
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public LDAPHelper(string userName, string password)
        {
            try
            {
                this.UserName = userName;
                this.Password = password;
            }
            catch
            {
                throw;
            }
        }
        /**/
        /// <summary>
        /// 通过domino LDAP服务验证用户名密码是否正确
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool VerifyUser(ref string message)
        {
            try
            {
                string strUser = "LDAP://ldap.luxshare.com.cn/uid=" + userName + ",ou=People,dc=luxshare-ict,dc=com";
                string strPath = "uid=" + userName + ",ou=People,dc=luxshare-ict,dc=com";

                DirectoryEntry entry = new DirectoryEntry(strUser, strPath, password, AuthenticationTypes.None);
                try
                {
                    object native1 = entry.NativeObject;
                    return true;
                }
                catch (System.Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
