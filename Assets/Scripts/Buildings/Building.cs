
using UnityEngine;

public abstract class Building : MonoBehaviour, PointOfInterest, Damagable
{
    private float health;
    [SerializeField] private BuildingData buildingData;


    void Start()
    {
        health = buildingData.Health;
    }

    public bool damageTaken(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy();
            return true;
        }
        return false;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }

    public abstract PriorityInfo getPriorityInofrmation();
}
