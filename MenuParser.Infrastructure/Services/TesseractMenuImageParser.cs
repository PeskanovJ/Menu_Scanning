using MenuParser.Application.Interfaces;
using MenuParser.Application.Menus.DTOs;
using Microsoft.AspNetCore.Http;
using Tesseract;
using System.Text.RegularExpressions;

namespace MenuParser.Infrastructure.Services
{
    public class TesseractMenuImageParser : IMenuImageParser
    {
        public async Task<List<ParsedMenuItem>> ParseAsync(IFormFile image)
        {
            // Save IFormFile to temp location
            var tempPath = Path.GetTempFileName();
            using (var stream = File.Create(tempPath))
            {
                await image.CopyToAsync(stream);
            }

            // OCR
            var extractedText = "";
            using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            using var img = Pix.LoadFromFile(tempPath);
            using var page = engine.Process(img);
            extractedText = page.GetText();

            // Parse
            var items = new List<ParsedMenuItem>();
            var lines = extractedText.Split('\n');
            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"^(.*?)[\s.]+([\d.,]+)$");
                if (match.Success)
                {
                    var name = match.Groups[1].Value.Trim();
                    var price = decimal.Parse(match.Groups[2].Value.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                    items.Add(new ParsedMenuItem(name, price, "USD"));
                }
            }

            return items;
        }
        private async Task<string> ExtractTextFromImageAsync(Stream imageStream)
        {
            // Save the stream to a temporary file
            var tempFilePath = Path.GetTempFileName();

            using (var fileStream = File.Create(tempFilePath))
            {
                await imageStream.CopyToAsync(fileStream);
            }

            using var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            using var img = Pix.LoadFromFile(tempFilePath);
            using var page = engine.Process(img);

            return page.GetText();
        }
    }
}
