using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadBala = 20f;

    public ParticleSystem muzzleFlashPrefab;

    [Header("Sonido")]
    public AudioSource audioSource;        // Solo 1 audio source
    public AudioClip sonidoDisparo;        // Solo 1 sonido

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (balaPrefab == null || puntoDisparo == null)
            return;

        // Sonido del disparo
        if (audioSource != null && sonidoDisparo != null)
        {
            audioSource.PlayOneShot(sonidoDisparo);
        }

        // Instanciar bala
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Asignarle velocidad
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = puntoDisparo.up * velocidadBala;
        }

        // Instanciar partículas del arma
        if (muzzleFlashPrefab != null)
        {
            ParticleSystem fx = Instantiate(muzzleFlashPrefab, puntoDisparo.position, puntoDisparo.rotation);
            fx.transform.localScale = Vector3.one * 0.3f;
            fx.Play();
            Destroy(fx.gameObject, 0.5f);
        }
    }
}
