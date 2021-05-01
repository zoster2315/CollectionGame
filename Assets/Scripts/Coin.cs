using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Object Created");
        ++CoinCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        --CoinCount;
        if (CoinCount <= 0)
        {
            GameObject timer = GameObject.Find("LevelTimer");
            Destroy(timer);
            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach (GameObject firework in fireworks)
                firework.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entred Collider");
        if (other.CompareTag("Player"))
            Destroy(gameObject);
    }
}
