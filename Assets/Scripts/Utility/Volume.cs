using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource _audio;
    void Update()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = PlayerPrefs.GetFloat("Volume");
    }

}
