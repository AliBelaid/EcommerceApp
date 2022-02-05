using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Entities;
using Core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
namespace Infrastructure.Services {
    public class PhotoServices : IPhotoServices {

        private readonly Cloudinary _cloudinary;
        public PhotoServices (IOptions<CloudinarySettings> config) {
            var acc = new Account (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary (acc);

        }
        public async Task<ImageUploadResult> AddPhotoAsync (IFormFile file) {
            var uploadResult = new ImageUploadResult ();

            if (file.Length > 0) {
                await using var stream = file.OpenReadStream();
                var uploadParems = new ImageUploadParams {
                    File = new FileDescription(file.FileName, stream), 
                    Transformation = new Transformation().Height(500).Width(500).Crop("thumb").Gravity("face")
                };

                uploadResult = await _cloudinary.UploadAsync (uploadParems);

            }
            return uploadResult;

        }

        public async Task<DeletionResult> DeletePhototoAsync (string publicId) {
            var deleteParems = new DeletionParams (publicId);
            var result = await _cloudinary.DestroyAsync (deleteParems);
            return result;
        }
    }
}