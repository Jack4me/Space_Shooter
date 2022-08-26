using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speedBullet;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speedBullet;
    }
}
