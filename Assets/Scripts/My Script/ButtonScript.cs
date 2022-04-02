using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject AboutUI;
    public GameObject CreditUI;

    void start()
    {
        AboutUI.SetActive(false);
    }

    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void about()
    {
        AboutUI.SetActive(true);
    }

    public void credit()
    {
        CreditUI.SetActive(true);
    }

    public void menu()
    {
        AboutUI.SetActive(false);
        CreditUI.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
