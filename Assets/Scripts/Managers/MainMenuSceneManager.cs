using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    public Button play;
    public Button editor;
    public Button options;
    public Button exit;

    void Start()
    {
        play.onClick.AddListener(playScene);
        editor.onClick.AddListener(editorScene);
        options.onClick.AddListener(optionsScene);
        exit.onClick.AddListener(exitScene);
    }

    void playScene()
    {
        SceneManager.LoadScene("GamePlay");
    }

    void editorScene()
    {
        SceneManager.LoadScene("GameEditor");
    }

    void optionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    void exitScene()
    {
        Application.Quit(0);
    }
}
