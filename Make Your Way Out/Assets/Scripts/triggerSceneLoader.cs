using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerSceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] private float waitToLoad;
    [Space(20)]
    [SerializeField] private AudioSource audio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeIn");

            if (audio != null)
            {
                audio.Play();
                Invoke("loadScene", waitToLoad);
            }
            else
            {
                loadScene();
            }
        }
    }
    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }



}
