using UnityEngine;

public class Sangre : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            // Obtener el componente SistemaHambre del jugador
            SistemaHambre sistemaHambre = other.GetComponent<SistemaHambre>();
            if(sistemaHambre != null){
                // Aumentar la vida del jugador en 10 puntos
                sistemaHambre.AumentarVida(10);
            }

            // Destruir este objeto "Sangre"
            Destroy(gameObject);
        }
    }
}
