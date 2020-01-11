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
                foreach (var material in renderer.materials)
                {
                    material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
                }
                //renderer.enabled = true;
            }
        }

        foreach(var renderer in renderersToDisable)
        {
            foreach (var material in renderer.materials)
            {
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
            }
            //renderer.enabled = false;
        }

        this.disabledRenderers = renderersToDisable;
    }
}
