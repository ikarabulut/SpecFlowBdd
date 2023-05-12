using System.Net.NetworkInformation;

using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public partial class StepDefinitions
{
    private Person _lucy;
    private Person _sean;
    private string _messageFromSean;
    private Network _network;
    private Dictionary<string, Person> _people;

    [BeforeScenario]
    public void CreateNetwork()
    {
        _network = new Network();
        _people = new Dictionary<string, Person>();
    }

    [When("Sean shouts {string}")]
    public void WhenSeanShouts(string message)
    {
        _people["Sean"].Shout(message);
        _messageFromSean = message;
    }

    [Then("Lucy hears Sean's message")]
    public void ThenPersonHearsSeansMessage()
    {
        Assert.Contains(_messageFromSean, _people["Lucy"].GetMessagesHeard());
    }

    [Given("a person named {word}")]
    public void GivenAPersonNamedLucy(string name)
    {
        _people.Add(name, new Person(_network));
    }
}