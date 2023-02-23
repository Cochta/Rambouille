using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScript : MonoBehaviour
{
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();
    }
    private void Start()
    {
        foreach (var button in _buttons)
        {
            if (!button.GetComponent<ButtonInteractionScript>().IsAvaillable)
            {
                button.interactable = false;
            }
        }
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void GoToLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void GoToLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void GoToLevel6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void GoToLevel7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void GoToLevel8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void GoToLevel9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void GoToBoss()
    {
        SceneManager.LoadScene("Level10");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
