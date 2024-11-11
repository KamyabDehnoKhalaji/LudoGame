using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public Text diceText;
    public PlayerMovement player;

    public void RollDice()
    {
        int diceResult = Random.Range(1, 7);
        if (diceText != null)
        {
            diceText.text = "Dice: " + diceResult;
        }
        player.MoveToken(diceResult);
    }
}



















