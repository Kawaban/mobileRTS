
using UnityEngine;
using UnityEngine.Events;

public abstract class Building : MonoBehaviour, PointOfInterest, Damagable
{
    private float health;
    private bool dead = false;
    [SerializeField] private BuildingData buildingData;
    [SerializeField] private ParticleSystem deathEffect;

    private UnityEvent<Building> eventDeath;

    public UnityEvent<Building> EventDeath { get => eventDeath; }
    public BuildingData BuildingData { get => buildingData; }

    protected void baseAwake()
    {
        if (eventDeath == null)
            eventDeath = new UnityEvent<Building>();
    }

    protected void baseStart()
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
        eventDeath.Invoke(this);
        deathEffect.Play();
        deathEffect.gameObject.transform.parent = null;
        ParticleSystemTimer.instanse.StartCoroutine(ParticleSystemTimer.instanse.TimerToStop(deathEffect, 1f));
        Destroy(gameObject);
    }

    public bool isDead()
    {
        return dead;
    }

    public abstract PriorityInfo getPriorityInofrmation();
}
