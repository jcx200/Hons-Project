using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveZAxis : MonoBehaviour
{


    public void MovePosZ()
    {
        transform.position += Vector3.forward;
    }
}
