using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public static bool isGamePaused;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject resumeButton;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isGamePaused = false;
    }

    // Update is called once per frame 
    void Update()
    {
        if (isGamePaused)
        {
            if (!isPaused)
            {
                isPaused = true;
            }

            PauseGame();
            //if(isPaused) this.resumeButton.GetComponent<Button>().Select();
            //EventSystem.current.SetSelectedGameObject(null);
            //EventSystem.current.SetSelectedGameObject(resumeButton);
        }
        else if (!isGamePaused)
        {
            if (isPaused)
            {
                isPaused = false;
            }
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadOptions()
    {
        //SceneManager.LoadScene("OptionMenu"); //SPOILER NO HAY 
       // Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("MainMenu"); 
    }
}
