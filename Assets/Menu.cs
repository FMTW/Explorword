using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioSource aSource;

    public void Wrapper(int level)
    {
        StartCoroutine("Level", level);
    }

    IEnumerator Level(int level)
    {
        aSource.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
