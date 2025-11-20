using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject balaPrefab;        // prefab de la bala
    public Transform puntoDisparo;       // punto donde aparece la bala
    public float velocidadBala = 20f;

    public ParticleSystem muzzleFlashPrefab; // partículas al disparar

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
            fx.transform.localScale = Vector3.one * 0.3f; // ACHICA el efecto
            fx.Play();
            Destroy(fx.gameObject, 0.5f); // dura muy poco
        }
    }
}
