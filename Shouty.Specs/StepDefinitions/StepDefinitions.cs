using System.Net.NetworkInformation;

using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public partial class StepDefinitions
{
    private Person _lucy;
    private Person _sean;
    private string _messageFromSean;

    [Given("Lucy is located/standing {int} meter(s) from Sean")]
    public void GivenPersonIsLocatedThisFarFromSean(int distance)
    {
        var network = new Network();
        _sean = new Person(network);
        _lucy = new Person(network);
        _lucy.MoveTo(distance);
    }

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
}