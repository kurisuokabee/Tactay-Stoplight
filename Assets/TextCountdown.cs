using TMPro;
using UnityEngine;

public class TextCountdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;     // Assign in Inspector
    public float countdownTime;
    public bool countdown;

    void Update()
    {
        if (countdown)
        {
            if (countdownTime > 0f)
            {
                countdownTime -= Time.deltaTime;
                countdownText.text = Mathf.CeilToInt(countdownTime).ToString();
            }
        }
        
    }
}
