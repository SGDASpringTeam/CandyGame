/**
 * Author: Hudson Green
 * Contributors: Alan Villalobos
 * Date Created: 2024-03-16
 * Description: Adds ranged abilities to enemy
**/

using UnityEngine;

[RequireComponent(typeof(PlayerUnit))]
public class PlayerRangedUnit : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;

    [Header("Bullet Properties")]
    [Tooltip("Amount of damage bullet should do")]
    [SerializeField] private float rangedDamage = 1.0f;
    [Tooltip("Distance in units bullet can travel before it is killed")]
    [SerializeField] private float range = 5.0f;
    [Tooltip("Speed of bullet in no particular unit of speed")]
    [SerializeField] private float bulletSpeed = 5.0f;

    [Header("Gun Properties")]
    [Tooltip("Rate of fire in rounds per minute (RPM) (60 RPM = 1 shot per second)")]
    [SerializeField] private float rateOfFire = 60.0f;

    private float timeSinceLastShot;
    private PlayerUnit pUnit;

    private void Start()
    {
        timeSinceLastShot = 0.0f;
        pUnit = GetComponent<PlayerUnit>();
    }

    // Update is called once per frame
    void Update()
    {  
        // Guard against unit not being deployed yet
        if (!pUnit.deployed) return;

        // Increase time since last shot by frametime
        timeSinceLastShot += Time.deltaTime;

        // Spawn bullet given rate of fire
        if(timeSinceLastShot > (1.0f / rateOfFire) * 60.0f)
        {
            // Spawn bullet
            SpawnBullet(transform.position);
            timeSinceLastShot = 0.0f;
        }

    }

    private void SpawnBullet(Vector3 spawnLocation)
    {
        // Guard against missing bullet prefab specified
        if (bulletPrefab == null) return;

        // Generate the bullet GameObject from prefab
        GameObject bullet = Instantiate(bulletPrefab, spawnLocation, Quaternion.identity);

        // Give bullet its properties
        bullet.GetComponent<PlayerBullet>().rangedDamage = rangedDamage;
        bullet.GetComponent<PlayerBullet>().range = range;
        bullet.GetComponent<PlayerBullet>().bulletSpeed = bulletSpeed;
        bullet.GetComponent<PlayerBullet>().type1 = pUnit.type1;
        bullet.GetComponent<PlayerBullet>().type2 = pUnit.type2;
        bullet.GetComponent<PlayerBullet>().playerUnit = pUnit;
    }
}