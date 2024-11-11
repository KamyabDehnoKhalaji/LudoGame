using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text coinText;
    public Transform[] path;
    private int coins = 0;
    private int currentPosition = 0;
    private float speed = 1f;

    void Start()
    {
        UpdateCoinText();
    }

    public void MoveToken(int steps)
    {
        StartCoroutine(MoveAlongPath(steps));
    }

    private IEnumerator MoveAlongPath(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            // چک می‌کنیم که آیا به انتهای مسیر رسیده‌ایم
            if (currentPosition >= path.Length - 1)
            {
                currentPosition = 0; // بازنشانی به خانه اول
            }
            else
            {
                currentPosition++; // حرکت به خانه بعدی
            }

            Vector3 startPos = transform.position;
            Vector3 endPos = path[currentPosition].position;
            float travelPercent = 0;

            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return null;
            }

            coins += 10;
            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}




















