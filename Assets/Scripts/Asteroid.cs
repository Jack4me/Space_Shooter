using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationAsteroid;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.angularVelocity = new Vector3(1f,1f,1f) * rotationAsteroid;
        _rb.angularVelocity = Random.insideUnitSphere * rotationAsteroid;
    }
}
