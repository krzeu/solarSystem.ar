using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.ARFoundation;


public class RotationAr : MonoBehaviour
{

    [SerializeField]
    private float _amplitude = 1;
    [SerializeField]
    private float _frequency = 0.1f;
    [SerializeField]
    private float _height = 1;
    [SerializeField]
    private float _startHeight = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Time.time * _frequency) * _amplitude;
        float y = _startHeight + Mathf.Sin(Time.time * _frequency) * _height;
        float z = Mathf.Sin(Time.time * _frequency) * _amplitude;

        transform.position = new Vector3(x, y, z);
    }
}