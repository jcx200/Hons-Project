using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class CharacterProgramming : MonoBehaviour
{

    //Command List
    public List<string> commands = new List<string>();

    //Jumping Code
    public LayerMask groundLayers;
    public SphereCollider col;
    public Vector3 characterStart = Vector3.zero;
    public Vector3 storedpos = Vector3.zero;
    private float JumpSpeed = 6.0F;

    Quaternion startRotation;

    //Audio
    public static AudioSource audioData;
    public static AudioClip sample;
    public static AudioClip tick;
    public static AudioClip sound2;
    public static AudioClip sound3;

    //Character
    CharacterController controller;

    [SerializeField]
    private Rigidbody playerbody;


    //Text
    public GameObject hwText;



    // Start is called before the first frame update
    void Start()
    {
        //Find characters initial state
        characterStart = this.gameObject.transform.position;
        startRotation = transform.rotation;

        //Create RigidBody and collider for the character
        playerbody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        
        //Get sound clips
        audioData = GetComponent<AudioSource>();
        sample = Resources.Load<AudioClip>("sample");
        tick = Resources.Load<AudioClip>("tick");
        sound2 = Resources.Load<AudioClip>("sound2");
        sound3 = Resources.Load<AudioClip>("sound3");
        
        //Hide Text
        hwText.SetActive(false);
    }


    void Update()
    {
        //Used for Jump command
        Vector3 moveDirection = new Vector3(0, 0, 0);

    }

    public void StartScript(List<string> commands)
    {
        //Coroutine allows for script to be paused and allows to run over time. Also allows params to be passed in. Passes in the commands selected as an ArrayList
        Debug.Log("Starting script");
        StartCoroutine(runScript(commands));
        
    }

    public void StopScript(List<string> commands)
    {
        //Stop Coroutines and clear command list
        StopAllCoroutines();
        Debug.Log("Count Before: " + commands.Count);
        commands.Clear();
        Debug.Log("Count after: " + commands.Count);

        //Return character to starting position
        transform.position = characterStart;
        transform.rotation = startRotation;
    }

    public IEnumerator runScript(List<string> cmds)
    {
        //Ensure character is in starting position and rotation when the script starts
        transform.position = characterStart;

        //Default storedpos as beginning position
        storedpos = characterStart;
        transform.rotation = startRotation;
        

        //prev_cmd stores the last command at the end of the foreach so RepeatLast can be used
        string prev_cmd = "";

        //Iterate through commands list
        foreach (string cmd in cmds)
        {
            //Go through all possible command types
            switch (cmd)
            {
                // MOVEMENT
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
                    playerbody.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
                    yield return new WaitForSeconds(1);
                    break;

                case "Spin":
                    for(int i = 0; i < 8; i++)
                    {
                        //Split into stages so rotation is obvious
                        transform.Rotate(0, 45F, 0);
                        yield return new WaitForSeconds(0.1F);
                    }
                    yield return null;
                    break;

                case "Rotate90":
                    transform.Rotate(0F, 90F, 0F);
                    yield return null;
                    break;

                case "Rotate180":
                    transform.Rotate(0, 180F, 0);
                    yield return null;
                    break;

                case "Rotate270":
                    transform.Rotate(0, 270F, 0);
                    yield return null;
                    break;

                case "movetostored":
                    transform.position = storedpos;
                    yield return null;
                    break;

                // SOUND
                case "playsound":
                    audioData.PlayOneShot(sample, 0.7F);
                    yield return new WaitForSeconds(1.5F); // Wait allows full audio clip to play
                    break;
                case "playsound2":
                    audioData.PlayOneShot(sound2, 0.7F);
                    yield return new WaitForSeconds(3F);
                    break;

                // CONTROL
                case "wait":
                    audioData.PlayOneShot(tick, 0.7F);
                    yield return new WaitForSeconds(5); // Allows full clip to play
                    break;

                case "repeat":
                    StartCoroutine(RepeatLast(prev_cmd));
                    break;

                case "repeatX2":
                    StartCoroutine(RepeatLast(prev_cmd));
                    yield return new WaitForSeconds(3F);
                    StartCoroutine(RepeatLast(prev_cmd));
                    break;

                case "storepos":
                    storedpos = this.gameObject.transform.position;
                    audioData.PlayOneShot(sound3, 0.7F);
                    yield return new WaitForSeconds(1F);
                    break;
                // TEXT

                case "shtext":
                    hwText.SetActive(true);
                    yield return new WaitForSeconds(3);
                    hwText.SetActive(false);
                    break;

                    
            }
            prev_cmd = cmd;

            yield return new WaitForSeconds(1);
        }
    }


    private IEnumerator RepeatLast(string prev_cmd)
    {
        switch (prev_cmd)
        {
            // MOVEMENT
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
                playerbody.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
                yield return new WaitForSeconds(1);
                break;

            case "Spin":
                for (int i = 0; i < 8; i++)
                {
                    transform.Rotate(0, 45F, 0);
                    yield return new WaitForSeconds(0.1F);
                }
                yield return null;
                break;

            case "Rotate90":
                transform.Rotate(0F, 90F, 0F);
                yield return null;
                break;

            case "Rotate180":
                transform.Rotate(0, 180F, 0);
                yield return null;
                break;

            case "Rotate270":
                transform.Rotate(0, 270F, 0);
                yield return null;
                break;



            // SOUND
            case "playsound":
                audioData.PlayOneShot(sample, 0.7F);
                yield return new WaitForSeconds(1.5F); // Wait allows full audio clip to play
                break;

            case "playsound2":
                audioData.PlayOneShot(sound2, 0.7F);
                yield return new WaitForSeconds(5);
                break;

            // TEXT
            case "shtext":
                hwText.SetActive(true);
                yield return new WaitForSeconds(3);
                hwText.SetActive(false);
                break;

            default:
                Debug.Log("Repeat not possible");
                break;
        }
        yield return new WaitForSeconds(1);
    }


}
