using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
	private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = gameObject.GetComponentInParent<DialogueTrigger>();
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
	{
		if(dialogueTrigger.isUnlocked)
			meshRenderer.enabled = true;
		else
			meshRenderer.enabled = false;
	}
}
