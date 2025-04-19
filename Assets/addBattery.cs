using System;
using UnityEngine;

public class addBattery : MonoBehaviour
{
    [SerializeField]
    private GameObject batteryManager;
    private BatteryManager batteryScript;

    void Start()
    {
        batteryScript = batteryManager.GetComponent<BatteryManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        batteryScript.addBattery(50);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        // On désactive le visuel/collider pour ne pas pouvoir la recollecter
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // Détruit l'objet APRÈS la durée du son
        Destroy(gameObject, audio.clip.length);
    }
}
