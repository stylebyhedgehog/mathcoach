using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInUI : MonoBehaviour
{
    [SerializeField] private InputField usernameField; 
    [SerializeField] private InputField passwordField; 
    [SerializeField] private Button backBtn;
    [SerializeField] private Button logInBtn;
    [SerializeField] private Button signUpBtn;
    [SerializeField] private Text warning;

    [SerializeField] private GameObject singUpPanel;
  
    void Start()
    {
        warning.gameObject.SetActive(false);
        InitActions();
        SessionStorage.singedInAction += SignedInAction;
    }

    private void Back()
    {
        warning.text = "";
        gameObject.SetActive(false);
    }

    private void InitActions()
    {

        backBtn.onClick.AddListener(() => Back());
        logInBtn.onClick.AddListener(() => LogIn());
        signUpBtn.onClick.AddListener(() => singUpPanel.SetActive(true));
    }

    private void LogIn()
    {
        UserData userData = new UserData(usernameField.text, passwordField.text);
        UserRepository.Instance.TryToSignIn(userData, OnSignInCallback);
    }

    private void SignedInAction()
    {
        gameObject.SetActive(false);
    }
    private void OnSignInCallback(bool value)
    {
        if (!value)
        {
            usernameField.text = "";
            passwordField.text = "";
            warning.gameObject.SetActive(true);
            warning.text = "Неверные данные";
        }
    }
}

