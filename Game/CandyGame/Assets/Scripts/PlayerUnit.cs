using UnityEngine;
using System.Collections;

public class PlayerUnit : MonoBehaviour
{
    [Header("Unit Attributes")] // Check TypeScript to see full list of types
    public string moldName; // moldName MUST be the same name as the UI Mold Button
    public PrimaryType type1;
    public SecondaryType type2;
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public float attackSpeed;

    [Header("Important Components")]
    [SerializeField] private HealthbarScript healthBar;

    // Important Variables for this Script
    private bool deployed;
    private BoxCollider2D hitbox;
    private GridTile placedTile;
    private CandyManager candyManager;
    private GameManager gameManager;
    private IEnumerator currentAttackRoutine;

    // When Unit is dragged from Shop, disable properties until deployed on grid
    private void Start()
    {
        deployed = false;

        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;

        candyManager = GameObject.Find("Candy Select").GetComponent<CandyManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Either wait for player to deploy unit, or proceed with main unit functions
    private void Update()
    {
        if (!deployed) ReadyToDeploy();
        else
        {
            PrepareAttack();
            UpdateHealth();
        }
    }

    // Give Player Unit proper type based on what the Mold was filled with
    public void SetTyping(CandyType candyType)
    {
        if (candyType == CandyType.None) return;

        else if (candyType == CandyType.Peppermint) {
        type1 = PrimaryType.Spicy;
        type2 = SecondaryType.Hard; }

        else if (candyType == CandyType.RockCandy) {
        type1 = PrimaryType.Sweet;
        type2 = SecondaryType.Hard; }

        else if (candyType == CandyType.HardCandy) {
        type1 = PrimaryType.Sour;
        type2 = SecondaryType.Hard; }

        else if (candyType == CandyType.Licorice) {
        type1 = PrimaryType.Spicy;
        type2 = SecondaryType.Soft; }

        else if (candyType == CandyType.Chocolate) {
        type1 = PrimaryType.Sweet;
        type2 = SecondaryType.Soft; }

        else if (candyType == CandyType.SourTaffy) {
        type1 = PrimaryType.Sour;
        type2 = SecondaryType.Soft; }

        else if (candyType == CandyType.CinnamonJelly) {
        type1 = PrimaryType.Spicy;
        type2 = SecondaryType.Gummy; }

        else if (candyType == CandyType.Bubblegum) {
        type1 = PrimaryType.Sweet;
        type2 = SecondaryType.Gummy; }

        else if (candyType == CandyType.Gumdrop) {
        type1 = PrimaryType.Sour;
        type2 = SecondaryType.Gummy; }
    }

    // Allow player to drag and drop the Unit from the Mold to the Grid
    private void ReadyToDeploy()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GridTile>() != null)
                {
                    placedTile = hit.collider.GetComponent<GridTile>();
                    if (placedTile.placeable && placedTile.currentUnit == null)
                    {
                        placedTile.PlaceUnit(this.gameObject);
                        deployed = true;
                        hitbox.enabled = true;
                        transform.position = hit.collider.gameObject.transform.position;
                        candyManager.DeployUnit(moldName);
                        return;
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }

    // Update Health Bar under Unit, and Kill Unit if HP goes below 0
    private void UpdateHealth()
    {
        if (currentHealth > 0) healthBar.UpdateHealthBar(currentHealth, maxHealth);
        else KillUnit();
    }
    private void KillUnit()
    {
        placedTile.currentUnit = null;
        Destroy(gameObject);
    }

    // Trigger an Attack based on attack speed. Also apply type damage multiplier
    private void PrepareAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1.0f, LayerMask.GetMask("Enemies"));
        if (hit.collider != null)
        {
            EnemyUnit enemyUnit = hit.collider.GetComponent<EnemyUnit>();
            if (enemyUnit != null && enemyUnit.currentHealth > 0)
            {
                if (currentAttackRoutine == null && enemyUnit != null && enemyUnit.currentHealth > 0)
                {
                    currentAttackRoutine = TriggerAttack(enemyUnit);
                    StartCoroutine(currentAttackRoutine);
                }
            }
        }
    }
    IEnumerator TriggerAttack(EnemyUnit foe)
    {
        while (foe != null && foe.currentHealth > 0)
        {
            //animator.SetTrigger("Attack");
            foe.currentHealth -= attackDamage * TypeDamageMultiplier(foe);
            //Debug.Log("Dealt " + attackDamage * TypeDamageMultiplier(foe) + " damage to " + foe.gameObject.name + "!");
            yield return new WaitForSeconds(attackSpeed);
        }

        if (foe != null) // When Player Unit Kills Enemy Unit
        {
            candyManager.ObtainMaterials(foe.type1, foe.type2);
            gameManager.UpdateEnemiesDestroyed();
            Destroy(foe.gameObject);
        }
        currentAttackRoutine = null;
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