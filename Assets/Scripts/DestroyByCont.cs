using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCont : MonoBehaviour
{

    public GameObject explosions;
    public GameObject playerExplosion;
    private GameObject cloneExplosion;

    public int scoreValue;
    private GameController controller; 

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            controller= gameControllerObject.GetComponent<GameController>();
        }
        if (controller == null)
        {
            Debug.Log("didnt have the reference");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cloneExplosion = Instantiate(playerExplosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
            controller.GameOver();
        }
        if (other.gameObject.tag == "Bolt")
        {
            cloneExplosion =Instantiate(explosions, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
            controller.addScore(scoreValue);
        }
    }
}
