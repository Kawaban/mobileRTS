using UnityEngine;


public class PriorityCalculator : MonoBehaviour
{
    [SerializeField] private static PriorityCalculatorData priorityCalculatorData;

    public static PriorityCalculator Instance { get; private set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public static float calculate(PriorityInfo client, PriorityInfo target)
    {
        float dist = -Vector3.Distance(client.position, target.position);
        float mark = dist;
        return dist;
    }


}
