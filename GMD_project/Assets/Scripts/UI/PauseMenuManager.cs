using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private static GameObject[] m_pauseObjects;
    private Button m_resumeButton;
    private Button m_menuButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        m_pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        m_resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        m_menuButton = GameObject.Find("MainMenuButton").GetComponent<Button>();
        hidePaused();

        m_resumeButton.onClick.AddListener(() => { 
            hidePaused();
        });

        m_menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Menu1");
        });
    }

    public static void hidePaused()
    {
        Time.timeScale = 1;
        foreach (var item in m_pauseObjects)
        {
            item.SetActive(false);
        }
    }

    public static void showPaused()
    {
        Time.timeScale = 0;
        foreach (var item in m_pauseObjects)
        {
            item.SetActive(true);
        }
    }
}
