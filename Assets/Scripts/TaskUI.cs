using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Text theory;

    [SerializeField] private Text taskNumber;
    [SerializeField] private Text taskStatemnet;
    [SerializeField] private InputField taskSolutionInput;
    [SerializeField] private Button checkAnswerButton;
    [SerializeField] private Text alert;


    [SerializeField] private Button previousTaskBtn;
    [SerializeField] private Button backToListBtn;
    [SerializeField] private Button nextTaskBtn;
    private Block block;
    private Task task;
    private int currentNumber = 1;

    private void Start()
    {
        checkAnswerButton.onClick.AddListener(() => checkAnswer());
        backToListBtn.onClick.AddListener(() => backToList());
        nextTaskBtn.onClick.AddListener(() => nextTask());
        previousTaskBtn.onClick.AddListener(() => previousTask());
    }
    public void InitTaskUI(Block blockInp)
    {
        block = blockInp;
        nextTaskBtn.gameObject.SetActive(true);
        setData();

    }
    //ADD CONTROLS (GO TO NEXT TASK)
    private void setData()
    {
        theory.text = block.Theory;
        taskNumber.text = block.Tasks["task" + currentNumber.ToString()].number.ToString();
        taskStatemnet.text = block.Tasks["task" + currentNumber.ToString()].statement;
        alert.gameObject.SetActive(false);
        taskSolutionInput.text = "";
        initControls();
    }

    private void checkAnswer()
    {
        alert.gameObject.SetActive(true);
        if (taskSolutionInput.text == block.Tasks["task"+currentNumber.ToString()].solution)
        {
            alert.text = "Верно";
        
            
        }
        else
        {
            alert.text = "Неверно";
        }
    }
    private void nextTask()
    {
        currentNumber += 1;
        setData();
    }

    private void previousTask()
    {
        currentNumber -= 1;
        setData();
    }

    private void initControls()
    {
        if (1 == currentNumber)
        {
            previousTaskBtn.gameObject.SetActive(false);
        }
        else
        {
            previousTaskBtn.gameObject.SetActive(true);
        }

        if (block.Tasks.Count  == currentNumber)
        {
            nextTaskBtn.gameObject.SetActive(false);
        }
        else
        {
            nextTaskBtn.gameObject.SetActive(true);
        }
    }
    private void backToList()
    {
        currentNumber = 1;
        gameObject.SetActive(false);
    }
}
