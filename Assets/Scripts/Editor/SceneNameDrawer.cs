using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneNameAttribute))]
public class SceneNameDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string[] nameList = (attribute as SceneNameAttribute).NameList;
        if (property.propertyType == SerializedPropertyType.String)
        {
            int num = Mathf.Max(0, Array.IndexOf<string>(nameList, property.stringValue));
            num = EditorGUI.Popup(position, property.displayName, num, nameList);
            property.stringValue = nameList[num];
            return;
        }
        if (property.propertyType == SerializedPropertyType.Integer)
        {
            property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, nameList);
            return;
        }
        base.OnGUI(position, property, label);
    }
}