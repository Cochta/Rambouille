using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwompSound : MonoBehaviour
{
    private AudioSource _audio;
    public bool IsVersus = false;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponentInParent<AudioSource>();
        if (IsVersus)
            _audio.volume = PlayerPrefs.GetFloat("Volume");
        else
            _audio.volume = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !IsVersus)
        {
            if (PlayerPrefs.HasKey("Volume"))
                _audio.volume = PlayerPrefs.GetFloat("Volume");
            else
                _audio.volume = 1.0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !IsVersus)
        {
            _audio.volume = 0.0f;
        }
    }
}
