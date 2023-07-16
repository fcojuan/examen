using Microsoft.AspNetCore.Components.Forms;
using Rinku.Service.IService;

namespace Rinku.Service
{
    public class ArchivoUnpload : IArchivoUnpload
    {
        private readonly IConfiguration _config;  //acessar appsettings.json
        private IWebHostEnvironment _environment;

        public ArchivoUnpload(IWebHostEnvironment environment, IConfiguration config)
        {
            _environment = environment;
            _config = config;
        }

        public bool ELiminarArchivo(string Nombrearchivo)
        {
            try
            {
                //string ImgDir = _environment.WebRootPath; //--wwwroot
                string ImgDir = _config["ImagenesDir:Directorio"] ?? "";

                string RutaDir = ImgDir;

                var ruta=$"{RutaDir}\\{Nombrearchivo}";
                if(File.Exists(ruta))
                {
                    File.Delete(ruta);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadArchivo(IBrowserFile file)
        {
            try
            {
                //string ImgDir = _environment.WebRootPath; //--wwwroot
                string ImgDir = _config["ImagenesDir:Directorio"] ?? "";

                string RutaDir = ImgDir;

                FileInfo fileinfo = new FileInfo(file.Name);
                var NombreArchivo=Guid.NewGuid().ToString()+fileinfo.Extension;
                var carpetaDirectorio=$"{RutaDir}\\ImagenEmpleado";
                var ruta = Path.Combine(RutaDir, "ImagenEmpleado", NombreArchivo);
                var memoryStream=new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if(!Directory.Exists(carpetaDirectorio)) 
                {
                    Directory.CreateDirectory(carpetaDirectorio);
                }

                await using (var fs=new FileStream(ruta, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }

                //--si se trabaja con wwwroot asi se debe mandar la ruta
                //var rutaCompleta = $"ImagenEmpleado/{NombreArchivo}";
                //--de lo contrario
                var rutaCompleta = ruta;

                return rutaCompleta;

            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
