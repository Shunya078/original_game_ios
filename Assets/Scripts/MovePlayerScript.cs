using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerScript : MonoBehaviour
{
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float runSpeed = 0.1f;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pos_x = transform.position.x;
        float pos_z = transform.position.z;
        horizontalMove = joystick.Horizontal * runSpeed;
        verticalMove = joystick.Vertical * runSpeed;
        transform.position += new Vector3(horizontalMove,0,verticalMove);
        if(pos_x >= 4.4f)
        {
            runSpeed = 0;
            if(joystick.Horizontal < 0)
            {
                runSpeed = 0.1f;
            }
        }
        if (pos_x <= -4.4f)
        {
            runSpeed = 0;
            if (joystick.Horizontal > 0)
            {
                runSpeed = 0.1f;
            }
        }
        if (pos_z >= 4.4f)
        {
            runSpeed = 0;
            if (joystick.Vertical < 0)
            {
                runSpeed = 0.1f;
            }
        }
        if (pos_z <= -4.4f)
        {
            runSpeed = 0;
            if (joystick.Vertical > 0)
            {
                runSpeed = 0.1f;
            }
        }
    }
}
