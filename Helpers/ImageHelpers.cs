
using Microsoft.AspNetCore.Http;
using System.Configuration;
using System.IO; 
namespace aspnetcore_api_sample.Helpers
{
    public class ImageHelpers
    {
        //string ImagePath = ConfigurationManager.AppSettings["ImagePath"].ToString();
        //public string UploadAlternativeImages(IFormFile File)
        //{
        //    if (File != null)
        //    {
        //        string FileName = System.IO.Path.GetFileName(File.FileName);
        //        string Extention = Path.GetExtension(File.FileName);

        //        string pathString = System.IO.Path.Combine(ImagePath);

        //        if (!Directory.Exists(pathString))
        //        {
        //            Directory.CreateDirectory(Server.MapPath(pathString));

        //        }

        //        string finalpath = pathString + FileName.Trim().Replace(" ", "");
        //        File.SaveAs(HttpContext.Current.Server.MapPath(finalpath));

        //        return finalpath;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
