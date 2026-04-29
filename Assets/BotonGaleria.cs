using UnityEngine;
using System.IO;

public class BotonGaleria : MonoBehaviour
{
    public void AbrirGaleria()
    {
        // 1. Definimos la ruta exacta a la carpeta de Imágenes (la misma que usamos en CapturaFoto)
        string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), "Fotos_Dia_Del_Niño");

        // 2. Verificamos si la carpeta existe para que no de error
        if (Directory.Exists(folderPath))
        {
            // En PC abrimos el explorador de archivos en esa ruta específica
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                // Usamos "file://" para que Windows entienda que es una ruta de carpeta
                Application.OpenURL("file://" + folderPath);
            }
        }
        else
        {
            // Si la carpeta aún no existe (porque no han tomado fotos), 
            // podemos abrir la carpeta de Imágenes general
            string generalPictures = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            Application.OpenURL("file://" + generalPictures);
            Debug.LogWarning("La carpeta específica no existe aún, se abrió Imágenes general.");
        }
    }
}