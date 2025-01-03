using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientFilterSplit.Model.Sample
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class User
    {
        /// <summary>
        /// 使用者的唯一識別碼
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者的名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 使用者的電子郵件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 使用者的出生日期
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 使用者的死亡日期
        /// </summary>
        public DateTime DateOfDeath { get; set; }
    }
}
