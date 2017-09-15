using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int hazardScoreValue;
    public int greenSmileScoreValue;

    private GameController gameController;

    private void Start()
    {
        //Debug.Log(transform.tag);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Unable to get controller");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            if (tag == "GreenSmile")
            {
                gameController.AddScore(greenSmileScoreValue);
            }
            else
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                Destroy(other.gameObject);
            }
            
        } else
        {
            gameController.AddScore(hazardScoreValue);
        }

        Destroy(gameObject);
    }

}
