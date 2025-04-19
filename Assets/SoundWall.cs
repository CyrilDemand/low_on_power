using UnityEngine;


public class SoundWall : MonoBehaviour
{
    private AudioSource[] sources;

    void Start()
    {
        // Récupère tous les AudioSource attachés à **ce GameObject**
        sources = GetComponents<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si tu veux que seul le "Player" déclenche :
        // if (!collision.gameObject.CompareTag("Player")) return;

        // Joue un AudioSource aléatoirement
        if (sources != null && sources.Length > 0)
        {
            int i = Random.Range(0, sources.Length);
            sources[i].Play();
        }
    }
}