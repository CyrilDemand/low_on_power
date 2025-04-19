using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // pour charger les scènes
public class WinningScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI batteryText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        batteryText.SetText("You won");
    
        // On récupère l'index courant et on passe à la scène suivante
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Vérifie qu'il existe bien une prochaine scène
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            // Tu es arrivé à la dernière scène (tu peux mettre un message spécial)
            batteryText.SetText("C'est fini !");
            // Ou revenir au menu, par exemple
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.Win();
        }
    }
}
