using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    public Vector2 Movement
    {
        get { return _movement; }

        set { _movement = value; }
    }

    private Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputMovement();
        AnimatorMovement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }


    void FixedUpdate()
    {

         _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

    }

    

    private void InputMovement()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void AnimatorMovement()
    {
        _anim.SetFloat("Horizontal", _movement.x);
        _anim.SetFloat("Vertical", _movement.y);
        _anim.SetFloat("Speed", _movement.sqrMagnitude);
    }

}
