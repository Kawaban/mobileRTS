using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshUpdater : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;
    public float secondsToUpdate;

    private bool isReady = true;


    void Update()
    {
        if (isReady)
        {
            Debug.Log("gg");
            navMeshSurface.BuildNavMesh();
            StartCoroutine(updateSurface());
        }
    }

    private IEnumerator updateSurface()
    {
        isReady = false;
        yield return new WaitForSeconds(secondsToUpdate);
        isReady = true;
    }
}
