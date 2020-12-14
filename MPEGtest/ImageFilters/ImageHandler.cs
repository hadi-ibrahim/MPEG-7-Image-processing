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
        private List<IImageObserver> _imageFilters = new List<IImageObserver>();


        public void UpdateImage(Bitmap newImage, bool temporary = false)
        {
            SaveImage(newImage, temporary, true);
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

        private void SaveImage(Bitmap image, bool temporary, bool testing = false)
        {
            // CurrentImageFileName += new Guid().ToString();
            // if (isUpdate) {UpdateImageByPath(""); NotifyObservers(true);}
            var savingPath = ImagePath + (temporary ? TempImageFileName : CurrentImageFileName);
            // NotifyObservers(true);
            // if (testing)
            // {
            //     savingPath = ImagePath + "GUI";
            //     image.Save(savingPath);
            //     UpdateImageByPath(savingPath);
            //     return;
            // }


            // image.Save(savingPath);
            NotifyObservers(image);

            // DeleteFileIfExists();
        }

        public Bitmap GetBitmapImage()
        {
            return Image.FromFile(ImagePath + CurrentImageFileName) as Bitmap;
        }

        public Bitmap GetTempBitmapImage()
        {
            return Image.FromFile(ImagePath + TempImageFileName) as Bitmap;
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

            Bitmap image = (Bitmap) Image.FromFile(newImagePath);
            //save Image to new path
            SaveImage(image, temporary);
        }
    }
}