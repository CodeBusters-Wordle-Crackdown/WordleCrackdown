using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [System.Serializable]
    public class State
    {
        public Color tileColor;
    }

    public State state { get; private set; }
    public char tileChar { get; private set; }


    private TextMeshProUGUI letter;
    private Image fill;
    

    // Start is called before the first frame update
    void Start()
    {
        letter = GetComponentInChildren<TextMeshProUGUI>();
        fill = GetComponent<Image>();
    }


    public void SetLetter(char c)
    {
        this.tileChar = c;
        letter.text = c.ToString();
    }
    
    public void SetState(State state)
    {
        this.state = state;
        fill.color = state.tileColor;
    }
}
