using System;

public interface IViewModel: IDisposable
{
    public event Action OnUpdateData;
}