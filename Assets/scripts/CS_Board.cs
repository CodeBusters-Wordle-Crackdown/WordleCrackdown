using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
    private static readonly KeyCode[] VALID_INPUTS = new KeyCode[]
    {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, 
        KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, 
        KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, 
        KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, 
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, 
        KeyCode.Z
    };

    private Row[] rows;
    private CS_Letters[] letters;
<<<<<<< Updated upstream
=======
    private Row currentRow;

    public int row_count;
    public int word_size;
>>>>>>> Stashed changes

    private string[] validWords;
    private string[] solutionWords;
    private string word;

    private int rowIndex;
    private int columnIndex;
     
    [Header("Tile States")]
    public Tile.State emptyTileState;
    public Tile.State occupiedTileState;
    public Tile.State correctTileState;
    public Tile.State wrongSpotTileState;
    public Tile.State incorrectTileState;

    [Header("Letter States")]
    public CS_Letters.LetterState emptyLetterState;
    public CS_Letters.LetterState correctLetterState;
    public CS_Letters.LetterState wrongSpotLetterState;
    public CS_Letters.LetterState incorrectLetterState;

    [Header("UI")]
    public GameObject invalidWordText;
    public GameObject newGameButton;


    private void Start()
    {
        rows = GetComponentsInChildren<Row>();
<<<<<<< Updated upstream
=======

        //Tell rows they may initialize their tile size
        foreach (Row row in rows)
        {
            row.InitializeTiles();
        }
        
>>>>>>> Stashed changes
        letters = GameObject.Find("Letters").GetComponentsInChildren<CS_Letters>();
        LoadData();
        SetRandomWord();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        Row currentRow = rows[rowIndex];

        // backspace a character in row
        if (Input.GetKeyDown(KeyCode.Backspace))
=======
        currentRow = rows[rowIndex];

        if (UnityEngine.Input.GetKeyDown(KeyCode.Backspace))
>>>>>>> Stashed changes
        {
            columnIndex = Mathf.Max(columnIndex - 1, 0);
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyTileState);
            invalidWordText.SetActive(false);
        }
        // if last column is filled
        else if (columnIndex >= currentRow.tiles.Length)
        {
            SubmitRow(currentRow);
        }
        // check for input
        else
        {
            for (int i = 0; i < VALID_INPUTS.Length; i++)
            {
                var input = VALID_INPUTS[i];
                if (Input.GetKeyDown(input))
                {
                    currentRow.tiles[columnIndex].SetLetter((char)input);
                    columnIndex++;
                    break;
                }
            }
        }
    }

<<<<<<< Updated upstream
=======
    public void InputChar(string input)
    {
        // Receive the first character of input as a char
        currentRow.tiles[columnIndex].SetLetter(input.ToLower()[0]);
        columnIndex++;
    }
    
    public void BackspaceChar()
    {
        columnIndex = Mathf.Max(columnIndex - 1, 0);
        currentRow.tiles[columnIndex].SetLetter('\0');
        currentRow.tiles[columnIndex].SetState(emptyTileState);
        invalidWordText.SetActive(false);
    }

