using UnityEngine;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour
{
    public Text puzzleText;
    public InputField answerInput;
    public Text resultText;
    
    private int currentQuestion;
    private int correctAnswer;
    
    void Start()
    {
        GeneratePuzzle();
    }
    
    void GeneratePuzzle()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        int operation = Random.Range(0, 3);
        
        switch (operation)
        {
            case 0:
                puzzleText.text = num1 + " + " + num2;
                correctAnswer = num1 + num2;
                break;
            case 1:
                puzzleText.text = num1 + " - " + num2;
                correctAnswer = num1 - num2;
                break;
            case 2:
                puzzleText.text = num1 + " × " + num2;
                correctAnswer = num1 * num2;
                break;
        }
    }
    
    public void CheckAnswer()
    {
        int userAnswer;
        if (int.TryParse(answerInput.text, out userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                resultText.text = "Correct! +10 points";
                GameManager.Instance?.AddScore(10);
                AudioManager.Instance?.PlaySFX("PowerUp_Collect");
                GeneratePuzzle();
            }
            else
            {
                resultText.text = "Wrong! Try again";
            }
        }
    }
}
