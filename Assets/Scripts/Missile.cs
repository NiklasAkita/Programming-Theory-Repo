using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float minSpeed = 5f;

    public GameObject gfx;
    private float actualSpeed;
    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = Random.Range(minSpeed, minSpeed + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardPlayer();
        FollowPlayer();
    }

    void FollowPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        Vector3 missilePosition = transform.position;
        Vector3 direction = (playerPosition - missilePosition).normalized;
        // transform.LookAt(playerPosition);
        transform.Translate(direction * Time.deltaTime * actualSpeed);
    }

    void RotateTowardPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        Vector3 missilePosition = transform.position;
        Vector3 direction = (playerPosition - missilePosition).normalized;
        gfx.transform.LookAt(playerPosition);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Shield")
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.Instance.DecreaseHealth();
        }
    }
}
