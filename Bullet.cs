using UnityEngine;

csharp Assets\Scripts\Bullet.cs
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
            rb.isKinematic = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.velocity = transform.up * speed;
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
        if (other == gameObject) return;

        Debug.Log($"Bala impactó: {other.name}");

        // Intentamos encontrar el componente Enemy
        Enemy enemigo = other.GetComponent<Enemy>()
                         ?? other.GetComponentInParent<Enemy>()
                         ?? other.GetComponentInChildren<Enemy>();

        if (enemigo != null)
        {
            Debug.Log($"Enemigo encontrado! Destruyendo...");
            enemigo.RecibirDaño(damage);
        }
        else
        {
            Debug.Log($"No se encontró componente Enemy en {other.name}");
        }

        // Destruye la bala al impactar con cualquier cosa
        Destroy(gameObject);
    }

}