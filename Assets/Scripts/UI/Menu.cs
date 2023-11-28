using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private EventSystem _system;

    [SerializeField]
    private Button _button;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
        }
    }

    private void Start()
    {
        _system.SetSelectedGameObject(_button.gameObject);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void ToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1.0f;
    }
    public void ToOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    public void ToVersus()
    {
        SceneManager.LoadScene("Versus");
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("Pause");
    }

}
