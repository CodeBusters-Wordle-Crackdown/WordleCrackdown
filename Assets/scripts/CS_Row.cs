using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Tile[] tiles { get; private set; }
    public string word
    {
        get
        {
            string word = "";

            for (int i = 0; i < tiles.Length; i++)
            {
                word += tiles[i].tileChar;
            }
            return word;
        }
    }

<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        tiles = GetComponentsInChildren<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
    public void InitializeTiles()
    {
        tiles = GetComponentsInChildren<Tile>();
    }
>>>>>>> Stashed changes
}
