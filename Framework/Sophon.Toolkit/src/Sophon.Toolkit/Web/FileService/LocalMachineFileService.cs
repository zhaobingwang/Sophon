using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Web.FileService
{
    /// <summary>
    /// 本地计算机文件服务
    /// </summary>
    public class LocalMachineFileService
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="formFile">表单文件</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task SaveAsync(IFormFile formFile, string savePath, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream, cancellationToken);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="formFile">表单文件</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>文件的MD5哈希值</returns>
        public async Task<string> SaveWithMd5Async(IFormFile formFile, string savePath, CancellationToken cancellationToken = default(CancellationToken))
        {
            string md5Hash;
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                md5Hash = CryptographyUtil.GetMd5Hash(stream);
                await formFile.CopyToAsync(stream, cancellationToken);
            }
            return md5Hash;
        }
    }
}