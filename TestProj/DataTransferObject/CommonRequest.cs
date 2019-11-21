using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    /// <summary>
    /// 處理狀態
    /// </summary>
    public enum StateEnum
    {
        /// <summary>
        /// 失敗
        /// </summary>
        Fail = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 逾時
        /// </summary>
        Timeout = 2,
    }

    /// <summary>
    /// 標準回傳內容
    /// </summary>
    public class CommonRequest
    {
        /// <summary>
        /// 執行狀態
        /// </summary>
        public StateEnum State { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
    }
}
