using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit
{
    public class BarcodeUtil
    {
        public byte[] GetQrCode(string content,
            int size = 20,
            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.Q)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);
            var qrCodeByte = qrCode.GetGraphic(size);
            return qrCodeByte;
        }

        public Image Get1DBarcode(string content)
        {
            var type = BarcodeLib.TYPE.UPCA;
            int width = 300;
            int height = 120;

            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            var imgBarcode = barcode.Encode(type, content, Color.Black, Color.White, width, height);
            return imgBarcode;
        }
        public Image Get1DBarcode(string content, int width, int height)
        {
            var type = BarcodeLib.TYPE.UPCA;
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            var imgBarcode = barcode.Encode(type, content, Color.Black, Color.White, width, height);
            return imgBarcode;
        }
        public Image Get1DBarcode(string content, int width = 300, int height = 120, BarcodeLib.TYPE type = BarcodeLib.TYPE.UPCA)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            var imgBarcode = barcode.Encode(type, content, Color.Black, Color.White, width, height);
            return imgBarcode;
        }
    }
}
