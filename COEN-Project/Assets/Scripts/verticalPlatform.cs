using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlatform : MonoBehaviour
{
    public PlatformEffector2D effector;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            effector.rotationalOffset = 180f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            effector.rotationalOffset = 0f;
        }
    }

}
