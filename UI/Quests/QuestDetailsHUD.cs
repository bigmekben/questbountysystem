using UnityEngine;
using UnityEngine.UI;

public class QuestDetailsHUD : MonoBehaviour, ICreditObserver
{
    [SerializeField, SerializeReference]
    public ProgressionTracker progressionTracker;
    public Text text;
    public Image doneIcon;
    public Image marquee;

    private void Awake()
    {
        progressionTracker.Subscribe(this);
        text.text = progressionTracker.DetailsToDisplay();
    }

    public void Credit()
    {
        progressionTracker.Credit();
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = progressionTracker.DetailsToDisplay();
        doneIcon.gameObject.SetActive(progressionTracker.IsDone());
        marquee.gameObject.SetActive(progressionTracker.IsDone());
    }
}