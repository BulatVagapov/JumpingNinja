using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private float loadingDuration;
    [SerializeField] private GameObject mainMenu;
    
    void Start()
    {
        loading();
    }

    private  void loading()
    {
        Sequence firstSequence = DOTween.Sequence();

        firstSequence.onComplete += LoadingIsComlete;

        firstSequence.Append(DOVirtual.Float(0.2f, 1, loadingDuration, v => loadingSlider.value = v));
    }

    private void LoadingIsComlete()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
