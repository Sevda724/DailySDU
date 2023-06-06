using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverTab : MonoBehaviour
{
    //public Button retryBtn;
    //[SerializeField] private InputField _inputField;
    //[SerializeField] private Button _button;
    //[SerializeField] private Text _resultText;
    // Start is called before the first frame update
    void Start()
    {
       // Button btn = retryBtn.GetComponent<Button>();
        //btn.onClick.AddListener(restartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToGames()
    {
        SceneManager.LoadScene("Games");
    }
    public void restartGame()
    {   

        //PlayerPrefs.SetString("BasketName", _inputField.text);
        //Debug.Log(PlayerPrefs.GetString("BasketName"));
        //Debug.Log(_inputField.text);
        //Time.timeScale = 1;
        //Time.timeScale = 1;
        SceneManager.LoadScene("Basketball");
    }
}
