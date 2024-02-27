using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : Building
{
    [SerializeField] private TurretData turretData;
    private List<Commander> enemyCommanders;
    private Damagable target;
    private bool canAttack=true;
    [SerializeField] private GunRotationController gunRotationController;
    [SerializeField] private ParticleSystem attackEffect;

    public List<Commander> EnemyCommanders { get => enemyCommanders; set => enemyCommanders = value; }

    void Awake()
    {
        base.baseAwake();
    }

     void Start()
    {
        base.baseStart();
    }
    

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = turretData.TypeOf;
        return priorityInfo;
    }

    private List<PointOfInterest> GetPointOfInterests()
    {
        List<PointOfInterest> points = new List<PointOfInterest>();

        foreach (Commander commander in enemyCommanders)
            foreach (PointOfInterest point in commander.getPointsOfInterest())
                if (CheckPoint(point))
                    points.Add(point);

        return points;
    }

    private bool CheckPoint(PointOfInterest point)
    {

        if (point is Unit)
        {
            if ((((Unit)point).UnitData.TypeOf == UnitType.AIR_UNIT && turretData.AttackType == AttackType.GROUND) || (((Unit)point).UnitData.TypeOf == UnitType.GROUND_UNIT && turretData.AttackType == AttackType.AIR))
                return false;
        }
        else if (point is Building)
        {
            if (turretData.AttackType == AttackType.AIR)
                return false;
        }

        return true;
    }

    private void Update()
    {
        CheckforAttack();
        Attack();
    }

    private void CheckforAttack()
    {
        List<PointOfInterest> points = GetPointOfInterests();
        foreach (PointOfInterest point in points)
        {
            if (Vector3.Distance(point.getPriorityInofrmation().position, transform.position) < turretData.AttackRange)
            {
                    gunRotationController.RotateGun(point.getPriorityInofrmation().position);
                    target = (Damagable)point;  
            }
        }
    }

    private void Attack()
    {
        if (target != null && canAttack)
        {
            if (target.isDead())
            {
                target = null;
                return;
            }
            target.damageTaken(turretData.Damage);
            attackEffect.Emit(1);
            StartCoroutine(AttackCooldown(turretData.ReloadTime));
        }
    }

    private IEnumerator AttackCooldown(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }






}
