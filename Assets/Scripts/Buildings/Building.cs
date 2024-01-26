
using UnityEngine;

public abstract class Building : MonoBehaviour, PointOfInterest, Damagable
{
    private float health;
    private bool dead = false;
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
        dead = true;
        Destroy(gameObject);
    }

    public bool isDead()
    {
        return dead;
    }

    public abstract PriorityInfo getPriorityInofrmation();
}
