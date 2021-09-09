using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "bird")
        {

            UIManager manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
            manager.AddPoint();
        }
    }
}
