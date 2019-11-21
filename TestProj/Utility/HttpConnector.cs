using DataTransferObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class HttpConnector
    {
        /// <summary>
        /// GET傳輸
        /// </summary>
        /// <param name="url">目的地網址</param>
        /// <param name="timeout">逾時(毫秒)</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns></returns>
        public static CommonRequest Get(
            string url,
            int timeout = 3000,
            string contentType = "application/json")
        {
            var result = new CommonRequest();

            try
            {
                var req = HttpWebRequest.Create(url) as HttpWebRequest;
                req.Method = "GET";
                req.ContentType = contentType;
                req.Timeout = timeout;

                using (var resp = req.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        result.Message = reader.ReadToEnd();
                    }
                }

                result.State = StateEnum.Success;
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.Timeout)
                {
                    result.State = StateEnum.Timeout;
                }
                else
                {
                    result.State = StateEnum.Fail;
                }
                result.Message = wex.Message;
            }
            catch (Exception ex)
            {
                result.State = StateEnum.Fail;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// POST傳輸
        /// </summary>
        /// <param name="url">目的地網址</param>
        /// <param name="data">傳送參數</param>
        /// <param name="encode">編碼</param>
        /// <param name="timeout">逾時(毫秒)</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns></returns>
        public static CommonRequest Post(
            string url,
            string data,
            Encoding encode,
            int timeout = 3000,
            string contentType = "application/json")
        {
            var result = new CommonRequest();

            try
            {
                var req = HttpWebRequest.Create(url) as HttpWebRequest;
                req.Method = "POST";
                req.ContentType = contentType;
                req.Timeout = timeout;

                #region Body
                var buf = encode.GetBytes(data);
                req.ContentLength = buf.Length;
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(buf, 0, buf.Length);
                }
                #endregion

                #region Response
                using (var resp = req.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        result.Message = reader.ReadToEnd();
                    }
                }
                #endregion

                result.State = StateEnum.Success;
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.Timeout)
                {
                    result.State = StateEnum.Timeout;
                }
                else
                {
                    result.State = StateEnum.Fail;
                }
                result.Message = wex.Message;
            }
            catch (Exception ex)
            {
                result.State = StateEnum.Fail;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
