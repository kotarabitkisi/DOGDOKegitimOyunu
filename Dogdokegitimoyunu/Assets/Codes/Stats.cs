using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public LampStats[] Lights;
    public GameObject[] Lazers;
    public bool allOfLightsAreGreen;
    public Camera cam;
    public GameObject LosePanel, WinPanel;
    public float score, reqScore;
    public Text scoreTxt;
    private void Start()
    {
        scoreTxt.text = "Score: " + score + "/" + reqScore;
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Button"))
                {
                    BtnLight BtnScr = hit.collider.gameObject.GetComponent<BtnLight>();
                    for (int i = 0; i < BtnScr.lights.Length; i++)
                    {
                        GameObject Light = BtnScr.lights[i];
                        Light.GetComponent<LampStats>().isGreen = !Light.GetComponent<LampStats>().isGreen;
                        if (Light.GetComponent<LampStats>().isGreen)
                        {
                            Light.GetComponent<MeshRenderer>().material.color = Color.green;
                        }
                        else { Light.GetComponent<MeshRenderer>().material.color = Color.red; }
                    }
                }
            }
        }
        #region ýþýklarýn hepsinin yeþil olduðunu kontrol etme
        allOfLightsAreGreen = true;
        for (int i = 0; i < Lights.Length; i++)
        {
            if (!Lights[i].isGreen) { allOfLightsAreGreen = false; break; }
        }
        if (allOfLightsAreGreen)
        {
            for (int i = 0; i < Lazers.Length; i++)
            {
                Lazers[i].SetActive(false);
            }
        }
        #endregion
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            score++;
            scoreTxt.text = "Score: " + score + "/" + reqScore;
        }
        else if (other.gameObject.CompareTag("Finish") && score >= reqScore)
        {
            Win();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Lose();
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
    public void Win()
    {
        gameObject.GetComponent<Movement>().canmove = false;
        WinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
