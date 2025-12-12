using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float tiempoInicial = 30f;
    private float tiempoRestante;

    public TextMeshProUGUI textoTiempo;
    public GameObject panelGameOver;

    private bool terminado = false;

    private GameObject panelVictoria;

    void Start()
    {
        EnemyManager em = Object.FindFirstObjectByType<EnemyManager>();
        if (em != null)
            panelVictoria = em.panelVictoria;

        tiempoRestante = tiempoInicial;

        if (panelGameOver != null)
            panelGameOver.SetActive(false);

        // ✔ Aseguro que el tiempo esté funcionando al iniciar
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (terminado) return;

        if (panelVictoria != null && panelVictoria.activeSelf)
            return;

        tiempoRestante -= Time.deltaTime;

        if (textoTiempo != null)
            textoTiempo.text = Mathf.Ceil(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            terminado = true;
            tiempoRestante = 0;

            if (panelGameOver != null)
                panelGameOver.SetActive(true);

            // ✔ DETENER EL JUEGO COMPLETAMENTE
            Time.timeScale = 0f;
        }
    }
}
