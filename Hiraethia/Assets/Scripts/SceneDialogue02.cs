using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneDialogue02 : MonoBehaviour {
    public Text textfield;
    string currenttext = "";
    bool isrunning = false;
    bool isforcedcomplete = false;
	int dialoguecounter = 1;
	public Image background1;
	public Image background2;

	//switchbackground((Image)Current Shown, (Image) to transition to, (float) Time of transition)
	void switchbackground(Image currentimage,Image nextimage, float aTime){
		StartCoroutine(FadeTo(currentimage,nextimage, aTime));
	}
	IEnumerator FadeTo(Image currentimage,Image nextimage,float aTime)
	{
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(0.0f,1.0f,t));
			nextimage.color = newColor;
			yield return null;
		}
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(1.0f,0.0f,t));
			currentimage.color = newColor;
			yield return null;
		}
	}

	//dialoguecall((String) to print out)
	void dialoguecall(string passstring)
	{
		isrunning = true;
		StartCoroutine(stringcall(passstring));
	}
	void printchar(char c) {
        textfield.text = textfield.text + c;
    }
    IEnumerator stringcall(string dialogue)
    {
        textfield.text = ""; 
       char[] chardialogue;
       chardialogue = dialogue.ToCharArray();
       for(int x = 0; x < dialogue.Length; x++){
           yield return new WaitForSeconds(.025f);
           printchar(chardialogue[x]);
           if (x == dialogue.Length-1)
           {
               isrunning = false;
           }
           if (isforcedcomplete == true)
           {
               textfield.text = dialogue;
               isforcedcomplete = false;
               isrunning = false;
               break;
               
           }
       }
    }

    void Start()
    {
		//First dialogue display
        currenttext = "Insert dialogue to be displayed."; //String type
        dialoguecall(currenttext);
	}

	void Update () {
		//Input Triggers
		if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)) || (Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
        if (isrunning == false)
        {
            dialoguecounter++;
            switch (dialoguecounter)
            {
                case 2://Second dialogue to display.
					switchbackground(background1,background2, .5f);
                    currenttext = "Dialogue Text Number Two";
                    dialoguecall(currenttext);
                    break;
                case 3:// Third
					currenttext = "Dialogue Text Number Three";
                    dialoguecall(currenttext);
                    break;
                case 4:// etc.
					currenttext = "Dialogue Text Number Four";
                    dialoguecall(currenttext);
                    break;
				case 5:// etc.
					currenttext = "Dialogue Text Number Five";
					dialoguecall(currenttext);
					break;
				default:// Clear dialogue on complete
					currenttext = "";
					dialoguecall(currenttext);
					break;
            }
        }
        else
        {
            isforcedcomplete = true;
        }
    }
	}
}
