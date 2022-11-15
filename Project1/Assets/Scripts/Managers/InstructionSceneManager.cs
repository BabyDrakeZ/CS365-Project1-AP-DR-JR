using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSceneManager : MonoBehaviour
{
    public AudioSource menuAdvance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeScene();
            if (!menuAdvance.isPlaying)
                menuAdvance.PlayOneShot(menuAdvance.clip, 0.25f);
        }
    }

    void ChangeScene()//DR
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
