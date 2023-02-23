using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private AudioSource _audio;

    [SerializeField]
    private AudioClip _death;

    private PlayerController _controller;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        _controller = GetComponent<PlayerController>();
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Danger")
        {
            StartCoroutine("Death");
        }
        if (collision.tag == "End")
        {
            string level = "Level" + collision.GetComponent<NextLevel>().Level.ToString();
            SceneManager.LoadScene(level);


        }
        if (collision.tag == "DoubleJump")
        {
            _controller.CanDoubleJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DoubleJump")
        {
            _controller.CanDoubleJump = false;
        }
    }
    public IEnumerator Death()
    {
        _audio.clip = _death;
        _audio.Play();
        _animator.SetBool("IsDead", true);
        _rb.simulated = false;
        _col.enabled = false;

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
