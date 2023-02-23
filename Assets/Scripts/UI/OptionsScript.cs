using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnValueChanged(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }
}
