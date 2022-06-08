using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RestartButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MeshRenderer restartButton;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material baseMaterial;


    public UnityEvent onClicked;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        onClicked?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        restartButton.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        restartButton.material = baseMaterial;
    }
}
