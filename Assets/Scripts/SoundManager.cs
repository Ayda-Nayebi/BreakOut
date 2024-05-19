using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private GameObject hitSFX;
    private void Start()
    {
        DestroySFX();
    }
    private void DestroySFX()
    {
        Destroy(hitSFX, 5);
    }

}
