using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public partial class StepDefinitions
{
    private Person _lucy = new Person();
    private Person _sean = new Person();

    private string _messageFromSean;

    [Given(@"Lucy is located (.*)m from Sean")]
    public void GivenLucyIsLocatedThisFarFromSean(int distance)
    {

        _lucy.MoveTo(distance);
    }

    [When(@"Sean shouts ""(.*)""")]
    public void WhenSeanShouts(string message)
    {
        _sean.Shout(message);
        _messageFromSean = message;
    }

    [Then(@"Lucy hears Sean's message")]
    public void ThenLucyHearsSeansMessage()
    {
        Assert.Contains(_messageFromSean, _lucy.GetMessagesHeard());
    }
}