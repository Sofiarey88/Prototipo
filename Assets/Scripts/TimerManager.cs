using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float tiempoInicial = 30f;
    private float tiempoRestante;

    public TextMeshProUGUI textoTiempo;
    public GameObject panelGameOver;

    private bool terminado = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;

        if (panelGameOver != null)
            panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (terminado) return;

        tiempoRestante -= Time.deltaTime;

        if (textoTiempo != null)
            textoTiempo.text = Mathf.Ceil(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            terminado = true;
            tiempoRestante = 0;

            if (panelGameOver != null)
                panelGameOver.SetActive(true);
        }
    }
}
