using UnityEngine;
using TMPro;
public class BatteryManager : MonoBehaviour
{
    
    public int battery = 100;
    [SerializeField]
    private TextMeshProUGUI batteryText; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battery = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeBattery(int i)
    {
        this.battery -= i;
        UpdateBatteryText();
    }
    
    public void addBattery(int i)
    {
        this.battery += i;
        UpdateBatteryText();
    }
    
    private void UpdateBatteryText()
    {
        if (batteryText != null)
            batteryText.text = battery.ToString(); // Affiche la valeur de la batterie
    }
}
