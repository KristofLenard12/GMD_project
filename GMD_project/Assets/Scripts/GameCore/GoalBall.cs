using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalBall : MonoBehaviour
{
    private Collider m_PlayerCollider;
    private GameObject[] m_WinUIObjects;
    private Button m_restartButton; 
    private Button m_menuButton;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        m_WinUIObjects = GameObject.FindGameObjectsWithTag("WinUI");

        m_restartButton = GameObject.Find("WinRestartButton").GetComponent<Button>();
        m_menuButton = GameObject.Find("WinMainMenuButton").GetComponent<Button>();

        m_restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        m_menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Menu1");
        });

        foreach (var item in m_WinUIObjects)
        {
            item.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_PlayerCollider.Equals(collision.collider))
        {
            Time.timeScale = 0;
            foreach (var item in m_WinUIObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
