using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Persecución")]
    public float velocidad = 3f;
    public float rangoDeteccion = 10f;
    public float distanciaParar = 1.5f;

    [Header("Partículas al morir")]
    public ParticleSystem deathParticles;

    private Transform jugador;
    private NavMeshAgent agent;
    private EnemyManager manager;

    private void Start()
    {
        // Obtener jugador
        GameObject jugadorObj = GameObject.FindGameObjectWithTag("Player");
        if (jugadorObj != null)
            jugador = jugadorObj.transform;

        // Obtener NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        agent.speed = velocidad;
        agent.stoppingDistance = distanciaParar;

        // Obtener referencia al EnemyManager
        manager = FindFirstObjectByType<EnemyManager>();
    }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion)
        {
            Perseguir();
        }
        else
        {
            agent.ResetPath();
        }
    }

    private void Perseguir()
    {
        if (agent == null) return;
        agent.SetDestination(jugador.position);
    }

    public void RecibirDaño(float cantidad)
    {
        // --- PARTICULAS AL MORIR (MEJORADO) ---
        if (deathParticles != null)
        {
            ParticleSystem efecto = Instantiate(
                deathParticles,
                transform.position + Vector3.up * 0.1f,  // un poquito arriba del piso
                Quaternion.identity
            );

            efecto.Play();
            Destroy(efecto.gameObject, efecto.main.duration + 0.5f);
        }

        // Registrar muerte
        if (manager != null)
        {
            manager.RegistrarMuerte();
        }

        // Destruir enemigo
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
