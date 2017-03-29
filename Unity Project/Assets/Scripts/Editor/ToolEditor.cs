using System.Collections;
using UnityEngine;
using System;
using UnityEditor;

public class ToolEditor : EditorWindow {
    // Created Mar 24, 2017 by rillyths

    
    private enum EditorState
    {
        ABOUT,
        EDIT,
        ADD
    }

    EditorState state;
    const string DATABASE_PATH = @"Assets/Scripts/Database/Tooldb.asset";
    
    int _selectedItem;
    string _newToolName;
    Vector2 _scrollPosition;
    ToolDatabase _tools;
    Tool _newTool;

    [MenuItem("Database/Tool Database")]
    public static void Init()
    {
        ToolEditor window = GetWindow<ToolEditor>();
        window.titleContent.text = "Tools";
        window.Show();
    }

    void OnEnable()
    {
        if (_tools == null)
        {
            _tools = (ToolDatabase)AssetDatabase.LoadAssetAtPath(DATABASE_PATH, typeof(ToolDatabase));
            if (_tools == null) CreateDatabase();
        }
        state = EditorState.ABOUT;
    }

    void CreateDatabase()
    {
        _tools = CreateInstance<ToolDatabase>();
        AssetDatabase.CreateAsset(_tools, DATABASE_PATH);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

        ShowList();
        ShowEditView();

        EditorGUILayout.EndHorizontal();
    }

    void ShowList()
    {
        EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));
        EditorGUILayout.Space();

        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, "Box", GUILayout.ExpandHeight(true));
        for(int i = 0; i < _tools.Count(); i++)
        {
            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("x", GUILayout.Width(25)))
            {
                if(EditorUtility.DisplayDialog("Remove Tool", "Remove " + _tools.GetItem(i).Name + " from the tools database", "Remove", "Cancel"))
                {
                    _tools.RemoveAt(i);
                    EditorUtility.SetDirty(_tools);
                    state = EditorState.ABOUT;
                    return;
                }
            }

            if(GUILayout.Button(_tools.GetItem(i).Name, "Box", GUILayout.ExpandWidth(true)))
            {
                _selectedItem = i;
                state = EditorState.EDIT;
            }


            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();


        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField("Tools: " + _tools.Count(), GUILayout.Width(100));
        if (GUILayout.Button("New Tool")) state = EditorState.ADD;
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }

    void ShowEditView()
    {
        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
        EditorGUILayout.Space();

        switch(state)
        {
            case EditorState.EDIT:
                ViewEditMode();
                break;
            case EditorState.ADD:
                ViewAddMode();
                break;
            case EditorState.ABOUT:
                ViewAboutMode();
                break;
        }

        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }

    void ViewEditMode()
    {
        Tool mySelect = _tools.GetItem(_selectedItem);

        GUILayout.BeginVertical();
        mySelect.Name = EditorGUILayout.TextField("Name", mySelect.Name);
        mySelect.Description = EditorGUILayout.TextField("Description", mySelect.Description);
        mySelect.BuyAt = Convert.ToInt32(EditorGUILayout.TextField("Price", mySelect.BuyAt.ToString()));
        mySelect.StacksTo = Convert.ToInt32(EditorGUILayout.TextField("Stack", mySelect.StacksTo.ToString()));
        mySelect.Icon = EditorGUILayout.ObjectField("Icon", mySelect.Icon, typeof(Sprite), false) as Sprite;

        mySelect.LevelRequired = Convert.ToInt32(EditorGUILayout.TextField("Level", mySelect.LevelRequired.ToString()));
        mySelect.Effect = Convert.ToInt32(EditorGUILayout.TextField("Effect", mySelect.Effect.ToString()));
        mySelect.MinEffect = Convert.ToInt32(EditorGUILayout.TextField("Min Effect", mySelect.MinEffect.ToString()));
        mySelect.equipmentSlot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", mySelect.equipmentSlot);
        mySelect.Type = (ToolType)EditorGUILayout.EnumPopup("Tool Type", mySelect.Type);
        mySelect.Prefab = EditorGUILayout.ObjectField("Prefab", mySelect.Prefab, typeof(GameObject), false) as GameObject;
        GUILayout.EndVertical();

        if (GUILayout.Button("Save", GUILayout.Width(100)))
        {
            EditorUtility.SetDirty(_tools);
            state = EditorState.ABOUT;
        }
    }
    
    void ViewAddMode()
    {
        _newToolName = EditorGUILayout.TextField(new GUIContent("Name: "), _newToolName);
        EditorGUILayout.Space();

        if(GUILayout.Button("Add", GUILayout.Width(100)))
        {
            _tools.Add(new Tool(_newToolName));
            _newToolName = string.Empty;
            EditorUtility.SetDirty(_tools);
            state = EditorState.ABOUT;
        }
    }

    void ViewAboutMode()
    {
        EditorGUILayout.LabelField("To-do:\n" +
                                   "\tAdd tool works on list\n" +
                                   "\tAdd tool lvl, effects\n" +
                                   "\tAdd tool equip slot",
                                   GUILayout.ExpandHeight(true));
    }
}
