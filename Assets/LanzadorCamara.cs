using UnityEngine;
using UnityEngine.UI;

public class LanzadorCamara : MonoBehaviour 
{
    // Variables para la textura de la cámara y la interfaz
    private WebCamTexture camaraTextura;
    public RawImage fondo; // Arrastra aquí tu RawImage desde el Inspector
    private int indiceActual = 0;

    void Start() 
    {
        // Al arrancar, intentamos configurar la primera cámara disponible
        ConfigurarCamara(0);
    }

    void Update() 
    {
        // Soporte para teclado: Si presionas 'C', cambia de cámara
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            CambiarCamara();
        }
    }

    /// <summary>
    /// Configura e inicia la cámara según el índice del dispositivo.
    /// </summary>
    public void ConfigurarCamara(int indice) 
    {
        WebCamDevice[] dispositivos = WebCamTexture.devices;

        // Si no hay cámaras conectadas, salimos para evitar errores
        if (dispositivos.Length == 0) 
        {
            Debug.LogError("No se detectaron cámaras en este equipo.");
            return;
        }

        // Si ya había una cámara encendida, la detenemos para liberar memoria
        if (camaraTextura != null) 
        {
            camaraTextura.Stop();
        }

        // Aseguramos que el índice esté dentro del rango de cámaras disponibles
        indiceActual = indice % dispositivos.Length;
        
        // Creamos la textura con el nombre del dispositivo seleccionado
        // Solicitamos 1920x1080 para que la GoPro entregue su máxima calidad
        camaraTextura = new WebCamTexture(dispositivos[indiceActual].name, 1920, 1080);
        
        // Asignamos la textura al componente RawImage de fondo
        fondo.texture = camaraTextura;
        
        // Iniciamos la transmisión
        camaraTextura.Play();
        
        Debug.Log("Cámara activa: " + dispositivos[indiceActual].name);
    }

    /// <summary>
    /// Método público para ser llamado desde el botón de la UI (OnClick)
    /// </summary>
    public void CambiarCamara() 
    {
        WebCamDevice[] dispositivos = WebCamTexture.devices;
        if (dispositivos.Length > 1) 
        {
            indiceActual++;
            ConfigurarCamara(indiceActual);
        }
        else 
        {
            Debug.LogWarning("Solo hay una cámara disponible. No se puede cambiar.");
        }
    }
}