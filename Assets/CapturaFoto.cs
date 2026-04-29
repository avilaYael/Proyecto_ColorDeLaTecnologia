using UnityEngine;
using System.Collections;
using System.IO;

public class CapturaFoto : MonoBehaviour
{
    public GameObject[] elementosAOcultar; 

    public void TomarFoto()
    {
        StartCoroutine(ProcesoCaptura());
    }

    IEnumerator ProcesoCaptura()
    {
        // 1. Ocultar interfaz
        foreach (GameObject obj in elementosAOcultar)
        {
            if (obj != null) obj.SetActive(false);
        }

        // Pequeña espera para que la GPU procese que ya no hay botones
        yield return new WaitForEndOfFrame();

        // 2. Configurar Ruta en Carpeta "Mis Imágenes"
        string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), "Fotos_Dia_Del_Niño");
        
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string fileName = "Foto_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string finalPath = Path.Combine(folderPath, fileName);

        // 3. Capturar
        ScreenCapture.CaptureScreenshot(finalPath);

        // Espera de seguridad para evitar parpadeos
        yield return new WaitForSeconds(0.2f); 

        // 4. Mostrar interfaz
        foreach (GameObject obj in elementosAOcultar)
        {
            if (obj != null) obj.SetActive(true);
        }
        
        Debug.Log("Foto guardada en: " + finalPath);
    }
}