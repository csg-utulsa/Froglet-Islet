using UnityEngine.UI;

public class FinishScreen : Form
{
    public Text titleText;
    public Text Credits;
    public Button restartButton;
    public Image deathEffect;
   
    void Awake()
    {
        restartButton.onClick.AddListener(OnRestartClick);
    }

    public override void Show()
    {
        base.Show();
        /*
        titleText.text = PlayerController.Instance.Health > 0 ? "YOU WIN!" : "YOU ARE DEAD!";
        Credits.text = "Credits";
        deathEffect.gameObject.SetActive(PlayerController.Instance.Health <= 0);
        */
    }

    private void OnRestartClick()
    {
        GameController.Instance.RestartGame();
    }
}