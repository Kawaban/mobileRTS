using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour, PointOfInterest, Damagable
{
    [SerializeField] private UnitData unitData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ParticleSystem deathEffect;
    private float health;
    private Vector3 destinationPoint;
    private PointOfInterest targetObject;
    protected UnitStartegyOverseer strategyOverseer;
    private bool dead = false;

    private List<Commander> enemyCommanders;
    private NeutralObjectManager neutralObjectManager;
    private Commander ourCommander;

    private UnityEvent<Unit> eventDeath;

    public UnitData UnitData { get => unitData; }
    public NavMeshAgent Agent { get => agent; }
    public float Health { get => health; set => health = value; }
    public Vector3 DestinationPoint { get => destinationPoint; set => destinationPoint = value; }
    public PointOfInterest TargetObject { get => targetObject; set => targetObject = value; }

    public NeutralObjectManager NeutralObjectManager { get => neutralObjectManager; set => neutralObjectManager = value; }
    public List<Commander> EnemyCommanders { get => enemyCommanders; set => enemyCommanders = value; }
    public UnityEvent<Unit> EventDeath { get => eventDeath; }
    public Commander OurCommander { get => ourCommander; set => ourCommander = value; }

    void Awake()
    {
        if (eventDeath == null)
            eventDeath = new UnityEvent<Unit>();
    }

     public virtual void onStart()
    {
        health = unitData.Health;
        NavigationConfiguration();
    }

    void Start()
    {
        onStart();
    }



    void Update()
    {
        strategyOverseer.reconsiderStrategy();
        strategyOverseer.ExecuteStrategy();
    }

    private void NavigationConfiguration()
    {
        agent.speed = unitData.Speed;
        agent.acceleration = unitData.Acceleration;
        agent.angularSpeed = unitData.RotationSpeed;
    }

    public virtual PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.UNIT;
        return priorityInfo;
    }

    public bool damageTaken(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
            return true;
        }
        return false;
    }



    private void Death()
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

    public abstract List<PointOfInterest> GetPointOfInterests();
    
}
