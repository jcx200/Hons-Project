using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour
{

    Vector3 startPos;
  
    //List to store selected commands in. Static modifier means that only one instance of the list exists.
    public static List<string> commands = new List<string>();
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        //Find the controllable character
        character = GameObject.Find("StickFigure");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "MovePlusX":
                Debug.Log(name + " added");
                commands.Add("PosX");
                break;
            case "MovePlusZ":
                Debug.Log(name + " added");
                commands.Add("PosZ");
                break;
            case "MoveMinusX":
                Debug.Log(name + " added");
                commands.Add("NegX");
                break;
            case "MoveMinusZ":
                Debug.Log(name + " added");
                commands.Add("NegZ");
                break;
            case "JumpBlock":
                Debug.Log(name + " added");
                commands.Add("Jump");
                break;
            case "Spin":
                Debug.Log(name + " added");
                commands.Add("Spin");
                break;
            case "Rotate90":
                Debug.Log(name + " added");
                commands.Add("Rotate90");
                break;
            case "Rotate180":
                Debug.Log(name + " added");
                commands.Add("Rotate180");
                break;
            case "Rotate270":
                Debug.Log(name + " added");
                commands.Add("Rotate270");
                break;
            case "StartModel":
                Debug.Log("Starting script with " + commands.Count + " commands");
                character.SendMessage("StartScript", commands);
                break;
            case "StopModel":
                character.SendMessage("StopScript", commands);
                Debug.Log("Script stopped and commands cleared");
                break;
            default:
                Debug.Log("Nothing");
                //Debug.Log(commands.Count);
                break;

        }
    }










 






}