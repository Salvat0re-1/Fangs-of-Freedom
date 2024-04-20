using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SistemaHambre : MonoBehaviour
{
    private float hambre = 100;
    private float reduccionHambre = 10;
    private float tiempoReducirHambre = 2;
    private float currentTimeReducirHambre;

    public TextMeshProUGUI textoHambre;
    public Slider sliderHambre; // Referencia al objeto Slider en la interfaz
    

    private void Start(){
        currentTimeReducirHambre = tiempoReducirHambre;
        sliderHambre.value = hambre;
    }

    private void FixedUpdate(){
        currentTimeReducirHambre -= Time.deltaTime;
        if(currentTimeReducirHambre <= 0){
            hambre -= reduccionHambre;
            currentTimeReducirHambre = tiempoReducirHambre;
        }

        // Limitar la hambre a cero si es menor que cero
        if(hambre < 0){
        hambre = 0;
        }

        textoHambre.text = "Hambre: " + hambre.ToString() + " / 100";
        sliderHambre.value = hambre; // Actualizar el valor del Slider


        if(hambre <= 0){
            // Aquí puedes agregar la lógica para la muerte por hambre, como cargar una escena de Game Over o reiniciar el nivel.
            Debug.Log("¡El jugador ha muerto de hambre!");
        }
    }

    public void AumentarVida(int cantidad){
    hambre += cantidad;
    // Asegurar que la hambre no supere 100
    hambre = Mathf.Clamp(hambre, 0, 100);
    // Actualizar el texto en la interfaz
    textoHambre.text = "Hambre: " + hambre.ToString();
    }

}
