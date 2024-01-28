using System.Collections;
using UnityEngine;

public class UnitAttack : UnitStrategy
{
    private bool canAttack = true;
    public void Execute(Unit unit)
    {
        CheckTarget(unit);
        SetPath(unit);
        if (canAttack)
            Shoot(unit);
    }

    private void Shoot(Unit unit)
    {
        if (((Damagable)unit.TargetObject).damageTaken(unit.UnitData.Damage))
        {
            unit.TargetObject = null;
        }

        unit.AttackCooldown(this);
    }

    private void CheckTarget(Unit unit)
    {
        if (((Damagable)unit.TargetObject).isDead())
        {
            unit.TargetObject = null;
        }
    }

    public IEnumerator AttackCooldown(float reloadTime)
    {
        canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        canAttack = true;
    }

    private void SetPath(Unit unit)
    {
        if (unit.TargetObject != null)
            unit.DestinationPoint = unit.TargetObject.getPriorityInofrmation().position;

        unit.Agent.SetDestination(unit.DestinationPoint);
        unit.Agent.stoppingDistance = unit.UnitData.TargetOffset;
    }

}
