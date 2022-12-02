using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    public float speed = 6.0f;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector2 _lookDirection = Vector2.up;
    private Vector2 _currentInput;

    private float _x;
    private float _y;


    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        bool run = false;

        Vector2 movement = new Vector2(_x, _y);

        if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();
            run = true;
        }

        _animator.SetBool("Run", run);
        _animator.SetFloat("lookX", movement.x);
        _animator.SetFloat("lookY", movement.y);
        
        _currentInput = movement;
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

    //碰撞后结束游戏
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        SceneManager.LoadScene("end");
    }
}