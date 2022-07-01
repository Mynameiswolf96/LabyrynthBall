using UnityEditor;

public class MenuItems
{
    [MenuItem("ObjectChange/Пункт меню %q")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "GeekBrains");
    }
}