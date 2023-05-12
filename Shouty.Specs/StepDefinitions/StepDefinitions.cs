using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public partial class StepDefinitions
{
    private Person _lucy = new Person("Lucy");
    private Person _sean = new Person("Sean");

    private string _messageFromSean;

    [Given("{Person} is located/standing {int} meters(s) from Sean")]
    public void GivenPersonIsLocatedThisFarFromSean(Person person, int distance)
    {

        person.MoveTo(distance);
    }

    [When("Sean shouts {string}")]
    public void WhenSeanShouts(string message)
    {
        _sean.Shout(message);
        _messageFromSean = message;
    }

    [Then("{Person} hears Sean's message")]
    public void ThenPersonHearsSeansMessage(Person person)
    {
        Assert.Contains(_messageFromSean, _lucy.GetMessagesHeard());
    }
}