using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.VersionControl;

//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.Windows;


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
    private Row currentRow;

    private string[] validWords;
    private string[] solutionWords;

    [Header("Config")] 
    [SerializeField] private float delayTime =1.5f; // For debugging purposes
    [SerializeField] private string word;

    public int row_count;
    public int word_size;

    private int rowIndex;
    private int columnIndex;

    [SerializeField]
    private TextMeshProUGUI solutionWordText;

    [Header("Prefabs")]
    public GameObject tilePrefab;

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

    [Header("Timer")]
    public bool timerMode = false;
    public CS_Timer CS_Timer;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private int score;
    [SerializeField]
    private int correctLetterScore;
    [SerializeField]
    private int wrongSpotLetterScore;
    // Keeps track of which letter has already been scored
    private string scoreString;

    [Header("Achievements")]
    public CS_Achievement CS_Achievement;
    private int correctLettersGuessedInGuess; // for achievement

    [Header("Sound Effects")]
    public AudioSource audioSource;
    public AudioClip[] typeSFX;
    public float typePitch;
    public float submitPitch;
    public float backspacePitch;
    public AudioSource correctGuessSFX;
    public AudioSource invalidWordSFX;

    [Header("Particle Effects")]
    public GameObject correctGuessPrefab;

    // Setup and start game
    private void Start()
    {
        //add try block to load game mode feature --cehinds 20 Nov 24
        try
        {   
            //loadGameMode data --cehinds 10 Nov 24
            loadGameMode();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load game mode data: "+ e.Message);
            Debug.Log("Restoring game mode to default configuration");
        }
        ///

        //build dynamic gameboard
        GameObject rowPrefab = GetComponentInChildren<Row>().gameObject;

        for (int i = 0; i < word_size - 1; i++)
        {
            Instantiate(tilePrefab, parent: rowPrefab.transform);
        }

        for (int i = 0; i < row_count - 1; i++)
        {
            Instantiate(rowPrefab, parent: gameObject.transform);
        }

        rows = GetComponentsInChildren<Row>();

        //Tell rows they may initialize their tile size
        foreach (Row row in rows)
        {
            row.InitializeTiles();
        }
        
        letters = GameObject.Find("Letters").GetComponentsInChildren<CS_Letters>();
        LoadData();
        SetRandomWord();
        solutionWordText.gameObject.SetActive(false);
        CS_Timer.StartTimer();
        score = 0;
        scoreText.text = ("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        currentRow = rows[rowIndex];

        // check for backspace input
        if (UnityEngine.Input.GetKeyDown(KeyCode.Backspace))
        {
            BackspaceChar();
        }
        // check for enter key input
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
        {
            SubmitRow();
        }
        // check for character input
        else if (columnIndex < word_size)
        {
            for (int i = 0; i < VALID_INPUTS.Length; i++)
            {
                var input = VALID_INPUTS[i];
                if (UnityEngine.Input.GetKeyDown(input))
                {
                    // Kinda hacky way to convert type KeyCode -> Char -> String.
                    // InputChar() Needs to recieve a string parameter in order
                    // for unity to call this event with a parameter from a button
                    InputChar(((char)input).ToString());
                    break;
                }
            }
        }
    }

    public void InputChar(string input)
    {
        //added try catch exception blocks for outof index errors //-cehinds 24 Nov 24
        try
        {// Receive the first character of input as a char
            if (columnIndex < word_size)
            {
                Debug.Log(message: "Current word size is: "+word_size+". Current column index is: " + columnIndex); //debug statement to track column index
                currentRow.tiles[columnIndex].SetLetter(input.ToLower()[0]);
                columnIndex++;
            }
        }
        catch(Exception e)
        {
            Debug.LogError(message: e +": Out of index Exception: current column index is "+columnIndex+". Max word size is "+ word_size, context: this);
            

        }

        // Type Sound effect
        audioSource.clip = typeSFX[UnityEngine.Random.Range(0, typeSFX.Length)];
        audioSource.pitch = typePitch;
        audioSource.Play();
    }
    
    public void BackspaceChar()
    {
        columnIndex = Mathf.Max(columnIndex - 1, 0);
        currentRow.tiles[columnIndex].SetLetter('\0');
        currentRow.tiles[columnIndex].SetState(emptyTileState);
        invalidWordText.SetActive(false);

        // Type Sound effect
        audioSource.clip = typeSFX[UnityEngine.Random.Range(0, typeSFX.Length)];
        audioSource.pitch = backspacePitch;
        audioSource.Play();
    }

    private void LoadData()
    {
        TextAsset solutionFile = null;
        TextAsset validFile = null;

        switch (word_size)
        {
            case 3:
                solutionFile = Resources.Load("3_solution_list") as TextAsset;
                validFile = Resources.Load("3_valid_list") as TextAsset;
                break;
            case 4:
                solutionFile = Resources.Load("4_solution_list") as TextAsset;
                validFile = Resources.Load("4_valid_list") as TextAsset;
                break;
            case 5:
                solutionFile = Resources.Load("official_wordle_common") as TextAsset;
                validFile = Resources.Load("official_wordle_all") as TextAsset;
                break;
            case 6:
                solutionFile = Resources.Load("6_solution_list") as TextAsset;
                validFile = Resources.Load("6_valid_list") as TextAsset;
                break;
            case 7:
                solutionFile = Resources.Load("7_solution_list") as TextAsset;
                validFile = Resources.Load("7_valid_list") as TextAsset;
                break;
        }
        validWords = validFile.text.Split('\n');
        solutionWords = solutionFile.text.Split('\n');

        // remove space character at end of words
        for (int i = 0; i < validWords.Length; i++)
            validWords[i] = validWords[i].Trim().ToLower();

        for (int i = 0; i < solutionWords.Length; i++)
            solutionWords[i] = solutionWords[i].Trim().ToLower();
    }

    private void SetRandomWord()
    {
        word = solutionWords[UnityEngine.Random.Range(0, solutionWords.Length)];
        word = word.ToLower().Trim();
        scoreString = word;
    }

    public void SubmitRow()
    {
        // If row isn't full, then return
        if (columnIndex < word_size)
        {
            return;
        }

        // If word isn't valid, then don't bother checking or submitting
        if (!IsValidWord(currentRow.word))
        {
            invalidWordText.transform.position = new Vector2(invalidWordText.transform.position.x, currentRow.transform.position.y);
            invalidWordText.SetActive(true);
            invalidWordSFX.Play();
            return;
        }

        // Type Sound effect
        audioSource.clip = typeSFX[UnityEngine.Random.Range(0, typeSFX.Length)];
        audioSource.pitch = submitPitch;
        audioSource.Play();

        // Solution word that gets modified as letters are guessed in order to avoid duplicates
        string remaining = word;

        for(int i = 0; i < currentRow.tiles.Length; i++)
        {
            Tile tile = currentRow.tiles[i];

            // tile has correct letter
            if(tile.tileChar == word[i])
            {
                // Is this the first time this column has been guessed correctly
                if (FirstTimeCorrectGuess(i))
                {
                    // For three birds achievement
                    correctLettersGuessedInGuess++;

                    correctGuessSFX.Play();

                    ParticleSystem correctGuessFX = Instantiate(correctGuessPrefab).GetComponent<ParticleSystem>();
                    correctGuessFX.gameObject.transform.position = tile.transform.position;
                    correctGuessFX.Play();
                    
                }

                // Set tile on gameboard to correct state
                tile.SetState(correctTileState);

                // modify and remove the correct letter from the solution word
                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");

                // Set letter on lower keyboard to correct state
                LetterToState(tile.tileChar, correctLetterState);

                // Add score
                if (scoreString[i] != ' ')
                {
                    scoreString = scoreString.Remove(i, 1);
                    scoreString = scoreString.Insert(i, " ");
                    score += correctLetterScore;
                    scoreText.text = ("Score: " + score);
                }
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
        for (int i = 0; i < currentRow.tiles.Length; i++)
        {
            Tile tile = currentRow.tiles[i];

            //If tile is not correct or incorrect
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

                    // Add score
                    score += wrongSpotLetterScore;
                    scoreText.text = ("Score: " + score);
                }
                // if remaining does not have the character anymore
                else
                {
                    tile.SetState(incorrectTileState);
                }
            }
        }

        if(correctLettersGuessedInGuess >= 3)
        {
            CS_Achievement.UnlockAchievement("Three Birds One Stone");
            CS_SaveSystem.saveGameData(this);
        }
        correctLettersGuessedInGuess = 0;

        // check if guess matches answer
        if (HasWon(currentRow))
        {
            score += score * (row_count - rowIndex);
            scoreText.text = ("Score: " + score);
            achievementCheck();
            if (CS_Timer.infiniteMode)
            {
                CS_SaveSystem.saveGameData(this);
                Invoke("ResetGameBoard",delayTime);
                return;
            }
            else
            {
                CS_SaveSystem.saveGameData(this);
                GameOver();
            }
        }

        rowIndex++;
        columnIndex = 0;

        // exhausted all guesses and failed
        if (rowIndex >= rows.Length)
            GameOver();
    }

    private bool IsValidWord(string guess)
    {
        for (int i = 0; i < validWords.Length; i++)
        {
            if (guess == validWords[i])
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
    
    public void GameOver()
    {
        // grey out remaining tiles on win
        for (int row = rowIndex + 1; row < rows.Length; row++)
        {
            for (int tile = 0; tile < rows[row].tiles.Length; tile++)
            {
                rows[row].tiles[tile].SetState(incorrectTileState);
            }
        }
        CS_Timer.StopTimer();
        scoreText.text = ("Score: " + score);
        solutionWordText.gameObject.SetActive(true);
        solutionWordText.text = "Solution: " + word;
        enabled = false;
        
        //added save game data
        CS_SaveSystem.saveGameData(this);
    }

    public void NewGame()
    {
        ClearBoard();
        SetRandomWord();
        CS_Timer.ResetTimer();
        CS_Timer.StartTimer();
        score = 0;
        scoreText.text = ("Score: " + score);
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
        foreach (CS_Letters letter in letters)
        {
            letter.SetState(emptyLetterState);
        }
        rowIndex = 0;
        columnIndex = 0;
        solutionWordText.gameObject.SetActive(false);
        invalidWordText.SetActive(false);
    }

    // Sets a specific character on the lower keyboard to a specific state
    private void LetterToState(char targetChar, CS_Letters.LetterState targetLetterState)
    {
        foreach (CS_Letters letter in letters)
        {
            if (letter.letter == targetChar)
            {
                letter.SetState(targetLetterState);
                break;
            }
        }
    }

    //converted the gameboard reset to a separate function so that I can add a delay with the "invoke" keyword--cehinds 27 Nov 24
    private void ResetGameBoard()
    {
        CS_Timer.AddTime(CS_Timer.correctGuessTimeReward);
        ClearBoard(); //added delay in infinite mode for correct words--cehinds 27 Nov 24
        SetRandomWord();

    }

    //added function to load game mode config. This sets the wordlength, the number of attempts, and changes CS_timer.inifiteMode and timerEnabled variables-cehinds 10 Nov 24
    public void loadGameMode()
    {
        Debug.Log("Initializing Gamemode...");
        cs_gameModeData mode = CS_SaveSystem.loadMode();
        word_size =mode.wordLength;
        Debug.Log("word size initialized to : "+word_size);
        row_count = mode.attempts;
        Debug.Log("row count initialized to : "+row_count);
        CS_Timer.infiniteMode = mode.infinite;
        Debug.Log("infinite mode: "+CS_Timer.infiniteMode);
        CS_Timer.timerEnabled = mode.timer;
        Debug.Log("timer mode: "+CS_Timer.timerEnabled);
        Debug.Log("Gamemode initialization complete.");


    }

    //returns game score --cehinds 20 Nov 24
    public int getGameScore()
    {
        return score;
    }

    private void achievementCheck()
    {
        float time = CS_Timer.timer;
        int timeLimit = CS_Timer.timeLimit;
        bool timedMode = CS_Timer.timerEnabled;

        // Speed Demon
        if (time <= 30)
            CS_Achievement.UnlockAchievement("Speed Demon");

        // Clutch
        if (timedMode && time >= timeLimit - 10)
            CS_Achievement.UnlockAchievement("Clutch");

        // One More Try
        if (rowIndex == row_count - 1)
            CS_Achievement.UnlockAchievement("One More Try");
    }

    private bool FirstTimeCorrectGuess(int columnIndex)
    {
        for (int j = 0; j < rowIndex + 1; j++)
        {
            if (rows[j].tiles[columnIndex].state == correctTileState)
            {
                return false;
            }
        }
        return true;
    }


}
