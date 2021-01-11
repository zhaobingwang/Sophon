using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Faker
{
    public class UserFaker
    {
        private readonly Bogus.DataSets.Name _name;
        private readonly Bogus.DataSets.PhoneNumbers _phoneNumbers;
        public UserFaker(string locale = Const.LANG_ZH_CN)
        {
            _name = new Bogus.DataSets.Name(locale);
            _phoneNumbers = new Bogus.DataSets.PhoneNumbers(locale);
        }

        /// <summary>
        /// 获取一个中文姓名
        /// </summary>
        /// <returns>中文姓名</returns>
        public string GetName()
        {
            var firstName = _name.FirstName();
            var lastName = _name.LastName();
            return $"{lastName}{firstName}";
        }

        /// <summary>
        /// 获取一个手机/电话号码
        /// </summary>
        /// <returns></returns>
        public string GetOnePhoneNumber()
        {
            return _phoneNumbers.PhoneNumber();
        }

    }
}
