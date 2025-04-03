using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 
// Dear maintainer:
// 
// Once you are done trying to 'optimize' this routine,
// and have realized what a terrible mistake that was,
// please increment the following counter as a warning
// to the next guy:
// 
// total_hours_wasted_here = 42
// 
public class IconGenerator : MonoBehaviour
{
    // Public variables accessible from the Unity editor
    public Camera cam_camera; // Reference to the camera component
    public GameObject sceneObject; //gameObject that is going to be processed
    public string nameIcon; // Base name for the icon files
    public string imageFolder; // Folder path where the icons will be saved
   
    private void Awake() // Awake is called when the script instance is being loaded
    {
        cam_camera = GetComponent<Camera>(); // Get the Camera component attached to this GameObject
    }


    [ContextMenu("Screenshot")] // Context menu allows this function to be called from the Unity editor
    private void ProcessScreenshots()
    {
        StartCoroutine(Screenshot()); // Start the Screenshot coroutine
    }
   
    private IEnumerator Screenshot() // Coroutine to handle the screenshot process
    {
            GameObject screenshotObject = sceneObject; // Get the current object

            screenshotObject.SetActive(true); // Activate the object

            yield return null; // Wait for the end of the frame

            // Construct the full path for the screenshot file
            string fullPath = $"{Application.dataPath}/objectto2dtexture/{imageFolder}/{nameIcon}_Icon.png";
            TakeScreenshot(fullPath); // Take a screenshot and save it to the specified path

            yield return null; // Wait for the end of the frame

            screenshotObject.SetActive(false); // Deactivate the object

            // Load the saved screenshot as a Sprite
            Sprite iconSprite = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/objectto2dtexture/{imageFolder}/{nameIcon}_Icon.png");
            if (iconSprite != null)
            {
#if UNITY_EDITOR
                EditorUtility.SetDirty(sceneObject); // Mark the object as dirty to ensure changes are saved in the editor
#endif
            }
            yield return null; // Wait for the end of the frame
    }
 
    void TakeScreenshot(string fullPath)// Function to take a screenshot and save it to the specified path
    {
        if (cam_camera == null)
        {
            cam_camera = GetComponent<Camera>(); // Ensure the camera component is assigned

        }
        // Create a new RenderTexture with specified dimensions
        RenderTexture rendertext = new RenderTexture(256, 256, 24);
        cam_camera.targetTexture = rendertext; // Assign the RenderTexture to the camera
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false); // Create a new Texture2D for the screenshot
        cam_camera.Render(); // Render the camera's view
        RenderTexture.active = rendertext; // Activate the RenderTexture
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0); // Read the pixels from the RenderTexture
        cam_camera.targetTexture = null; // Reset the camera's target texture
        RenderTexture.active = null; // Deactivate the RenderTexture
        if (Application.isEditor)
        {
            DestroyImmediate(rendertext); // Immediately destroy the RenderTexture if running in the editor
        }
        else
        {
            Destroy(rendertext); // Destroy the RenderTexture if running in a build
        }
        // Encode the screenshot to PNG format and write it to the specified file path
        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);

#if UNITY_EDITOR
        AssetDatabase.Refresh(); // Refresh the asset database to recognize the new screenshot file
#endif
    }
}
