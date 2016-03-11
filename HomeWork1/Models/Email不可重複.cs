using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace HomeWork1.Models
{
    //同一個客戶下的聯絡人，其 Email 不能重複。
    public class Email不可重複Attribute : ValidationAttribute
    {
        public string 客戶Id { get; private set; }
        private 客戶資料Entities db = new 客戶資料Entities();

        public Email不可重複Attribute(string 客戶id)
        {
            客戶Id = 客戶id;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Email = (string)value;
            var property = validationContext.ObjectType.GetProperty(客戶Id);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "{0} 不存在",
                        客戶Id
                    )
                );
            }

            var 客戶id = property.GetValue(validationContext.ObjectInstance, null);
            var data = db.Database.SqlQuery<客戶聯絡人>(@"  
                              SELECT *   
                              FROM dbo.客戶聯絡人 p   
                              WHERE p.客戶Id = @p0 and p.Email = @p1",客戶id, Email);

            var otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if (data.Count() != 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }


}