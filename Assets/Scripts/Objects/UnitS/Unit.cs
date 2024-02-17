using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Unit : MonoBehaviour, PointOfInterest, Damagable
{
    [SerializeField] private UnitData unitData;
    [SerializeField] private NavMeshAgent agent;
    private float health;
    private Vector3 destinationPoint;
    private PointOfInterest targetObject;
    protected UnitStartegyOverseer startegyOverseer;
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
        startegyOverseer = new UnitStartegyOverseer(this);
        health = unitData.Health;
        NavigationConfiguration();
        startegyOverseer.setDefaultStrategy();
    }

    void Start()
    {
        onStart();
    }



    void Update()
    {
        startegyOverseer.reconsiderStrategy();
        startegyOverseer.ExecuteStrategy();
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
        Destroy(gameObject);
    }

    public void AttackCooldown(UnitAttack unitAttack)
    {
        StartCoroutine(unitAttack.AttackCooldown(unitData.ReloadTime));
    }

    public bool isDead()
    {
        return dead;
    }

    public virtual List<PointOfInterest> GetPointOfInterests()
    {
        List<PointOfInterest> points = new List<PointOfInterest>();

        foreach (Commander commander in enemyCommanders)
            points.AddRange(commander.getPointsOfInterest());

        foreach (NeutralObject neutralObject in neutralObjectManager.objects)
            if(!(neutralObject is Mineral))
             points.Add(neutralObject);

        return points;
    }
}
