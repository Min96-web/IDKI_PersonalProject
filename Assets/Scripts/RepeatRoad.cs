using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    // determin how far the GameObject can move before it needs to reset its position
    private float _repeatWidth;
    //Stores the initial position of GameObject when the scene starts
    private Vector3 _startPos;

    // Start is called before the first frame update
    private void Start()
    {
        //GameObjects starting position
        _startPos = transform.position;
        //Half the width of boxcollider in z
        _repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    private void Update()
    { 
        //If GameObject's current z position is less than its starting z-position minus repeatwidth, if true resets to startposition.
        if (transform.position.z < _startPos.z - _repeatWidth) transform.position = _startPos;
    }
}