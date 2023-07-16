using Microsoft.AspNetCore.Components.Forms;

namespace Rinku.Service.IService
{
    public interface IArchivoUnpload
    {
        Task<string> UploadArchivo(IBrowserFile file);
        bool ELiminarArchivo(string Nombrearchivo);
    }
}
