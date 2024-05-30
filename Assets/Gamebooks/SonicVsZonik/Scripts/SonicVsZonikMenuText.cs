using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SonicVsZonikMenuText : MonoBehaviour
{
	[SerializeField] private bool isHeader;
	[SerializeField] private TMP_Text currentText;
	
	public static string header0 = "Dummy";
	public static string text0 = 
		"This is dummy text. If you're reading this, something's gone wrong!";
	
	public static string header1 = "Introduction (1/2)";
	public static string text1 =
		"This is a gamebook. You don't read through it like you would a normal book, starting at the first page and ending with the last. In <i>Sonic Vs Zonik</i> you decide how Sonic and Tails will defeat the evil Zonik. How will they fight the Badniks and overcome all the other tricks, traps and puzzles they will find along the way? That choice is up to you. If you make the right choices for them, they'll win; make the wrong ones — well, you'll soon find out!\n\nBefore you start to read the book, have a look at the rules on the next few pages. They are not very complicated, so don't worry! They are almost the same as the ones in the other Sonic Gamebooks. You will need one ordinary six-sided die and a pencil.";
	
	public static string header2 = "Introduction (2/2)";
	public static string text2 = 
		"Before you start, you have to decide how good Sonic is at doing things. If you look at page 12, you will see a chart called Sonic's <i>Vital Statistics</i>. As well as listing Sonic's abilities, it has a place to record what Sonic is carrying (Sonic's Stuff), and also places to record how many lives he has left and how many rings he has collected. Tails doesn't have his own abilities — in this book they're the same as Sonic's.\n\nSonic (and Tails) have six abilities: Speed, Strength, Agility, Coolness, Quick Wits and Good Looks. Beside each on the chart is a description of what each ability means. Read these and then decide what ability you want Sonic to be best at. Now write a '5' in the box by this ability. Then look for the one you want him to be next best at, and write a '4' by its side. Now write a '3' by his third best ability and then a '2' by all the rest. These numbers show what Sonic's strengths and weaknesses are.";
	
	public static string header3 = "Doing Things";
	public static string text3 = 
		"Some sections of this book will ask you to roll a die against one of Sonic's abilities. To do this you must roll the die. Look at the result, and then add it to the number you have given to Sonic's ability. For instance, if you needed to roll against Sonic's Strength, you should roll the die and then look at Sonic's Strength score. If you rolled a 3 and Sonic had a Strength of 4, then the score would be 7 (3 + 4). The section you are reading will tell you the number you have to beat to succeed.";
	
	public static string header4 = "Fighting";
	public static string text4 = 
		"Sonic also uses his abilities to fight his enemies. To do this, Sonic must use one of his abilities: you will be told which one in the section you are reading.\n\nAll of the enemies have a fighting score. This is a number between 5 and 10. The lower the number, the worse they are at fighting. To fight them, roll the die and add it to the ability score that Sonic is using. If Sonic rolls higher than or equal to an enemy's fighting score, then he has hit it (some enemies need more than one hit to destroy them!). If an enemy is not destroyed, then it can try to hit Sonic! Roll one die and add it to its fighting score. If the result is more than 10, then it has hit Sonic ... OUCH! If Tails is helping Sonic, then Sonic can add 3 to his die roll. In some cases, this may be less, but it depends on what is happening.\n\nIf Sonic is hit by an enemy, he will either lose all his rings or, if he doesn't have any rings, he will lose one of his lives.";
	
	public static string header5 = "Lives";
	public static string text5 = 
		"Sonic starts the book with three lives. If he loses them all, he has failed and must start the adventure again from the beginning. Tails has no lives of his own and if Sonic has lost all his, then he must go back to the beginning as well. Sonic can 'buy' an extra life with 100 rings if he wants to, but he must have collected 100 rings first. Beware, some parts of the adventure need rings to gain access to parts of the Zones.";
	
	public static string header6 = "Carrying Stuff";
	public static string text6 = 
		"Sonic starts with a few items. These are already written down in Sonic's Stuff. They include an energy gun. This nifty piece of hardware shoots out a beam of pure Cool. Anything evil or eggy caught by it will be frozen for a while. Unfortunately, every time Sonic fires it, it costs 10 rings, so use it wisely. The book will tell you if and when he can use his Stuff. Throughout the adventure, he will be able to pick up other things. Write these down in Sonic's Stuff so that you will remember what he has collected. Also, cross off the ones he and Tails don't have any more.\n\nSomewhere in this adventure, Sonic will find the Zone Chip. This may be used at any time in the game by turning to section 237. You will not see this number printed in the book very often, so make a note of it for when you find the Chip, otherwise Sonic won't be able to use it.\n\nSonic and Tails will find rings and be given credits and points in the adventure and you will need to write these down as well - remember to use a pencil, though, as these will need to be altered quite a lot as you read this book.";
	
	public static string header7 = "Get Started";
	public static string text7 = 
		"Well, that's it for the rules, now turn to section 1 and start your adventure with Sonic and Tails as they battle against Zonik and the Badniks.";
	
	public static string[] textLibrary = {text0, text1, text2, text3, text4, text5, text6, text7};
	public static string[] headerLibrary = {header0, header1, header2, header3, header4, header5, header6, header7};
	
	public void UpdateText() {
		if (isHeader) {
			currentText.text = headerLibrary[SonicVsZonikMenu.index];
		}
		else {
			currentText.text = textLibrary[SonicVsZonikMenu.index];
		}
	}
	
}
