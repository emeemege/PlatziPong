using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool useAccelerometer = false;
    public float accelerometerSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useAccelerometer)
        {
            transform.position = new Vector3( transform.position.x
                                            , Mathf.Clamp(GetAccelerometerValue().y * accelerometerSpeed, -3.8f, 3.8f)
                                            , transform.position.z);
        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3( transform.position.x
                                            , Mathf.Clamp(mousePos.y, -3.8f, 3.8f)
                                            , transform.position.z);
        }
    }

    Vector3 GetAccelerometerValue()
    {
        Vector3 acc = Vector3.zero;
        float period = 0.0f;

        foreach(AccelerationEvent evnt in Input.accelerationEvents)
        {
            acc += evnt.acceleration * evnt.deltaTime;
            period += evnt.deltaTime;
        }
        if (period > 0)
        {
            acc *= 1.0f / period;
        }
        return acc;
    }
}
