using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sophon.Toolkit.File
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
        /// <param name="relativePath">相对路径</param>
        /// <param name="rootPath">根路径</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <param name="now">当前时间（默认为null，表示取本地时间）</param>
        /// <returns></returns>
        public async Task<FileInfo> SaveAsync(IFormFile formFile, string relativePath, string rootPath,
            CancellationToken cancellationToken = default(CancellationToken),
            DateTime? now = null)
        {
            if (now == null)
                now = DateTime.Now;
            var nowValue = now.Value;
            var name = formFile.FileName;
            var size = formFile.Length;
            var path = Path.Combine(relativePath, nowValue.ToString("yyyy"), nowValue.ToString("MM"), nowValue.ToString("dd"));
            var id = GuidGenerator.Instance.Create().ToString();
            var fileInfo = new FileInfo(path, name, size, id);
            fileInfo.SaveName = $"{id.Replace("-", "")}.{fileInfo.Extension}";

            var fullDir = Path.Combine(rootPath, path);
            if (!Directory.Exists(fullDir))
            {
                Directory.CreateDirectory(fullDir);
            }
            var fullPath = Path.Combine(fullDir, fileInfo.SaveName);
            fileInfo.Md5 = await SaveWithMd5Async(formFile, fullPath, cancellationToken);
            return fileInfo;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="formFile">表单文件</param>
        /// <param name="relativePath">相对路径</param>
        /// <param name="rootPath">根路径</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <param name="now">当前时间（默认为null，表示取本地时间）</param>
        /// <returns></returns>
        public async Task<IEnumerable<FileInfo>> SaveAsync(List<IFormFile> formFiles, string relativePath, string rootPath,
            CancellationToken cancellationToken = default(CancellationToken),
            DateTime? now = null)
        {
            if (!formFiles.Any())
            {
                return default;
            }
            var tasks = new List<Task<FileInfo>>();
            foreach (var formFile in formFiles)
            {
                tasks.Add(SaveAsync(formFile, relativePath, rootPath, cancellationToken));
            }
            return await Task.WhenAll(tasks);
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