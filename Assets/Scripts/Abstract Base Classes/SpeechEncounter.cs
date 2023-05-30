using System.Collections;
using UnityEngine;

public abstract class SpeechEncounter : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;
    public GameObject speechPanel;

    protected abstract bool SpeechConditionMet(); // Linked from Static Player Info in inherited classes

    protected virtual void Start() 
    {
        text.SetActive(false);
        text2.SetActive(false);
        speechPanel.SetActive(false);
    }

    protected virtual void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && SpeechConditionMet())
        {
            speechPanel.SetActive(true);
            text.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        else if (player.gameObject.tag == "Player" && !SpeechConditionMet())
        {
            speechPanel.SetActive(true);
            text2.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    protected IEnumerator WaitForSec()
    {
        if (SpeechConditionMet())
        {
            yield return new WaitForSeconds(7); // Standard delay after text is displayed to when it goes away
            speechPanel.SetActive(false);
            text.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(7);  
            speechPanel.SetActive(false);
            text2.SetActive(false);
        }
    }
}
