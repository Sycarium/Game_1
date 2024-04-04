using UnityEngine;

public class BossSequence : MonoBehaviour
{
    private float attackCycleInterval = 10f;
    private float timeSinceLastCycle;

    private void Start()
    {
        timeSinceLastCycle = attackCycleInterval;
    }

    private void Update()
    {
        // Keep track of time
        timeSinceLastCycle += Time.deltaTime;

        // Cycle through attack patterns every 10 seconds
        if (timeSinceLastCycle >= attackCycleInterval)
        {
            timeSinceLastCycle = 0f;
            CycleAttackPatterns();
        }
    }

    private void CycleAttackPatterns()
    {
        // Implement different attack patterns here
        int patternIndex = Random.Range(0, 3); // Assuming you have three patterns

        switch (patternIndex)
        {
            case 0:
                AttackPattern1();
                break;

            case 1:
                AttackPattern2();
                break;

            case 2:
                AttackPattern3();
                break;

            // Add more cases for additional patterns

            default:
                break;
        }
    }

    private void AttackPattern1()
    {
        // Implement your first bullet pattern here
        // Example: Spiral pattern
       // BulletManager.Instance.StartSpiralPattern(transform.position, 5f, 20, 3f);
    }

    private void AttackPattern2()
    {
        // Implement your second bullet pattern here
        // Example: Concentric circles
    //BulletManager.Instance.StartConcentricCirclesPattern(transform.position, 5, 3f, 10f);
    }

    private void AttackPattern3()
    {
        // Implement your third bullet pattern here
        // Example: Random spread
     //   BulletManager.Instance.StartRandomSpreadPattern(transform.position, 20, 5f);
    }

    // Add more methods for additional attack patterns
}
