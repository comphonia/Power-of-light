using UnityEngine.UI; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] Button resumeButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button quitButton;

    [SerializeField] string menuScene_name = "Menu"; 

    private void Awake()
    {
        resumeButton.onClick.AddListener(delegate { Resume(); });
        menuButton.onClick.AddListener(delegate { Menu(); });
        quitButton.onClick.AddListener(delegate { Quit(); });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume(); 
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        PauseMenuController.instance.pauseMenuIsClosed = true; 
    }

    void Resume()
    {
        gameObject.SetActive(false); 
    }

    void Menu()
    {
        SceneManager.LoadScene(menuScene_name);
    }

    void Quit()
    {
        Application.Quit(); 
    }
}
