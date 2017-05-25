using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arm
{
    class LoadImageFromCamera
    {
        //private readonly string _cameraLogin = "admin";
        //private readonly string _cameraPassword = "axi778523tech";

       public  LoadImageFromCamera(string Login,string Password ,string Url,string FileName )
        {
            //const string cameraUrl = @"http://10.174.18.127:80/Streaming/channels/1/picture?snapShotImageType=JPEG";
            if (!string.IsNullOrEmpty(Url))
            {
                var request = System.Net.WebRequest.Create(Url);
                request.Credentials = new System.Net.NetworkCredential(Login, Password);
                request.Proxy = null;
                var resp = request.GetResponse();
                var res_str = resp.GetResponseStream();
                using (var frame = new Bitmap(res_str))
                {
                    var _loadedBitmap = (Bitmap)frame.Clone();
                    _loadedBitmap.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    _loadedBitmap.Dispose();
                }
                res_str.Close();
                resp.Close();
            }
        }
        public LoadImageFromCamera(string Login, string Password, string Url, string FileName1, string FileName2)
        {
            //const string cameraUrl = @"http://10.174.18.127:80/Streaming/channels/1/picture?snapShotImageType=JPEG";
            if (!string.IsNullOrEmpty(Url))
            {
                var request = System.Net.WebRequest.Create(Url);
                request.Credentials = new System.Net.NetworkCredential(Login, Password);
                request.Proxy = null;
                var resp = request.GetResponse();
                var res_str = resp.GetResponseStream();
                using (var frame = new Bitmap(res_str))
                {
                    var _loadedBitmap = (Bitmap)frame.Clone();
                    _loadedBitmap.Save(FileName1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    _loadedBitmap.Save(FileName2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    _loadedBitmap.Dispose();
                }
                res_str.Close();
                resp.Close();
            }
        }
    }
}
