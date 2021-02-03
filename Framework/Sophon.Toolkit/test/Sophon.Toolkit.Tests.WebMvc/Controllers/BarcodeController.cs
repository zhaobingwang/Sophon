using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Tests.WebMvc.Controllers
{
    public class BarcodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QRCode()
        {
            BarcodeUtil barcodeUtil = new BarcodeUtil();
            var imgByte = barcodeUtil.GetQrCode("Test QRCode");
            return File(imgByte, @"image/png");
        }

        public IActionResult Barcode1D()
        {
            BarcodeUtil barcodeUtil = new BarcodeUtil();
            var imgBarcode = barcodeUtil.Get1DBarcode("A1234567890", 200, 80, BarcodeLib.TYPE.CODE128);
            using (var ms = new MemoryStream())
            {
                imgBarcode.Save(ms, ImageFormat.Png);
                var imgByte = ms.GetBuffer();
                return File(imgByte, @"image/png");
            }
        }
    }
}
