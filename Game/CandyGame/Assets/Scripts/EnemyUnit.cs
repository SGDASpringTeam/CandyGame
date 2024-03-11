using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [Header("Unit Attributes")]
    public PrimaryType type1;
    public SecondaryType type2;
    public float maxHealth;
    public float currentHealth;
    public float attack;
    public float speed;

    // Important Variables for this Script
    bool isAttacking = false;

    private void Start()
    {
        type1 = SetRandomType<PrimaryType>();
        type2 = SetRandomType<SecondaryType>();
    }

    private void Update()
    {
        MoveUnit();
    }

    private void MoveUnit()
    {
        if (!isAttacking) transform.Translate(speed * Time.deltaTime * Vector3.left);
    }

    private void AttackUnit(PlayerUnit foe)
    {
        foe.currentHealth -= attack * TypeDamageMultiplier(foe);
        if (foe.currentHealth <= 0) Destroy(foe.gameObject);
        Debug.Log("Dealt " + attack * TypeDamageMultiplier(foe) + " damage!");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Unit"))
        {
            AttackUnit(collision.gameObject.GetComponent<PlayerUnit>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Unit"))
        {
            isAttacking = false;
        }
    }

    private Type SetRandomType<Type>()
    {
        System.Array types = System.Enum.GetValues(typeof(Type));
        return (Type)types.GetValue(UnityEngine.Random.Range(0, types.Length));
    }

    private float TypeDamageMultiplier(PlayerUnit foe)
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