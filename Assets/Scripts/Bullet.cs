using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 1f;
    public float lifeTime = 3f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);

        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = transform.up * speed;
        }
    }

    private void Update()
    {
        // Fallback si no hay Rigidbody
        if (rb == null)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleHit(collision.gameObject);
    }

    private void HandleHit(GameObject other)
    {
        // Evita dañarse a sí misma u otros proyectiles
        if (other == gameObject) return;

        // Si golpea a un enemigo, le aplicamos daño
        if (other.CompareTag("Enemy"))
        {
            Enemy enemigo = other.GetComponent<Enemy>();
            if (enemigo != null)
            {
                enemigo.RecibirDaño(damage);
            }
        }

        // Destruye la bala al impactar con cualquier cosa (quita si no lo quieres)
        Destroy(gameObject);
    }
}
