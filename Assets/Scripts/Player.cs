using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAttributes Attributes;

    private Rigidbody2D rb;
    private Animator anim;

    private int _health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _health = Attributes.Health;

        Debug.Log("VIDA INICIAL " + _health);
    }

    void Update()
    {
        ToggleScene();

        if (Input.GetButtonDown("Fire1") && Attributes.CanAttack)
        {
            anim.SetTrigger("attack");
        }
    }

    private void FixedUpdate()
    {
        float _direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(_direction * Attributes.Speed, rb.velocity.y);

        // Flip player
        if (_direction > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (_direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Set animation (idle or walk)
        if (_direction != 0)
        {
            anim.SetInteger("transition", 1);
        } else
        {
            anim.SetInteger("transition", 0);
        }
    }

    private void ToggleScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;

            if (currentScene == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            _health--;
            Debug.Log("VIDA atual " + _health);
        }

        if (collision.CompareTag("Skill Attack"))
        {
            Attributes.CanAttack = true;
            Destroy(collision.gameObject);
        }
    }
}
