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

	IEnumerator backgroundswitchspeed() {
		yield return new WaitForSeconds(1.0f);
	}
	void backgroundswitch(ref Image currentimage,ref Image nextimage){
		Color currentimagecolor = currentimage.color;
		Color nextimagecolor = nextimage.color;
		Debug.Log (currentimagecolor.a);
		for(float o = 1.00f; o > 0.0f; o=o-.01f){
			currentimagecolor.a = o;
			currentimage.color = currentimagecolor;
			StartCoroutine(backgroundswitchspeed());
		}
		for(float s = 0.0f; s < 1.00f; s=s+.01f){	
			nextimagecolor.a = s;
			nextimage.color = nextimagecolor;
			StartCoroutine(backgroundswitchspeed());
		}

	}

	void printchar(char c) {
        textfield.text = textfield.text + c;
    }
    void dialoguecall(string passstring)
    {
        isrunning = true;
        StartCoroutine(stringcall(passstring));
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
    // Use this for initialization
    void Start()
    {
		//First dialogue display
        currenttext = "Insert dialogue to be displayed."; //String type
        dialoguecall(currenttext);
	}
	
	// Update is called once per frame
	void Update () {
		//Input Triggers
		if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)) || (Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
        if (isrunning == false)
        {
            dialoguecounter++;
            switch (dialoguecounter)
            {
                case 2://Second dialogue to display
                    currenttext = "...";
                    dialoguecall(currenttext);
                    break;
                case 3:// Third
					backgroundswitch(ref background1,ref background2);
                    currenttext = "....";
                    dialoguecall(currenttext);
                    break;
                case 4:// etc.
                    currenttext = ".....";
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
