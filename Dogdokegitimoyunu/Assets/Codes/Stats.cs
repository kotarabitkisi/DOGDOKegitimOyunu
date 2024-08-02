using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject LosePanel;
    public float score,reqScore;
    public Text scoreTxt;
    private void Start()
    {
        scoreTxt.text = "Score: " + score + "/" + reqScore;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            score++;
            scoreTxt.text = "Score: " + score + "/" + reqScore;
        }
        else if (other.gameObject.CompareTag("Finish")&&score>=reqScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    public void Lose()
    {
        gameObject.GetComponent<Movement>().canmove = false;
        LosePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
