using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public Vector2 startTime;
    private void Start()
    {
        StartCoroutine(Maneuver());
    }

    private IEnumerator Maneuver()
    {
        yield return WaitForSeconds(Random.Range(startTime.x, startTime.y));

    }
}
