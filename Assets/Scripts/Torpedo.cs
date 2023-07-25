using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : Missile
{
    // POLYMORPHISM
    // ABSTRACTION

    public override float CalcSpeed(float speed)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return speed;
        }
        Vector3 playerPosition = player.transform.position;
        Vector3 missilePosition = transform.position;
        Vector3 direction = (playerPosition - missilePosition);
        return speed / (direction.magnitude / 10);
    }
}
