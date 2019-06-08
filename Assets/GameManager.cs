using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    RaycastHit hit;

    Transform cam;

    GameObject previousObject;
    public LayerMask item;

    int lives;
    int score;

    public string[] taskItem;
    int taskIndex;
    string selectedItem;

    //UI
    public Text scoreText;
    public Text taskText;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;



    void Start()
    {
        cam = Camera.main.transform;
        taskIndex = 0;
        lives = 3;
        score = 0;
        UIUpdate();
    }

    void Update()
    {

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 4f, item))
        {
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            if (hit.transform.gameObject != previousObject)
            {
                print("yip");
                if (previousObject != null)
                {
                    previousObject.GetComponent<Outline>().enabled = false;
                }

                previousObject = hit.transform.gameObject;
                hit.transform.GetComponent<Outline>().enabled = true;
            }


        }
        else
        {
            if (previousObject != null)
            {
                previousObject.GetComponent<Outline>().enabled = false;
                previousObject = null;
            }
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * 4f, Color.green);
        }

    }

    void UIUpdate()
    {
        if (lives == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (lives == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (lives == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            print("GAMEOVER");
        }

        scoreText.text = "" + score;
        taskText.text = "Find the \"" + taskItem[taskIndex] + "\"";
    }

    void Win()
    {

    }

    public void ItemCheck()
    {
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 4f, item))
        {
            selectedItem = hit.transform.gameObject.name;
            selectedItem = selectedItem.ToLower();

            if (selectedItem.Contains(taskItem[taskIndex]))
            {
                score++;
                taskIndex++;
                if (taskIndex < taskItem.Length)
                {
                    UIUpdate();
                }
                else
                {
                    Win();
                }
                print("correct");
            }
            else
            {
                lives--;
                if (score > o)
                {
                    score--;
                }
                UIUpdate();
                print("incorrect");
            }
            
        }
    }

    public void Refresh()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
