using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public Button back;
    void Start()
    {
        back.onClick.AddListener(backAction);
    }

    void backAction()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
