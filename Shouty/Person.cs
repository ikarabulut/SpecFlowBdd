namespace Shouty;

public class Person
{
    private readonly Network _network;
    private readonly List<string> _messagesHeard = new();

    public Person(Network network)
    {
        _network = network;
        _network.Subscribe(this);
    }
    public void MoveTo(int distance)
    {

    }

    public void Shout(string message)
    {
        _network.Broadcast(message);
    }

    public IEnumerable<string> GetMessagesHeard()
    {
        return _messagesHeard;
    }

    public void Hear(string message)
    {
        _messagesHeard.Add(message);
    }
}