using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);    
    }

    public void setMaxHp(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }

    public void setHp(int _health)
    {
        slider.value = _health;
    }
}
