using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public int enemigosTotales = 3;
    private int enemigosMuertos = 0;
    public bool juegoTerminado = false;


    public TMP_Text contadorText;
    public GameObject panelVictoria;

    private void Start()
    {
        // 🔥 CUENTA AUTOMÁTICAMENTE LOS ENEMIGOS EN LA ESCENA
        enemigosTotales = GameObject.FindGameObjectsWithTag("Enemy").Length;

        ActualizarContador();
        panelVictoria.SetActive(false);
    }

    public void RegistrarMuerte()
    {
        if (juegoTerminado) return; // ← evita activar dos paneles

        enemigosMuertos++;
        ActualizarContador();

        if (enemigosMuertos >= enemigosTotales)
        {
            juegoTerminado = true;   // ← MARCA EL JUEGO COMO FINALIZADO
            panelVictoria.SetActive(true);
        }
    }

    void ActualizarContador()
    {
        contadorText.text = enemigosMuertos + "/" + enemigosTotales;
    }
}
