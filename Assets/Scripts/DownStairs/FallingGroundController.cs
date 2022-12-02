using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroundController : MonoBehaviour
{
    [Header("ƽ̨�����ٶ�")]
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
     * ƽ̨�����ƶ�
     */
    private void MoveUp()
    {
        movement.y = speed;
        transform.position += movement * Time.deltaTime;
    }

}
