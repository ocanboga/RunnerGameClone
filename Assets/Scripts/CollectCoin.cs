using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public int maxScore;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    public Animator PlayerAnim;
    public GameObject EndPanel;
    private void Start()
    {
        PlayerAnim = this.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddCoin();
        }
        else if(other.CompareTag("End"))
        {
            EndPanel.SetActive(true);
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            if(score >= maxScore)
            {
                PlayerAnim.SetBool("Win",true);
            }
            else PlayerAnim.SetBool("Lose", true);

        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
