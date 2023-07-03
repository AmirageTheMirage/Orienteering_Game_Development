//using UnityEditor;
//using UnityEngine;

//public class AlignScript : EditorWindow
//{
//    [MenuItem("Window/Align Scene View Camera with Selected GameObject Rotation")]
//    private static void AlignCameraWithRotation()
//    {
//        GameObject selectedObject = Selection.activeGameObject;
//        if (selectedObject != null)
//        {
//            SceneView sceneView = SceneView.lastActiveSceneView;
//            if (sceneView != null)
//            {
//                Quaternion desiredRotation = selectedObject.transform.rotation;
//                sceneView.rotation = desiredRotation;
//            }
//        }
//    }
//}
