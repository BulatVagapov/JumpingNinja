using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoseNinjaButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private int ninjaindex;
    [SerializeField] private int ninjaPrice;
    [SerializeField] private GameObject chosenText;
    [SerializeField] private GameObject priceBlock;
    [SerializeField] private TMP_Text priceText;
    public int Ninjaindex => ninjaindex;
    public int NinjaPrice => ninjaPrice;
    public Button Button => button;

    private static ChoseNinjaButton currentButton;

    public void InitButton()
    {
        if (NinjaManager.Instance.OpenedNinjas.OpenedNinjas[ninjaindex])
        {
            priceBlock.SetActive(false);
        }

        if (currentButton == null && NinjaManager.Instance.OpenedNinjas.ChosenNinjaIndex == ninjaindex)
        {
            currentButton = this;

            currentButton.ChoseNinja();
        }

        priceText.text = ninjaPrice.ToString();

        button = GetComponent<Button>();
        button.onClick.AddListener(() => BuyNinja());
    }

    public void ChangeCurrentButton()
    {
        if (currentButton != null) currentButton.UnChoseNinja();

        currentButton = this;
        currentButton.ChoseNinja();
    }

    public void UnChoseNinja()
    {
        chosenText.SetActive(false);
    }

    public void ChoseNinja()
    {
        chosenText.SetActive(true);
    }

    private void BuyNinja()
    {
        NinjaManager.Instance.ChoseNewNinja(ninjaindex);
        priceBlock.SetActive(false);
        NinjaManager.Instance.OpenedNinjas.OpenedNinjas[ninjaindex] = true;
        NinjaManager.Instance.OpenedNinjas.ChosenNinjaIndex = ninjaindex;
        ChangeCurrentButton();
        NinjaManager.Instance.SaveOpenedNinjas();
    }
}
