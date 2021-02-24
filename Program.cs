using System;
using System.Drawing;
using ZXing;

namespace QrcodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Qrcode
            String article, Brand, dateString;
            int  price;

            //some parameters to enter in QR code in string
            Console.WriteLine("enter name of article:");
            article = "Lait";
            Console.WriteLine("enter name of the Brand:");
            Brand = "Gvina";
            Console.WriteLine("enter price:");
            price = 5;
            Console.WriteLine("enter purchase date");
            dateString = new DateTime(2021, 11, 26).ToString("MM-dd-yyyy");
            Console.WriteLine(dateString);

            //generate QrCode
            var qrcodewritter = new BarcodeWriter();
            qrcodewritter.Format = BarcodeFormat.QR_CODE;
            qrcodewritter.Write(
                 article + "\n" +
                 Brand + "\n" +
                 price + "\n" +
                 dateString +
                "").Save(@"PATH.bmp");
            Console.WriteLine("the code is generated");

            //read QR Code
            var qrcodebitmap = (Bitmap)Bitmap.FromFile(@"PATH.bmp");
            var qrcodeReader = new BarcodeReader();
            var qrcodeResult = qrcodeReader.Decode(qrcodebitmap);
            Console.WriteLine($"decode: {qrcodeResult.Text}");


            Console.ReadKey();
            #endregion
        }
    }
}