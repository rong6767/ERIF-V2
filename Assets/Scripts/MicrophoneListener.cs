using UnityEngine;

public class MicrophoneListener : MonoBehaviour
{
    private AudioClip microphoneInput;
    private bool microphoneInitialized;
    private int sampleWindow = 128;
    public float volume;

    void Start()
    {
        // Check if a microphone is present
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 1, 44100);
            microphoneInitialized = true;
        }
        else
        {
            Debug.LogError("Microphone not found.");
            microphoneInitialized = false;
        }
    }

    void Update()
    {
        if (microphoneInitialized)
        {
            volume = GetAverageVolume()*100;
            Debug.Log("Volume: " + volume);
        }
    }

    float GetAverageVolume()
    {
        float[] waveData = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (sampleWindow + 1); // null means the first microphone

        if (micPosition < 0)
        {
            return 0;
        }

        microphoneInput.GetData(waveData, micPosition);

        float levelMax = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        return Mathf.Sqrt(levelMax);
    }

    void OnDisable()
    {
        if (microphoneInitialized)
        {
            Microphone.End(Microphone.devices[0]);
        }
    }
}