
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class PhotoEditorUtils
{
    private string _sourceFolder;
    private string _outputFolder;
    private static Regex r = new Regex(":");

    public PhotoEditorUtils(string sourceFolder, string outputFolder)
    {
        _sourceFolder = sourceFolder;
        _outputFolder = outputFolder;
    }

    public void AddTakenDateToPhotos()
    {
        var files = GetAllImagesInFolderAndSubfolders();

        foreach (string filePath in files)
        {
            try
            {
                string fileName = Path.GetFileName(filePath);
                string resultFilePath = Path.Combine(_outputFolder, fileName);
                while (File.Exists(resultFilePath))
                {
                    resultFilePath = Path.Combine(_outputFolder,
                        fileName + new Random().Next());
                }
                AddTakenDateToPhoto(filePath, resultFilePath);
            }
            catch (Exception ex)
            {
                File.AppendAllLines("Log.txt", new[] { filePath, ex.Message });
            }
        }
    }

    private List<string> GetAllImagesInFolderAndSubfolders()
    {
        var files = Directory.GetFiles(_sourceFolder, "*.*", SearchOption.AllDirectories)
            .Where(file => Regex.IsMatch(file, @"^.+\.(jpg|jpeg|png|tiff|bmp)$", RegexOptions.IgnoreCase))
            .ToList();
        return files;
    }

    DateTime GetTakenDate(Image img)
    {
        PropertyItem propItem = img.GetPropertyItem(36867);
        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
        return DateTime.Parse(dateTaken);
    }

    void AddTakenDateToPhoto(string sourceImgPath, string destImgPath)
    {
        Image image = Image.FromFile(sourceImgPath);
        DateTime takenDate = GetTakenDate(image);
        var formattedDate = takenDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
        Graphics gr = Graphics.FromImage(image);
        gr.SmoothingMode = SmoothingMode.HighQuality;
        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

        Font font = new Font("Times New Roman", 150);
        gr.DrawString(formattedDate, font, new SolidBrush(Color.White), 10f, 10f);
        gr.Save();

        image.Save(destImgPath);
        gr.Dispose();
        image.Dispose();
    }
}