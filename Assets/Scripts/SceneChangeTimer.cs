using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChangeTimer : MonoBehaviour
{
    public float startingTime = 60f; // Ba�lang�� zaman� (saniye cinsinden)
    private float currentTime;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
        UpdateCountdownText();
    }

    void Update()
    {
        // Zamanlay�c�y� her �er�eve g�ncelle
        currentTime -= Time.deltaTime;

        // E�er zaman s�f�ra veya alt�na d��t�yse, sahneyi de�i�tir
        if (currentTime <= 0)
        {
            ChangeScene();
        }

        // Zaman� her g�ncelledi�imizde metni g�ncelle
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        // TextMeshProUGUI'yi g�ncelle
        countdownText.text = currentTime.ToString("F0"); // F0 format� tam say� olarak g�sterir
    }

    void ChangeScene()
    {
        // Sahneyi de�i�tirmek istedi�iniz kod buraya gelecek
        // �rne�in, sahne ad�n� kullanarak y�kleme yapabilirsiniz:
        // SceneManager.LoadScene("HedefSahneAd�");

        // �rne�in, bir sonraki sahneyi y�klemek i�in:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Bu �rnekte sadece bir sonraki sahneyi y�kleyece�im varsayal�m:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
