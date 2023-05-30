using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class input : MonoBehaviour
{
    private string inputs;
    public GameObject inputfield;
    public InputManager inputManager;
    public bool inRiddle = false;
    private string[] riddles = new string [3];
    private string[] answers = new string [3];
    public TMP_Text  textElement;
    public TMP_Text textElement2;
    public TMP_Text Faliure_Text;
    private int riddle;
    public TMP_InputField main_input_field;
    public GameObject player;
    private string scr;
    public GameObject dogstopper;
    public GameObject Text;
    public GameObject Text2;
    private int flag;
    private int flag2;


    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        flag2 = 0;
        inputfield.SetActive(false);
        scr = "Player Locomotion";
        riddles[0] = "What goes up but never comes down?";
        riddles[1] = "What has to be broken before you can use it?";
        riddles[2] = "The more you take, the more you leave behind. What are they?";
        answers[0] = "Your Age";
        answers[1] = "An egg";
        answers[2] = "Footsteps";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRiddle && Input.GetKeyDown(KeyCode.Escape)) {inRiddle = false; exitRiddle();}
    }
    void OnTriggerEnter(Collider player)
    {
        if(flag == 0)
        {
            if(player.gameObject.tag == "Player" && !inRiddle)
            {
                //if(flag2 == 0)
                riddle = Riddle();
                textElement.text= riddles[riddle];
                textElement2.text = "To pass you must first solve one of my riddles";
                Text.SetActive(true);
                Text2.SetActive(true);

                inputfield.SetActive(true);
                main_input_field.ActivateInputField();
                inputManager.OnDisable();
                inRiddle = true;
                StartCoroutine(WaitForSec());
                //}
            //(player.GetComponent(scr) as MonoBehaviour).enabled = false;


            }
        }

    }
    public void ReadStringInput(string s)
    {
        inputs  = s;
        if(inputs.ToLower() == answers[riddle].ToLower())
        {
            textElement.text = "Congrats you have solved my riddle, you may pass" ;
            //(player.GetComponent(scr) as MonoBehaviour).enabled = true;
            dogstopper.SetActive(false);
            //Destroy(Text2);
            //Destroy(inputfield);
            Text2.SetActive(false);
            inputfield.SetActive(false);
            inputManager.OnEnable();
            StartCoroutine(WaitForSec2());
        }
        else if(inputs =="")
        {
        ;   
        }
        else
        {
            Faliure_Text.text = "Try again";
            StartCoroutine(WaitForSec3());
        }
        
    }
    private int Riddle()
    {
        int index = Random.Range(0,3);
        return index;

    }


    IEnumerator WaitForSec()
    {
        flag = 1;
        yield return new WaitForSeconds(20);
        Debug.Log("made it");
        inputfield.SetActive(false);
        Text.SetActive(false);
        Text2.SetActive(false);
        inRiddle = false;
        flag = 0;
        
    }

    public void exitRiddle()
    {
        inputfield.SetActive(false);
        Text.SetActive(false);
        Text2.SetActive(false);
        inRiddle = false;
        inputManager.OnEnable();
        flag = 0;
    }
    IEnumerator WaitForSec2()
    {
        flag = 1;
        Destroy(Faliure_Text);
        yield return new WaitForSeconds(8);
        Destroy(Text);
        Destroy(Text2);
    }
    
    IEnumerator WaitForSec3()
    {
        yield return new WaitForSeconds(10);
        Faliure_Text.text = "";


    }


}
