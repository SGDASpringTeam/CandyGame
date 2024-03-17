/**
 * Author: Hudson Green
 * Contributors: N/A
 * Date Created: 2024-03-16
 * Description: Adds ranged abilities to enemy
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerUnit))]
public class PlayerRangedUnit : MonoBehaviour
{

    public bool disableMeleeAttack = true;              // PlayerUnit.cs is responsible for checking if this is true

    [SerializeField] private GameObject bulletPrefab = null;

    [Header("Bullet Properties")]
    [SerializeField] private float rangedDamage = 1.0f;
    [SerializeField] private float range = 5.0f;
    [SerializeField] private float bulletSpeed = 5.0f;
    [Tooltip("Amount of enemies the bullet can hit before being killed (how many enemies can it pass thru?")]
    [SerializeField] private int hitsUntilDespawn = 1;

    [Header("Gun Properties")]
    [SerializeField] private float rateOfFire = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerUnit pUnit = GetComponent<PlayerUnit>();

        // Guard against unit not being deployed yet
        if (!pUnit.deployed) return;

    }
}
