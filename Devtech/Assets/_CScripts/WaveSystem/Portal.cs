using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IInteractable
{
    private string nextLevelName;
    public void Interact(int coins)
    {
        StartCoroutine(WaitForFade());
    }

    IEnumerator WaitForFade()
    {
        FindObjectOfType<Fade>().FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void SetNextLevelName(string s)
    {
        nextLevelName = s;
    }

}
