using UnityEngine;
using UnityEngine.EventSystems;

public class ControlButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float direction;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        NinjaManager.Instance.ChosenNinja.MovementDirectionX = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        NinjaManager.Instance.ChosenNinja.MovementDirectionX = 0;
    }
}
