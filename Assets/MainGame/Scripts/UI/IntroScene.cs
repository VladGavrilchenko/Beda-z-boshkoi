using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScene : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        double coundTime = FindAnyObjectByType<VideoPlayer>().clip.length;
        StartCoroutine(StartNextScene((float)coundTime));
    }


    private IEnumerator StartNextScene(float coundTime)
    {
        yield return new WaitForSeconds(coundTime);
        SceneManager.LoadScene(1);
    }
}
