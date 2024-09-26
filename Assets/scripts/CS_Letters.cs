using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CS_Letters : MonoBehaviour
{
    [System.Serializable]
    public class LetterState
    {
        public Color tileColor;
    }

    public LetterState state {  get; private set; }

    public char letter;
    private Image tileFill;


    // Start is called before the first frame update
    void Start()
    {
        // get the first character of the string in the "text input" box of the TextMeshPro component (Letter that is displayed on the UI)
        letter = gameObject.GetComponentInChildren<TextMeshProUGUI>().text[0];
        tileFill = gameObject.GetComponentInChildren<Image>();
    }

    public void SetState(LetterState state)
    {
        this.state = state;
        tileFill.color = state.tileColor;
    }
}
