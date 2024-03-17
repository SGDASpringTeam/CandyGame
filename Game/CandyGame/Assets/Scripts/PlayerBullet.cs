/**
 * Author: Hudson Green
 * Contributors: N/A
 * Date Created: 2024-03-16
 * Description: Bullet script for player units
**/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{

    [NonSerialized] public float rangedDamage = 1.0f;
    [NonSerialized] public float range = 5.0f;
    [NonSerialized] public float bulletSpeed = 10.0f;
    [NonSerialized] public int hitsUntilDespawn = 1;

    private Vector3 spawnLocation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
        // Get current spawn location
        spawnLocation = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // Check if location exceeds bullet range: dist = sqrt[(x2 - x1)^2 + (y2 - y1)^2]
        Vector3 coordDist = transform.position - spawnLocation;     // (x2 - x1, y2 - y1)
        if (Math.Sqrt((coordDist.x * coordDist.x) + (coordDist.y * coordDist.y)) > range)
            Destroy(this);

        // Set velocity
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(
            bulletSpeed * Time.deltaTime * 60.0f, 
            0.0f, 
            0.0f
        );

    }
}
