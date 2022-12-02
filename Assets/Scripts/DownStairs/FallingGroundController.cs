using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroundController : MonoBehaviour
{
    [Header("平台上升速度")]
    public float speed = 2;

    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6.5f)
        {
            MoveUp();
        }
    }

    /**
     * 平台向上移动
     */
    private void MoveUp()
    {
        movement.y = speed;
        transform.position += movement * Time.deltaTime;
    }

}
