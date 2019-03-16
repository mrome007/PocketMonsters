using System;

public class IndexEventArgs : EventArgs
{
    public int Index { get; set; }

    public IndexEventArgs()
    {
        Index = 0;
    }

    public IndexEventArgs(int index)
    {
        Index = index;
    }
}
