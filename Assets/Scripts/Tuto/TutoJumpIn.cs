using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoJumpIn : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textKey;
    [SerializeField]
    private TextMeshProUGUI _textText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _textKey.text = "w";
            _textText.text = "              Jump";
        }
    }
}
