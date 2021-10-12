using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light Sun;
    public Light Moon;
    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 2f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

}
