using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTimer : MonoBehaviour
{
    public static ParticleSystemTimer instanse;
     void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
        else
        {
            Destroy(this);
        }

    }
    public IEnumerator TimerToStop(ParticleSystem particleSystem, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        particleSystem.Stop();
    }
}
