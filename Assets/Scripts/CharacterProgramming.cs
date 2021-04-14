using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProgramming : MonoBehaviour
{

    public List<string> commands = new List<string>();
    

    public Vector3 characterStart = Vector3.zero;
    public Vector3 end = Vector3.zero;
    public float velocity = 6.0F;
    public float JumpSpeed = 8.0F;
    public float gravity = 15.0F;
    public Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    [SerializeField]
    private Rigidbody playerbody;



    // Start is called before the first frame update
    void Start()
    {
        characterStart = this.gameObject.transform.position;
    }






    public void StartScript(List<string> commands)
    {
        //Coroutine allows for script to be paused and allows to run over time. Also allows params to be passed in. Passes in the commands selected as an ArrayList
        StartCoroutine(runScript(commands));
        Debug.Log("MESSAGE SENT");
    }

    public void StopScript(List<string> commands)
    {
        StopAllCoroutines();
        Debug.Log("Count Before: " + commands.Count);
        commands.Clear();
        Debug.Log("Count after: " + commands.Count);

        //Return character to starting position
        transform.position = characterStart;
    }

    public IEnumerator runScript(List<string> cmds)
    {
        //Ensure character is in starting position when the script starts
        transform.position = characterStart;

        foreach (string cmd in cmds)
        {

            //Go through all possible command types
            switch (cmd)
            {
                case "PosX":  
                    transform.position += Vector3.right;
                    yield return null;
                    break;
                case "NegX":
                    transform.position += Vector3.left;
                    yield return null;
                    break;
                case "PosZ":
                    transform.position += Vector3.forward;
                    yield return null;
                    break;
                case "NegZ":
                    transform.position += Vector3.back;
                    yield return null;
                    break;
                case "Jump":
                    
                    yield return null;
                    break;
                case "rotate90":
                    yield return null;
                    break;
                case "rotate180":
                    yield return null;
                    break;
                case "rotate270":
                    yield return null;
                    break;
                case "spin":
                    yield return null;
                    break;

            }
        }
    }


//    public void OnTriggerEnter(Collider other)
  //  {

    //}


}
