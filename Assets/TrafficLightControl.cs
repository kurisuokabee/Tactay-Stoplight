using System.Collections;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    [SerializeField] GameObject[] lightObjs; 

    float[] delays = { 5f, 2f, 5f }; // Delay pattern
    
    void Start()
    {
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            for (int i = 0; i < lightObjs.Length; i++)
            {
                GameObject obj = lightObjs[i]; //init a gameobject based on the gameobject array
                Renderer renderer = obj.GetComponent<Renderer>(); //get the renderer from that gameobject
                TextCountdown text = obj.GetComponentInChildren<TextCountdown>();

                if (renderer != null)
                {
                    Material mat = renderer.material; //init the material from the renderer material

                    // Turn ON emission from the material
                    mat.EnableKeyword("_EMISSION");
                    text.countdownTime = delays[i];
                    text.countdown = true;

                    // Wait for the delay
                    yield return new WaitForSeconds(delays[i]);

                    // Turn OFF emission from the material
                    mat.DisableKeyword("_EMISSION");
                    text.countdown = false;
                    text.countdownText.text = delays[i].ToString();
                }
            }
        }
    }
}
