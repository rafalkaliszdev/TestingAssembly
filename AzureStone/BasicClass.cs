using System;
using System.Security.Cryptography;
//using System.Security.Cryptography.al
using System.Text;
using TestingAssembly;

namespace AzureStone
{
    public class BasicClass : IInterface
    {
        private string _property;
        //public BasicClass(string init)
        //{
        //    this._property = init;
        //}

        public BasicClass()
        {
            this._property = "hello world";
        }

        public string ReturnHashed()
        {
            var q = MD5.Create();

            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(_property));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
