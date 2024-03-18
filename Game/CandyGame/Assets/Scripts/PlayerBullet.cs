/**
 * Author: Hudson Green
 * Contributors: Alan Villalobos
 * Date Created: 2024-03-16
 * Description: Bullet script for player units
**/

using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : MonoBehaviour
{

    [NonSerialized] public float rangedDamage;
    [NonSerialized] public float range;
    [NonSerialized] public float bulletSpeed;
    [NonSerialized] public PrimaryType type1;
    [NonSerialized] public SecondaryType type2;
    [NonSerialized] public PlayerUnit playerUnit;

    private Vector3 spawnLocation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
        // Get current spawn location
        spawnLocation = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy Unit"))
        {
            EnemyUnit foe = collision.gameObject.GetComponent<EnemyUnit>();

            foe.currentHealth -= rangedDamage * TypeDamageMultiplier(foe);
            if(foe != null && foe.currentHealth <= 0)
            {
                playerUnit.KillEnemy(foe);
            }

            Destroy(this.gameObject);
        }
    }

    // Deals More or Less Damage based on the Type Matchup
    private float TypeDamageMultiplier(EnemyUnit foe)
    {
        PrimaryType foeType1 = foe.type1;
        SecondaryType foeType2 = foe.type2;
        float type1Multiplier;
        float type2Multiplier;

        // Compare Primary Type

        if (foeType1 == type1) type1Multiplier = 1.0f; // Equal Type

        else if (type1 == PrimaryType.Sour && foeType1 == PrimaryType.Sweet) type1Multiplier = 1.5f; // Sour beats Sweet
        else if (type1 == PrimaryType.Sweet && foeType1 == PrimaryType.Spicy) type1Multiplier = 1.5f; // Sweet beats Spicy
        else if (type1 == PrimaryType.Spicy && foeType1 == PrimaryType.Sour) type1Multiplier = 1.5f; // Spicy beats Sour

        else type1Multiplier = 0.5f; // Enemy has Disadvantage

        // Compare Secondary Type

        if (foeType2 == type2) type2Multiplier = 1.0f; // Equal Type

        else if (type2 == SecondaryType.Hard && foeType2 == SecondaryType.Soft) type2Multiplier = 1.5f; // Hard beats Soft
        else if (type2 == SecondaryType.Soft && foeType2 == SecondaryType.Gummy) type2Multiplier = 1.5f; // Soft beats Gummy
        else if (type2 == SecondaryType.Gummy && foeType2 == SecondaryType.Hard) type2Multiplier = 1.5f; // Gummy beats Hard

        else type2Multiplier = 0.5f; // Enemy has Disadvantage

        // Return Overall Result

        float typeMultiplier = 0.0f;

        if ((type1Multiplier + type2Multiplier) / 2 == 1) typeMultiplier = 1.0f;

        else if ((type1Multiplier == 1.0 || type2Multiplier == 1.0) && (type1Multiplier == 0.5 || type2Multiplier == 0.5)) typeMultiplier = 0.5f;
        else if ((type1Multiplier == 1.0 || type2Multiplier == 1.0) && (type1Multiplier == 1.5 || type2Multiplier == 1.5)) typeMultiplier = 1.5f;

        else if (type1Multiplier == 0.5 && type2Multiplier == 0.5) typeMultiplier = 0.1f;
        else if (type1Multiplier == 1.5 && type2Multiplier == 1.5) typeMultiplier = 2.0f;

        return typeMultiplier;
    }
}