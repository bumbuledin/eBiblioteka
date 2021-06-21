using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace eBiblioteka.Mobile.Helpers
{
    public class ImageHelper
    {
        public PickOptions GetOptionsFromHelper()
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.iOS, new[] { ".jpg", ".png" } }, 
                { DevicePlatform.Android, new[] { ".jpg", ".png" } },
                { DevicePlatform.UWP, new[] { ".jpg", ".png" } },
                { DevicePlatform.Tizen, new[] { ".jpg", ".png" } },
                { DevicePlatform.macOS, new[] { ".jpg", ".png" } }, 
            });

            var options = new PickOptions
            {
                PickerTitle = "Odaberite novu sliku: ",
                FileTypes = customFileType,
            };

            return options;    
        }

        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
        
}
