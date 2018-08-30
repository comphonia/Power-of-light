using UnityEngine.UI; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanel : MonoBehaviour {

    public static DefeatPanel instance;

	[SerializeField] Button tryAgainButton;
	[SerializeField] Button menuButton;

    [SerializeField] string nameMenuScene = "MainMenu";

    

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 
        tryAgainButton.onClick.AddListener(delegate { TryAgain(); });
        menuButton.onClick.AddListener(delegate { OpenMenu(); }); 
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f; 
    }

    void TryAgain ()
    {
        WavesSpawner.instance.TryAgain();
        GameMaster.instance.WaveEnded();    
    }

    void OpenMenu()
    {
        SceneManager.LoadScene(nameMenuScene);
    }
}
