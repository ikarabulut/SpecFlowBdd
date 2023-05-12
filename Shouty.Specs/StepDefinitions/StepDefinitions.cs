using System.Net.NetworkInformation;

using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public partial class StepDefinitions
{
    private Person _lucy;
    private Person _sean;
    private string _messageFromSean;
    private Network _network = new Network();

    [When("Sean shouts {string}")]
    public void WhenSeanShouts(string message)
    {
        _sean.Shout(message);
        _messageFromSean = message;
    }

    [Then("Lucy hears Sean's message")]
    public void ThenPersonHearsSeansMessage()
    {
        Assert.Contains(_messageFromSean, _lucy.GetMessagesHeard());
    }

    [Given(@"a person named Lucy")]
    public void GivenAPersonNamedLucy()
    {
        _lucy = new Person(_network);
    }

    [Given(@"a person named Sean")]
    public void GivenAPersonNamedSean()
    {
        _sean = new Person(_network);
    }
}