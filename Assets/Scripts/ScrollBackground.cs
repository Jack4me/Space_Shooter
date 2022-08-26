using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;
    public Transform curentObject;
    void Start()
    {
        curentObject = GetComponent<Transform>();
    }


    void Update()
    {
        curentObject.position = new Vector3(
            curentObject.position.x,
            curentObject.position.y,
           Mathf.Repeat(Time.time * scrollSpeed, tileSize));
    }
}
