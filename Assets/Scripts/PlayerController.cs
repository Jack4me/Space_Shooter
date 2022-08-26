using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bound
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed = 20;
    public Bound bound;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject animationShot;
    public GameObject cloneShot;
    public float fireRate = 0f;
    public float fireNext = 0.5f;
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireNext)
        {
            fireNext = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            cloneShot = Instantiate(animationShot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            Destroy(cloneShot, 1f);
            GetComponent<AudioSource>().Play();
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0f, moveVertical) * speed;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, bound.xMin, bound.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bound.zMin, bound.zMax));
    }
}
