using UnityEngine.UI; 
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DefeatPanel : MonoBehaviour {

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button menuButton;
    [SerializeField] string menuScene_name = "MainMenu";

    private void Awake()
    {
        tryAgainButton.onClick.AddListener(delegate { TryAgain(); });
        menuButton.onClick.AddListener(delegate { OpenMenu(); });
    }

    void TryAgain()
    {
        GameMaster.instance.UpdateLastingEnemiesUI(0);
        gameObject.SetActive(false);
    }

    void OpenMenu()
    {
        SceneManager.LoadScene(menuScene_name); 
    }
}
