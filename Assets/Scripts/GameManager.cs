using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isReady;
    public GameObject gameReset;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        isReady = true;
        StartCoroutine(GameSystem());
    }

    private IEnumerator GameSystem()
    {
        while (true)
        {
            yield return new WaitUntil(() => isReady);

            isReady = false;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));

            GameObject obj = ObjectPooler.SharedInstace.GetPooledObject();
            if (obj)
            {
                obj.SetActive(true);
            }
            else
            {
                gameReset.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

            yield return null;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
