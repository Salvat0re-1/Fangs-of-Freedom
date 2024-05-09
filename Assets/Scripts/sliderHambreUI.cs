using UnityEngine;
using UnityEngine.UI;

public class SliderHambreUI : MonoBehaviour
{
    public Slider sliderHambre; // Referencia al objeto Slider en la interfaz

    // Método para actualizar el slider de hambre
    public void ActualizarSliderHambre(float valorHambre)
    {
        // Asegurar que el slider esté configurado correctamente en Unity
        if (sliderHambre != null)
        {
            // Actualizar el valor del slider según el hambre actual
            sliderHambre.value = valorHambre;
        }
        else
        {
            Debug.LogWarning("El slider de hambre no está asignado en el Inspector.");
        }
    }
}
