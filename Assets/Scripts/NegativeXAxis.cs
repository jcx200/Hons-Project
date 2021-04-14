using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeXAxis : MonoBehaviour
{

    public void MoveNegX()
    {
        transform.position += Vector3.left;
    }
}
