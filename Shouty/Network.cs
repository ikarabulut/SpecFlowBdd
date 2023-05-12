namespace Shouty;

public class Network
{
    private readonly List<Person> _listeners = new List<Person>();

    public virtual void Subscribe(Person person)
    {
        _listeners.Add(person);
    }

    public virtual void Broadcast(string message)
    {
        foreach (var listener in _listeners)
        {
            listener.Hear(message);
        }
    }
}