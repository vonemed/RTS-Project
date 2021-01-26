using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgrade : MonoBehaviour
{
    public BuildingStats currentBuilding;
    //Parameters
    public int hp;
    Button upgradeButton;
    bool upgraded;

    void Start()
    {
        upgradeButton = GetComponent<Button>();
        upgradeButton.onClick.AddListener(Upgrade);
    }

    void Update()
    {
        
    }

    void Upgrade()
    {
        if (!upgraded)
        {
            hp += 100;
            upgraded = true;
            currentBuilding.hp = hp;
        }
    }
}
