using UnityEngine;
using TMPro; // IMPORTANTE

public class EnemyManager : MonoBehaviour
{
    public int enemigosTotales = 3;
    private int enemigosMuertos = 0;

    public TMP_Text contadorText;   // ← aquí arrastrás TU TEXTO
    public GameObject panelVictoria; // ← aquí arrastrás EL PANEL

    private void Start()
    {
        ActualizarContador();
        panelVictoria.SetActive(false);
    }

    public void RegistrarMuerte()
    {
        enemigosMuertos++;

        ActualizarContador();

        if (enemigosMuertos >= enemigosTotales)
        {
            panelVictoria.SetActive(true);
        }
    }

    void ActualizarContador()
    {
        contadorText.text = enemigosMuertos + "/" + enemigosTotales;
    }
}
