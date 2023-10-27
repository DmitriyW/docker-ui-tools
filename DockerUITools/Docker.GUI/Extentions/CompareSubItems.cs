namespace Docker.GUI.Extentions;

public static class CompareSubItems
{
    public static bool Compare(this ListViewItem currentItem, ListViewItem inputItem)
    {
        var result = true;

        for (int i = 0; i < currentItem.SubItems.Count; i++)
        {
            var current = currentItem.SubItems[i].Text;
            var input = inputItem.SubItems[i].Text;

            result = result && current == input;
        }

        return result;
    }
}
