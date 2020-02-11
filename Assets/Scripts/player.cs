using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    private int _coins;
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isGrounded;

    public int Health;
    public float Speed;
    public int JumpForce;
    public Transform GroundChek;
    public float ChekRadius;
    public LayerMask WhatIsGround;

    public TMP_Text CoinsScore;
    public TMP_Text HealthPlayer;

    private void Start()
    {
        HealthPlayer.text = Health.ToString();

        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundChek.position, ChekRadius, WhatIsGround);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.Play("runplayer");
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.Play("runleft");
            transform.Translate(Speed * Time.deltaTime * -1, 0, 0);
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            _rb.AddForce(new Vector2(0, JumpForce));
        }
    }
    public void ApplyDamage(int damage)
    {
        Health -= damage;
        HealthPlayer.text = Health.ToString();
        if (Health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Coins")
        {
            _coins++;
            CoinsScore.text = _coins.ToString();
            Destroy(other.gameObject);
        }
    }
}
