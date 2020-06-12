using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light _light;
    public float range;
    public float angle;

    void Awake()
    {
        _light = GetComponent<Light>();
        _light.range = range;
        _light.spotAngle = angle;
    }
}
