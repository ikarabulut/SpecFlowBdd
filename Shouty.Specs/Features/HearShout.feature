Feature: Hear Shout

@mytag
Scenario: Listener is located within range
	Given Lucy is located 15 meters from Sean
	When Sean shouts "free bagels at Sean's"
	Then Lucy hears Sean's message

Scenario: Listener is standing within range
    Given Lucy is standing 15 meters from Sean
    When Sean shouts "free bagels at Sean's"
    Then Lucy hears Sean's message

Scenario: Listener hears a different message
    Given Lucy is standing 15 meters from Sean
    When Sean shouts "Free coffee!"
    Then Lucy hears Sean's message
