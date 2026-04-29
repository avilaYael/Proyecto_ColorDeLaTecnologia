using UnityEngine;
using UnityEngine.UI;

public class AdministradorFiltros : MonoBehaviour
{
    // Aquí arrastraremos el objeto "ImagenMarcoPrincipal" que cubre la pantalla
    public Image imagenMarcoPrincipal; 

    // Esta función la llamará el botón
    public void CambiarFiltro(Sprite nuevoMarco)
    {
        // 1. Cambiamos el dibujo del marco
        imagenMarcoPrincipal.sprite = nuevoMarco;
        
        // 2. Nos aseguramos de que sea visible (Alpha al 100%)
        var tempColor = imagenMarcoPrincipal.color;
        tempColor.a = 1f; 
        imagenMarcoPrincipal.color = tempColor;
    }
}