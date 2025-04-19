using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // pour charger les scènes

public class BatteryManager : MonoBehaviour
{
    
    public int battery = 70;
    [SerializeField]
    private TextMeshProUGUI batteryText; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateBatteryText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeBattery(int i)
    {
        this.battery -= i;
        UpdateBatteryText();
        if (this.battery<0)
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex);

        }
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
