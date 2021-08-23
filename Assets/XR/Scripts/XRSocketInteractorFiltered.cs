using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorFiltered : XRSocketInteractor
{
    public string filterTag = string.Empty;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && CompareTags(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && CompareTags(interactable);
    }

    private bool CompareTags(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(filterTag);
    }
}
