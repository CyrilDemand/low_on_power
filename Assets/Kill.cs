using UnityEngine;
using UnityEngine.SceneManagement;
public class Kill : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerStartPos;

    void Start()
    {
        // On récupère le joueur via le tag
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerStartPos = player.transform.position; // On sauvegarde la position de départ
    }

    // OnCollisionEnter2D : pour collisions physiques 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Recharge la scène active (reset total)
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}