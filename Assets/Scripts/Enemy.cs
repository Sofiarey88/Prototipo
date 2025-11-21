using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Persecución")]
    public float velocidad = 3f;
    public float rangoDeteccion = 10f;
    public float distanciaParar = 1.5f;

    [Header("Partículas al morir")]
    public ParticleSystem deathParticles;    // <<< arrastrás tu prefab acá

    private Transform jugador;
    private bool persiguiendo = false;

    private void Start()
    {
        GameObject jugadorObj = GameObject.FindGameObjectWithTag("Player");

        if (jugadorObj != null)
        {
            jugador = jugadorObj.transform;
            Debug.Log($"Enemigo {gameObject.name} encontró al jugador");
        }
        else
        {
            Debug.LogWarning("No se encontró jugador con tag 'Player'");
        }
    }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion && distancia > distanciaParar)
        {
            persiguiendo = true;
            Perseguir();
        }
        else
        {
            persiguiendo = false;
        }
    }

    private void Perseguir()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        Quaternion mirarRotacion = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, mirarRotacion, Time.deltaTime * 5f);

        transform.position += direccion * velocidad * Time.deltaTime;
    }

    public void RecibirDaño(float cantidad)
    {
        Debug.Log($"<color=red>Enemigo {gameObject.name} recibió {cantidad} de daño y será destruido</color>");

        // EFECTO DE PARTÍCULAS
        if (deathParticles != null)
        {
            ParticleSystem efecto = Instantiate(deathParticles, transform.position, Quaternion.identity);
            efecto.Play();
            Destroy(efecto.gameObject, 2f);
        }

        // >>> REGISTRAR MUERTE <<<
        EnemyManager manager = Object.FindFirstObjectByType<EnemyManager>();
        if (manager != null)
        {
            manager.RegistrarMuerte();
        }

        Destroy(gameObject);
    }



private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaParar);
    }
}
