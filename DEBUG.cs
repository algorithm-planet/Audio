using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DEBUG_audio : MonoBehaviour
{
    [Range(0.1f, 0.5f)]
    public float a = 0.5f;
    [Range(1, 12)]
    public int index = 1;

    private void Update()
    {
        dt = 1f / AudioSettings.outputSampleRate;
        if (Input.GetKeyDown(KeyCode.Space))
            t = 0f;
    }

    float t = 0f,
          dt;
    private void OnAudioFilterRead(float[] data, int channels)
    {
        for(int i = 0; i < data.Length; i += 2)
        {
            t += dt;
            float f = 220f * Mathf.Pow(2, index / 12f);

            float damp = Mathf.Pow(64, -t),
                  wave = Mathf.Sin(2 * Mathf.PI * f * t);

            float h = a * damp * wave;
            //left
            data[i] = h;
            //right
            data[i + 1] = h;
        }
    }
}
