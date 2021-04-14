using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Apply RigidBody Physics to the controllable character
public class StickPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerbody;

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // playerbody.velocity = Vector3.right;
    }
}
