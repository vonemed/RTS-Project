using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameplayUI : MonoBehaviour
{
    Button menuButton;
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(mainMenu);
    }

    void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
