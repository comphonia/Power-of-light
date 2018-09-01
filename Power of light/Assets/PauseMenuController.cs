using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    [SerializeField] GameObject pauseMenuPanel;
    [HideInInspector] public bool pauseMenuIsClosed = true;
    public static PauseMenuController instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuIsClosed)
        {
            pauseMenuPanel.SetActive(true);
            pauseMenuIsClosed = false; 
        }
    }

    public void Close ()
    {
        pauseMenuPanel.SetActive(false); 
    }
}
