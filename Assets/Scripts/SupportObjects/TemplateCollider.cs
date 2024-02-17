using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateCollider : MonoBehaviour
{
    private Boolean isColliding = false;

    public Boolean IsColliding
    {
        get { return isColliding; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
            isColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Ground")
            isColliding = false;
    }
    
}
