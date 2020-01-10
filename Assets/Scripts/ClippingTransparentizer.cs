using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ClippingTransparentizer : MonoBehaviour
{
    private IEnumerable<Renderer> disabledRenderers = Array.Empty<Renderer>();

    // Update is called once per frame
    void Update()
    {
        var camera = this.GetComponentInChildren<Camera>();
        if (camera == null)
        {
            return;
        }

        var vectorToParent = this.transform.position - camera.transform.position;
        var rayHitsBetweenCameraAndParent = Physics.RaycastAll(camera.transform.position, vectorToParent, vectorToParent.magnitude);
        var renderersToDisable = new List<Renderer>();
        foreach (var hit in rayHitsBetweenCameraAndParent)
        {
            if (hit.collider.transform.IsChildOf(this.transform))
            {
                // Same game object - do not transparentize
            }
            else
            {
                var renderers = hit.collider.GetComponents<Renderer>();
                renderersToDisable.AddRange(renderers);
            }
        }

        foreach (var renderer in this.disabledRenderers.Except(renderersToDisable))
        {
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }

        foreach(var renderer in renderersToDisable)
        {
            renderer.enabled = false;
        }

        this.disabledRenderers = renderersToDisable;
    }
}