>>>>>>> Stashed changes
    private void LoadData()
    {
        TextAsset textFile = Resources.Load("official_wordle_all") as TextAsset;
        validWords = textFile.text.Split('\n');

        textFile = Resources.Load("official_wordle_common") as TextAsset;
        solutionWords = textFile.text.Split('\n');
<<<<<<< Updated upstream
=======

        // remove space character at end of words
        for (int i = 0; i < validWords.Length; i++)
            validWords[i] = validWords[i].Trim();

        for (int i = 0; i < solutionWords.Length; i++)
            solutionWords[i] = solutionWords[i].Trim();
>>>>>>> Stashed changes
    }

    private void SetRandomWord()
    {
        word = solutionWords[Random.Range(0, solutionWords.Length)];
        word = word.ToLower().Trim();
    }

    private void SubmitRow(Row row)
    {
        // If word isn't valid, then don't bother checking or submitting
        if (!IsValidWord(row.word))
        {
            invalidWordText.SetActive(true);
            return;
        }

        // Solution word that gets modified as letters are guessed in order to avoid duplicates
        string remaining = word;

<<<<<<< Updated upstream
        for(int i = 0; i < row.tiles.Length; i++)
        {
            Tile tile = row.tiles[i];
=======
        for(int i = 0; i < currentRow.tiles.Length; i++)
        {
            Tile tile = currentRow.tiles[i];
>>>>>>> Stashed changes

            // tile has correct letter
            if(tile.tileChar == word[i])
            {
                // Set tile on gameboard to correct state
                tile.SetState(correctTileState);

                // modify and remove the correct letter from the solution word
                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");

                // Set letter on lower keyboard to correct state
                LetterToState(tile.tileChar, correctLetterState);
            }            
            // solution word does not contain tile's letter at all
            else if(!word.Contains(tile.tileChar))
            {
                tile.SetState(incorrectTileState);
                LetterToState(tile.tileChar, incorrectLetterState);
            }
        }

        // check for tiles that are neither fully correct or fully incorrect
        // (wrong spot tiles) or (guess with one correct letter and other wrong identical letters)
<<<<<<< Updated upstream
        for (int i = 0; i < row.tiles.Length; i++)
=======
        for (int i = 0; i < currentRow.tiles.Length; i++)
>>>>>>> Stashed changes
        {
            Tile tile = row.tiles[i];

            if (tile.state != correctTileState && tile.state != incorrectTileState)
            {
                // if remaining has the character but it is wrong spot
                if (remaining.Contains(tile.tileChar))
                {
                    tile.SetState(wrongSpotTileState);

                    // find correct index of letter and replace with space in remaining
                    int index = remaining.IndexOf(tile.tileChar);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");

                    LetterToState(tile.tileChar, wrongSpotLetterState);
                }
                // if remaining does not have the character anymore
                else
                {
                    tile.SetState(incorrectTileState);
                }
            }
        }

<<<<<<< Updated upstream
        if (HasWon(row))
=======
        if (HasWon(currentRow))
>>>>>>> Stashed changes
        {
            enabled = false;
        }

        rowIndex++;
        columnIndex = 0;

        // exhausted all guesses and failed
        if (rowIndex >= rows.Length)
            enabled = false;
    }

    private bool IsValidWord(string guess)
    {
        for (int i = 0; i < validWords.Length; i++)
        {
<<<<<<< Updated upstream
            if (validWords[i] == guess)
=======
            if (guess == validWords[i])
>>>>>>> Stashed changes
            {
                return true;
            }
        }
        return false;
    }

    private bool HasWon(Row row)
    {
        for (int i = 0; i < row.tiles.Length; i++)
        {
            if (row.tiles[i].state != correctTileState) 
            { 
                return false;
            }
        }
        return true;
    }

    public void NewGame()
    {
        ClearBoard();
        SetRandomWord();
        enabled = true;
    }

    private void ClearBoard()
    {
        for (int row = 0; row < rows.Length; row++)
        {
            for(int tile = 0; tile < rows[row].tiles.Length; tile++)
            {
                rows[row].tiles[tile].SetLetter('\0');
                rows[row].tiles[tile].SetState(emptyTileState);
            }
        }
<<<<<<< Updated upstream
=======
        foreach (CS_Letters letter in letters)
        {
            letter.SetState(emptyLetterState);
        }
>>>>>>> Stashed changes
        rowIndex = 0;
        columnIndex = 0;
    }

    // Sets a specific character on the lower keyboard to a specific state
    private void LetterToState(char targetChar, CS_Letters.LetterState targetLetterState)
    {
        foreach (CS_Letters letter in letters)
        {
<<<<<<< Updated upstream
            Debug.Log(letter.letter + " - " + targetChar);
=======
>>>>>>> Stashed changes
            if (letter.letter == targetChar)
            {
                letter.SetState(targetLetterState);
                Debug.Log("found: " + letter.letter);
                break;
            }
        }
    }

    private void OnEnable()
    {
<<<<<<< Updated upstream
        newGameButton.SetActive(false);
=======
        
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
<<<<<<< Updated upstream
        newGameButton.SetActive(true);
=======
        
>>>>>>> Stashed changes
    }
}
