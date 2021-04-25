using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace MyGarden.Helpers
{
    public class PermissionsHelper
    {
        [Obsolete]
        public static async Task<bool> RequestCameraAndGalleryPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            var photosStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted || photosStatus != PermissionStatus.Granted)
            {
                var permissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync( new Permission[] { Permission.Camera, Permission.Storage, Permission.Photos });
                var cameraResult = permissionRequestResult[Permission.Camera];
                var storageResult = permissionRequestResult[Permission.Storage];
                var photosResults = permissionRequestResult[Permission.Photos];

                return ( cameraResult != PermissionStatus.Denied && storageResult != PermissionStatus.Denied && photosResults != PermissionStatus.Denied);
            }

            return true;
        }
    }
}
