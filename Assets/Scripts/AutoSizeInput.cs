using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AutoSizeInput : MonoBehaviour {
    public float lineMaxWidth=470;
    public int lineCount=0;
    public float height;
    public float preferredHeight,preferWidth,flexibleHeight,flexiWidth;
    public Text inputText;
    public float curentWidth,lastLineWidth=0;
    public GameObject panel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTextChange(string textInput)
    {
        preferredHeight = inputText.preferredHeight;
        preferWidth = inputText.preferredWidth;
        flexibleHeight = inputText.flexibleHeight;
        flexiWidth = inputText.flexibleWidth;

        curentWidth = preferWidth - lastLineWidth;
        if (curentWidth > lineMaxWidth)
        {
            lastLineWidth = preferWidth;
            curentWidth = 0;
            lineCount++;
        }
        if (preferWidth < lastLineWidth)
        {
            lineCount--;
            lastLineWidth -= lineMaxWidth;
            if (lastLineWidth < 20) lastLineWidth = 0;
        }
        height = 50 + lineCount * 23;
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        panel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
}
