using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text;

namespace Infrastructure.Utils
{
    public static class PdfUtils
    {
        public static string GetText(string pdfFilePath)
        {
            StringBuilder text = new StringBuilder();

            PdfReader pdfReader = new PdfReader(pdfFilePath);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            var pages = pdfDoc.GetNumberOfPages();

            for (int page = 1; page <= pages; page++)
            {
                string extractedText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page));

                text.Append(extractedText);
            }

            return text.ToString();
        }

    }
}
