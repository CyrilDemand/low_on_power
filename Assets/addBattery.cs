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
        batteryScript.addBattery(40);
        Destroy(gameObject);
    }
}
