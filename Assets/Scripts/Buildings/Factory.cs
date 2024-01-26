using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    [SerializeField] List<FactoryData> factoryDataLevels;
    [SerializeField] private Transform spawnPoint;
    private int level;
    private int levelMax;
    private bool readyToGenearate;
    [SerializeField] private PriorityObserver enemyObserver;
    [SerializeField] private PriorityObserver allyObserver;

    void Start()
    {
        level = 0;
        levelMax = factoryDataLevels.Count;
        /* StartCoroutine(GenerationCooldown(factoryDataLevels[level].SecondsToGenerate));*/
        readyToGenearate = true;
}

    void Update()
    {
        if (readyToGenearate)
            GenerateUnit();
    }

    private void GenerateUnit()
    {
        GameObject generatedUnit = Instantiate(factoryDataLevels[level].GeneratedUnit, spawnPoint.position, Quaternion.identity);
        allyObserver.PointsOfInterest.Add(generatedUnit.GetComponent<Unit>());
        generatedUnit.GetComponent<Unit>().EnemyObserver = enemyObserver;
        StartCoroutine(GenerationCooldown(factoryDataLevels[level].SecondsToGenerate));
    }

    public IEnumerator GenerationCooldown(float seconds)
    {
        readyToGenearate = false;
        yield return new WaitForSeconds(seconds);
        readyToGenearate = true;
    }

    public void levelUP()
    {
        level++;
    }

    public bool checkToLevelUp()
    {
        if (level < levelMax) return true;
        return false;

    }

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.FACTORY;
        return priorityInfo;
    }
}
