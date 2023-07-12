Feature: Page Object Model

A short summary of the feature


Scenario: All-Around Program

	Given I am on "All-Around" page and i validate the program card is "All-Around"
	When  i press split sourruounding volume on 'All-Around' program
	Then i validate "Right HI" volume is '9'
	And i validate "Left HI" volume is '9'
	When i set "Right HI" sourrounding volume to "3" from "9" of All-Around program 
	And i set "Left HI" sourrounding volume to "10" from "9" of All-Around program 
	Then i validate "Right HI" volume is '3'
	And i validate "Left HI" volume is '10'
	When  i press merge sourrounding voulume on All-Around program
	Then i validate "HI" volume is '3'
	When i set "HI" sourrounding volume to "13" from "3" of All-Around program
	Then i validate "HI" volume is '13'
	When i press 'Speech Clarity' quick button on 'All-Around' Program
	Then validate 'Speech Clarity' quick button is enabled on 'All-Around' Program
	When i press 'Noise filter' quick button on 'All-Around' Program
	Then validate 'Noise filter' quick button is enabled on 'All-Around' Program
	And  validate 'Speech clarity' quick button is disabled on 'All-Around' program
	When i press 'Speech clarity' quick button on 'All-Around' Program
	Then validate 'Speech clarity' quick button is enabled on 'All-Around' Program
	And validate 'Noise filter' quick button is disabled on 'All-Around' program
	When i press Sound Enhancer button on 'All Around' program
	And i set 'Bass gain' to '4' from '0' on All-Around Sound Enhancer
	And i set 'Middle gain' to '-3' from '0' on All-Around Sound Enhancer
	And i set 'Treble gain' to '5' from '0' on All-Around Sound Enhancer
	Then i validate "Bass gain" is "4" on All-Around Sound Enhancer
	And  i validate "Middle gain" is "-3" on All-Around Sound Enhancer
	And i validate "Treble gain" is "5" on All-Around Sound Enhancer
	When i press Tinnitus Manager on All-Around Sound Enhancer
	And i press Nature sounds button "Calming waves" on All-Around Tinnitus Manager
	And i press Nature sounds button "Breaking Waves" on All-Around Tinnitus Manager
	When i press the exit button on 'All Around' Sound Enhancer
	When i swipe 'left' to 'Hear in noise' program from current program
	Then i validate program card is "Hear in noise"
	When i press Sound Enhancer button on 'Hear in noise' program
    And i press 'Tinnitus Manager' on 'Hear in noise' Sound Enhancer
	And i press white noise button 'Slight variation' on 'Hear in noise' Tinnitus Manager
	When i press 'Reset' button on All-Around Tinnitus Manager
	When i press the exit button on 'Hear in noise' Sound Enhancer
	When i swipe 'left' to 'Outdoor' program from current program
	Then i validate program card is "Outdoor"
	When i press Sound Enhancer button on 'Outdoor' program
	And i drag Wind Noise Reduction to 'Strong' on 'Outdoor' Sound Enhancer
	When i press the exit button on 'Outdoor' Sound Enhancer
	And i swipe 'left' to 'Music' program from current program
	Then i validate program card is "Music"
	When I press 'Music' program on the top ribbon bar
	Then i validate program card is "Music"
	When I press 'Outdoor' program on the top ribbon bar
	Then i validate program card is "Outdoor"
	When I press 'Hear in noise' program on the top ribbon bar
	Then i validate program card is "Hear in noise"
	When I press 'All-Around' program on the top ribbon bar
	Then i validate program card is "All-Around"
	When i press Program overview button on topribbonbar
	And i press 'Hear in noise' program on Program overview
	When i press 'Outdoor' program on Program overview
	When i press 'Music' program on Program overview
	When i press 'All-Around' program on Program overview
	When i press the 'Close' button on Program overview
	When i press menu item 'My ReSound' on bottom ribbon bar
    And I press 'Learn about the app' on My ReSound
	When I press 'Volume control' on Learn about the app
	And I swipe 'left' to '2 / 3' page on Learn about the app
	Then validate 'Left and right volume' animation is shown on Volume control
	When I swipe 'left' to '3 / 3' page on Learn about the app
    Then  validate 'Mute' animation is shown on Volume control
	When I close on Learn about the app and back to My Resound page
	And I press 'Guiding tips' on My ReSound
	When I press 'OK' on 'Please notice' dialog
	Then validate title is 'Guiding tips' on Guiding tips page
	When I press 'Noise filter' on Guiding tips
	And I press 'Got it' on 'Noise filter' nudging dialog
	And I press 'My Resound' on bottom ribbon bar and back to 'Guiding tips' on My Resound
	And I press 'Music program' on Guiding tips
	Then validate 'Got it' button enabled on 'Music program' nudging dialog
	Then validate 'Back to tips' button enabled on 'Music program' nudging dialog
	When I press 'Got it' on 'Music program' nudging dialog
	And i press menu item 'More' on bottom ribbon bar
	Then validate 'Auto-activate favorite locations' switch is 'on'
	When I press 'Auto-activate favorite locations' switch on More menu
	Then validate 'Auto-activate favorite locations' switch is 'off'
	When I press 'Auto-activate favorite locations' switch on More menu
	Then validate 'Auto-activate favorite locations' switch is 'on'
	When I press more menu item 'About'
	Then validate page title is displayed on 'About' page
	And validate html view is displayed on 'About' page
	When I press 'back' from 'About' page
	And I press more menu item 'Legal information'
	When I press Legal information item 'MANUFACTURER'
	Then I validate page title is displayed on 'Manufacturer' page
	When I press 'back' from 'Manufacturer' page
	And I press Legal information item 'TERMS AND CONDITIONS'
	Then I validate page title is displayed on 'Terms and Conditions' page
	When I press 'back' from 'Terms and Conditions' page
	And I press Legal information item 'PRIVACY POLICY'
    Then I validate page title is displayed on 'PRIVACY POLICY' page
	Then validate html view is displayed on 'PRIVACY POLICY' page
	When I press 'back' from 'PRIVACY POLICY' page 
	And I press 'back' from 'Legal information' page
	And I press more menu item 'Support'
    Then I validate page title is displayed on 'Support' page
	And validate html view is displayed on 'Support' page
	When I press back from 'Support' page
	And i press menu item 'Home' on bottom ribbon bar
