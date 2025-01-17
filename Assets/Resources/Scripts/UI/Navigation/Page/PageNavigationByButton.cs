using System;

public class PageNavigationByButton : NavigationByButton
{
    protected override void Go()
    {
        PageManagement.EnableByIndex(index);
    }

    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int index)
    {
        if (index < 0)
        {
            throw new Exception("Индекс не может быть отрицательным");
        }

        this.index = index;
    }
}