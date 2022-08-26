using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject enemyGun;
    public Transform shotSpawn;
    private AudioSource _audio;
    public float shotRate;
    public float delay;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, shotRate);
    }

    public void Fire()
    {
        Instantiate(enemyGun, shotSpawn.position, shotSpawn.rotation);
        _audio.Play();
    }

}
