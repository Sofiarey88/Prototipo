using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int enemigosTotales = 3;   // cuántos enemigos necesitas matar
    public int enemigosMuertos = 0;

    public GameObject pantallaVictoria; // panel de victoria en canvas

    private void Awake()
    {
        // Singleton básico
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EnemigoMuerto()
    {
        enemigosMuertos++;

        Debug.Log($"Enemigos muertos: {enemigosMuertos}/{enemigosTotales}");

        if (enemigosMuertos >= enemigosTotales)
        {
            Victoria();
        }
    }

    void Victoria()
    {
        Debug.Log("¡GANASTE!");
        if (pantallaVictoria != null)
            pantallaVictoria.SetActive(true);
    }
}
