using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button quitButton;

    [SerializeField] string sceneToLoadOnPlay = "GameScene";
    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 

        playButton.onClick.AddListener(delegate { PlayButtonTask(); });
        optionsButton.onClick.AddListener(delegate { OptionsButtonTask(); });
        creditsButton.onClick.AddListener(delegate { CreditsButtonTask(); });
        quitButton.onClick.AddListener(delegate { QuitButtonTask(); });
    }

    void PlayButtonTask()
    {
        SceneManager.LoadScene(sceneToLoadOnPlay); 
    }

    void OptionsButtonTask()
    {
        Active(false); 
    }

    void CreditsButtonTask()
    {
        Active(false);
    }

    void QuitButtonTask()
    {
        Debug.Log("QUIT");
        Application.Quit(); 
    }

    void Active (bool value)
    {
        gameObject.SetActive(value); 
    }
}
