using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private float _repeatWidth;
    private Vector3 _startPos;

    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    private void Update()
    { 
        if (transform.position.z < _startPos.z - _repeatWidth) transform.position = _startPos;
    }
}