using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using MPEGtest.Common;

namespace MPEGtest.ImageFilters
{
    public class ImageHandler : IImageHandler
    {
        private static string CurrentImageFileName = "Original";
        private const string TempImageFileName = "Temp";
        private const string ImagePath = "../../../wwwroot/";
        private Bitmap _image;

        private List<IImageObserver> _imageFilters = new List<IImageObserver>();


        public void UpdateImage(Bitmap newImage, bool temporary = false)
        {
            SaveImage(newImage, temporary);
        }

        private void DeleteFileIfExists()
        {
            Console.WriteLine("Searching for File {0}", Path.Combine(ImagePath, CurrentImageFileName));
            if (File.Exists(Path.Combine(ImagePath, CurrentImageFileName)))
            {
                File.Delete(Path.Combine(ImagePath, CurrentImageFileName));
                Console.WriteLine("File deleted.");
            }
            else Console.WriteLine("File not found");
        }

        private void SaveImage(Bitmap image, bool temporary)
        {
            // Save Image To Service
            _image = image;
            // Notify Views Of Change
            NotifyObservers(image);
        }

        public Bitmap GetBitmapImage()
        {
            return _image;
        }

        public Bitmap GetTempBitmapImage()
        {
            // return Image.FromFile(ImagePath + TempImageFileName) as Bitmap;
            return null;
        }
        

        public string GetImageUrl()
        {
            var savingPath = ImagePath + (false ? TempImageFileName : CurrentImageFileName);
            _image.Save(savingPath);
            return savingPath;
        }


        public bool SubscribeObserver(IImageObserver imageObserver)
        {
            try
            {
                _imageFilters.Add(imageObserver);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool UnSubscribeObserver(IImageObserver imageObserver)
        {
            try
            {
                _imageFilters.Remove(imageObserver);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private void NotifyObservers(Bitmap image, bool empty = false)
        {
            foreach (var filter in _imageFilters)
            {
                filter.ReceiveImageUpdates(image);
                // filter.ReceiveImageUpdates(empty ? "" : ImagePath + CurrentImageFileName);
            }
        }

        public void UpdateImageByPath(string newImagePath, bool temporary = false)
        {
            // load an image

            var image = (Bitmap) Image.FromFile(newImagePath);
            //save Image to new path
            SaveImage(image, temporary);
        }
    }
}