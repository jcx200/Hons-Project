using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeZAxis : MonoBehaviour
{
    public void MoveNegZ()
    {
        transform.position += Vector3.back;
    }
}
