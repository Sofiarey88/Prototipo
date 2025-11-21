using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float tiempoInicial = 30f;
    private float tiempoRestante;

    public TextMeshProUGUI textoTiempo;
    public GameObject panelGameOver;

    private bool terminado = false;

    // ✔ añadido: referencia al panel de victoria (NO necesita modificar otros scripts)
    private GameObject panelVictoria;

    void Start()
    {
        // ✔ buscamos el panel de victoria aunque esté DESACTIVADO
        EnemyManager em = Object.FindFirstObjectByType<EnemyManager>();
        if (em != null)
            panelVictoria = em.panelVictoria;

        tiempoRestante = tiempoInicial;

        if (panelGameOver != null)
            panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (terminado) return;

        // ✔ si el panel de victoria está activo → NO mostrar GameOver
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
        }
    }
}
