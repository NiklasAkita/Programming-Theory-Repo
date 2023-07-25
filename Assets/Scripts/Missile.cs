using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Missile : MonoBehaviour
{
    protected float speed = 5f;

    public GameObject gfx;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        FollowPlayer();
    }

    // ABSTRACTION
    public virtual float CalcSpeed(float speed)
    {
        return speed;
    }
    void FollowPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }
        Vector3 playerPosition = player.transform.position;
        Vector3 missilePosition = transform.position;
        Vector3 direction = (playerPosition - missilePosition).normalized;
        // transform.LookAt(playerPosition);
        transform.Translate(direction * Time.deltaTime * CalcSpeed(speed));
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
