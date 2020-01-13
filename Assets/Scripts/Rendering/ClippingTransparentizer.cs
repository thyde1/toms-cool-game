using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ClippingTransparentizer : MonoBehaviour
{
    private IEnumerable<Transparentizable> transparentizedObjects = Array.Empty<Transparentizable>();

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
        var gameObjectsToTransparentize = new List<Transparentizable>();
        foreach (var hit in rayHitsBetweenCameraAndParent)
        {
            if (hit.collider.gameObject.TryGetComponent<Transparentizable>(out var transparentizable))
            {
                gameObjectsToTransparentize.Add(transparentizable);
            }
        }

        foreach (var transparentizedObject in this.transparentizedObjects.Except(gameObjectsToTransparentize))
        {
            if (transparentizedObject != null)
            {
                transparentizedObject.Untransparentize();
            }
        }

        foreach(var objectToTransparentize in gameObjectsToTransparentize)
        {
            objectToTransparentize.Transparentize();
        }

        this.transparentizedObjects = gameObjectsToTransparentize;
    }
}
