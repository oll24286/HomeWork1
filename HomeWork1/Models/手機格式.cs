using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeWork1.Models
{
    //實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 "\d{4}-\d{6}" 的格式 ( e.g. 0911-111111 )
    public class 手機格式Attribute : DataTypeAttribute
    {
        public 手機格式Attribute()
            : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            var strIn = (string)value;  

            if (String.IsNullOrEmpty(strIn))
                return false;

            // Return true if strIn is in valid cellphone format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"\d{4}-\d{6}", 
                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
