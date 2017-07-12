using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Model
{
    /// <summary>
    /// 伞租赁器
    /// </summary>
    [Table("sys_device")]
    public class UmbrellaDevice
    {
        /// <summary>
        /// 主板编号
        /// </summary>
        [Key]
        public string DeviceId { get; set; }

        /// <summary>
        /// 读头编号
        /// </summary>
        public int ReaderIndex { get; set; }
    }
}
