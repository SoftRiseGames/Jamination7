using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChangeTimer : MonoBehaviour
{
    public float startingTime = 60f; // Baþlangýç zamaný (saniye cinsinden)
    private float currentTime;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
        UpdateCountdownText();
    }

    void Update()
    {
        // Zamanlayýcýyý her çerçeve güncelle
        currentTime -= Time.deltaTime;

        // Eðer zaman sýfýra veya altýna düþtüyse, sahneyi deðiþtir
        if (currentTime <= 0)
        {
            ChangeScene();
        }

        // Zamaný her güncellediðimizde metni güncelle
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        // TextMeshProUGUI'yi güncelle
        countdownText.text = currentTime.ToString("F0"); // F0 formatý tam sayý olarak gösterir
    }

    void ChangeScene()
    {
        // Sahneyi deðiþtirmek istediðiniz kod buraya gelecek
        // Örneðin, sahne adýný kullanarak yükleme yapabilirsiniz:
        // SceneManager.LoadScene("HedefSahneAdý");

        // Örneðin, bir sonraki sahneyi yüklemek için:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Bu örnekte sadece bir sonraki sahneyi yükleyeceðim varsayalým:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
