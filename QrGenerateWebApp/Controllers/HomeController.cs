using Microsoft.AspNetCore.Mvc;
using QrGenerateWebApp.Models;
using System;
using System.IO;
using QRCoder;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace QrGenerateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FPIDVMS2022Context _context;

        public HomeController(FPIDVMS2022Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var invoices = _context.SellMasters.ToList();
            return View(invoices);
        }

        public IActionResult GenerateQrCode(string invoiceNo)
        {
            var invoice = _context.SellMasters.FirstOrDefault(i => i.InvoiceNo == invoiceNo);
            if (invoice == null)
            {
                return NotFound();
            }

            var qrCodeData = $"{invoice.OrderNumber}, {invoice.PartyAddress}, {invoice.Car}, {invoice.TotalWithVat}";
            var qrCodeImage = GenerateQrCodeImage(qrCodeData);

            return File(ImageToByteArray(qrCodeImage), "image/png");
        }

        private Bitmap GenerateQrCodeImage(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}