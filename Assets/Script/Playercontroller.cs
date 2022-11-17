using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///���ƽ�ɫ�ƶ���������������

public class Playercontroller : MonoBehaviour
{
    public float speed = 5f;///�ƶ��ٶ�

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();///�Ѿ�ʵ����
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");///��ȡxy

        Vector2 movement = new Vector2(_x, _y);

        if(!Mathf.Approximately(a:movement.x,b:0.0f)||!Mathf.Approximately(a: movement.y, b: 0.0f))
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();
        }

        _animator.SetFloat(name: "lookX", _lookDirection.x);
        _animator.SetFloat(name: "lookY", _lookDirection.y);
        _animator.SetFloat(name: "speed", movement.magnitude);

        _currentInput = movement;
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

}
