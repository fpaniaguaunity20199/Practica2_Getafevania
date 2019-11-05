using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    float x, y;
    public FixedJoystick fixedJoystick;
    private void Update()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                x = fixedJoystick.Horizontal;
                y = fixedJoystick.Vertical;
                break;
            case RuntimePlatform.WindowsEditor:
                x = fixedJoystick.Horizontal;
                y = fixedJoystick.Vertical;
                break;
            case RuntimePlatform.WindowsPlayer:
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");
                break;
        }
        Move(x);
    }
    private void Move(float x)
    {
        if (Mathf.Abs(x) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(x * Time.deltaTime * speed, 0);
        } 
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
