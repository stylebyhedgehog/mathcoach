using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpUI : MonoBehaviour
{
    [SerializeField] private InputField usernameField;
    [SerializeField] private InputField passwordField;
    [SerializeField] private InputField passwordConfField;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button signUpBtn;
    [SerializeField] private Text warning;

    void Start()
    {
        warning.gameObject.SetActive(false);
        InitActions();
        SessionStorage.singedInAction += SignedInAction;
    }

    // Update is called once per frame
    private void InitActions()
    {
        backBtn.onClick.AddListener(() => Back());
        signUpBtn.onClick.AddListener(() => SingUp());
    }
    private void Back()
    {
        warning.text = "";
        gameObject.SetActive(false);
    }
    private void SingUp()
    {
        string passwordConfirm = passwordConfField.text;
        UserData userData = new UserData(usernameField.text, passwordField.text);
        UserRepository.Instance.TryToSignUp(userData, passwordConfirm, OnSignUpCallback);
    }

    private void SignedInAction()
    {
        gameObject.SetActive(false);
    }
    private void OnSignUpCallback (int en)
    {
        warning.gameObject.SetActive(true);
        if (en == 0)
        {
            warning.text = "Пароли не совпадают";
        } else if (en == 1)
        {
            warning.text = "Пользователь с таким логином уже существуюет";
        } else if (en == 2)
        {
            warning.text = "Вы успешно зарегистрировались";
        }
        
    }
}
