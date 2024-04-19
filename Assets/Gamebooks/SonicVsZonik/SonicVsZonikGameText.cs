using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SonicVsZonikGameText : MonoBehaviour
{
	[SerializeField] private bool isHeader;
	[SerializeField] private TMP_Text currentText;
	
	public class Section
	{
		public string text;
		public int[] choices;
		public int diceGoal = 0;
		public string diceAbility;
		public bool visited = false;
		public bool mackSection = false;
		public bool asteronSection = false;
	};
	
	public static Section section0 = new Section()
	{
		text = "This is dummy text. If you're reading this, something's gone wrong!"
	};

	public static Section section1 = new Section()
	{
		text = "Something very strange had happened in the Green Hill Zone. One minute Sonic had been sitting playing with his Mega Drive, the next thing he was being attacked by a group of maniac bunnies. They were usually his friends! He'd tried to speak to them, but all they kept shouting at him was something about him filling all their burrows with rotten eggs. Sonic didn't even like eggs, and the bunnies were his mates, so he'd never dream of doing that to them. Suddenly, everything had gone black... Sonic could see stars, not the kind of stars in the night sky, but the kind that whizz around the inside of your head. It was as if the whole of the universe was circling around him — Sonic, of course, being the centre of the universe.\n\n'Hey, slow down, it was day-time a minute ago!'\n\nSuddenly, his senses returned and he jumped to his feet. The bunnies were gone. He was alone, confused and not sure what was going on.\n\n'Wow, this is weird,' says Sonic.\n\nSonic might be covered in spines, but they don't protect his head. Gingerly, he raises a paw to the rapidly growing bruise.\n\n'Oh no! It's the size of an egg ... hey, now don't say egg! Bad vibes about that word. I suppose I'd better find out whether the bunnies were right.'\n\nSonic set out through the Green Hills, still not really believing what had happened in the past ten minutes. Everything looked normal, the hills were green, the sky was blue. Yes, this had to be the Green Hill Zone. But there was something, something odd, nagging him.\n\n'ZZZZzzzzwing!'\n\nA small silver object flew towards Sonic's head, embedding itself in a tree behind him. Sonic turned around to take a look at the tree. There, half-buried in the bark, was the familiar shape of a Buzzer.\n\n'ZZZzzz ... buzzzz! Get ya next time. Buzzz!' threatened the Buzzer, rather pathetically, as he was firmly stuck in the tree.\n\nSonic smiled, all was well in the Green Hill Zone. They always try to get me, he thought, but never manage it. The thought formed a smile. Sonic started walking away from the cursing Buzzer, wondering whether to head for the hills or one of the bridges. Imagine you are Sonic - what would you do? Go to the hills (turn to <b>106</b>)? If you think Sonic should head towards the river, then turn to <b>177</b>.",
		choices = new int[2] {106, 177}
	};

	public static Section section2 = new Section()
	{
		text = "The commissionaire explains that Zonik has ransacked most of the casino, and scared away all of its customers. All the damage must be put right - and quickly. If Sonic and Tails will help him, then the commissionaire will be pleased to return the favour.\n\nTo help them, he gives them 50 credits. Make a note of them in Sonic' s Stuff. While Sonic and Tails are in the casino, these can be used just like rings; unfortunately, though, they are worthless anywhere else. Now turn to <b>274</b>.",
		choices = new int[1] {274}
	};

	public static Section section3 = new Section()
	{
		text = "Running, spinning and jumping across the Green Hill Zone, Sonic is quickly gaining on his friend Tails. Sonic cannot help but wonder why Tails is trying to get away from him. Perhaps this is a game? Maybe Tails is just trying to see if Sonic is awake enough to close the gap? At last, Sonic catches up with Tails and skids to a halt. Tails looks tired and afraid. Sonic goes towards him, but Tails backs off.\n\n'Why are you running away from me?' Sonic splutters. Tails just looks at him. Sonic is getting desperate. 'What is going on here?' Sonic demands.\n\nTails continues looking at Sonic, and leans a little closer to him. This makes Sonic feel a bit weird, like some kind of exhibit in a zoo. Now that Tails is this close, Sonic is shocked at the state of him. As well as the mud and dirt, poor old Tails' fur is singed and blackened in over a dozen places. Sonic is still confused. He opens his mouth to repeat the questions. Tails quickly reaches out with a paw and touches Sonic on the snout. Then, quick as a flash, he whips the paw away again.\n\n'What are you up to, Tails?' exclaims Sonic.\n\nTails just smiles. 'So it is you,' he says, very relieved. 'The real you, after all.' Now turn to <b>291</b>.",
		choices = new int[1] {291}
	};

	public static Section section4 = new Section()
	{
		text = "Sonic stares at the jars, wondering what to do with them. Suddenly, one of the jars cracks and then splinters into pieces. Standing in its place is a perfectly formed mini-Zonik. Another jar starts to crack, then another. Horrified, Sonic realizes that the jars are starting to hatch!\n\nSonic and Tails must fight the mini-Zoniks. Tails will not be able to help Sonic. The mini-Zoniks have a fighting score of 5 and only need one hit to be destroyed. Unfortunately, there are five of them! Sonic must fight them one after another. If he wins, turn to <b>130</b>.\n\nIf, regrettably, the mini-Zoniks win, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {130}
	};

	public static Section section5 = new Section()
	{
		text = "Grabber, normally everyone's worst enemy, is in no fit state to fight and seems glad that Sonic doesn't want to tussle with him.\n\n'Grrr, getting too old for this, I am,' he says. 'I'm going to have to power down for a while ... have a little rest.'\n\nTails and Sonic can see the red glow of Grabber's eyes start to fade as the spider begins to cut his own power.\n\n'Wait!' shouts Tails. 'Who attacked you?'\n\n'It was Sonic, of course,' Grabber's voice is getting slower all the time as the power drains away from his circuits.\n\n'No, NO ... I'm Sonic!' says Sonic. 'There can't be two of us!'\n\n'Best . . . best you ask Robotnik 'bout that one,' says Grabber, his voice becoming a whisper.\n\n'What do you mean?' questions Sonic, but by now the lights in the spider's eyes have gone. Turn to <b>209</b>.",
		choices = new int[1] {209}
	};

	public static Section section6 = new Section()
	{
		text = "It's only a short way to this bouncer, and both of them make it easily, scoring 5 points if this is the first time they have been here. There's a great view of the game from here, and it stretches off as far as the eye can see in every direction. Now roll the die. If the score is 1 or 2, then Sonic and Tails <i>must</i> go to <b>298</b>. If the score is 3 or more, then they head for another bouncer off to the left (turn to <b>181</b>), or aim for the central spinner (turn to <b>124</b>).",
		choices = new int[3] {298, 181, 124}
	};

	public static Section section7 = new Section()
	{
		text = "The tunnel slowly curves around to the left, its grey metal walls covered in a film of Mega Mack. There are even puddles of it on the tunnel floor. Being careful to avoid these, Sonic and Tails slowly walk along, trying to think of anything to take their minds off the awful smell! After a little while they come to another branch in the tunnel. If you want them to head left, turn to <b>296</b>. If you would rather Sonic and Tails followed the right-hand tunnel, turn to <b>101</b>.",
		choices = new int[2] {296, 101}
	};

	public static Section section8 = new Section()
	{
		text = "It is very dark inside the cave. The walls are glowing with a very dim light, just enough to see where they are going, but that's about all. If Sonic has a torch, turn to <b>79</b>. If he does not have a torch, then turn to <b>115</b>.",
		choices = new int[2] {79, 115}
	};

	public static Section section9 = new Section()
	{
		text = "'OK,' says Sonic. 'The cave it is!'\n\nBoth the heroes charge off at a frightening speed, though at least Sonic manages to remember the small stream and easily avoids it this time.\n\nAt this rate the journey to the caves takes exactly one minute, and neither of them is even out of breath! The inside of the cave is dark and dank, maybe even a bit eggy!\n\n'I never remember it smelling this bad,' says Tails. 'Me neither,' says Sonic. After a few moments their eyes get used to the darkness and Sonic can see a pile of rings in the corner.\n\n'At least the rings are still safe!' says Sonic as he starts to pick them up. Beside the pile of rings Sonic sees a small computer chip. He picks it up and looks at it. There are brief instructions printed on the side of it: 'Zone Chip. To activate, insert 10 rings per person'. Sonic may now use the Zone Chip at any time. To use it, cross off 10 rings from Sonic's Stuff, or 20 rings if Tails is using it too. Then, make a note of the section you are reading, before turning to <b>237</b>.\n\nTails, however, has spotted something else. Over in the far corner is a small needle-shaped thing, and it's glowing blue! Sonic has managed to collect 10 rings (add them to his Vital Statistics sheet). If you would like him to go and have a look at the blue needle, turn to <b>174</b>. If you think it's about time the heroes left, turn to <b>201</b>.",
		choices = new int[2] {174, 201}
	};

	public static Section section10 = new Section()
	{
		text = "Sonic and Tails have been in the maze for ages now. The Mack is getting dangerously close to their feet and they still don't know the way out. They are getting desperate! Should they follow the main tunnel (turn to <b>151</b>), or go into the smaller tunnel off to the left (turn to <b>21</b>)?",
		choices = new int[2] {151, 21},
		mackSection = true
	};

	public static Section section11 = new Section()
	{
		text = "Putting their trust in the strange creatures, Sonic and Tails follow them through a maze of corridors and tunnels. The creatures seem to know the tunnels very well. After what seems like ages, they come to a halt in a large, dimly lit cavern. As Sonic's eyes get used to the light, he begins to realize that there are literally thousands of the creatures here, and every one of them is staring intently at him and Tails! Turn to <b>225</b>.",
		choices = new int[1] {225}
	};

	public static Section section12 = new Section()
	{
		text = "Once across the river, Sonic was in one of the many small woods that dotted the Zone. All looked as it should be: the trees were still large things with brown trunks and lots of big green bits on top; there were plenty of them and they all had one end firmly stuck in the ground.\n\n'Completely normal,' says Sonic, just as a large brown object lands at his feet with a thump. Sonic looks at the thing, unsure what it is or why it is there. 'A coconut?' he says, just as the second one hits him squarely on the chest. Sonic sprawls on to the ground, but he is back on his feet in a second.\n\n'Yik, Yik, Yik! Cop that, Spiky!'\n\nSonic looks up towards where the voice was coming from, and he sees the face of Coconuts grinning down at him from the top of a tree.\n\n'Plenty more where that came from, Spiky! Yik!' Coconuts howls with laughter as he reaches for another coconut to hurl in Sonic's direction. Just as Sonic is wondering what to do, the numbers 1 3 2 pop into his mind ... how strange! Will Sonic get out of the way of the annoying monkey (turn to <b>38</b>), or will he try to speak to him (turn to <b>246</b>)?",
		choices = new int[2] {38, 246}
	};

	public static Section section13 = new Section()
	{
		text = "The walls of the tunnel form a perfect tube. Made of some dull greyish metal streaked with horrible smears of dried-on Mack, they look a bit like Robotnik's white coat with all its egg stains - Euugh!\n\nAfter a while the tunnel branches in two. Which way should Sonic and Tails go? Straight on (turn to <b>125</b>) or to the left (turn to <b>204</b>)?",
		choices = new int[2] {125, 204},
		mackSection = true
	};

	public static Section section14 = new Section()
	{
		text = "Picking their moment carefully, Sonic and Tails prepare to fight the Badnik. It has a fighting score of 7 and it will need five hits to be destroyed. Tails will help Sonic. This is one MEAN dude!\n\nIf you think it might be wiser for Sonic and Tails to try something else, there is still time. But what should they do:\n\nUse the energy gun?\t\t\tTurn to <b>230</b>\nTry using some glue?\t\t\tTurn to <b>107</b>\nTry to roll the Badnik over?\t\t\tTurn to <b>53</b>\n\nIf you decide Sonic and Tails shouldn't be such wimps, then fight the Badnik. If they win, turn to <b>249</b>. If Sonic and Tails fail to beat the Badnik, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[4] {230, 107, 53, 249}
	};

	public static Section section15 = new Section()
	{
		text = "The trapdoor opens easily to reveal a small spiral staircase leading down into the darkness. The staircase- goes down and down and then down some more and it gradually starts to get hotter. If Sonic has a torch, turn to <b>163</b>.\n\nIf he doesn't have a torch, then roll the die and add the score to Sonic's Agility. If the result is 6 or more, turn to <b>251</b>. If the result is less than 6, turn to <b>34</b>.",
		choices = new int[3] {163, 251, 34}
	};

	public static Section section16 = new Section()
	{
		text = "As they creep down the passage, the sound of digging gets louder and louder.\n\n'It's got to be an archaeologist,' says Tails. 'I mean, who else would want to be digging about in this place!'\n\n'Well, looks like we won't have to wait long to find out,' replies Sonic.\n\nThe passageway is coming to an end. The cavern ahead is well lit, and after creeping slowly round the final bend, Tails' question is answered.\n\n'It's UNCOOL TO CRAWL!' The voice is loud, but Sonic's lips aren't moving!\n\nTurn to <b>169</b>.",
		choices = new int[1] {169}
	};

	public static Section section17 = new Section()
	{
		text = "Sonic's touch on the Start button was perfection! Our heroes have rolled on to the table at just the right speed. They glide perfectly through a Bonus Zone.\n\nTen rings appear from thin air and tumble on to the platform beneath the Bonus. Add them to Sonic's Stuff. A split second later, Sonic and Tails touch down as well.\n\n'Cool!' says Tails.\n\n'No, Mega Cool,' corrects Sonic.\n\nFrom here they can go one of two ways, which will they choose?\n\nThe platform to the right?\t\t\tTurn to <b>218</b>\nThe platform to the left?\t\t\tTurn to <b>109</b>",
		choices = new int[2] {218, 109}
	};

	public static Section section18 = new Section()
	{
		text = "Face to face with a mirror image of himself, Sonic is quite literally dumbstruck, which, let's face it, doesn't happen very often! It was Zonik who broke the silence first.\n\n'So, you're the one I was made to look like,' he says, then pauses. 'Hmm, I think I'm an improvement, don't you?'\n\nSonic's mouth falls open, unable to believe that anyone would have the cheek to speak to him like this.\n\nZonik continues. 'Soon I'll have enough rings to reach the Ring Zone.' He raises a finger and points it straight at Sonic. 'Then you'll get yours!' With that, he launches into an enormous spin that sends him over Sonic's head, past the hovering Tails and he is gone. By the time Sonic has recovered his balance, there is no sign of Zonik.\n\n'Now you've seen him too,' says Tails.\n\n'Yes,' says Sonic. After a while, he turns to look Tails straight in the eye. 'And next time I'll be the one doing the talking!' Turn to <b>209</b>.",
		choices = new int[1] {209}
	};

	public static Section section19 = new Section()
	{
		text = "Unable to control his natural curiosity, Sonic darts around the comer to see what is going on, closely followed by Tails. They come face to face with Grabber, the Zone's resident steel spider and a real hard case. He's lying on his back, all eight metal legs flailing in the air. Above him is a blue blur. The blur, moving at fantastic speed, spins through the air and lands with a mighty thump on Grabber's head, sending sparks and bits of metal flying in all directions.\n\n'Outstanding!' Sonic says aloud.\n\n'I'm glad you think so,' says the blue hedgehog, now standing on the shattered remains of Grabber.\n\n'THAT'S HIM! The one that attacked me!' exclaims Tails.\n\nWill Sonic and Tails attack Zonik (turn to <b>123</b>), or will they wait and see what happens (turn to <b>18</b>)?",
		choices = new int[2] {123, 18}
	};

	public static Section section20 = new Section()
	{
		text = "Reacting with incredible speed, Sonic grabs the target with one paw and Tails with the other, sending both of them whizzing off towards a mushroom bouncer on the right. They hit the bouncer square on, scoring 5 points if this is the first time they have been here. Then they bounce back the way they came, towards the target again. Turn to <b>86</b>.",
		choices = new int[1] {86}
	};

	public static Section section21 = new Section()
	{
		text = "After what seems like ages, this tunnel emerges at last into a very large room. Its ceiling is so far above their heads that neither Sonic nor Tails can see the top of it. The walkway carries on to the centre, where there are no less than four possible exits! Where should they go now?\n\nNorth?\t\t\tTurn to <b>194</b>\nSouth?\t\t\tTurn to <b>240</b>\nEast?\t\t\tTurn to <b>179</b>\nWest?\t\t\tTurn to <b>100</b>",
		choices = new int[4] {194, 240, 179, 100},
		mackSection = true
	};

	public static Section section22 = new Section()
	{
		text = "The silver ball is travelling too fast to avoid and it strikes both Sonic and Tails a mighty blow, sending them flying down to the bottom of the game. Remove 5 Credits from Sonic's Stuff. The huge flippers shoot up to meet them and both get hit again! Remove another 5 Credits from Sonic's Stuff. Still, at least they're travelling back up to the top of the game now, and they are soon back at the central spinner. Turn to 124.",
		choices = new int[1] {124}
	};

	public static Section section23 = new Section()
	{
		text = "Sonic and Tails have beaten the Spike Buggy so many times before that this should be a walk-over! Around the corner in the valley, the familiar shape of Robotnik's creation comes into view. When Sonic first came across it, Robotnik himself used to drive the contraption, But when he kept losing, he automated the buggy to drive itself. The buggy isn't moving ... It can't have seen either of our heroes yet. They creep closer and closer and still the buggy remains absolutely motionless.\n\n'What's up with it ... it's never done this before,' says Tails in a whisper.\n\nPatience never being his strong point, Sonic determines to investigate. 'Well, let's find out, shall we? CHARGE!!!' With that, Sonic hurls himself towards the buggy. With one graceful jump he somersaults through the air and lands with a crunch on the buggy's roof. CRASH! He disappears in a cloud of dust. Tails looks on horrified as the whole buggy collapses into a heap of scrap metal.\n\nAfter a few seconds, Sonic emerges from the debris, covered in smuts and oil. 'I've never managed that before,' he says.\n\n'I think,' says Tails, 'that something, or someone else, beat us to it.'\n\n'You mean the other Sonic?' says Sonic, apparently disappointed that it wasn't him who had demolished the buggy.\n\n'Looks that way.'\n\n'Well if it was him, then he's saved me ... er I mean us, the trouble then,' Sonic looks awkward.\n\n'I suppose he has,' smiles Tails, and together they walk towards the gate that would take them from the Green Hills to a place altogether less agreeable. Turn to <b>250</b>.",
		choices = new int[1] {250}
	};

	public static Section section24 = new Section()
	{
		text = "'I've been looking for you: you must get back to the Metropolis Zone and help with the cloning,' booms out the voice. Roll the die twice and add the score to Sonic's Quick Wits. If the result is 7 or more, turn to <b>277</b>. If the result is less than 7, then turn to <b>43</b>.",
		choices = new int[2] {277, 43}
	};

	public static Section section25 = new Section()
	{
		text = "This is getting heavy! Sonic and Tails are still trapped in the maze and all their rings are gone too. Go back to the maze and carry on. For each 5 points you get from now on, remove one of Sonic's Lives. If you are still in the maze and Sonic has no lives left, you <i>must</i> turn to <b>231</b>. Write this number down so you do not forget it.",
		choices = new int[0] {}
	};

	public static Section section26 = new Section()
	{
		text = "The sandy path leads into the jungle, running beneath huge palm trees. This is the sort of place that Coconuts would like to hang out in and both of them keep a wary eye on the tree-tops. In fact, they are so intent looking above them that the first either knew of the treasure chest was when Tails walked straight into it with a THUMP!\n\n'Ow!' says Tails, stubbing his paw against the half-buried chest.\n\nSonic looks at the large wooden chest that stands right in the middle of the pathway. 'Now, who would want to put a treasure chest in such an obvious position?'\n\n'Perhaps they dropped it,' says Tails rubbing his paw.\n\n'Or,' says Sonic, 'they, whoever they are, wanted us to find it.'\n\nDo you want Sonic to open the chest and see what's inside it (turn to <b>254</b>), or to leave the chest where it is (turn to <b>80</b>)?",
		choices = new int[2] {254, 80}
	};

	public static Section section27 = new Section()
	{
		text = "Sonic and Tails walk around a corner in the tunnel and, surprise surprise, come to another junction. Will they go to the left (turn to <b>261</b>), or will they carry straight on (turn to <b>103</b>)?",
		choices = new int[2] {261, 103},
		asteronSection = true
	};

	public static Section section28 = new Section()
	{
		text = "Following Whiffy's well-drawn map, our heroes have no trouble finding the secret little cove and, sure enough, tied up against one side is a sleek and powerful speedboat. Following the rest of Whiffy's instructions, the pair set off eastwards. Compared to the sailing boat, this one zooms along like the wind!\n\n'We'll be there in no time at this rate!' shouts Tails, straining to make his voice heard above the roar of the boat's engines.\n\nAbove them, the sky is a perfect blue, except for an odd little grey cloud. Sonic looks at it; something about the cloud wasn't quite right! Will Sonic take the speedboat to look at the cloud (turn to <b>142</b>), or will he head on towards the Casino Zone (turn to <b>183</b>)?",
		choices = new int[2] {142, 183}
	};

	public static Section section29 = new Section()
	{
		text = "Sonic stares at the paper for ages, but all he sees is a lot of scribble. 'Well that was a great help,' he says at last, rolling it up again.\n\n'Hmm. That's it then, nothing to worry about at all,' says Tails, with a silly look on his face. Sonic steps through the door and finds himself in a tunnel, lit by dim star-shaped lanterns hung along the wall. On some of the following sections you will see a * symbol. When you see it, roll the die. If the result is 1, then turn to <b>211</b>. Remember to make a note of the section number you were on, so that you can return to it!\n\nDo you think Sonic should go to the left (turn to <b>282</b>) or to the right (turn to <b>224</b>)?",
		choices = new int[2] {282, 224}
	};

	public static Section section30 = new Section()
	{
		text = "'I feel sure we're lost,' says Tails, after yet another ten minutes' walk.\n\n'OK,' says Sonic, annoyed. 'Tell me something I don't know! Why don't you go first for a change?'\n\nTails goes to the front and soon comes to a junction. So, what's Tails going to do now he has his big chance? Go to the left (turn to <b>282</b>) or to the right (turn to <b>103</b>)?",
		choices = new int[2] {282, 103},
		asteronSection = true
	};

	public static Section section31 = new Section()
	{
		text = "All three adversaries square up to each other - Zonik on one side and Tails and Sonic on the other. Sonic strikes first and misses. Zonik tries to clump him over the head as he goes by and misses again. Both aim a sweeping back kick at each other, then BOOOOOOOOM!!! There is a huge explosion. Zonik flies through the air in one direction and Sonic in the other. The emerald shoots up into the air. If only Tails can catch it.\n\nRoll the die and add 7 to the result. If your score is 10 or more, then turn to <b>234</b>. If your score is less than 10, turn to <b>76</b>.",
		choices = new int[2] {234, 76}
	};

	public static Section section32 = new Section()
	{
		text = "The cloud passes safely by and Zonik is even closer! At this rate he'll be caught in no time. Suddenly, a huge shadow appears above them, rapidly followed by a loud screeching.\n\n'That's all we need,' says Sonic, pointing to the awkward-looking Badnik floating above them. It's a Balkiry. It shouldn't prove too much trouble, but it's bound to slow them up. The Balkiry dives in to attack, and our friends will have to fight it.\n\nThe Balkiry has a fighting score of 6, but it is so clumsy that it can only attack every other turn. If Tails is flying the skimmer, then roll against Strength and add 2 to Sonic's score. If Sonic is flying it, then use Speed, but deduct 1 from the score. If Tails is hovering, then he can help Sonic, who fights with Agility. If they win, turn to 192. However, if they lose, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {192}
	};

	public static Section section33 = new Section()
	{
		text = "Just when it looks like Sonic is going to land in the oil, a gust of wind hits him and carries him on to the sandy beach of the island. He has impressed himself! Add 1 point to Sonic's Coolness. Turn to <b>128</b>.",
		choices = new int[1] {128}
	};

	public static Section section34 = new Section()
	{
		text = "One minute Sonic is walking down the steps, the next he and Tails are falling through the blackness. SPLOOOSH!!!\n\n'Oh no, what's this?' shouts Sonic.\n\n'Smells bad!' replies Tails. In the darkness, Sonic can just see his friend's face a few metres away. Sonic and Tails have fallen into a puddle of Mack ... Bad news!!! Deduct 1 point from Sonic's Good Looks score because he looks a wreck at the moment! Unfortunately there aren't any mirrors around, so both of them will just have to put up with the mess for a while. Up ahead there's another tunnel and no time for them to waste. Turn to <b>46</b>.",
		choices = new int[1] {46}
	};

	public static Section section35 = new Section()
	{
		text = "Once through the clouds, Sonic and Tails find themselves in a huge expanse of blue sky.\n\n'Look!' screams Tails, pointing. 'It's him!'\n\nSonic looks in the direction his friend is indicating and, sure enough, there is Zonik in his cloud skimmer. At last, our heroes are within striking distance! Zonik looks over his shoulder and realizes how close his pursuers are. The fight is on! Will Sonic and Tails attack Zonik from above (turn to <b>153</b>), or will they attack him from below (turn to <b>96</b>)?",
		choices = new int[2] {153, 96}
	};

	public static Section section36 = new Section()
	{
		text = "This time our heroes don't go so quickly, and they easily hit the bouncer and then jump up on top of it, scoring 5 points if this is the first time they have been here. Standing on top of the bouncer, they can both feel it throbbing under their feet. Perhaps they had better not stay here too long! Now roll the die. If the score is 1 or 2, you <i>must</i> turn to <b>298</b>. If the score is 3 or more, then Sonic and Tails can aim at another bouncer below them (turn to <b>189</b>), or they can aim at a large target (turn to <b>295</b>).",
		choices = new int[3] {298, 189, 295}
	};

	public static Section section37 = new Section()
	{
		text = "It's only a short way to this bouncer and both of them make it easily, scoring 5 points if this is the first time they have been here. Now roll the die. If the score is 1 or 2, you <i>must</i> turn to <b>298</b>. If the score is 3 or more, then Sonic and Tails can head for a bouncer some way above them (turn to <b>189</b>), or they can aim for the central spinner (turn to <b>124</b>).",
		choices = new int[3] {298, 189, 124}
	};

	public static Section section38 = new Section()
	{
		text = "On a normal day Sonic would quite happily have trashed Coconuts, but today was not an ordinary day! The coconuts were flying thick and fast now ... perhaps it would be better to leave the monkey to it. Turn to <b>144</b>.",
		choices = new int[1] {144}
	};

	public static Section section39 = new Section()
	{
		text = "Sonic sets off boldly around the corner, and realizes almost at once that he has made a BAD MISTAKE! The man sees Sonic, and his face goes purple with rage. 'So you're back, are you? Well, this time I'm ready,' he says, before charging towards Sonic, swinging the club straight at the hedgehog's head! This looks very much like another case of mistaken identity. Sonic will have to think and talk very fast to get out of this one! Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, then turn to <b>97</b>. If the score is less than 7, turn to <b>258</b>.",
		choices = new int[2] {97, 258}
	};

	public static Section section40 = new Section()
	{
		text = "The small sandy island looms on the horizon, and in no time the brave duo are only a hundred or so metres away. If Sonic and Tails are still in a small boat, then turn to <b>137</b>. If the boat has sunk already, turn to <b>273</b>.",
		choices = new int[2] {137, 273}
	};

	public static Section section41 = new Section()
	{
		text = "Bad news! Sonic's run out of credits again. If this is the best you, Sonic and Tails can do, it's no wonder Zonik is doing so well! All you can do now is start the adventure all over again, although it might be an idea to practise playing for a while before you do so!\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[0] {}
	};

	public static Section section42 = new Section()
	{
		text = "Sonic definitely knows where he is now. Through the archway they find themselves in a wide, low corridor. The walls are still made of the same dull metal, but there is no Mack and everywhere is brightly lit by neon lights in the ceiling.\n\nSonic points towards the end of the corridor. 'All we've got to do is get to the end, go through a little door on the right and we'll be at the gate,' he says. He and Tails set off, deeply relieved to be out of the maze. Up ahead, the corridor bends sharply to the left. 'Just around that corn -' Sonic suddenly falls silent, hearing voices approaching. Turn to <b>148</b>.",
		choices = new int[1] {148}
	};

	public static Section section43 = new Section()
	{
		text = "Sonic can't think why Robotnik is speaking to him like this. If Sonic has 10 rings, he may use the energy gun (turn to <b>289</b>). If he does not have 10 rings, or you think he should fight Robotnik, turn to <b>242</b>.",
		choices = new int[2] {289, 242}
	};

	public static Section section44 = new Section()
	{
		text = "The pole is about two metres high, with a round sign at the top.\n\n'I wonder what it is,' asks Tails.\n\n'I don't know, what does \"Bus Stop\" mean?' replies Sonic. They don't have to wait long to find out. Turn to <b>202</b>.",
		choices = new int[1] {202}
	};

	public static Section section45 = new Section()
	{
		text = "The gold door opens and Sonic and Tails find themselves careering down a long tunnel. The tunnel goes on and on, with our heroes travelling faster and faster as they fall.\n\n'This must go all the way to the bot –' Tails is cut off short as they tumble through a bonus gate. The gate clatters around, winning our game gurus no less than 40 points! Unfortunately though, they are now falling out of control towards the bottom of the game.\n\nSonic looks down. 'Oh NO!!!' He sees the gaping black hole screaming up towards them. 'Looks like it's game over!!!' Tails and Sonic tumble through the Game Over hole together. Turn to <b>135</b>.",
		choices = new int[1] {135}
	};

	public static Section section46 = new Section()
	{
		text = "The tunnels here are much smaller than before, and lit only by the eerie glow of the Mack. Sonic and Tails walk cautiously along the narrow raised walkway that stands about two metres above the floor of the tunnel.\n\nSonic looks down at his trainers. Euugghh!! He really will have to do something about them as soon as he gets a chance. Tails doesn't look much better either. Sonic is about to say something when there is a loud clang behind them. Spinning round, Sonic is just quick enough to see a massive steel shutter drop behind them, cutting off their retreat! Both of the little heroes look at each other, then Tails says, 'What's that?' He tilts his head, listening intently.\n\n'What's what?' replies Sonic.\n\n'That gurgling noise ...' answers Tails, his ears swivelling round to pick up the source of the sound. Sonic can hear it now as well. 'Search me, there are lots of strange noises round here. Come on, we've got to get moving. I need to find somewhere to sort out these trainers!'\n\nIn most of the following sections you will see a * symbol. Every visit to one of these sections counts as 1 point. If at any time your point score exceeds 20, turn to <b>288</b>. Write this number down so you will remember it.\n\nThe tunnel branches to the left and to the right. If you want them to follow the left tunnel, turn to <b>239</b>. If you think Sonic and Tails should follow the right one, turn to <b>188</b>.",
		choices = new int[2] {239, 188}
	};

	public static Section section47 = new Section()
	{
		text = "No trouble, whatsoever. Sonic leaps through the air and with one deft flick of the wrist, the lever has been pulled. Almost immediately, the platforms whirr into action behind him. Turn to <b>233</b>.",
		choices = new int[1] {233}
	};

	public static Section section48 = new Section()
	{
		text = "This branch of the tunnel is well lit and really quite clean for a change.\n\n'So, Sonic,' says Tails, 'how exactly are we going to \"persuade\" Robotnik to tell us what is going on?'\n\nSonic hesitates, the truth was that he didn't have a clue. Of course he couldn't possibly admit that, so in the end he simply says, 'Have faith, old friend, I'll think of something, you'll see.'\n\nThey carry on walking for a few more minutes, and then they turn a corner in the tunnel and come face to face with something really rather strange. Lying in the middle of the tunnel floor is a large pile of rings.\n\n'There must be over fifty there, Sonic. What a stroke of luck!' exclaims Tails. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, then turn to <b>145</b>. If the score is less than 7, turn to <b>92</b>.",
		choices = new int[2] {145, 92}
	};

	public static Section section49 = new Section()
	{
		text = "Very gently, Sonic reaches over and presses the large red button marked Start! There is a click, and then a rumble behind them. Suddenly, there is a loud WHOOOSH, and a blast of air catches Tails and Sonic. The wind carries them up the ramp towards the start of the game.\n\n'It's a lot gentler than the old spring,' yells Sonic, though judging from Tails' expression, he's not convinced! Up ahead they can see the top of the ramp approaching at a terrific speed. Suddenly the ramp curves back on itself and they find themselves falling uncontrollably.\n\nRoll the die and add the result to Sonic's Strength. If the score is 10 or more, turn to <b>203</b>. If the score is less than 10, then turn to <b>168</b>.",
		choices = new int[2] {203, 168}
	};

	public static Section section50 = new Section()
	{
		text = "Sonic sees the floor open underneath him, but it's too late and he finds himself falling to the floor below.\n\n'OOOF!' It was just far enough to hurt. Fortunately, his pride is the only thing that's really been damaged. Sonic looks up at the smooth, sheer walls, but there's no way out. All he can do is press the red Return button. Turn to <b>187</b>.",
		choices = new int[1] {187}
	};

	public static Section section51 = new Section()
	{
		text = "Tails twists and turns around the clouds, skilfully avoiding each one. He's such a natural at flying that even Sonic is impressed! Turn to <b>35</b>.",
		choices = new int[1] {35}
	};

	public static Section section52 = new Section()
	{
		text = "It was not easy seeing off Chop Chop, the deck of a small boat not being the ideal place from which to fight! The boat hasn't fared so well, unfortunately, and now it has several large holes in it.\n\n'I hope we find somewhere to land soon,' says Tails, looking at the battered hull.\n\n'What about that small island over there?' replies Sonic.\n\nTails strains his eyes and, sure enough, there is an island! 'Well, at least luck's on our side today,' whispers Tails to himself. Turn to <b>40</b>.",
		choices = new int[1] {40}
	};

	public static Section section53 = new Section()
	{
		text = "Although it appears terrifying, the Badnik doesn't look all that stable. One well-timed push might just send it rolling over like a turtle. Patiently, our friends wait for the right moment, and then charge the Badnik with all their strength. They hit the side of it at exactly the same time – perfection. The robot wobbles, then tilts and with a mighty CRASH rolls over upside-down!\n\n'WYYNNNNN ... PERPPPS ... ZZZZZzzzzzz ... z ... ' it goes and then falls silent.\n\n'Outstanding! Get a new pair of trainers for that one!' exclaims Tails.\n\n'You weren't so bad yourself, old friend,' replies Sonic. Turn to <b>249</b>.",
		choices = new int[1] {249}
	};

	public static Section section54 = new Section()
	{
		text = "Even though Sonic uses every bit of charm he possesses, the commissionaire is not convinced. There is no way that he will allow Sonic in his casino. Sonic is unceremoniously thrown out, along with Tails. With no chance of getting through the casino, Sonic's quest is now hopeless. Both he and Tails, unfortunately, have to go back to the beginning of this game and start again. YOUR ADVENTURE ENDS HERE",
		choices = new int[0] {}
	};

	public static Section section55 = new Section()
	{
		text = "'This one terminates at the city centre. Take your seats, please.' Sonic and Tails sit down and the bus moves off.\n\n'Well, I suppose it beats walking,' says Tails as he looks out of the window. Outside the landscape rushes past, the bus really is moving very quickly and in no time at all the gates of Metropolis loom in front of them.\n\n'We're going to have to be careful in here, Tails,' says Sonic. 'I think the best thing to do is to pretend I'm Zonik.'\n\n'What about me, then?' asks Tails.\n\n'Perhaps you can be Taylz or something,' replies Sonic.\n\nThe bus finally comes to a stop in a large square in the middle of the city. Metropolis is a very busy place, and there are people and robots everywhere – although none of them seems to be taking any notice of our friends. Where will they go from here? Will they explore the area on foot (turn to <b>259</b>), or will they head for the subway (turn to <b>64</b>)?",
		choices = new int[2] {259, 64}
	};

	public static Section section56 = new Section()
	{
		text = "After only a few hundred metres, even the inside of the tunnel is as black as night and the stench of oil is becoming unbearable. The two friends stop and look at each other, only the whites of their eyes visible in the darkness.\n\n'I don't know about you, Tails, but I have had enough of tunnels for a while,' says Sonic.\n\n'The boat then?' suggests Tails.\n\n'Yeah, let's go back and try the boat,' Sonic replies. Turn to <b>206.</b>",
		choices = new int[1] {206}
	};

	public static Section section57 = new Section()
	{
		text = "Suddenly, the robots realize what is going on and move in to attack our heroes. There are so many that Tails will not be able to help Sonic - he has enough to do himself.\n\nSonic can fight robots using whatever ability he wants (you choose). Because they are so clumsy, only one robot can attack at a time. There are six robots queuing up to deal with him, and Sonic must fight them one after another.\n\n\t\t\t\tFighting Score\t\tHits to Destroy\nRobot 1\t\t5\t\t1\nRobot 2\t\t5\t\t1\nRobot 3\t\t5\t\t2\nRobot 4\t\t5\t\t2\nRobot 5\t\t6\t\t2\nRobot 6\t\t6\t\t3\n\nWhen a robot is destroyed, it will release 10 rings that Sonic can pick up. Remember to add them to Sonic's Stuff. If Sonic wins, he and Tails can destroy the rest of the machines in peace (turn to <b>208</b>). If the robots win, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {208}
	};

	public static Section section58 = new Section()
	{
		text = "With a short but powerful spin, Sonic speeds around the corner. He is followed by Tails, hovering a metre or so above the floor. The owner of the deep metallic voice is easy to spot. Standing a few metres in -front of our heroes is Grabber, the plant's very own metal spider. The other ... was Sonic! Or at least a thing that looked just like Sonic. 'That's the thing that attacked me,' exclaims Tails. 'It's Zonik!' Both Grabber and Zonik turn around and look straight at the real Sonic and Tails. Turn to <b>5</b>.",
		choices = new int[1] {5}
	};

	public static Section section59 = new Section()
	{
		text = "Sonic and Tails walk up to the door labelled 'Spine Fields' and listen carefully. They can hear nothing. 'Ah well, only one thing for it!' says Sonic, and he kicks the door. It swings open! Inside, they see a large room with rows of glass dishes neatly lying on the ground. Above, giant spotlights shine down on them.\n\n'You know, Sonic, this place reminds me of a greenhouse,' says Tails, looking up at the spotlights.\n\nSonic takes a closer look at the dishes, each of them contains a tiny pulsating blob of blue gunge. They smell distinctly Eggy! By the far wall, there is a door labelled 'Production Line'. What should Sonic and Tails do?\n\nGo and look in the other room (if they haven't been there already)?\t\t\tTurn to <b>236</b>\nSmash the place up?\t\t\tTurn to <b>62</b>\nGo through the door labelled 'Production Line'?\t\t\tTurn to <b>248</b>",
		choices = new int[3] {236, 62, 248}
	};

	public static Section section60 = new Section()
	{
		text = "Leaning forward, Sonic gingerly reaches out with a paw and tries the lid of the chest. It's not locked.\n\n'Here we go, then,' says Sonic, and with a flick of the wrist the lid is open. Peering inside they can see GOLD! Unable to resist the temptation, Tails reaches out a paw to touch it. BOOM! The chest was trapped. Both Sonic and Tails are thrown back by the explosion to land with a thump on the ground. Deduct 1 point from Sonic's Strength <i>or</i> remove 10 rings from Sonic's Stuff, the choice is yours. Turn to <b>80</b>.",
		choices = new int[1] {80}
	};

	public static Section section61 = new Section()
	{
		text = "The tunnel slowly curves around to the right, its grey metal walls covered in a film of Mega Mack. Here and there, there are even puddles of it on the floor. Being careful to avoid these, Sonic and Tails slowly walk along, trying to think of anything to take their minds off the awful smell! After a little while, they come to another branch in the tunnel. What should Sonic and Tails do:\n\nFollow the left-hand tunnel?\t\t\tTurn to <b>101</b>\nFollow the right-hand tunnel?\t\t\tTurn to <b>89</b>",
		choices = new int[2] {101, 89}
	};

	public static Section section62 = new Section()
	{
		text = "Sonic and Tails set about the place! Sonic spins around like a maniac, smashing everything within reach. Tails is a little slower, but he manages his fair share and in no time the whole place is a wreck. Roll the die. If the score is 1 or 2, turn to <b>275</b>. If the score is 3 or more, what should Sonic and Tails do:\n\nGo and look in the other room (if they haven't been there already)?\t\t\tTurn to <b>236</b>\nGo through the door labelled 'Production Line'?\t\t\tTurn to<b>248</b>",
		choices = new int[2] {236, 248}
	};

	public static Section section63 = new Section()
	{
		text = "The poor post has been well and truly mashed! Even with Sonic's super-strength, he cannot raise it. After half an hour of trying, he decides to leave it where it is. The view from the hilltop is superb and in the distance Sonic can see a little river with a bridge, and beyond that a small wood.\n\n'That looks like a good way to go,' says Sonic out loud. Turn to <b>177</b>.",
		choices = new int[1] {177}
	};

	public static Section section64 = new Section()
	{
		text = "Sonic and Tails find themselves in a broad, well-lit tunnel. High above them they can hear the hustle and bustle of the city, but down here all is quiet. Which way will they go now:\n\nTo the right?\t\t\tTurn to <b>241</b>\nTo the left?\t\t\tTurn to <b>48</b>",
		choices = new int[2] {241, 48}
	};

	public static Section section65 = new Section()
	{
		text = "Tails sees the gate to the Casino Zone first, and points it out to Sonic. The glaring neon signs above are a very welcome sight. Without slowing down at all, Sonic aims the boat straight at the gate.\n\n'We're going to CRASH!!' screams Tails.\n\n'No we're NOT!' shouts Sonic, and a split second before they reach the gate, Sonic grabs Tails and goes into a spin that carries both him and his furry friend flying through the gate. Turn to <b>226</b>.",
		choices = new int[1] {226}
	};

	public static Section section66 = new Section()
	{
		text = "Leaving the fruit machine behind, Sonic and Tails walk further into the casino. Surprisingly, the place is deserted. Usually the casino is bustling with creatures from all over Mobius who've come to play the games.\n\n'Let's go and look at the pinball machines,' says Sonic. 'They're cool.'\n\nThe casino was famous for its pinball machines, though even Sonic had to admit that they had been a bit of a pain when Robotnik had had a go at them, but that was all in the past.\n\n'All right then,' says Tails. 'But just a quick look.'\n\nSonic is already charging off towards the pinball hall before Tails finishes speaking. Turn to <b>113</b>.",
		choices = new int[1] {113}
	};

	public static Section section67 = new Section()
	{
		text = "At last the mighty Rexon has been beaten, and he is now just a pile of scrap at Sonic's feet. Rexons are known to be great collectors of rings, and not far away Tails manages to find a hoard of twenty-five of the little beauties. Add them to Sonic's Stuff. Now it's time to get back to the heli-chopper and the Mystic Cave. Turn to <b>121</b>.",
		choices = new int[1] {121}
	};

	public static Section section68 = new Section()
	{
		text = "Sonic reaches out and presses the red button. The skimmer's engines spring to life. Sonic pulls the joystick back and the skimmer flies into the air.\n\n'See, old friend, nothing to this flying. Anyone can do it!' The skimmer judders and wobbles as Sonic struggles to control it.\n\n'Push the stick forward!' shouts Tails. Sonic does it and the skimmer moves off after Zonik. Even Sonic thinks it might have been better to have let Tails fly the skimmer! Turn to <b>114</b>.",
		choices = new int[1] {114}
	};

	public static Section section69 = new Section()
	{
		text = "The little boat bobs its way quite happily across the sea, apparently just as good at floating on oil as on water. Neither Sonic nor Tails has any idea how long the voyage is going to take. The Aquatic Ruin is huge, and it always took Sonic and Tails ages to get through the normal way.\n\nSonic is pondering this problem, when the sea suddenly bursts into a fountain right in front of the boat. A split second later, it is followed by a sleek silver shape. The shape makes straight for the boat, a huge mouth opening to reveal row upon row of sharp teeth. In an instant the boat is hit, and the prow becomes a radically different shape!\n\n'CHOP CHOP!' exclaims Tails. Should Sonic and Tails stay and fight Chop Chop (turn to <b>193</b>), or should they try and sail the boat away (turn to <b>279</b>)?",
		choices = new int[2] {193, 279}
	};

	public static Section section70 = new Section()
	{
		text = "'Do you know something,' says Sonic, 'when this adventure's over, it would be really cool to spend just a few hours playing a game or something.'\n\n'Too right,' says Tails. 'And get a burger or two in as well!'\n\nSonic and Tails can either go to the left (turn to <b>27</b>) or to the right (turn to <b>268</b>).",
		choices = new int[2] {27, 268},
		asteronSection = true
	};

	public static Section section71 = new Section()
	{
		text = "A brilliant blue beam shoots out of the energy gun and surrounds the hover ship in an odd blue mist. 'Come on, Tails, let's GET OUT OF HERE!!!' Sonic screams, slamming the boat into gear. Thanks to the energy gun, Sonic and Tails have escaped. Turn to <b>65</b>.",
		choices = new int[1] {65}
	};

	public static Section section72 = new Section()
	{
		text = "Sonic and Tails start destroying the place! Sonic spins around like a maniac, smashing everything in his path. Tails is a little slower, but he manages his fair share and in no time everything is a wreck. Roll the die. If the score is 1 or 2, turn to <b>275</b>.\n\nIf the score is 3 or more, what should Sonic and Tails do?\n\nGo and look in the other room (if they haven't been there already)?\t\t\tTurn to <b>59</b>Go through the door labelled 'Production Line'?\t\t\tTurn to <b>248</b>",
		choices = new int[3] {275, 59, 248}
	};

	public static Section section73 = new Section()
	{
		text = "The inside of the hut is very dim, and although Sonic and Tails strain their eyes, they cannot see very far inside. But they can hear something breathing and moving about! Raising his paw, Sonic knocks politely on the door.\n\n'Who is it?' splutters a voice from inside. It was the muffled voice of a person with a cold.\n\n'Sonic -' a sharp nudge in the ribs reminds Sonic to say,'- and Tails, of course.'\n\n'Come in, then,' says the voice.\n\nIt takes a few seconds for their eyes to get used to the darkness of the hut, but then Sonic and Tails can see a small homely room. Sitting in a well-stuffed armchair is the owner of the hut. Turn to <b>91</b>.",
		choices = new int[1] {91}
	};

	public static Section section74 = new Section()
	{
		text = "Despite a thorough search of the cave, neither Tails nor Sonic finds anything. It looks like the only way out of this cave is to try and open the steel door. Sonic and Tails look at the lever by its side.\n\n'After you,' says Sonic, gesturing for Tails to try the lever.\n\n'No, after you,' replies Tails.\n\n'No, really,' says Sonic.\n\n'No, you try it, Sonic. I insist!' smiles Tails, bowing gracefully to his friend.\n\nGingerly, Sonic reaches out and pulls the lever, and the door slides open with a faint wooshing sound. 'There you are! Nothing to it,' says Sonic.\n\n'Let's hope you feel the same way about those, then!' says Tails, pointing to the two Guardbots who have suddenly appeared!\n\nSonic and Tails must fight the Guardbots using Strength. The Guardbots have a fighting score of 5, but both can attack Sonic each round. Tails will help Sonic. If our heroes win, turn to <b>256</b>. If Sonic and Tails are beaten by the Guardbots, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {256}
	};

	public static Section section75 = new Section()
	{
		text = "How will Sonic pick up the needle? If he uses his hands, turn to <b>140</b>. If he uses a pair of tweezers (if he has them ... the Zone Chip might help!), turn to <b>219</b>.",
		choices = new int[2] {140, 219}
	};

	public static Section section76 = new Section()
	{
		text = "As the emerald flies through the air, Tails hovers and reaches out for the gem with both paws. He misses it, and it sails through the air into the paws of the waiting Zonik!\n\n'You want some of this?' says Zonik waving the emerald at Tails.\n\nSonic is back on his feet now and he looks on in horror at what has happened.\n\n'It would be so easy to destroy you now,' snarls Zonik. 'But I think I shall save that pleasure till later.' With that, he goes into a supersonic spin and vanishes.\n\nThe explosion destroyed all of Sonic's rings (if he didn't have any, then he loses a life instead). It also broke the energy gun, though Sonic hangs on to it, in case he meets someone who can fix it! Depressed by this failure, Sonic and Tails make their way out of the cave. Turn to <b>191</b>.",
		choices = new int[1] {191}
	};

	public static Section section77 = new Section()
	{
		text = "The door leads into a room so dark that neither Sonic nor Tails can see further than their noses. Groping around, Tails suddenly says, 'I think I've got something here, Sonic.'\n\nTails passes the object to Sonic and a few seconds later the room is lit up by the beam from a torch in Sonic's hand.\n\n'Nice find, Tails,' says Sonic as he plays the beam around the room and to his delight sees a pile of 10 rings in the far corner! Add them and the torch to Sonic's Stuff. The only way out of this room is to leave the way the heroes came in. Turn to <b>101</b>.",
		choices = new int[1] {101}
	};

	public static Section section78 = new Section()
	{
		text = "Sonic desperately tries to control the cloud skimmer as it flies through the clouds. One touch and our heroes will be done for! Roll the die and add the result to Quick Wits. Then roll the die again and add the result to Sonic's Agility. If both scores are 7 or more, turn to <b>35</b>. If either score is less than 7, turn to <b>165</b>.",
		choices = new int[2] {35, 165}
	};

	public static Section section79 = new Section()
	{
		text = "Sonic pulls out the torch and the passage is illuminated in a bright white light. Up ahead, he can see that the passage opens into a large cavern. Pointing the torch at the ground reveals something strange.\n\n'Look at that. What do you make of it, Tails?' asks Sonic. The floor of the cave is covered in scuffs and scratches.\n\n'Looks like something heavy has been dragged this way,' replies Tails.\n\n'Yes, and look at this!' Sonic stoops and points at the ground.\n\n'It's a spine just like yours!' exclaims Tails.\n\n'Yep. I reckon our friend Zonik is pretty close.'\n\n'What about these scratches though? And look at those lumps of metal,' says Tails, pointing out some jagged pieces of steel a little way up the passage.\n\nShould Sonic and Tails go and look in the big cavern (turn to <b>88</b>), or should they retrace their steps and explore the other passageway (turn to <b>267</b>)?",
		choices = new int[2] {88, 267}
	};

	public static Section section80 = new Section()
	{
		text = "After another short walk, the pathway opens into a large clearing in the jungle. In the middle is a small hut made of twigs, leaves and other bits and pieces from the forest. From the small chimney comes a thin wisp of white smoke. There must be someone at home! Should Sonic and Tails go and see who lives in the hut (turn to <b>73</b>), or should they carry on looking for some way off the island (turn to <b>266</b>)?",
		choices = new int[2] {73, 266}
	};

	public static Section section81 = new Section()
	{
		text = "Sonic crouches down and pulls the lever. It's a bit stiff, but eventually it moves. He waits for a second or so, but nothing happens. It looks like the only way out of this cave is to try and open the steel door. Sonic and Tails look at the lever by the side of the door.\n\n'After you,' says Sonic, gesturing for Tails to try the lever.\n\n'No, after you,' replies Tails.\n\n'No, really,' says Sonic.\n\n'No, you try it, Sonic. I insist!' smiles Tails, bowing gracefully to his friend.\n\nGingerly, Sonic reaches out and pulls the lever. The door slides open with a faint wooshing sound.\n\n'There you are. Nothing to it,' says Sonic. Turn to <b>256</b>.",
		choices = new int[1] {256}
	};

	public static Section section82 = new Section()
	{
		text = "Soon, the casino is left far behind and the heli-chopper is cruising high above the peaks and volcanoes of the Hilltop Zone.\n\n\'I'm pleased we don't have to get through that lot on foot,' says Tails.\n\n'Yeah, me too,' agrees Sonic, remembering a previous run-in with a Rexon. Down below, something glints among the hills.\n\n'I wonder what that is,' says Sonic, pointing to the object through the window.\n\n'Well, there's a lever here that says \"Land\", if you want to have a look ...' suggests Tails.\n\nShould Sonic land the heli-chopper (turn to <b>105</b>), or should they ignore whatever it is and carry on towards the Mystic Caves (turn to <b>67</b>)?",
		choices = new int[2] {105, 67}
	};

	public static Section section83 = new Section()
	{
		text = "This tunnel only goes on for a few metres before dividing into three. Which tunnel will they follow now:\n\nThe right-hand one?\t\t\tTurn to <b>103</b>\nThe middle one?\t\t\tTurn to <b>141</b>\nThe left-hand one?\t\t\tTurn to <b>224</b>",
		choices = new int[3] {103, 141, 224},
		asteronSection = true
	};

	public static Section section84 = new Section()
	{
		text = "The fruit machine whirrs into action, while Sonic and Tails stare at it. A WINNER!!! Roll the die twice and add the scores together. This is the number of rings that the fruit machine pays out! Add these to Sonic's Stuff.\n\nIf you want Sonic to play the fruit machine again, turn to <b>171</b>. If you think he should stop wasting time, turn to <b>97</b>.",
		choices = new int[2] {171, 97}
	};

	public static Section section85 = new Section()
	{
		text = "Tails climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, but Tails has the advantage of being a natural flyer. Reaching out, he presses the red button, and the skimmer's engines spring to life. Then he pulls the joystick back and the skimmer flies into the air. Turn to <b>68</b>.",
		choices = new int[1] {68}
	};

	public static Section section86 = new Section()
	{
		text = "The super duo speed out into the game at terrific speed. Hurtling towards them, they can see a large target flashing with bright green lights. First Sonic, and then Tails, hits the target square in the middle. If this is the first time that Sonic and Tails have been to this target, they have scored 10 points. Add them to Sonic's Point Score.\n\nNow roll the die and add the result to Sonic's Speed. If the score is less than 6, turn to <b>283</b>. If the score is 6 or more, then Sonic and Tails may go to:\n\nA bouncer\t\t\tTurn to <b>20</b>\nAnother bouncer\t\t\tTurn to <b>265</b>\nThe central spinner\t\t\tTurn to <b>124</b>",
		choices = new int[4] {283, 20, 265, 124}
	};

	public static Section section87 = new Section()
	{
		text = "Sonic gets out the small bag labelled 'Sky Net'.\n\n'Looks like a good time to try using this thing,' he shouts to Tails. The bag has a small label attached to it marked 'Instructions'. It reads: 'Throw bag at enemy'.\n\n'Oh well, here we go, then,' says Sonic as he throws the bag at Zonik's cloud skimmer. The bag flies through the air. There is a bright flash and a gigantic mega net appears out of nowhere. Zonik flies straight into it and his skimmer is instantly entangled.\n\n'ALL RIGHT!' yells Tails.\n\nZonik's skimmer spirals out of control towards the planet's surface. Sonic and Tails follow. Turn to <b>214</b>.",
		choices = new int[1] {214}
	};

	public static Section section88 = new Section()
	{
		text = "The passage walls open out above their heads. The cavern is very large and, even with the torch, its middle is hidden by an inky blackness. Suddenly, Tails' foot hits something hard.\n\n'Grrrrr! Gnssh!' growls the unseen thing.\n\nTails feels something shoot past his leg. 'SONIC! There's something in here!'\n\n'GNSSSH!!!'\n\nSonic can see it now! Dimly lit, a few metres away is the unmistakable outline of a Crawlton! Turn to <b>129</b>.",
		choices = new int[0] {}
	};

	public static Section section89 = new Section()
	{
		text = "The tunnel goes on and on, all the time slowly curving to the right. Here and there are odd tangles of pipes, piles of oily rags and other rubbish stacked along the edges of the tunnel. After a few minutes, Tails stops and says, 'Look, Sonic ... a door!'\n\nTails is right. Over on the right-hand wall is a small rusty door, half open. Should Sonic and Tails go through the door (turn to <b>77</b>), or should they continue down the tunnel (turn to <b>101</b>)? '",
		choices = new int[2] {77, 101}
	};

	public static Section section90 = new Section()
	{
		text = "The two skimmers twist and turn this way and that all over the sky. Eventually, Sonic and Tails' skimmer can't take any more. It buckles under yet another of Zonik's flying kicks and spirals out of control towards the planet's surface. Zonik follows! Turn to <b>214</b>.",
		choices = new int[1] {214}
	};

	public static Section section91 = new Section()
	{
		text = "'Hi, I'm Whiffy. Pleased to meet you,' the furry black-and-white creature says, holding out a paw towards Sonic.\n\n'Hello,' replies Sonic.\n\n'I've heard a lot about you,' says Whiffy. 'I used to live in the Green Hills a few years ago, but being a skunk doesn't tend to make you very popular, so I came to live here.' Whiffy goes on to tell Sonic and Tails that he has seen lots of Robotnik' s Badniks around lately, and that they seem to be looking for something, though unfortunately he doesn't know what.\n\nAfter a long chat, Whiffy gives Sonic a map. 'This will show you the way to a speedboat that's moored on the other side of the island. There are even instructions on how to drive it on the other side of the map!'\n\nJust as Sonic and Tails are about to leave, Whiffy says, 'Oh, one more thing, take this, it might come in useful sometime.' He hands over a small brown bottle with a cork jammed tightly into it. Add this to Sonic's Stuff and then turn to <b>28</b>.",
		choices = new int[1] {28}
	};

	public static Section section92 = new Section()
	{
		text = "Just as they both reach the rings, a large net falls from the roof and catches Sonic and Tails underneath it. A TRAP! They struggle for a few minutes, but it is no use - they are held fast.\n\n'If you don't want to be captured, you'd best come with us,' squeals a high-pitched voice. Several small furry creatures appear. They start to chew away at the net with their small pointed teeth and in no time our heroes are free.\n\n'Come quickly ... very quickly,' warns one of the creatures. Sonic and Tails have been taken by surprise. The creatures don't look very friendly but, then again, they haven't attacked.\n\n'Quickly, quickly. Come with us, or the robots will be here,' warns the leader of the creatures.\n\nShould Sonic and Tails go with the creatures (turn to <b>11</b>), or should they try to run away (turn to <b>213</b>)?",
		choices = new int[2] {11, 213}
	};

	public static Section section93 = new Section()
	{
		text = "Our heroes have seen off the Slicer, and they take a short breather. Suddenly, the rubbish around them starts to heave and jerk. Another Slicer appears and then another, and another – there are hundreds of them.\n\n'I don't think this is a good place to be right now,' says Sonic rather obviously. 'Come on, Tails! Run!!!'\n\nLuckily for both of them, the Slicers aren't very fast and they soon manage to escape. Unfortunately, it looks like using the footpath is out of the question. Should Sonic and Tails go to the raft (turn to <b>257</b>), or to the strange-looking pole (turn to <b>44</b>)?",
		choices = new int[2] {257, 44}
	};

	public static Section section94 = new Section()
	{
		text = "Quick as a flash, Sonic flips over backwards and catches the bouncer with his foot and Tails with his right paw, dragging himself and his friend round on to the bouncer. They score 5 points if this is the first time they have been here. Now our friends can either bounce back to the spinner (turn to <b>124</b>), or they can jump to another bouncer on the right (turn to <b>37</b>).",
		choices = new int[2] {124, 37}
	};

	public static Section section95 = new Section()
	{
		text = "'This one stops just inside the West Gate. Take your seats, please.'\n\nSonic and Tails sit down, and the bus moves off. 'Well, I suppose it beats walking,' says Tails as he looks out of the window. Outside the landscape rushes past, the bus really is moving very quickly and in no time at all the gates of Metropolis loom in front of them.\n\n'We're going to have to be careful in here, Tails,' says Sonic. 'I think the best thing to do is to pretend I'm Zonik.'\n\n'What about me then?' asks Tails.\n\n'Perhaps you can be Taylz, or something,' replies Sonic.\n\nThe bus finally comes to a stop and its door opens. Metropolis is a very busy place, and there are people and robots everywhere, although none of them seems to be taking any notice of our friends. Where will they go from here?\n\nExplore the area on foot?\t\t\tTurn to <b>259</b>Head for the subway?\t\t\tTurn to <b>64</b>",
		choices = new int[2] {259, 64}
	};

	public static Section section96 = new Section()
	{
		text = "Our friends go into a shallow dive to pick up speed, and they are soon directly below Zonik' s cloud skimmer. Then, climbing again, they fly to within touching distance of the enemy! Turn to <b>158</b>.",
		choices = new int[1] {158}
	};

	public static Section section97 = new Section()
	{
		text = "Using every bit of charm he's got, Sonic manages to persuade the man. Sonic discovers that he is the casino's commissionaire (a very important person!). Sonic tells the commissionaire that it was Zonik, and not himself, who was responsible for all the damage to the casino. Furthermore, Sonic offers to help the commissionaire put right all the damage. Turn to <b>2</b>.",
		choices = new int[1] {2}
	};

	public static Section section98 = new Section()
	{
		text = "Sonic can't believe what is happening. Tails has been his friend ever since he can remember. Determined to catch up with Tails, Sonic leaps off the platform and tumbles expertly on to the floor of the valley with not a single spine out of place.\n\nTails is already a long way off up the valley, and Sonic hares off after him. Sonic moves a lot faster than Tails, and he is catching him up easily when disaster strikes. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>154</b>. If the score is less than 7, turn to <b>284</b>.",
		choices = new int[2] {154, 284}
	};

	public static Section section99 = new Section()
	{
		text = "Our heroes decide to go by the normal route, despite the fact that everything is covered in horrible, sticky black oil. The jetty leads slowly down into the tunnel disappearing under the waves. Usually, this tunnel allows excellent views of the teeming fish that live round the city, but today all Sonic and Tails can see is the pitch-black sludge of oil. Turn to <b>56</b>.",
		choices = new int[1] {56}
	};

	public static Section section100 = new Section()
	{
		text = "A hedgehog, even a blue one, could very easily go mad in a place like this. Soon Sonic and Tails find themselves at another junction. Check the number of points you have scored so far. If it's more than 20, turn to <b>288</b>. If you have scored less than 20, where will Sonic and Tails go now?\n\nFollow the left tunnel?\t\t\tTurn to <b>125</b>\nStay in this tunnel?\t\t\tTurn to <b>272</b>",
		choices = new int[2] {125, 272},
		mackSection = true
	};

	public static Section section101 = new Section()
	{
		text = "After what seems like ages, the tunnel opens out into a huge domed room, its walls lined with a maze of pipes. The air is filled with hissing and gurgling and the sound of distant machinery. This is definitely not a nice place! 'I'm beginning to wonder whether it was such a good idea to come in here,' says Tails.\n\nSonic looks around and thinks. So far they haven't seen a single sign of the impostor Sonic since they entered the plant. If it wasn't for the fact that the buggy had been broken, Sonic would have doubted whether the impostor existed at all. Maybe it was just Tails and his imaginations? 'He must have come this way, Tails. All we've got to do is find him.'\n\nTails, who was still holding his nose, replies, 'Well, I hope we find this other Sonic soon. I don't think that I can stand this smell much longer.' Now, since Tails had his nose pinched, the words sounded a little different. Tails had meant to say Sonic, but what he actually said was Zonik. 'At least we've got a name for the impostor now ... we'll call him Zonik!'\n\nTurn to <b>217</b>.",
		choices = new int[1] {217}
	};

	public static Section section102 = new Section()
	{
		text = "Somehow the fearless duo have managed to beat the hover ship, which slowly spirals down before crashing into the oil. Sonic and Tails hear the ship hit some rocks, just below the surface of the oil. 'Sparks pierce the darkness and the oil catches light!\n\n'Do you think Robotnik was really in there?' asks Tails. Sonic looks at him and shrugs.\n\n'Come on, Tails, let's GET OUT OF HERE!!!' Sonic screams, slamming the boat into gear. Turn to <b>65</b>.",
		choices = new int[1] {65}
	};

	public static Section section103 = new Section()
	{
		text = "The tunnel slowly begins to wind downhill, and become really rather dark. Eventually, our friends find themselves at yet another intersection. Should they go:\n\nTo the right?\t\t\tTurn to <b>83</b>\nTo the left?\t\t\tTurn to <b>224</b>\nStraight on?\t\t\tTurn to <b>282</b>",
		choices = new int[3] {83, 224, 282},
		asteronSection = true
	};

	public static Section section104 = new Section()
	{
		text = "Standing a few paces in front of him is the familiar figure of his friend Tails, who has, it must be said, a rather odd look in his eye. There is a terrible silence, that seems to last ages, before Tails finally reaches out with a tree branch. Sonic gratefully grabs it. Tails pulls the soaking hedgehog out of the water. Turn to <b>3</b>.",
		choices = new int[1] {3}
	};

	public static Section section105 = new Section()
	{
		text = "Sonic pulls the lever that says 'Land' and the heli-chopper does just that, gliding slowly down to the ground only a few metres away from the shiny object.\n\nSonic and Tails climb out of the machine to have a closer look at the thing. It's a silver dome, half buried in some mud. The dome is about half a metre across. Something about it is familiar to Sonic, but he can't quite figure out what it is. Suddenly, the dome moves and Sonic and Tails both realize what they've been looking at. The gigantic head of a Rexon slowly rises from the mud. Our heroes have just been looking at its top!\n\nThere might still be time to run to the heli-chopper and get out of here. Should Sonic and Tails do this (turn to <b>263</b>), or should they stand and fight the Rexon (turn to <b>220</b>)?",
		choices = new int[2] {263, 220}
	};

	public static Section section106 = new Section()
	{
		text = "The hills looked just like Sonic expected them to look - all green and, well, hilly. Sonic stopped. Up ahead was one of the star posts. Usually he could see it from far away, its light shining out like a beacon. Today Sonic couldn't see it at all.\n\n'That's strange,' he said. Sonic had been to the post so many times that even if he couldn't see it, he could still find it. This fact didn't make the discovery he was about to make any easier.\n\nAfter a few more steps, Sonic discovered why he hadn't been able to see the post, for, in a little hollow in the hillside, there was a black and twisted lump of metal about two metres long. That was all that remained of the post! Who could have done such a thing? Sonic stared down at the post. Should he try to repair it (turn to <b>63</b>), or should he move on and find out what is going on (turn to <b>155</b>)?",
		choices = new int[2] {63, 155}
	};

	public static Section section107 = new Section()
	{
		text = "Sonic reaches for the tube of glue that the rats gave him. With a careful shot he might be able to jam the Badnik' s missile launchers. Sonic takes aim and squeezes the tube. The glue shoots through the air in a graceful arc. A direct hit! The glue seeps into the missile launchers, but it has no effect whatsoever! All the glue has been used (delete it from Sonic's Stuff), and now our friends will have to try something else. What should they do?\n\nFight the Badnik robot?\t\t\tTurn to <b>14</b>Use the energy gun?\t\t\tTurn to <b>14</b>Try to roll the Badnik over?\t\t\tTurn to <b>53</b>'",
		choices = new int[3] {14, 230, 53}
	};

	public static Section section108 = new Section()
	{
		text = "Now it's time to fight! Zonik has a fighting score of 6 and Sonic needs three hits to disable his skimmer. Sonic may fight using any of his abilities (you choose). Tails will help Sonic. If Sonic and Tails win, turn to <b>136</b>. If they lose, then turn to <b>90</b>.",
		choices = new int[2] {136, 90}
	};

	public static Section section109 = new Section()
	{
		text = "The platform is only a short drop, and both our friends make it easily. Below them they can see the game, stretching away into the distance. Sonic moves closer to the edge of the platform to have a better look and doesn't notice the trip wire! BOOOOM!!! There is a massive explosion, catapulting Sonic and Tails (none too gracefully) to the ground.\n\n'That's never happened before!' says Sonic, picking himself up, trying to act as if neither his body nor pride has been injured! Remove 5 credits from Sonic's Stuff.\n\nTo the right, Sonic and Tails can see a row of targets. Directly below there is a spinner. Do they:\n\nAim at the targets?\t\t\tTurn to <b>295</b>\nDrop into the spinner?\t\t\tTurn to <b>124</b>",
		choices = new int[2] {295, 124}
	};

	public static Section section110 = new Section()
	{
		text = "Sonic manages to persuade the man, who he discovers is the casino's commissionaire, that Zonik was responsible for the damage. Sonic offers to help the commissionaire put right all the damage Zonik has caused. Turn to <b>2</b>.",
		choices = new int[1] {2}
	};

	public static Section section111 = new Section()
	{
		text = "This tunnel looks a bit more promising. It's wider than the others, so Tails and Sonic can walk side by side. The gurgling sound continues and it's fairly obvious that the Mack is gradually getting higher! After about a hundred metres, the tunnel opens into a large circular chamber, from which there are three tunnels. Where should Sonic and Tails go:\n\nTo the right?\t\t\tTurn to <b>272</b>\nTo the left?\t\t\tTurn to <b>179</b>\nStraight on?\t\t\tTurn to <b>21</b>",
		choices = new int[3] {272, 179, 21},
		mackSection = true
	};

	public static Section section112 = new Section()
	{
		text = "The tunnel is very narrow, and soon Sonic and Tails can only walk along in single file. The tunnel itself is lit by small lanterns placed at irregular intervals along the walls. Then, without warning, one of the lanterns moves! Sonic and Tails have stumbled into the lair of four Flashers!\n\nIn the narrow tunnel, Sonic will have to fight the Flashers on his own, though luckily for him, they can only attack one at a time. Sonic must use his Agility. Because the tunnel is so narrow, Sonic may not use the energy gun. The Flashers have a fighting score of 5. They will fight to the death. If Sonic wins, turn to <b>169</b>.\n\nIf the Flashers beat him ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {169}
	};

	public static Section section113 = new Section()
	{
		text = "Sonic races around the corner and then screeches to a halt. Standing in front of the ornate entrance to the Pinball Hall is a giant of a man dressed in a bright red uniform. He must be nearly three metres tall! He is pacing backwards and forwards, muttering something to himself and carrying a nasty-looking wooden club. HE DOES NOT LOOK HAPPY! Tails has caught up with Sonic. The man has not seen either of them yet, but unfortunately he's blocking the entrance. Who will go and speak to the man with the club?\n\nSonic?\t\t\tTurn to <b>39</b>\nOr Tails?\t\t\tTurn to <b>286</b>",
		choices = new int[2] {39, 286}
	};

	public static Section section114 = new Section()
	{
		text = "Sonic struggles with the skimmer's controls, but no matter how hard he tries, the skimmer refuses to budge. All the time, Zonik is getting further and further away. Sonic is going to have to try something else. Should he let Tails fly the skimmer (turn to <b>85</b>)? Or should Sonic rely on Tails, and let him hover both of them after Zonik (turn to <b>216</b>)?",
		choices = new int[2] {85, 216}
	};

	public static Section section115 = new Section()
	{
		text = "Sonic and Tails stumble blindly into the large cavern. The glow from the walls is far too weak to reach into the centre. Suddenly, Tails' foot hits something hard.\n\n'Grrrr, Gnssh,' it growls. \n\nTails feels something shoot past his leg. 'SONIC! There's something in here!'\n\n'GNSSSH!'\n\nSonic can see it now! Dimly lit, a few metres away is the unmistakable outline of a Crawlton! Turn to <b>129</b>.",
		choices = new int[1] {129}
	};

	public static Section section116 = new Section()
	{
		text = "Now it's time to fight! Zonik is a much better pilot than Sonic! Zonik has a fighting score of 6 and Sonic needs three hits to disable his skimmer. Sonic may fight using any of his abilities (you choose). However, because he is so bad at flying the skimmer, subtract one from his score. Tails will help Sonic.\nIf Sonic and Tails win\t\t\tTurn to <b>136</b>If they lose\t\t\tTurn to <b>90</b>",
		choices = new int[2] {136, 90}
	};

	public static Section section117 = new Section()
	{
		text = "Despite all of Sonic's careful observations, he somehow managed to get it completely wrong. The first step goes OK, then the next plank just disappears, and Sonic finds himself spinning uncontrollably through the air. Roll the die and add the result to Sonic's Agility. If the score is 7 or more, then Sonic has still managed to get across (more by luck than judgement though!). If the score is less than 7, then he has got wet and he must lose all his rings, or a life if he doesn't have any rings!\n\nIn any event, Sonic at last manages to get across the booby-trapped bridge. Safely over, Sonic starts to think about what to do next. There are a lot of hills here, maybe he should head for them? Suddenly, Sonic spots something that makes his spines stand on end. Turn to <b>200</b>.",
		choices = new int[1] {200}
	};

	public static Section section118 = new Section()
	{
		text = "The trapdoor opens easily to reveal a small spiral staircase leading down into the darkness. The staircase goes down and down and then down some more, and it gradually starts to get hotter. If Sonic has a torch, turn to <b>163</b>. If he doesn't have a torch, then roll the die and add the result to Sonic's Agility. If the score is 6 or more, turn to <b>251</b>. If the score is less than 6, turn to <b>34</b>.",
		choices = new int[3] {163, 251, 34}
	};

	public static Section section119 = new Section()
	{
		text = "Sonic climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, which wasn't really Sonic's style anyway. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>68</b>. If the score is less than 7, turn to <b>227</b>.",
		choices = new int[2] {68, 227}
	};

	public static Section section120 = new Section()
	{
		text = "With great difficulty, they manage to push the raft off the bank and jump on. Carried by the current, the raft slowly floats off towards the city. Both of our friends fall silent, realizing that they are about to enter the very home of Robotnik. This is going to be VERY dangerous! After about half an hour, the stream enters a tunnel.\n\n'I think we must be going inside the city now,' says Sonic, looking out into the gloom. Eventually, the raft comes to a halt.\n\n'Where to now then, Sonic?' asks Tails.\n\n'Those stairs look like a fair bet,' answers Sonic, pointing to the far side of the tunnel. Turn to <b>64</b>.",
		choices = new int[1] {64}
	};

	public static Section section121 = new Section()
	{
		text = "The heli-chopper glides high above the Hilltop Zone. From up here the place looks almost beautiful – how misleading! Then, at long last ...\n\n'Look, it's the cave,' shouts Tails, pointing out of the window, and sure enough, there it is. The heli-chopper starts to descend of its own accord and lands right outside the cave's entrance. The Mystic Cave is a strange place. Some people even think it was the first place on Mobius, and now and again archaeologists dig up something really old from inside it. There are two main passageways leading off the cave's entrance. Should Sonic and Tails follow the left-hand passage (turn to <b>8</b>), or the right-hand one (turn to <b>267</b>)?",
		choices = new int[2] {8, 267}
	};

	public static Section section122 = new Section()
	{
		text = "Every so often, there is a faint booming noise coming from above them.\n\n'Perhaps this is where they make Badniks? What do you reckon, Sonic?' asks Tails.\n\n'Well, if it is, then we've come to the right place!' replies Sonic. 'I've had just about enough of Robotnik. He's such a DRAG!'\n\nAhead of them the tunnel divides in two again. Should Sonic and Tails go to the left (turn to <b>70</b>), or to the right (turn to <b>83</b>)?",
		choices = new int[2] {70, 83},
		asteronSection = true
	};

	public static Section section123 = new Section()
	{
		text = "Face to face with the impostor at last, Sonic is unable to control himself and lunges in to attack. Zonik casually steps to one side, leaving Sonic to charge by harmlessly.\n\n'Hmm, you're going to have to do better than that,' says Zonik, but he makes no attempt to attack Sonic. Back on balance, Sonic tries again, this time with a more skilful spin. But again, Zonik side-steps the attack.\n\n'Now,' says Zonik, raising a finger pointed straight at Sonic, 'is not the time.' With that, he launches into an enormous spin that sends him over Sonic's head, past the hovering Tails. In a second he is gone. By the time Sonic has recovered, there is no sign of Zonik. What could he have meant by 'This is not the time'? Turn to <b>209</b>.",
		choices = new int[1] {209}
	};

	public static Section section124 = new Section()
	{
		text = "Sonic and Tails find themselves in the game's central spinner. It looks like a massive fairground roundabout. There are five exits from the spinner back into the game, each of which is spring loaded, so make sure our friends are careful! Both of them have played the game already, but they must remember that Zonik has been here before them, which makes it an altogether more dangerous place to be!\n\nSonic and Tails are now committed to playing the game. There are only two ways out, and one of them is <i>unthinkable</i>! Each time they visit a part of the game, write down the number of the section so that you know they have been there already. They may not use the gold exit until they have scored 100 points in the game. Make a note of the points they score. Which exit should they use to leave the game:\n\nThe red exit?\t\t\tTurn to <b>295</b>\nThe yellow exit?\t\t\tTurn to <b>299</b>\nThe blue exit?\t\t\tTurn to <b>229</b>\nThe green exit?\t\t\tTurn to <b>86</b>\nThe gold exit?\t\t\tTurn to <b>45</b>",
		// TODO: Add 45 to choices
		choices = new int[4] {295, 299, 229, 86}
	};

	public static Section section125 = new Section()
	{
		text = "No sooner has the last junction disappeared behind them, than another appears before the brave heroes. This one has two forks. Should Sonic and Tails head to the right (turn to <b>204</b>), or to the left (turn to <b>111</b>)?",
		choices = new int[2] {204, 111},
		mackSection = true
	};

	public static Section section126 = new Section()
	{
		text = "Oh no, what a dismal performance! Sonic and Tails have run out of credits before they have even finished the first game! This is pathetic! From out of nowhere, a voice says, 'I'd expected better of you two. I can just manage to give you another 20 credits, but that's all.' It's the voice of the commissionaire. As if by magic, another 20 credits appear in Sonic's paw. Make sure you help him to use them wisely. Turn to <b>124</b>.",
		choices = new int[1] {124}
	};

	public static Section section127 = new Section()
	{
		text = "The chip starts to flash with red lights, emitting a quiet humming sound. Suddenly, Sonic feels a little dizzy. The next thing he knows, he's standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone.\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic must choose carefully. He will only be allowed to go through a door once. Then it will seal shut for ever. Once you have decided which one he should go through, write its number down so that you don't use it again! Which door do you think Sonic should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>",
		choices = new int[4] {149, 290, 252, 245}
	};

	public static Section section128 = new Section()
	{
		text = "Pleasant as it is, Sonic and Tails are still trapped on the island and they need to find a way off it fairly quickly. There are two paths leading away from the beach. Should Sonic and Tails follow the path to the West (turn to <b>26</b>), or the one to the East (turn to <b>247</b>)?",
		choices = new int[2] {26, 247}
	};

	public static Section section129 = new Section()
	{
		text = "Sonic and Tails must fight the Crawlton. Sonic can use either his Strength or Speed (you choose), and Tails can help him. The Crawlton has a fighting score of 6 and he needs two hits to destroy him. If Sonic and Tails win, turn to <b>292</b>.\n\nIf the Crawlton wins, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {292}
	};

	public static Section section130 = new Section()
	{
		text = "All around them the Fak-Tor-Eee lies in ruins. It'll be a long time before any more Zoniks come off the production line. But where is the first Zonik? Unfortunately, they don't have to wait long to find out.\n\n'What have you done?' shouts Zonik. The evil hog spins into view. 'Robotnik is going to fry you for this!' Zonik lands a few metres in front of Sonic.\n\n'Shut up, Egg Breath. You're all washed up.'\n\nZonik coils up and Sonic steps back, ready to fight. Then Zonik does something unexpected - he runs away! 'You think you've won, but you haven't!' he shouts.\n\nCaught on the hop, it's a second or so before Sonic can get after him, and by then it's too late. Zonik has disappeared through a side door.\n\n'Come on, Tails! After him,' yells Sonic, charging after Zonik. Turn to <b>269</b>.",
		choices = new int[1] {269}
	};

	public static Section section131 = new Section()
	{
		text = "More bad news! Try as he might, Sonic just can't think of the right thing to say. Tails must be upset with him, not even to come and help him out of a fix like this! Sonic must go back to <b>244</b> and try to think of something better to say!",
		choices = new int[1] {244}
	};

	public static Section section132 = new Section()
	{
		text = "As Sonic shuffles his feet along the cavern floor, his right trainer scuffs against something hard. Looking down, he sees what looks like a lever half buried in the ground. The lever looks very similar to the one beside the door. Should Sonic pull the lever (turn to <b>81</b>), or should he leave it alone (turn to <b>294</b>)?",
		choices = new int[2] {81, 294}
	};

	public static Section section133 = new Section()
	{
		text = "Sonic and Tails effortlessly glide on to the third target, scoring 10 points if this is the first time they have been here. Now a choice has to be made. Should they take a chance and jump down towards the bottom of the game (turn to <b>185</b>), or should they step into the nearby warp chute (turn to <b>124</b>)?",
		choices = new int[2] {185, 124}
	};

	public static Section section134 = new Section()
	{
		text = "Sonic coils himself up like a spring and launches himself at the nearest piece of machinery. The machine crumples up like tinfoil. Tails hovers high in the air, and then swoops down like a dive-bomber, smashing another machine into atoms. The pair repeat this again and again, and again.\n\nThe robots standing around them are taken by surprise, and for a few moments just stand and stare at what's going on. Turn to <b>57</b>.",
		choices = new int[1] {57}
	};

	public static Section section135 = new Section()
	{
		text = "The two intrepid heroes tumble through the Game Over hole.\n\n'You know, Tails,' says Sonic, picking himself up off the floor, 'I don't come here often.'\n\nTails gives his friend one of <i>those</i> looks.\n\n'I mean, it's so rare for me actually to lose,' he continues.\n\n'Of COURSE it is,' replies Tails sarcastically.\n\nThe brave friends seem to be in some kind of control room. Over to the left is a large hole in the floor through which the losing player's ball would go. The rest of the room is full of computer equipment.\n\n'Do you understand any of this?' asks Tails, looking at the bewildering mess of circuits.\n\n'Of course,' says Sonic (what else would you expect!). Looks like there's going to be trouble between the two friends. He picks up a games console.\n\n'It's just like a Mega Drive,' says Tails.\n\n'Not quite,' says Sonic. 'Look,' he points out the title of the cartridge.\n\n'Death Ball? I haven't heard of that one,' says Tails.\n\n'Well, I think we've just been playing it. It's wired straight into the main computer.' The machine is indeed plugged into the game's main control console.\n\n'No guesses about who did this, eh?' says Sonic. 'Looks like we've just missed him again.'\n\n'Yes,' replies Tails, wondering if they will ever catch up the evil Zonik. 'Still, there's an easy way to sort out the game for the commissionaire,' he says, and he reaches out to pull the connecting wire from the console. Roll the die and add the result to Sonic's Quick Wits. If the score is 6 or more, turn to <b>297</b>. If the score is less than 6, turn to <b>146</b>.",
		choices = new int[2] {297, 146}
	};

	public static Section section136 = new Section()
	{
		text = "The two skimmers twist and turn this way and that all over the sky. Finally, Zonik's skimmer can't take any more. It buckles under yet another of Sonic's flying kicks, and it spirals out of control towards the planet's surface. Sonic and Tails follow. Turn to <b>214</b>.",
		choices = new int[1] {214}
	};

	public static Section section137 = new Section()
	{
		text = "They have just reached the island in time. Or have they?! A few metres from the shore the boat finally calls it a day and starts to sink. Tails starts to hover and will reach the island without any difficulty. Sonic, however, must jump and it's a LONG WAY.\n\nRoll the die and add the result to Sonic's Agility. If the score is equal to or greater than 7, turn to <b>33</b>. If the score is less than 7, turn to <b>238</b>.",
		choices = new int[2] {33, 238}
	};

	public static Section section138 = new Section()
	{
		text = "The pillar is very tall. If only Sonic had brought Tails, it would have been easy! Well, now there's only one thing for it - Sonic is going to have to try and jump to the top! This will mean pushing himself to the limit. Roll the die and add the result to Sonic's Speed. Then, roll the die again and add the result to Sonic's Strength.\n\nIf both scores are 6 or more, then Sonic manages to reach the tweezers. Remember to add them to Sonic's Stuff. If either score is less than 6, the jump is just a little too much for him and he has failed. In any event, the only thing left for Sonic to do is press the red Return button. Turn to <b>187</b>.",
		choices = new int[1] {187}
	};

	public static Section section139 = new Section()
	{
		text = "There has to be a way up the platforms, but what is it? Sonic stares at them for ages without any luck. All the time he keeps an eye on Tails, high above him.\n\n'There must be an easy answer to this one,' he says aloud. Then he remembers the lever. Turn to <b>207</b>.",
		choices = new int[1] {207}
	};

	public static Section section140 = new Section()
	{
		text = "Sonic reaches down to pick up the needle. Then, at the exact moment the tip of his paw touches it, there is a loud explosion and Sonic is thrown to the far corner of the cave.\n\n'Strange ...' says Tails dryly. 'That's exactly what it did to me.'\n\nThe needle has been blown to bits in the explosion. It's time Sonic left for the Chemical Plant, but before he goes, subtract one life or all of Sonic's rings if he has any! Perhaps, however, Sonic has learnt something from this - add 1 to his Coolness score.\n\nTurn to <b>201</b>.",
		choices = new int[1] {201}
	};

	public static Section section141 = new Section()
	{
		text = "After a while, Sonic and Tails find themselves at an intersection of four tunnels. They all look so alike and both of them feel very lost!\n\n'Any ideas which one take?' says Sonic. In which direction should they head now:\n\nNorth?\t\t\tTurn to <b>30</b>\nSouth?\t\t\tTurn to <b>83</b>\nEast?\t\t\tTurn to <b>224</b>\nWest?\t\t\tTurn to <b>103</b>",
		choices = new int[4] {30, 83, 224, 103},
		asteronSection = true
	};

	public static Section section142 = new Section()
	{
		text = "Carefully, Sonic steers the boat towards the cloud. The closer they get, the odder the cloud looks. It appears almost solid and doesn't change shape like a cloud should. Then, when they are almost right underneath it, the cloud suddenly shimmers and disappears. There is a bright flash. Rubbing his eyes, Sonic looks up again and sees in its place a bright silver hover ship, just like the one Robotnik is in the habit of flying around in!!!\n\n'SO .. . this is where you've got to, is it?' booms out a mechanical voice from the ship.\n\nIt's Robotnik!!!\n\nWhat will Sonic and Tails do? Will they stay and speak to Robotnik (turn to <b>24</b>), or will they try and sail away (turn to <b>183</b>)?",
		choices = new int[2] {24, 183}
	};

	public static Section section143 = new Section()
	{
		text = "Both of them set off to walk towards the city. They find what looks like a footpath threading its way through the junk and other rubbish and mess that surrounds the Metropolis. The footpath slowly winds its way downhill towards a stinky dirty stream flowing away from the city.\n\n'Look at the state of that stream, Sonic. What a mess,' says Tails, disgusted at the sight before him.\n\n'Well, that's the Metropolis Zone all over, my friend. That's why Robotnik likes the place so much. He loves the filth!' The path follows the stream for a while, and then bends back up the hill.\n\n'Which way now, I wonder,' says Sonic, thinking aloud.\n\n'Why don't I have a little look around?' replies Tails and starts to hover. From up there, Tails can see a lot more than Sonic. 'Well, the path looks like it still goes to the city, but there's a raft moored up just around the bend,' he points down the river.\n\nWill Sonic and Tails follow the footpath (turn to <b>223</b>), or will they have a look at the raft (turn to <b>257</b>)?",
		choices = new int[2] {223, 257}
	};

	public static Section section144 = new Section()
	{
		text = "After a little while, the trees thinned out and Sonic was back in the open. Up ahead he could hear the sound of another river. Sure enough, around the next bend in the path, there was a river. Not a very wide one, but Sonic's heart sank never the less, for the bridge across it was not all it could have been. The planks that made up the walkway were moving! Sonic stops and looks at them for a while, trying to work out the pattern.\n\nSoon Sonic feels sure that he has worked it out and will be able to cross safely. With a look of determination, he takes a few steps backwards and then charges towards the bridge. In which order should Sonic step on the planks:\n\nThe third, then the second, then the first?\t\t\tTurn to <b>173</b>\nThe first, then the third, then the second?\t\t\tTurn to <b>186</b>\nThe second, then the third, then the first?\t\t\tTurn to <b>117</b>",
		choices = new int[3] {173, 186, 117}
	};

	public static Section section145 = new Section()
	{
		text = "'Wait a minute, Tails, no one's going to leave a great big pile of rings just lying around. It's got to be a trap.'\n\n'Do you know something? You're absolutely right!' squeals a high-pitched voice. Suddenly, the tunnel is full of furry animals, all about half a metre high, with sharp little teeth.\n\n'But not one of ours,' screeches another.\n\n'If you don't want to be nabbed, you'd best come with us,' says another.\n\n'And quickly ... very quickly,' adds yet another.\n\nSonic and Tails have been taken by surprise. The creatures don't look very friendly, but then again they haven't attacked.\n\n'Quickly, quickly. Come with us, or the robots will be here,' warns the leader of the creatures.\n\nShould our friends go with the creatures (turn to <b>11</b>), or should they try to run away (turn to <b>213</b>)?",
		choices = new int[2] {11, 213}
	};

	public static Section section146 = new Section()
	{
		text = "Sonic notices the small black and red wire underneath the Mega Drive. Following it with his eyes, he sees it leads underneath the console to a ... 'OH NO!!! Don't touch it, it's a BOMB!!!'\n\nBOOOOOOOOOM!\n\nA few minutes later, our hero comes round. He can still see stars whizzing around inside his head, but where is Tails? Relieved, Sonic sees his friend sitting a few metres away, rubbing his head.\n\n'That'll teach you to be so impatient,' says Sonic. Tails doesn't reply and instead just looks away.\n\n'Well, I suppose we had better get moving, old friend,' says Sonic. There is only one way out of this room, conveniently marked 'Exit'. As he walks through it, Sonic turns to Tails, 'And don't touch anything this time.'\n\nThe explosion has destroyed 20 rings. Delete them from Sonic's Stuff. If he doesn't have any rings, then he loses a life instead! Turn to <b>157</b>.",
		choices = new int[1] {157}
	};

	public static Section section147 = new Section()
	{
		text = "Just as Sonic grabs the bag, the robot springs to life. Instantly it aims a punch, but Sonic is too fast and easily avoids it. Unfortunately, the Badnik is now between him and the Return button and Sonic is going to have to fight his way through.\n\nThe Badnik has a fighting score of 6 and needs two hits to be destroyed. Sonic must fight using Strength. If Tails is with him, he will help. If Sonic wins, then he presses the Return button. Remember to add the sky net to Sonic's Stuff before turning to <b>187</b>. If the robot has finished off Sonic, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {187}
	};

	public static Section section148 = new Section()
	{
		text = "There are two voices. One is deep and metallic - the other, well, it seems familiar to Sonic but he can't quite place it. Crouching just out of sight around the corner, the heroes are unable to see who was speaking.\n\n'Sonic, that voice,' says Tails, his own voice quivering, slightly frightened at what he is about to tell Sonic. 'It sounds just like ...' he pauses,'... like YOU!'\n\nWhat will our brave friends do? Should they wait and listen to what is being said (turn to <b>255</b>), or should they rush around the corner and confront the mysterious pair (turn to <b>58</b>)?",
		choices = new int[2] {255, 58}
	};

	public static Section section149 = new Section()
	{
		text = "The door opens automatically to reveal a long corridor. It's all white and completely empty. Sonic enters it and takes a few steps. Suddenly, a trapdoor opens right under his feet. Roll the die and add the result to Sonic's Agility. If the score is 6 or more, turn to <b>205/b>. If the score is less than 6, and Sonic is alone, turn to <b>50</b>. If Tails is with Sonic, turn to <b>176</b>.",
		choices = new int[3] {205, 50, 176}
	};

	public static Section section150 = new Section()
	{
		text = "The rats lead Sonic and Tails away from the cavern, back through the maze of corridors. At last, they reach a rusty old iron door set in the wall of the tunnel.\n\n'That's where you wants to go. Yes, through there,' the rats say together, and then melt away into the shadows. Fortunately, the door has been left open, and our friends peer into the murk on the other side.\n\n'Let's have a look at this first,' says Sonic, and he unrolls the scroll. It is covered in a spidery scrawl. Roll the die and add the result to Sonic's Quick Wits. If the score is 6 or more, turn to <b>285</b>. If the score is less than 6, turn to <b>29</b>.",
		choices = new int[2] {285, 29}
	};

	public static Section section151 = new Section()
	{
		text = "Slowly the tunnel gets wider and wider and begins to climb uphill. The level of the Mack begins to drop as they climb! Finally, they turn one more corner in the tunnel and come face to face with a huge archway.\n\n'I know this place,' exclaims Sonic. 'The gate to the Aquatic Ruin isn't far from here. We've made it, Tails!' Through the archway they can almost smell the fresh air already! Turn to <b>42</b>.",
		choices = new int[1] {42}
	};

	public static Section section152 = new Section()
	{
		text = "Despite the fact that the machinery has stopped working, there are still a lot of jars with mini-Zoniks inside them. Sonic looks at them, wondering what to do. Roll the die and add the result to Sonic's Quick Wits. If the score is 6 or more, turn to <b>287</b>. If the score is less than 6, turn to <b>4</b>.",
		choices = new int[2] {287, 4}
	};

	public static Section section153 = new Section()
	{
		text = "Using the advantage of height, Sonic and Tails swoop down on Zonik's cloud skimmer, passing it with only centimetres to spare! Turn to <b>268</b>.",
		choices = new int[1] {268}
	};

	public static Section section154 = new Section()
	{
		text = "Now that was pure Cool - with a capital C! Or was it just luck? Sonic's the only one who will ever know and there's not much chance of him admitting it, is there?!\n\nWhether it was skill or luck, the little blue super-being manages not only to spot the almost hidden stream, he also manages to leap it in a single bound, finishing off with an amazing spin, just for good measure.\n\n'OUTSTANDING,' Sonic can't resist the temptation to sing his own praises. 'Hmmm, well not bad, I suppose,' he continues, a little less over-the-top. Turn to <b>3</b>.",
		choices = new int[1] {3}
	};

	public static Section section155 = new Section()
	{
		text = "It didn't take a mechanical genius to work out that the post was well and truly broken. Sonic decides not even to try and repair it. The view from the hilltop is superb and in the distance Sonic can see a little river with a bridge, and beyond that a small wood.\n\n'That looks like a good way to go,' says Sonic out loud. Turn to <b>177</b>.",
		choices = new int[1] {177}
	};

	public static Section section156 = new Section()
	{
		text = "What had looked like a solid brick wall a few seconds ago, suddenly starts to move. First one huge claw, and then another, appears and the whole 'wall' starts to grind slowly towards our heroes.\n\n'It's a Shellcracker!' screams Sonic.\n\nSonic and Tails must fight the Shellcracker using Strength. Tails will help Sonic. The Shellcracker has a fighting score of 6 and needs two hits to be destroyed. If Sonic and Tails win, turn to <b>278</b>. If they fail to beat the Shellcracker, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {278}
	};

	public static Section section157 = new Section()
	{
		text = "Passing through the door, they find themselves outside the game at last. 'Excellent, the game is back under my control. I can clear up the rest of the mess myself.' It is the commissionaire, his mouth forming a huge smile. 'Whatever you want you can have,' he says.\n\n'Well, actually we're in a bit of a hurry,' pipes up Tails.\n\n'Hurry? I might be able to help you there,' says the commissionaire. 'Come with me.' He shows them through a small side-door and into a lift that takes them up to the roof of the casino. 'My heli-chopper is the fastest in the Zones. It can take you as far as the Mystic Cave if you want. No need to worry about flying it, either. It's all remote control. Oh, and by the way, don't forget these.' The commissionaire hands Sonic a bag. Inside are 100 rings. 'That's your prize for beating the game. Fair's fair!' he says and with that the heli-chopper rises majestically into the air. Turn to <b>82</b>.",
		choices = new int[1] {82}
	};

	public static Section section158 = new Section()
	{
		text = "Zonik pulls round his skimmer and flies straight at Sonic's. Looks like he's decided to fight it out. There's not much time to think!\n\nWhat will Sonic and Tails do:\n\nFight it out?\t\t\tTurn to <b>161</b>\nUse a sky net (if they have one)?\t\t\tTurn to <b>87</b>\nUse the energy gun?\t\t\tTurn to <b>190</b>",
		choices = new int[3] {161, 87, 190}
	};

	public static Section section159 = new Section()
	{
		text = "A brilliant blue beam shoots out of the energy gun and <i>misses</i> the hover ship completely!!! ... Looks like Sonic and Tails are going to have to fight the hover ship the hard way. Turn to <b>242</b>.",
		choices = new int[1] {242}
	};

	public static Section section160 = new Section()
	{
		text = "That was a bad mistake! The panel opens and BOOOOOOOM! Surprise, surprise, a bomb goes off. Sonic is sent flying through the air to land in a heap in the corner. This explosion will remove all of Sonic's rings or a life if he hasn't got any.\n\nIf Sonic has survived, then he must now press the Return button, turn to <b>187</b>. If this has finished Sonic off, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {187}
	};

	public static Section section161 = new Section()
	{
		text = "How are Sonic and Tails flying?\n\nIf Sonic is flying the cloud skimmer\t\t\tTurn to <b>116</b>\nIf Tails is flying the cloud skimmer\t\t\tTurn to <b>210</b>\nIf Tails is hovering\t\t\tTurn to <b>108</b>",
		choices = new int[3] {116, 210, 108}
	};

	public static Section section162 = new Section()
	{
		text = "Oops! Now that wasn't supposed to happen at all. Sonic mistimed the jump, missed the lever completely, and landed with a thump on the ground ... OUCH. Turn back to <b>207</b> and let Sonic have another go. Before you do, roll the die. If Sonic scores a 1, then unfortunately he's lost either all his rings or a life if he doesn't have any rings!",
		choices = new int[1] {207}
	};

	public static Section section163 = new Section()
	{
		text = "Sonic flicks the torch's switch and the staircase fills with light. The end of the steps is just below where he is standing.\n\n'Looks like another tunnel, Tails,' says Sonic. Turn to <b>46</b>.",
		choices = new int[1] {46}
	};

	public static Section section164 = new Section()
	{
		text = "Sonic runs over to the skimmer, quickly followed by Tails. There are two seats in the strange flying machine, one of them with a joystick in front of it. Who will fly the machine:\n\nTails?\t\t\tTurn to <b>85</b>\nSonic?\t\t\tTurn to <b>119</b>",
		choices = new int[2] {85, 119}
	};

	public static Section section165 = new Section()
	{
		text = "Flying through an acid cloud-field at this speed is always dangerous. Just when they are nearly through, the wing of the cloud skimmer brushes against a small cloud. There's a hiss and the wing drops off! The skimmer instantly goes out of control and careers towards the planet's surface.\n\nRoll the die and add the result to Sonic's Agility. If the score is 5 or more, then he manages to grab hold of Tails, who hovers out of danger. Turn to <b>35</b>. If the score is less than 5 then, unfortunately, Sonic falls all the way to the planet's surface, and it's a long walk home!\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {35}
	};

	public static Section section166 = new Section()
	{
		text = "Brilliant though Sonic and Tails might be, the deck of a small boat is not the best place to fight. They manage to fend off Chop Chop for quite a while, but really it is only a matter of time. Suddenly, Chop Chop manages to get his teeth around the side of the boat and rips a huge chunk out of it. The boat begins to sink fast.\n\n'Tails!' shouts Sonic, but he needn't have worried. Tails is already hovering and reaches out and grabs his friend's paw, lifting him clear in the nick of time.\n\n'Nice one!' says Sonic. Tails hovers a little longer, so they are safely out of reach of the robot tuna who thrashes around underneath them.\n\n'Where to now, then?' says Sonic, looking up at his friend. 'That island over there looks good to me, Sonic,' says Tails, pointing to the horizon. Turn to <b>40</b>.",
		choices = new int[1] {40}
	};

	public static Section section167 = new Section()
	{
		text = "Sonic pushes the two-player button and then waits. Nothing happens for a moment or two, then the screen flickers into life.\n\n'Wow, it's Badnik Fighter II. Brilliant!' Sonic loves this game.\n\nRoll the die and add the result to Sonic's Quick Wits. As Tails is helping, you may add 2 to the result. If the score is 10 or more, turn to <b>198</b>. If the score is less than 10, then the unthinkable has happened and the game players have lost. They must press the Return key. In disgust, turn to <b>187</b>.",
		choices = new int[2] {198, 187}
	};

	public static Section section168 = new Section()
	{
		text = "Sonic and Tails have come up the ramp far too fast, and they find themselves tumbling towards the bottom of the table. Tails has started to hover and will be safe. Sonic, however, must find some other way to escape. All around him the various targets and bumpers flash past, if only he can somehow grab hold of one of those bumpers. Sonic reaches out with his left paw. A bumper flashes past, just millimetres out of his reach. He tries again and again, but with no success. Below him, he sees a flipper. 'This is going to HURT!!!'\n\nThe flipper springs up as Sonic approaches it, and hits him so hard that the blue superhedgehog looks more like a strangely coloured cricket ball. He then shoots back towards the top of the table. In a blink of an eye, Sonic lands with a thump on a platform right at the top of the table. Remove two credits from Sonic's Stuff as a penalty for hitting the flipper!\n\n'Not bad, but it's better if you fly!' Tails says, looking smug as he stands and watches Sonic dusting himself down.\n\n'OK, then,' says Sonic, a little annoyed at his smiling friend, 'as you're <i>so cool</i>, let's see you go first for a change!' Now Tails is in the hot seat, which way will he go? The platform to the right (turn to <b>218</b>)? The platform to the left (turn to <b>109</b>)?",
		choices = new int[2] {218, 109}
	};

	public static Section section169 = new Section()
	{
		text = "Standing beside a hole in the middle of the cavern is Zonik!\n\n'You know, Pin Brain,' he mocks Sonic, 'without that heli-chopper you would have been way behind me, you're getting slow in your old age!'\n\n'Who are you calling Pin Brain, Egg Breath!' retorts Sonic.\n\n'Well, it doesn't really matter what we are calling each other now I have this. DOES IT?!!!' Zonik is holding up his right paw. In it he has a Chaos Emerald! 'It's amazing what you find if you look hard enough!' he continues. With the power of the emerald, nothing will be able to stop him. Sonic and Tails are going to have to act fast!\n\nWhat should they do:\n\nUse the energy gun?\t\t\tTurn to <b>271</b>\nFight?\t\t\tTurn to <b>31</b>\nUse a bottle of Whiffy liquid?\t\t\tTurn to <b>180</b>",
		choices = new int[3] {271, 31, 180}
	};

	public static Section section170 = new Section()
	{
		text = "Tails desperately tries to control the cloud skimmer as it flies through the clouds. Touch one of them and our heroes will be done for! Roll the die. If the score is 1, turn to <b>165</b>. If the score is 2 or more, then turn to <b>35</b>.",
		choices = new int[2] {165, 35}
	};

	public static Section section171 = new Section()
	{
		text = "The fruit machine is lit up like a Christmas tree and Sonic becomes mesmerized by it. Each game costs 1 ring, and Sonic cannot resist the temptation. Roll the die twice. If the result adds up to 4 or less, turn to <b>84</b>. If the result adds up to 5 or more, turn to <b>199</b>. Remember to subtract 1 ring from Sonic's Stuff.",
		choices = new int[2] {84, 199}
	};

	public static Section section172 = new Section()
	{
		text = "The panel slides open to reveal an odd-looking red ball. Sonic picks the ball up and looks at it. 'Hmm, I suppose this must be the energy bomb.' Add it to Sonic's Stuff. All that Sonic can do now is press the red Return button. Turn to <b>187</b>.",
		choices = new int[1] {187}
	};

	public static Section section173 = new Section()
	{
		text = "Despite all Sonic's careful observations, he somehow manages to get it completely wrong. The first step went OK, then the next plank just disappeared and Sonic finds himself spinning uncontrollably through the air.\n\nRoll the die and add the result to Sonic's Agility. If the score is 7 or more, then he still manages to get across (more by luck than judgement though!). If the score is lower, unfortunately he's got wet and he must lose either a life or all his rings!\n\nIn any event, Sonic at last manages to get across the more-dangerous-than-it-looked bridge. There are a lot of hills on the other side. Just as Sonic is deciding which way to go, he sees something that makes his spines stand on end. Turn to <b>200</b>.",
		choices = new int[1] {200}
	};

	public static Section section174 = new Section()
	{
		text = "The blue needle is glowing with a faint light on the floor of the cave. It looks very much like one of Sonic's spines! If you think the needle isn't important and should be left where it is, then hurry on to the Chemical Plant (turn to <b>201</b>). If Sonic picks up the needle, turn to <b>75</b>.",
		choices = new int[2] {201, 75}
	};

	public static Section section175 = new Section()
	{
		text = "'There is no way I'm staying in this place a second longer!' says Sonic. 'I mean look at the mess, if I'm not careful I'll get these trainers dirty, or worse!'\n\nTails sighs. 'OK then, Sonic. Let's get going.' Both of them walk out of the store-room. Sonic's vanity can be a little bit of a pain at times, thinks Tails! Turn to <b>101</b>.",
		choices = new int[1] {101}
	};

	public static Section section176 = new Section()
	{
		text = "Sonic sees the floor open underneath him, but it's too late and he finds himself falling to the floor beneath. Fortunately for him, Tails manages to hover and catches him before he hits it. Tails pulls Sonic back up to the corridor, and they continue walking.\n\nAhead, the tunnel opens up into a large room. Making very sure there aren't any more hidden traps, Sonic and Tails walk into the room. The only things there are a large red button marked Return and a very tall pillar. On top of the pillar, Sonic can just see a pair of tweezers. What should Sonic and Tails do now:\n\nPress the red button?\t\t\tTurn to <b>187</b>\nGet the tweezers?\t\t\tTurn to <b>264</b>",
		choices = new int[2] {187, 264}
	};

	public static Section section177 = new Section()
	{
		text = "The familiar sound of the river could be clearly heard in the distance. Sonic didn't really like the river. He didn't really like any rivers. They were all right to look at, but he didn't fancy getting wet one little bit!\n\nSonic walked into the valley and breathed a sigh of relief; at least there was a proper bridge here today. The Green Hill Zone bridges had a nasty habit of doing their own thing. Sometimes they were normal, other times bits of them collapsed as you walked on them. Sometimes they even disappeared when you were half-way across! Gingerly, Sonic tiptoes across the bridge, casting a cautious eye at the water. Somewhat relieved, he reaches the other side — you could never be too careful with bridges! Turn to <b>12</b>.",
		choices = new int[1] {12}
	};

	public static Section section178 = new Section()
	{
		text = "Sonic pushes the F1 key and the screen suddenly springs to life.\n\n'ONE- OR TWO-PLAYER GAME?'\n\nIf Sonic is alone, turn to <b>232</b>. If Tails is here too, then turn to <b>167</b>.",
		choices = new int[2] {232, 167}
	};

	public static Section section179 = new Section()
	{
		text = "Another tunnel, another fork at the end of it! This place is such a maze! Tails looks down at the Mack. It's a good deal higher than the last time he looked! If you have more than 20 points, turn to <b>288</b>. In which direction should Tails and Sonic now go:\n\nTo the left?\t\t\tTurn to <b>194</b>\nTo the right?\t\t\tTurn to <b>111</b>\nStraight on?\t\t\tTurn to <b>10</b>",
		choices = new int[3] {194, 111, 10},
		mackSection = true
	};

	public static Section section180 = new Section()
	{
		text = "Sonic pulls out the glass bottle of liquid that Whiffy gave him. He throws it at Zonik. He misses, but the bottle shatters on the ground, splashing Zonik's trainers! For a second or so, nothing happens, then the smell hits them!\n\n'OH, wow man!' is all that Sonic can manage. Tails doesn't even do that well and goes a funny shade of green. As for Zonik, well he starts to puff and jerk like he's got an ice cube down his back. Now he's hopping about on one foot. Then WHOOOSH ... Zonik runs from the cavern like nothing Sonic or Tails have ever seen before, dropping the Chaos Emerald in his haste.\n\nWith a paw firmly clamped over his nose, Sonic walks over to where Zonik had been standing and picks up the emerald. 'Good stuff that,' he says, pointing to the broken bottle. Tails just nods, and thinks he is going to be sick.\n\nTurn to <b>76</b>.",
		choices = new int[1] {76}
	};

	public static Section section181 = new Section()
	{
		text = "Even though they are travelling at breakneck speed, Sonic and Tails manage to stay in control. They skid to a halt on top of the bouncer, scoring 5 points if this is the first time they have been here. From here they can see another bouncer. Turn to <b>6</b>.",
		choices = new int[1] {6}
	};

	public static Section section182 = new Section()
	{
		text = "'What do you mean \"WHAT DO I RECOMMEND?\" I've got better things to do than answer fool questions like that!' The bus driver seems very annoyed for some reason. 'Now either you tell me where you want to go or I'm leaving you here.' What will Sonic say:\n\n'All the way, please'?\t\t\tTurn to <b>55</b>\n'The city gates'?\t\t\tTurn to <b>95</b>",
		choices = new int[2] {55, 95}
	};

	public static Section section183 = new Section()
	{
		text = "Crashing the boat into gear, Sonic speeds away from the hover ship, but in a few seconds it is up above him once more. 'STOP!!!' booms out the voice, and the boat is engulfed in a strange green beam. A split second later, the engine dies and the boat judders to a halt. Turn to <b>24</b>.",
		choices = new int[1] {24}
	};

	public static Section section184 = new Section()
	{
		text = "Now that the robot is closer, Sonic can clearly see that written on the bag are the words 'Sky Net'. Should Sonic reach out and take the bag (turn to <b>147</b>)? Or is it a better idea to press the red Return button (turn to <b>187</b>)?",
		choices = new int[2] {147, 187}
	};

	public static Section section185 = new Section()
	{
		text = "Leaping into the unknown, they jump from the target, gradually picking up speed until they are tumbling out of control towards the bottom of the game and the flippers! BANG!!! A flipper smashes them back towards the top of the game. That hurt! Remove 5 credits from Sonic's Stuff, and then turn to <b>124</b>. If Sonic doesn't have 5 credits left, turn to <b>126</b>. If the commissionaire has already given Sonic another 20 credits, you <i>must</i> turn to <b>41</b>.",
		choices = new int[3] {124, 126, 41}
	};

	public static Section section186 = new Section()
	{
		text = "With the skill and coolness that only Sonic could produce, he expertly hops across the bridge in exactly the right order, even managing a little spin at the end. More than a little happy with his performance, Sonic finds himself among a lot of hills. Just as he was deciding which way to go, he sees something that makes his spines stand on end.\n\nTurn to <b>200</b>.",
		choices = new int[1] {200}
	};

	public static Section section187 = new Section()
	{
		text = "Suddenly, there is a funny kind of wobbly feeling, and Sonic (and Tails if he is there) find themselves back where the Zone Chip was first used. You should have written this down. If you haven't, let's hope you've got a good memory! If you haven't got a good memory, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[0] {}
	};

	public static Section section188 = new Section()
	{
		text = "The tunnel leads on and on, and the heroes' footsteps echo on for ages. The gurgling noise continues and after a while Sonic gets used to it and forgets that it's there. At last, Sonic sees the tunnel branching in two and looks around to tell Tails, and realizes that Tails has dropped quite a way behind him. 'What's the matter now?' he shouts, seeing Tails crouching down about twenty metres back down the tunnel.\n\n'Look,' says Tails, pointing at a small pipe in the tunnel wall. Annoyed at the delay, Sonic stomps back to where his friend is waiting. Out of the pipe is gurgling a steady glooping mess of Mack!!!!\n\n'We're in a trap, Sonic,' says Tails. 'If we don't get out of these tunnels soon, we're going to be drowned in Mack!!!!!!!'\n\nShould the heroes go down the left tunnel (turn to <b>239</b>) or the right one (turn to <b>13</b>)?",
		choices = new int[2] {239, 13},
		mackSection = true
	};

	public static Section section189 = new Section()
	{
		text = "Bunching himself up into a ball, Sonic tries to spring as he tumbles through the air. The bouncer looms in front of him, and somehow he manages to grab hold of it, with Tails hanging on to his feet for all he's worth. They've made it! Score 5 points if this is the first time they have been here.\n\nStanding on top of the bouncer, they can both feel it throbbing under their feet. Perhaps they had better not stay here too long! Should they aim at another bouncer above them (turn to <b>36</b>), or try and get into the long chute, way off to the right (turn to <b>195</b>)?",
		choices = new int[2] {36, 195}
	};

	public static Section section190 = new Section()
	{
		text = "Sonic aims the energy gun at Zonik and fires, but Zonik is moving too quickly and the beam misses! There's no time for a second shot. Turn to <b>161</b>.",
		choices = new int[1] {161}
	};

	public static Section section191 = new Section()
	{
		text = "After a few minutes' walk, the cavern first closes into a small passageway and then opens out again to the outside world. Light streams in and for a few moments our heroes have to squint against the bright light. There is a smell too, exhaust fumes, garbage, and a wall of noise.\n\n'Welcome to the Metropolis Zone, old friend,' says Sonic.\n\n'It's so nice to be back.' Sonic's voice is heavy with sarcasm.\n\nIn the distance, they can see the jagged skyline of Metropolis – home of Robotnik! Hopefully, it would also hold the secret of Zonik as well, since there was now little doubt that the two must be connected. It's still quite a long way to the city. Will Sonic and Tails set off immediately (turn to <b>143</b>), or will they investigate the strange-looking pole sticking out of the ground a few metres away (turn to <b>44</b>)?",
		choices = new int[2] {143, 44}
	};

	public static Section section192 = new Section()
	{
		text = "After a few seconds of blue skies, more clouds appear. This time they're not so big, but there are lots of them. Our heroes could fly around them, but that would take too long. There's only one thing for it!\n\n'We're going to have to fly straight through that lot!' yells Sonic. How are Sonic and Tails flying?\n\nIf Sonic is flying the cloud skimmer\t\t\tTurn to <b>78</b>\nIf Tails is flying the cloud skimmer\t\t\tTurn to <b>170</b>\nIf Tails is hovering\t\t\tTurn to <b>51</b>",
		choices = new int[3] {78, 170, 51}
	};

	public static Section section193 = new Section()
	{
		text = "Sonic and Tails attack Chop Chop. Chop Chop's fighting score is 6. If you are unsure what to do, look back at the beginning of the book for instructions. If Sonic is hit by Chop Chop, then turn to <b>166</b>. If Sonic and Tails win the fight, turn to <b>52</b>.",
		choices = new int[2] {166, 52}
	};

	public static Section section194 = new Section()
	{
		text = "No sooner has the last junction disappeared behind them, than another appears before the brave heroes. This one has two forks. Which one do Sonic and Tails take? The one going off to the right (turn to <b>111</b>), or the one to the left (turn to <b>204</b>)?",
		choices = new int[2] {111, 204},
		mackSection = true
	};

	public static Section section195 = new Section()
	{
		text = "The chute runs all the way down the side of the game. Tails and Sonic move faster and faster.\n\n'ALL RIGHT!!!!' yells Sonic as they approach the bottom. Here the chute curves back out into the middle and the brave adventurers find themselves flying through the air once more. A large round target looms up in front of them and they strike it fair and square, scoring 10 points if this is the first time they have been here.\n\nIn the distance they can just see another target. Roll the die and add the result to Sonic's Strength, and then add his Agility. If the combined score is 10 or more, turn to <b>228</b>. If the combined score is less than 10, turn to <b>283</b>.",
		choices = new int[2] {228, 283}
	};

	public static Section section196 = new Section()
	{
		text = "Very gently, Sonic reaches over and presses the large red button marked Start! There is a click, and then a rumble behind them. Suddenly, there is a loud WHOOOSH, and a blast of air catches Tails and Sonic. It carries them up the ramp towards the start of the game.\n\n'It's a lot softer than the old spring,' yells Sonic, though judging from Tails' expression, he's not convinced!\n\nAfter a couple of seconds, the wind dies away, and our heroes start to slow down, before rolling to a stop a few metres away from the top of the ramp. There, they stay for a moment before starting to slide back to the bottom. It looks like they're going to have to press the Start button again. Should they press the button:\n\nFairly hard?\t\t\tTurn to <b>280</b>\nHard?\t\t\tTurn to <b>49</b>",
		choices = new int[2] {280, 49}
	};

	public static Section section197 = new Section()
	{
		text = "Sonic pulls out the energy bomb and lobs it into the middle of the machinery. There is a flash of brilliant white light and a noise like thunder. Staring through the smoke, Sonic can see that the bomb has knocked out all the robots.\n\n'Outstanding! I must get hold of some more of these,' he says. Now the robots have been dealt with, Sonic and Tails can destroy the rest of the machines in peace.\n\nTurn to <b>208</b>.",
		choices = new int[1] {208}
	};

	public static Section section198 = new Section()
	{
		text = "The game has been won. Suddenly, a door opens in the wall just above the computer to reveal a hidden safe. In the safe there is a pair of gloves. Add these to Sonic's Stuff. There is nothing left to do now except press the Return button. Turn to <b>187</b>.",
		choices = new int[1] {187}
	};

	public static Section section199 = new Section()
	{
		text = "The fruit machine whirrs into action while Sonic and Tails are staring at it. Sonic loses. If Sonic plays the fruit machine again, turn to <b>171</b>. If he thinks it's a waste of time, turn to <b>97</b>.",
		choices = new int[2] {171, 97}
	};

	public static Section section200 = new Section()
	{
		text = "Straight ahead, the hillside is cut by a small deep-sided valley, its sides almost sheer. From time to time, Robotnik was in the habit of setting a moving-platform maze here to trap the unwary. Mind you, the risk was worth it, since Robotnik usually baited the top of the trap with at least half a dozen rings.\n\nThere were two things about the maze that made Sonic think that the bunnies might not have been mad after all. Firstly, the platforms weren't moving. OK, he could cope with that. The second thing was the fact that Tails was lying on the highest platform ... and he didn't look happy!\n\nTurn to <b>253</b>.",
		choices = new int[1] {253}
	};
	
	public static Section section201 = new Section()
	{
		text = "It is not far to the gate connecting the Green Hills with the Chemical Plant. Strange that something as nasty as the Chemical Plant could be so close to the Green Hills. Up ahead Sonic could see the start of the deep valley that led to the gate. He also knew that just around the corner would be the Spike Buggy, one of Robotnik's creations. Slow and clumsy but still dangerous, it would have to be beaten before they could get to the gate.\n\nWill Sonic and Tails attack the Spike Buggy head on (turn to <b>23</b>), or will they try to sneak past it (turn to <b>222</b>)?",
		choices = new int[2] {23, 222}
	};

	public static Section section202 = new Section()
	{
		text = "A big red bus can look rather strange if you've never seen one before! Neither Sonic nor Tails had, so they were a little confused. The bus stops beside the pole, and the doors open.\n\n'Metropolis, Metropolis. All stops to Metropolis!' Our two friends look at each other, not really sure what to make of all this.\n\n'Well, come on if you're getting on. No time to waste!'\n\nWill Sonic and Tails get on the bus (turn to <b>270</b>), or will they set off on foot (turn to <b>143</b>).",
		choices = new int[2] {270, 143}
	};

	public static Section section203 = new Section()
	{
		text = "Sonic and Tails have come up the ramp far too fast, and they find themselves tumbling towards the bottom of the table. Tails has started to hover and will be safe. Sonic, however, must find some other way to escape. All around him the various targets and bumpers flash past - if only he can somehow grab hold of one of those bumpers.\n\nSonic reaches out with his left paw and just manages to grab one. Hanging on for all he's worth, the bumper spins him round and catapults him back to the top of the table, where he lands with a thump on a platform.\n\n'Not bad, but it's quicker by air!' Tails says, looking smug as he stands and watches Sonic dusting himself down.\n\n'OK then,' says Sonic, a little annoyed at his smirking friend. 'As you're SO COOL, let's see you go first for a change!'\n\nNow Tails is in the hot seat, which way will he go?\n\nThe platform to the right?\t\t\tTurn to <b>218</b>\nThe platform to the left?\t\t\tTurn to <b>109</b>",
		choices = new int[0] {}
	};

	public static Section section204 = new Section()
	{
		text = "This tunnel looks like the one they have just left. It would be real easy to get lost here! There are two exits out of this part of the complex. Should Sonic and Tails carry straight on (turn to <b>111</b>), or should they take a right turn (turn to <b>272</b>)?",
		choices = new int[2] {111, 272},
		mackSection = true
	};

	public static Section section205 = new Section()
	{
		text = "Sonic takes a quick side-step and easily avoids falling into the trap. Ahead, the tunnel opens into a large room. Being careful to make sure there aren't any more hidden traps, Sonic walks in. The only things there are a large red button marked Return and a very tall pillar. On top of the pillar Sonic can just see a pair of tweezers. What should Sonic do now? Press the red button (turn to <b>187</b>)? If Sonic is alone and he wants to get the tweezers, turn to <b>138</b>. If Tails is with him, turn to <b>264</b>.",
		choices = new int[3] {187, 138, 264}
	};

	public static Section section206 = new Section()
	{
		text = "The small sailing boat has been left dumped on the beach for some reason. Nothing seems to be wrong from first impressions, but both of the heroes are a little wary all the same.\n\n'Do you know anything about boats?' Tails asks Sonic.\n\n'Yes, of course,' replies Sonic, who knew they floated and hoped that that was enough. Together, they push the boat into the glooping mess that was now the ocean.\n\n'See,' said Sonic as they both climbed aboard. 'NO PROBLEM!'\n\nThe boat starts to move out to sea, even though there was no breeze in its small sail. Turn to <b>69</b>.",
		choices = new int[1] {69}
	};

	public static Section section207 = new Section()
	{
		text = "The lever is set about three metres above the floor of the valley – an easy jump for someone of Sonic's ability, isn't it? Roll the die and add the result to Sonic's Agility. If the score is more than 6, turn to <b>47</b>. If the score is less than 6, then turn to <b>162</b>.",
		choices = new int[2] {47, 162}
	};

	public static Section section208 = new Section()
	{
		text = "Have Sonic and Tails already smashed up the Bottle Bank and the Spine Fields? If they have, then turn to <b>130</b>. If they have not smashed up these rooms, turn to <b>152</b>.",
		choices = new int[2] {130, 152}
	};

	public static Section section209 = new Section()
	{
		text = "Neither Sonic nor Tails really knows what to make of all this. The only thing that's for sure is that Zonik has to be stopped, though how they are going to do it remains to be seen! Through the gate to the Aquatic Ruin, the sea breeze hits them like a breath of fresh air. Or rather it should have done, instead all they could smell was oil!\n\n'Looks like the Oil Ocean to me, Sonic. I thought you said this was going to be the Aquatic Ruin?' says Tails.\n\n'Well, it should be,' replies a rather puzzled Sonic. In front of them stretches the coast line, <i>usually</i> lapped by brilliant blue seas. Today the sea has turned black ... like oil.\n\n'Looks like oil ... smells like oil,' says Tails, bending down to dip a paw into the edge of the sea. 'And feels like oil too!'\n\n'OK, so it's oil!' says Sonic, a little irritated. The normal route down to the submerged city lies straight in front of them. About a hundred metres over to the right, a small sailing boat lies on the beach. Will Sonic and Tails go by the normal route (turn to <b>99</b>), or will they try the boat (turn to <b>206</b>)?",
		choices = new int[2] {99, 206}
	};

	public static Section section210 = new Section()
	{
		text = "Now it's time to fight! Zonik has a fighting score of 6 and his skimmer needs to be hit three times to put it out of action. Sonic may fight using any of his abilities (you choose). Tails cannot help Sonic – he needs to fly the skimmer – but because Tails is such a natural flyer, Sonic may add 1 to whatever score he gets. If Sonic and Tails win, turn to <b>136</b>. If they lose, then turn to <b>90</>.",
		choices = new int[2] {136, 90}
	};

	public static Section section211 = new Section()
	{
		text = "Before reading any further, make sure you have written down the number of the section you have just come from, otherwise you won't be able to continue this adventure!\n\nSonic and Tails have got so used to the star-shaped lanterns that they don't give them a second glance any more. This is a big mistake. Suddenly, one of the lanterns starts to pulse and make a whining noise. Sonic and Tails look at each other, mystified. Slowly, the whining gets louder and louder ... BOOOOOM!!!!! The lantern explodes, sending five missiles straight towards our two friends.\n\n'ASTERON!' shouts Sonic. There's no time to run from the missiles. Sonic and Tails will have to dodge them.\n\nRoll the die and add the result to Sonic's Agility. If the score is 7 or more, then Sonic has managed to dodge the missiles. If the score is less than 7, at least one of the missiles has hit him. A missile hit will destroy all Sonic's rings or, if he doesn't have any rings, it will remove one of his lives.\n\nReturn to the last section you read before this one.",
		choices = new int[0] {}
	};

	public static Section section212 = new Section()
	{
		text = "As the Zonik jars move along the conveyor-belt, they get sprayed with a yellow mist. Sonic doesn't know what it is, but judging by the way the tiny Zoniks jump about, it looks important. The glue would jam that nozzle up nicely! Taking aim, Sonic squeezes the tube and a blob lands right on the end of the nozzle. SPURGGLLEE!!\n\nFor a few moments nothing happens, then a red light starts to flash on the nearest machine, then another and another. The conveyor-belt grinds to a halt.\n\n'BURRR ... BURRRR ... EMERGENCY ... EMERGENCY!!!!!' booms out a mechanical voice. All the robots start to move away from the machinery.\n\n'Hmm,' says Tails. 'I'd say we've broken it.'\n\nTurn to <b>208</b>.",
		choices = new int[1] {208}
	};

	public static Section section213 = new Section()
	{
		text = "Spotting their chance to escape, Sonic flips over backwards and spins off down the tunnel, quickly followed by Tails, though strangely the creatures make no attempt to chase after them. Still moving at breakneck speed, they round a bend and see with horror no less than four of Robotnik's Guardbots walking towards them. Sonic judders to a halt and is abruptly knocked flying by Tails, whose reactions weren't quite as good as his! Faced with a choice of a dozen or so small furry creatures and four Guardbots, who Sonic knew were hostile, there wasn't much option!\n\n'RUN AWAY!' shouts Sonic, and with that both he and Tails run off back the way they had just come. Fortunately, the Guardbots seem not to have seen them, and soon they find themselves back where they had first seen the rings. The furry creatures are still there. It looks like they're going to have to trust them after all. Turn to <b>11</b>.",
		choices = new int[1] {11}
	};

	public static Section section214 = new Section()
	{
		text = "The surface of the Zone is barren and rocky and not very nice at all. At last, Sonic and Tails and Zonik stand facing each other. It's time for the final showdown!\n\nIf Zonik crash-landed, he has a fighting score of 5, otherwise it is 7. Like Sonic, he has three lives, and therefore needs to be hit three times to be beaten. If Sonic crash-landed, then he must subtract 1 from each of his die rolls.\n\nSonic <i>must</i> have the gloves to fight Zonik. (If Sonic hasn't been to the Special Zone yet, then he must go and get them if he has enough rings - use the Zone Chip from Sonic's Stuff.) Tails will help Sonic. Finally, if Sonic has the Chaos Emerald, he may add 2 to each of his die scores. If Sonic and Tails win, turn to <b>300</b>. If Zonik beats them, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {300}
	};

	public static Section section215 = new Section()
	{
		text = "Grabber immediately scuttles towards our two adventurers, but before he can do so, Zonik disappears into a spin and strikes the spider a massive blow. Grabber goes down with a thump and rolls on to his back, all eight metal legs flailing in the air. Above him is a blue blur. The blur, moving at fantastic speed, spins through the air and lands with a mighty thump on Grabber's head, sending sparks and bits of metal flying in all directions.\n\n'Outstanding!' Sonic says aloud.\n\n'I'm glad you think so,' says the blue hedgehog now standing on the shattered remains of Grabber.\n\n'THAT'S HIM! The one that attacked me,' exclaims Tails\n\nFace to face with a mirror image of himself, Sonic is quite literally dumbstruck, which, let's face it, doesn't happen very often! It was Zonik who broke the silence first.\n\n'So, you're the one I was made to look like,' he sneers. 'Hmm, I think I'm an improvement, don't you?'\n\nSonic's mouth falls open, unable to believe that anyone would have the cheek to speak to him like this. Zonik continues his taunting. 'Soon I'll have enough rings to reach the Ring Zone.' He raises a finger and points it straight at Sonic. 'Then you'll get yours!' With that, he launches into an enormous spin that sends him over Sonic's head, past the hovering Tails, and he is gone. By the time Sonic has recovered his balance, there is no sign of Zonik.\n\n'Now you've seen him too,' says Tails, relieved that his story has been proven.\n\n'Yes,' says Sonic. He looks at the disappearing trail of dust, then turns to look Tails straight in the eye. 'The next time, I'll be the one doing the talking!'\n\nGrabber, meanwhile, has been slowly struggling to his feet. There are only five of them left and his body is covered in dents, but he still looks pretty mean. Will Sonic and Tails attack Grabber and finish him off (turn to <b>293</b>), or will they try and speak to him (turn to <b>5</b>)?",
		choices = new int[2] {293, 5}
	};

	public static Section section216 = new Section()
	{
		text = "'Come on, Tails, fly after him!' yells Sonic. Tails flies into the air holding out a paw for Sonic to grab. Zonik is already just a dot on the horizon. Our friends will have to move fast to catch him! Turn to <b>114</b>.",
		choices = new int[1] {114}
	};

	public static Section section217 = new Section()
	{
		text = "The room that they are in is truly enormous, and even after about ten minutes' walking, they still cannot see the other side – and all the time the sound of machinery gets louder and louder.\n\n'I'm not so sure we should be going this way. That noise doesn't sound very friendly,' says Tails.\n\nSonic smiles and replies, 'Then how about we go this way then?' Sonic points to the ground, very obviously pleased with himself at spotting the small trapdoor half hidden under a pile of rags, a little off to the left. Tails could get annoyed at the way Sonic showed off sometimes, and he was just trying to think of something to say to put his friend in his place, when he spotted the ideal thing.\n\n'Or what about that one you're standing on!'\n\nSonic looks down at his feet. 'Yes,' he says after a short pause. 'Or that one!' Should they go down the trapdoor under the pile of rags (turn to <b>118</b>), or down the one that Sonic is standing on (turn to <b>15</b>)?",
		choices = new int[2] {118, 15}
	};

	public static Section section218 = new Section()
	{
		text = "The platform is only a short drop, and both of our friends make it easily. Below them, they can see the game, stretching away into the distance. To the right, they can see a row of targets. Directly below, there is a spinner. Do they:\n\nAim at the targets?\t\t\tTurn to <b>86</b>\nDrop into the spinner?\t\t\tTurn to <b>124</b>",
		choices = new int[2] {86, 124}
	};

	public static Section section219 = new Section()
	{
		text = "Sonic reaches down and picks up the needle with his tweezers. It is indeed exactly like one of his own spines in all save two respects. Firstly, it is glowing and secondly it smells distinctly EGGY! Being careful not to touch it, Sonic places the spine in his bag. Remember to add it to Sonic's Stuff, then it's time to go to the Chemical Plant. Turn to <b>201</b>.",
		choices = new int[1] {201}
	};

	public static Section section220 = new Section()
	{
		text = "Sonic and Tails must fight the Rexon. He has a fighting score of 6 and needs two hits to be killed. Tails will help Sonic fight. If you cannot remember how to do this, then read again the section at the beginning of the book. The Rexon will fight to the death, and it is so aggressive that Sonic cannot use the energy gun, even if he wants to. Sonic must fight the Rexon using Strength. If Sonic and Tails beat the Rexon, turn to <b>67</b>. If the Rexon wins, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {67}
	};

	public static Section section221 = new Section()
	{
		text = "The chip starts to flash with red lights and emit a quiet humming sound. Suddenly, Sonic feels a little dizzy and Tails starts to sway from side to side. The next thing they know, they're standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic and Tails must choose carefully. They will only be allowed to go through a door once. It will seal shut for ever afterwards. Once they have decided which one to go through, put its number down so that they do not try and use it again! Which door do you think Sonic and Tails should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>",
		choices = new int[4] {149, 290, 252, 245}
	};

	public static Section section222 = new Section()
	{
		text = "The sides of the valley were very steep and the going very slow. Far below, Sonic and Tails could see the ominous shape of the buggy. When Sonic first came across it, Robotnik himself used to drive the contraption, but when he kept losing, he automated the buggy to drive itself. The buggy didn't move. It can't have seen either of our heroes. It went against the grain for Sonic to refuse a fight, but with Tails still a little under the weather after his ordeal, it was probably the best thing to do. After another half an hour, the two heroes were past the buggy and standing at the gate to the Chemical Plant. Turn to <b>250</b>.",
		choices = new int[1] {250}
	};

	public static Section section223 = new Section()
	{
		text = "The footpath slowly makes its way uphill. The sides of it are now piled high with rubbish.\n\n'You know,' says Tails, 'you always bring me to the nicest places, Sonic.' Sonic turns to look at his friend, thinking of some suitable reply, when suddenly a giant silver claw shoots out of the rubbish in front of him.\n\n'SLICER!!!' yells Tails. The claw flies past Sonic's head. Sonic and Tails must fight the Slicer using Speed. Tails will help. The Slicer has a fighting score of 6, but it only needs one hit to be destroyed. If Sonic and Tails win, turn to <b>93</b>. If Slicer beats them, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {93}
	};

	public static Section section224 = new Section()
	{
		text = "The tunnel winds this way and that for ages. At last, our friends come to a three-way junction. In which direction should they go:\n\nTo the left?\t\t\tTurn to <b>122</b>\nStraight on?\t\t\tTurn to <b>30</b>\nTo the right?\t\t\tTurn to <b>83</b>",
		choices = new int[3] {122, 30, 83},
		asteronSection = true
	};

	public static Section section225 = new Section()
	{
		text = "'Greetings, you are Sonic, are you not? Oh, and your brave companion Tails, if I'm not mistaken,' the voice comes from a wizened old creature sitting in the middle of the cave.\n\n'Yes, I'm Sonic. And who might you be?' replies Sonic.\n\n'Well, I \"might\" be anyone, as it is I'm Frisp. I'm the chief of the Tunnel Rats,' the creature waves his arm around the room.\n\nSo, they're rats! 'What were the rings left lying around for?' asks Sonic.\n\n'They were left by Robotnik as a trap. It's just as well we were there to help you,' says Frisp, and the other rats murmur their approval.\n\n'How did you know to be there at the right time, then?' asks Tails.\n\nFrisp stands up and holds his arms wide. 'I am Frisp and I can see the future,' the other rats start to chant. Frisp continues, 'I know that you seek one like yourself and also I know that, as we speak, he is at the FakTor-Eee in the centre of the city. He is a creature of Robotnik, and he is of great evil.'\n\n'EVIL, EVIL,' the other rats chant. They seem to know more about what's going on than Sonic does!\n\n'Will you help us?' asks Tails.\n\n'Help? HELP? Of course we will help,' exclaims Frisp. 'Here, take these.' The old rat holds out a roll of paper, a tube of glue, and a bright red piece of plastic. 'These will help you, but remember also that the power of light is greater than steel. Now be gone, for you have but little time. My rats will show you the way.' Remember to add these things to Sonic's Stuff. Turn to <b>150</b>.",
		choices = new int[1] {150}
	};

	public static Section section226 = new Section()
	{
		text = "Sonic and Tails fly through the gate and land in an undignified heap. Looking around, they see that they have indeed arrived in the casino. It is lit up by multicoloured lights, and there are signs all over the place showing the way to various attractions.\n\n'You know, Tails,' says Sonic, 'I always quite liked this place. Come on, let's have a look around.' With that Sonic is off, leaving a still dazed Tails to hurry after him. After a few seconds, Sonic spots a large fruit machine against a wall. Will Sonic go and play it (turn to <b>171</b>), or will he ignore it (turn to <b>66</b>)?",
		choices = new int[2] {171, 66}
	};

	public static Section section227 = new Section()
	{
		text = "At last, Sonic and Tails are up in the air and in hot pursuit of the evil Zonik. Despite his head start, our heroes are gaining on him by the second.\n\n'Watch out for the acid clouds,' shouts Sonic. 'Touch one and we're finished!'\n\n'Like that one, you mean?' Tails points to a large acid cloud looming up in front of them.\n\n'Yes, just like that one!' warns Sonic. Should our friends swerve to the right (turn to <b>192</b>) or to the left (turn to <b>32</b>)?",
		choices = new int[2] {192, 32}
	};

	public static Section section228 = new Section()
	{
		text = "With great body control, Sonic and Tails speed towards the next target. They strike it a glancing blow, scoring 10 points if this is the first time they have been here. In the distance yet another target can be seen. Roll the die and add the result to Sonic's Strength, and then add his Agility. If the combined score is 10 or more, turn to <b>133</b>. If the combined score is less than 10, turn to <b>283</b>.",
		choices = new int[2] {133, 283}
	};

	public static Section section229 = new Section()
	{
		text = "Sonic and Tails speed out into the game at a terrific rate. Everything is a blur, and only at the very last minute does Sonic see a large target flashing with bright blue lights. First Sonic, and then Tails, hits the target square in the middle. If this is the first time they have been here, then they score 10 points. Add them to Sonic's Point Score. Now roll the die and add the result to Sonic's Strength. If the score is less than 6, you <i>must</i> turn to <b>283</b>. If the score is 6 or more, then Sonic and Tails can go either to a bouncer (turn to <b>181</b>), or to another bouncer (turn to <b>6</b>), or spring back to <b>124</b>.",
		choices = new int[4] {283, 181, 6, 124}
	};

	public static Section section230 = new Section()
	{
		text = "Carefully, Sonic powers up the energy gun and takes aim. A direct hit! The Badnik wobbles slightly but keeps on firing. Sonic and Tails may now fight the Badnik if they wish. The Badnik has a fighting score of 6 and three hits will be needed to destroy it. Tails will help Sonic. This is one MEAN hombre! Fortunately, though, the energy gun does seem to have slowed him down a bit. Or would it be wiser for Sonic and Tails to try something else – there is still time? Should they:\n\nTry using some glue?\t\t\tTurn to <b>107</b>\nTry to roll the Badnik over?\t\t\tTurn to<b>53</b>\n\nIf Sonic and Tails decide not to be such wimps, and fight the Badnik, turn to <b>249</b> if they win. If the Badnik wins, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[3] {107, 53, 249}
	};

	public static Section section231 = new Section()
	{
		text = "This is a sad day for Mobius. You have allowed Sonic and Tails to be so soaked in Mack that they have lost their special abilities for ever! Eventually, they'll make it out on their own, but their days of being superheroes are over. Looks like Zonik has won.\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[0] {}
	};

	public static Section section232 = new Section()
	{
		text = "Sonic pushes the one-player button and waits. Nothing happens for a moment or two, then the screen lights up.\n\n'Wow, it's Mobius Fighter II. Brilliant!' Sonic loves this game. Roll the die and add the result to Sonic's Quick Wits. If the score is 6 or more, turn to <b>198</b>. If the score is less than 6, then the unthinkable has happened and Sonic has lost. He must press the Return key. In disgust, turn to <b>187</b>.",
		choices = new int[2] {198, 187}
	};

	public static Section section233 = new Section()
	{
		text = "Now the platforms are moving again, the route up to Tails is an easy one. Well, at least it was easy to someone like Sonic. Three hops, a jump, one little spin and a final hop and Sonic gets to the top. He looks anxiously down at the motionless body of Tails. His friend looks awful.\n\n'Tails,' Sonic reaches out a paw to touch his friend. Tails, it's me ... Sonic,' he says. Gradually, Tails wakes up. He looks at Sonic, his eyes getting wider and wider.\n\n'No! No! Stay away from me! STAY AWAY!!!' Tails screams. He tries to hover, but he can't because his tails are tied together. His eyes look wild, and Sonic is sure that he is frightened.\n\n'But Tails, it's me, Sonic. I'm your friend. Who did this to you?'\n\n'You did! You did!' howls Tails, his eyes filling with tears. With this, Tails tries once more to hover, and this time the knot in his tails falls out and he is away.\n\n'Come back!' yells Sonic, but his friend is already gone. Turn to <b>98</b>.",
		choices = new int[1] {98}
	};

	public static Section section234 = new Section()
	{
		text = "As the emerald flies through the air, Tails hovers and catches it smartly with both paws. Zonik, who's on his feet by now, sees this and starts to back away. 'You want some of this!' says Tails, waving the emerald at Zonik.\n\n'You haven't heard the last of this!' shouts Zonik, turning and running away for all he's worth.\n\nSonic, too, is back on his feet again, and Tails tosses him the emerald. Immediately, Sonic feels strong and all the damage done by the explosion is put right. Sonic admires the emerald. The small gems hold awesome power. Now they were really in business. Remember to add the Chaos Emerald to Sonic's Stuff, then turn to <b>191</b>.",
		choices = new int[1] {191}
	};

	public static Section section235 = new Section()
	{
		text = "Sonic just manages to spin out of the way of the ball as it whizzes past him. Tails manages to get airborne, so he is safe as well. Unfortunately, the effort has caused both of them to lose their balance, and both Sonic and Tails start to fall towards the bottom of the game. Rushing past them on the right is the central spinner, if only they can reach it. Roll the die and add the result to Sonic's Agility. If the score is 6 or more, then turn to <b>124</b>. If the score is less than 6, turn to <b>283</b>.",
		choices = new int[2] {124, 283}
	};

	public static Section section236 = new Section()
	{
		text = "Our two friends creep up to the door labelled Bottle Bank. There is no noise coming from inside, and Sonic pushes open the door boldly, to find a huge storeroom full of shelves.\n\n'These shelves are full of bottles. Look!' says Tails, pointing to the nearest shelf. A quick look round reveals that the place is crammed with bottles of a faintly familiar shape. By the far wall there is a door labelled Production Line. What should the heroes do now:\n\nGo and look in the other room (if they haven't been there already)?\t\t\tTurn to <b>59</b>\nSmash the place up?\t\t\tTurn to <b>72</b>\nGo through the door labelled Production Line?\t\t\tTurn to <b>248</b>",
		choices = new int[3] {59, 72, 248}
	};

	public static Section section237 = new Section()
	{
		text = "Carefully, Sonic takes out the Zone Chip and looks at it. It will cost 10 rings to use it himself, or 20 if he wishes Tails to come with him. Once you have decided whether you want Tails to go or not, you must cross that number of rings off Sonic's Stuff. If you don't want Sonic to use the Chip at all, return to the section you have just come from. If you want Sonic to use the Chip, turn to <b>127</b>. If you think Tails should go as well, turn to <b>221</b>.",
		choices = new int[2] {127, 221}
	};

	public static Section section238 = new Section()
	{
		text = "Despite a MASSIVE effort by Sonic, he tumbles into the oil just millimetres from the shore. The oil is only shallow, but the splash covers him in the stuff from head to foot! Subtract one point from Sonic's Good Looks, and then turn to <b>128</b>.",
		choices = new int[1] {128}
	};

	public static Section section239 = new Section()
	{
		text = "The walls of the tunnel form a perfect tube. They are made of some dull greyish metal streaked with horrible smears of dried-on Mack. They look a bit like a Robotnik' s white coat with all its egg stains ... Euugh! After a while, the tunnel branches in two. One tunnel carries straight on (turn to <b>194</b>), the other curves off to the right (turn to <b>204</b>).",
		choices = new int[2] {194, 204},
		mackSection = true
	};

	public static Section section240 = new Section()
	{
		text = "Abruptly, Sonic and Tails find themselves standing at a T-junction. Should they go left (turn to <b>100</b>) or right (turn to <b>276</b>)?",
		choices = new int[2] {100, 276},
		mackSection = true
	};

	public static Section section241 = new Section()
	{
		text = "The whole of Metropolis is honeycombed with these tunnels, but since neither of them knew what they were looking for, this could be a very long job.\n\n'Where do you think we ought to head for, Sonic?' asks Tails.\n\n'I was thinking we should head for Robotnik's HQ, and then play it by ear from there,' says Sonic, almost as an afterthought. 'I mean, he's bound to know what's going on, all we've got to do is persuade him to tell us.'\n\n'Easy, really,' says Tails, not convinced.\n\n'Oh no! We've come to a dead end,' says Sonic, looking at the wall in front of them.\n\n'Hang on! Walls don't move!' screams Tails. Quickly, turn to <b>156</b>.",
		choices = new int[1] {156}
	};

	public static Section section242 = new Section()
	{
		text = "Launching into a spin, Sonic aims himself straight at the ship, closely followed by Tails. The hover ship has a fighting score of 5 and it needs to be hit twice to be destroyed. In this fight, Tails may help Sonic. Sonic will fight using his Strength. If Tails and Sonic manage to beat the hover ship, then turn to <b>102</b>. If they lose, turn to <b>281</b>.",
		choices = new int[2] {102, 281}
	};

	public static Section section243 = new Section()
	{
		text = "The shattered body of Grabber lies at their feet. Sonic and Tails look down at the heap of scrap metal, and spot something gold in among the debris. Poking around, they find 20 rings! Add these to Sonic's Stuff and then turn to <b>209</b>.",
		choices = new int[1] {209}
	};

	public static Section section244 = new Section()
	{
		text = "BAD NEWS!!! Sonic's worst nightmare comes true! The river is ice cold and already Sonic can feel himself slowly sinking. The cold is severely limiting his aquatic abilities. There's only one thing for it: he calls out and hopes Tails will come to the rescue. Roll the die and add the result to Sonic's Good Looks. If the score is 10 or more, then turn to <b>104</b>. If the score is less than 10, turn to <b>131</b>.",
		choices = new int[2] {104, 131}
	};

	public static Section section245 = new Section()
	{
		text = "The door opens before Sonic has even touched it. There is no room behind it, only two small panels set into the wall and a small red button with the word Return above it. Above the right-hand panel is the word Abomb, and above the left-hand one is written Ebomb. The panels look like they will slide open. Should Sonic:\n\nOpen the right-hand panel?\t\t\tTurn to <b>160</b>\nOpen the left-hand panel?\t\t\tTurn to <b>172</b>\nPress the Return button?\t\t\tTurn to <b>187</b>",
		choices = new int[3] {160, 172, 187}
	};

	public static Section section246 = new Section()
	{
		text = "Carefully keeping a very close eye open for flying coconuts, Sonic tries to talk to the irritating monkey.\n\n'Tell me, Coconuts, what's it like to be smelly, ugly and stupid?' Sonic frowns and waits, hoping that he has said the right thing to Coconuts. Sonic really has a way with words, quite a charmer in fact!\n\n'Go and play with a neutron blaster, flea bag!' Coconuts jeers back.\n\nPerhaps, thinks Sonic, that wasn't quite the right thing to say. Coconuts grabs another missile and flings it at Sonic. No point in trying to reason with him, thinks Sonic. Turn to <b>144</b>.",
		choices = new int[1] {144}
	};

	public static Section section247 = new Section()
	{
		text = "The sandy path leads into the jungle, running beneath huge palm trees. This is the sort of place that Coconuts would like to hang out in and both of them keep a wary eye on the tree-tops. They are so intent looking above them that the first either knew of the treasure chest was when Tails walked straight into it with a THUMP!\n\n'Ow!' says Tails.\n\nSonic looks at the large wooden chest that stands right in the middle of the pathway. 'Now, who would want to put a treasure chest in such an obvious place?'\n\n'Perhaps they dropped it?' says Tails, rubbing his leg.\n\n'Or,' says Sonic, 'they, whoever they are, wanted us to find it?'\n\nShould Sonic open the chest and see what's inside it (turn to <b>254</b>), or should he leave it where it is (turn to <b>80</b>)?",
		choices = new int[2] {254, 80}
	};

	public static Section section248 = new Section()
	{
		text = "Carefully, Sonic pushes open the door and peers through it. 'WOW ... Mega ...' Sonic just can't help himself. Through the door they can see a room so big they cannot even see the roof, let alone the other side of it! There are machines all over the place and robots too! The place is buzzing with activity, and it all seems to be centred around a slow-moving conveyor belt, but from where our friends are standing, they cannot see what's going on.\n\n'Let's have a closer look,' whispers Sonic, and our two friends slowly creep towards the conveyor belt. The robots are so intent on doing whatever it is that they are doing, that no one sees them. When they are closer, they can see that the conveyor belt is full of glass jars. Jars with blue stuff in them.\n\n'OH NO!' exclaims Tails. 'Look!' he says, pointing at the jars. Sonic obeys, looks at the jars and sees what has spooked Tails. Every jar contains a small blue hedgehog. One Zonik was bad enough, but the way this place is churning them out there would soon be thousands!\n\nWhat will our friends do:\n\nSmash the place up?\t\t\tTurn to <b>134</b>\nThink about using some glue (if Sonic has any in his Stuff)?\t\t\tTurn to <b>212</b>\nUse an energy bomb (again only if Sonic has one)?\t\t\tTurn to <b>197</b>",
		choices = new int[3] {134, 212, 197}
	};

	public static Section section249 = new Section()
	{
		text = "With the Badnik dealt with, Sonic and Tails can have a good look around the cavern. Over on the far side is a solid steel door with a lever beside it. Apart from that the cavern looks empty. Roll the die and add the result to Sonic's Quick Wits. If the score is 6 or more, turn to <b>132</b>. If the score is less than 6, then turn to <b>74</b>.",
		choices = new int[2] {132, 74}
	};

	public static Section section250 = new Section()
	{
		text = "Sonic always felt a little funny when he went through a Zone Gate. Not surprising really, jumping from one place to another like that without regard for the laws of nature was bound to make a hedgehog feel a little dizzy. Even if the gate didn't affect him, the stench that hit the two heroes a split second after they were in the Chemical Plant was enough to turn your trainers green! Everywhere, they could smell the unmistakably vile Mega Mack.\n\n'Pheeeew,' says Tails. 'Whiffy!'\n\nAhead of them, Sonic can see the familiar tunnels of the Chemical Plant disappearing into the distance. The plant is a real maze.\n\n'Which way?' asks Tails, trying to keep the worst of the smell out by pinching his nose tightly.\n\n'Your guess is as good as mine,' replies Sonic. In front of them, the tunnel branches to the left and to the right. Should they go left (turn to <b>7</b>) or right (turn to <b>61</b>)?",
		choices = new int[2] {7, 61}
	};

	public static Section section251 = new Section()
	{
		text = "Just in time, Sonic sees the missing step and with a skilful spin grabs Tails. At the same time, he pulls both himself and his furry friend clear of the huge puddle of Mack that was lurking at the bottom of the steps.\n\n'So COOL!' says Sonic and for once Tails just has to agree! A long tunnel stretches into the distance in front of them. Turn to <b>46</b>.",
		choices = new int[1] {46}
	};

	public static Section section252 = new Section()
	{
		text = "The door opens automatically to reveal a small room. In the middle is a computer console. Curious, Sonic walks over to have a closer look. There is a message printed on the screen. It says, PRESS RETURN TO EXIT OR F1 TO PLAY. What will Sonic do:\n\nPress Return?\t\t\tTurn to <b>187</b>\nPress F1?\t\t\tTurn to <b>178</b>",
		choices = new int[2] {187, 178}
	};

	public static Section section253 = new Section()
	{
		text = "In a daze, Sonic walks over to the start of the maze. Tails was in a dreadful state. His fur was all muddy and it looked like – but, no, it couldn't be true – someone had tied poor Tails' two tails together! Sonic's blood boiled ... who could have done this to his friend?\n\n'Tails ... TAILS,' Sonic shouts, but Tails doesn't move. 'I must rescue him,' Sonic says aloud. Sonic looks at the platforms and spots a small wooden lever set into the cliff. Should Sonic try to help Tails (turn to <b>139</b>), or will he have a look at the lever (turn to <b>207</b>)?",
		choices = new int[2] {139, 207}
	};

	public static Section section254 = new Section()
	{
		text = "Leaning forward, Sonic gingerly reaches out with a paw and tries the lid of the chest. It's not locked.\n\n'Here we go, then,' says Sonic, and with a flick of the wrist the lid is open. Peering inside, they can see GOLD – 10 rings to be precise! Add these to Sonic's Stuff and then turn to <b>80</b>.",
		choices = new int[1] {80}
	};

	public static Section section255 = new Section()
	{
		text = "'So, now I have you! Grrrr ... at last!' says the deep metallic voice. 'It will be a great pleasure to see you in my web!'\n\n'You are so Uncoolnik, Grabber, you know that, don't you?' replies the other voice, which does sound very like Sonic's own.\n\n'I think I shall make you a small piece Cooler, my friend ...'\n\n'Grrr!' The metallic voice is cut short by huge CRAASH. Turn to <b>19</b>.",
		choices = new int[1] {19}
	};

	public static Section section256 = new Section()
	{
		text = "Light streams through the open door, along with the clamouring noise of machinery and a faint acidy smell. 'Look, what's this?' asks Tails, inspecting a small sign on the door. Sonic reads it aloud: '\"Cloning Plant. Strictly no admittance\". Best we go in and have a look around in that case!' he adds, with a smile on his face. From here our friends can walk up a short corridor and open a door. The door has a sign above it, saying 'Spine Fields – Danger'. Should they go through the door (turn to <b>59</b>)? If this is too risky, then they can walk the opposite way and open a door labelled 'Bottle Bank' (turn to <b>236</b>).",
		choices = new int[2] {59, 236}
	};

	public static Section section257 = new Section()
	{
		text = "The raft is a rather rickety affair. Tails kicks it and pulls a face. There's an ominous creaking sound, but the raft stays in one piece.\n\n'Well, it looks safe enough,' says Tails, not sounding at all convinced. Sonic looks at it, and then the nasty smelly stream. Should they:\n\nFloat down the stream on the raft?\t\t\tTurn to <b>120</b>\nGo and look at the footpath?\t\t\tTurn to <b>223</b>\nReturn to the strange-looking pole?\t\t\tTurn to <b>44</b>",
		choices = new int[3] {120, 223, 44}
	};

	public static Section section258 = new Section()
	{
		text = "Sonic tries to use his charm and wits to persuade the man, who he discovers is no less a person than the casino's commissionaire. Sonic explains that it was Zonik, and not himself, who had done the damage. The commissionaire is not convinced.\t\tRoll the die again and add the result to Sonic's Quick Wits. If the score is 6 or more, then turn to <b>110</b>. If the score is less than 6, turn to <b>54</b>.",
		choices = new int[2] {110, 54}
	};

	public static Section section259 = new Section()
	{
		text = "The streets of Metropolis are thronged with every kind of creature imaginable, and everywhere there are Badniks! Sonic and Tails move slowly, ducking from one small alleyway to the next, desperately trying to remain unseen.\n\n'This is getting us nowhere fast, old friend,' says Tails. Sonic has to agree. About thirty metres ahead of them, they can see another Subway entrance.\n\n'The Subway it is then,' decides Sonic. Turn to <b>64</b>.",
		choices = new int[1] {64}
	};

	public static Section section260 = new Section()
	{
		text = "Braving the smell, Sonic and Tails gingerly explore the dank little room. Roll the die and add the result to Sonic's Good Looks. If the score is 6 or more, then turn to <b>262</b>. If the score is less than 6, turn to <b>175</b>.",
		choices = new int[2] {262, 175}
	};

	public static Section section261 = new Section()
	{
		text = "There are lots of the strange star-shaped lanterns in this part of the tunnel. In different circumstances, they might have even looked pretty! No time to think of that though, Sonic and Tails have come to a junction. Will they go to the left (turn to <b>103</b>) or carry straight on (turn to <b>27</b>)?",
		choices = new int[2] {103, 27},
		asteronSection = true
	};

	public static Section section262 = new Section()
	{
		text = "Although Sonic isn't really that keen on poking around in such a dirty smelly place, he puts the interests of Mobius above his own and sets about searching. After not very long at all, he finds a pile of oily rags. Kicking them aside, he discovers no less than 10 rings! Add these to Sonic's Stuff and then it is time to get out of here. Turn to <b>101</b>.",
		choices = new int[1] {101}
	};

	public static Section section263 = new Section()
	{
		text = "Roll the die and add the result to Sonic's Speed. If the score is 6 or more, then he and Tails have made it to the heli-chopper. They can now fly away (turn to <b>121</b>). If the score is less than 6, they will have to stand and fight the Rexon (turn to <b>220</b>).\n\nAlternatively, Sonic may spend 10 rings and use the energy gun. This will freeze the Rexon long enough for both Sonic and Tails to escape comfortably. If you have used the energy gun and paid the price in rings, then turn to <b>121</b>.",
		choices = new int[2] {121, 220}
	};

	public static Section section264 = new Section()
	{
		text = "The pillar is indeed very high, but with Tails here that's absolutely NO PROBLEM! Tails hovers up and picks up the tweezers. Remember to add them to Sonic's Stuff. Now, the only thing left for them to do is to press the red Return button. Turn to <b>187</b>.",
		choices = new int[1] {187}
	};

	public static Section section265 = new Section()
	{
		text = "Reacting with incredible speed, Sonic grabs the target with one paw and Tails with the other, sending both of them whizzing off towards a mushroom bouncer on the left. They give the bouncer a glancing blow, scoring 5 points if this is the first time they have been here. Then they bounce back the way they came, towards the target again. Turn to <b>86</b>.",
		choices = new int[1] {86}
	};

	public static Section section266 = new Section()
	{
		text = "After skirting around the edge of the clearing for what seems like ages, they finally pick up another pathway leading to the North. The pathway gradually leads uphill, until it finally comes to an end against a solid range of cliffs.\n\n'Looks like we're going to have to go back the way we came,' says Tails.\n\nSonic looks at the cliff face, sheer and as smooth as glass. 'Reckon you're right, we might as well have a look at the hut after all,' Sonic suggests.\n\nIt's a lot easier going back down the path than it had been climbing up it, and in no time at all they are back in the clearing. Turn to <b>73</b>.",
		choices = new int[1] {73}
	};

	public static Section section267 = new Section()
	{
		text = "Although it is dark here, the walls of the cave give off a strange greenish glow, enough for our heroes to see where they are going at least. After a while, they come to a fork in the passageway. To the right, there is a small tunnel with lights at the end of it (turn to <b>112</b>).\n\nAlong the main passageway can be heard strange noises! Sonic and Tails strain their ears ... It sounds like digging!\n\n'Probably just another archaeologist,' says Tails in a matter-of-fact way. If you want them to go and investigate the noise, turn to <b>16</b>.",
		choices = new int[2] {112, 16}
	};

	public static Section section268 = new Section()
	{
		text = "Soon, this tunnel begins to widen out until our heroes find themselves in a large cavern ... Thud, thud. BOOOOM!\n\n'What's –' Tails is cut off before he can say any more. BOOOOM. Thud.\n\n'They're missiles. Hit the floor.' Sonic sees the missiles impacting on the wall near where he had been standing a second ago. But where were they coming from?\n\n'There it is!' yells Tails. Sonic looks to where his friend is pointing. Over near the middle of the cave, a gigantic robot lumbers into view. It is the biggest Sonic's ever seen! It's like a massive ball, totally round! The missiles are flying thick and fast from it. What will Sonic and Tails do:\n\nFight the Badnik robot?\t\t\tTurn to <b>14</b>\nUse the energy gun?\t\t\tTurn to <b>230</b>\nTry using some glue?\t\t\tTurn to <b>107</b>\nTry to roll the Badnik over?\t\t\tTurn to <b>53</b>",
		choices = new int[4] {14, 230, 107, 53}
	};

	public static Section section269 = new Section()
	{
		text = "Sonic is the first through the door and he sees Zonik disappearing into the clouds. The door has brought our heroes to the start of the Sky Chase Zone. Zonik is riding a cloud skimmer. There is another one on the platform. Will Sonic and Tails get into the cloud skimmer (turn to <b>164</b>)? Or will Sonic rely on Tails, and let him hover both of them after Zonik (turn to <b>216</b>)?",
		choices = new int[2] {164, 216}
	};

	public static Section section270 = new Section()
	{
		text = "Carefully, Sonic and then Tails get on to the bus. Sitting behind the steering wheel is a small silver robot wearing a rather battered peaked cap.\n\n'Where to, then?'\n\nWhat will Sonic say?\n\n'All the way, please.'\t\t\tTurn to <b>55</b>\n'The city gates.'\t\t\tTurn to <b>95</b>\n'What do you recommend?'\t\t\tTurn to <b>182</b>",
		choices = new int[3] {55, 95, 182}
	};

	public static Section section271 = new Section()
	{
		text = "Sonic powers up the energy gun with 10 rings and fires at Zonik. The beam shoots out towards him. Zonik is covered in the energy field and stops. BANG!!!! The energy field shatters, and Zonik stands before them once more.\n\n'You're going to have to do better than that,' he sneers.\n\nWhat will Sonic and Tails try now:\n\nFight?\t\t\tTurn to <b>31</b>\nUse a bottle of Whiffy liquid?\t\t\tTurn to <b>180</b>",
		choices = new int[0] {}
	};

	public static Section section272 = new Section()
	{
		text = "Another tunnel, another fork at the end of it! This place is such a maze! Tails looks down af the Mack. It's a good deal higher than the last time he looked!\n\nCheck the number of points you have scored so far. If it's more than 20, you <i>must</i> turn to <b>288</b>.\n\nTails and Sonic can now go either to the left (turn to <b>21</b>) or to the right (turn to <b>13</b>).",
		choices = new int[2] {21, 13},
		mackSection = true
	};

	public static Section section273 = new Section()
	{
		text = "They have just reached the island in time. Or have they?! A few metres from the shore, Tails' grip on Sonic's paw finally fails, sending Sonic tumbling towards the oil beneath him. Without the extra weight, Tails will reach the island without any difficulty. Sonic, however, must jump and it's a LONG WAY.\n\nRoll the die and add the result to Sonic's Agility. If the score is equal to or greater than 7, then turn to <b>33</b>. If the score is less than 7, turn to <b>238</b>.",
		choices = new int[2] {33, 238}
	};

	public static Section section274 = new Section()
	{
		text = "The commissionaire stands aside, allowing our heroes to enter the Pinball Hall. In the casino, pinball is far more than simply a table with a steel ball rolling around in it. Here, the PLAYER IS THE BALL!\n\n'The worst damage is in the Big Table,' says the commissionaire. 'All the traps are deadly now, so be very careful!'\n\nTaking the man's advice, Sonic and Tails climb into the entrance to the machine.\n\n'Good luck!' shouts the commissionaire. 'I'll meet you at the other end.'\n\nSonic looks up the steep ramp along which both he and Tails will soon be catapulted. 'Here we go then, let's ROLL!' he says, reaching up towards the Start button. How hard will Sonic press the button:\n\nSoftly?\t\t\tTurn to <b>196</b>\nFairly hard?\t\t\tTurn to <b>280</b>\nHard?\t\t\tTurn to <b>49</b>",
		choices = new int[3] {196, 280, 49}
	};

	public static Section section275 = new Section()
	{
		text = "Unfortunately, smashing all this stuff has made so much noise that a Badnik has come to see what's going on! A large robot appears at the door with no less than four arms, each ending in a vicious claw. Sonic and Tails must fight the Badnik. Tails will help Sonic. The Badnik has a fighting score of 5 and needs three hits to be destroyed. Sonic and Tails must fight using Strength. If they win, our friends will find 20 rings in the wreckage. Once Sonic has beaten the robot, turn to <b>62</b> if they were in the Spine Fields. Turn to <b>72</b> if they were in the Bottle Bank.\n\nIf the Badnik has beaten the two heroes, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[2] {62, 72}
	};

	public static Section section276 = new Section()
	{
		text = "The Mack glows very bright in this tunnel, but being able to see more doesn't really help. Up ahead there's yet another choice to be made. Will Sonic and Tails go to the left (turn to <b>100</b>) or to the right (turn to <b>272</b>)?",
		choices = new int[2] {100, 272},
		mackSection = true
	};

	public static Section section277 = new Section()
	{
		text = "Quick as a flash, Sonic realizes that Robotnik has mistaken him for the evil Zonik. Pushing Tails down out of sight, he replies: 'I am sorry, master, I'll make my way there right now.'\n\n'Make sure you do, I have important business elsewhere to attend to. When I return, you had better be there. And also try and keep out of sight. You've already done far too much damage, especially to the Aquatic Zone.'\n\n'Sorry, master, I got carried away,' says Sonic.\n\n'That's as maybe, but I shall have to put it right, now,' the voice pauses. 'Don't worry, your time will come soon.' The voice tries to sound friendly. 'Now, off to the Metropolis Zone ... and quickly!' With that, the hover ship zooms off. Tails sits up and looks at Sonic.\n\n'The Metropolis Zone?' he says, rather confused.\n\n'Yes, and as quick as we can,' replies Sonic.\n\nTurn to <b>65</b>.",
		choices = new int[1] {65}
	};

	public static Section section278 = new Section()
	{
		text = "Shellcrackers are never an easy opponent, and the fight was a tough one. From the shattered remains, Sonic finds 20 rings and a broken piece of claw. Add these to Sonic's Stuff, and then turn to <b>48</b>.",
		choices = new int[1] {48}
	};

	public static Section section279 = new Section()
	{
		text = "Frantically, both Tails and Sonic start to sail the boat away from Chop Chop, but it is no good. Suddenly, Chop Chop leaps from the sea right in front of them and takes another chunk out of the boat with his vicious jaws. Looks like they're going to have to fight him after all!\n\nTurn to <b>193</b>.",
		choices = new int[1] {193}
	};

	public static Section section280 = new Section()
	{
		text = "Sonic reaches over and presses the large red button marked Start! He gives it a fairly hard push. There is a click, and then a rumble behind them. Suddenly, there is a loud WHOOOSH, and a blast of air catches Tails and Sonic. It carries them up the ramp towards the start of the game.\n\n'It's a lot gentler than the old spring,' yells Sonic, though judging from Tails' expression, he's not convinced!\n\nAfter a couple of seconds the wind starts to fade away and our heroes slow down as the top of the ramp approaches. Just when it seems they aren't going to make it, the ramp curves back on itself and they find themselves falling. Turn to <b>17</b>.",
		choices = new int[1] {17}
	};

	public static Section section281 = new Section()
	{
		text = "Despite all their efforts, our heroes cannot even make a dent in the hover ship. Suddenly, two claw-like arms spring out of its sides and grab both Sonic and Tails in a tight grip. Slowly, the arms drag the helpless friends into the ship. Sonic and Tails have been captured by Robotnik! They have failed in their mission and must start again!\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[0] {}
	};

	public static Section section282 = new Section()
	{
		text = "The tunnel is made of shiny, almost black metal, and their footsteps echo on and on as they walk.\n\n'This must be the Fak-Tor-Eee basement,' says Sonic. 'I wonder what they make here?'\n\nThe tunnel forks in two again. Will Sonic and Tails go to the left (turn to <b>261</b>) or to the right (turn to <b>122</b>)?",
		choices = new int[2] {261, 122},
		asteronSection = true
	};

	public static Section section283 = new Section()
	{
		text = "Sonic and Tails mistime their move! Missing their target, they are caught in the game's Gravity Field and are pulled down towards the bottom and the waiting <i>Flippers</i>! BANG!!! A flipper smashes them back towards the top of the game. Ouch, that hurt! Remove 5 credits from Sonic's Stuff. Turn to <b>124</b>. If Sonic doesn't have 5 credits left, turn to <b>126</b>. If the commissionaire has already given Sonic another 20 credits, then you <i>must</i> turn to <b>41</b>.",
		choices = new int[3] {124, 126, 41}
	};

	public static Section section284 = new Section()
	{
		text = "Sonic is just too busy trying to catch up with his friend to notice the small stream. When at last he does see it, it is too late. Sonic lands in it, with a loud SPLASH! Turn to <b>244</b>.",
		choices = new int[1] {244}
	};

	public static Section section285 = new Section()
	{
		text = "As Sonic stares at the paper, he suddenly realizes that it is some kind of poem.\n\n'What's it say?' asks Tails.\n\n'Well, it seems to be some kind of poem. Funny, I never took rats to be into all that sort of stuff! Still, looks like it says,\n\n<i>Left,\nRight,\nLeft,\nRight,\nUpside-down,\nThen go to ground.</i>'\n\n'Hmm. That's it then, nothing to worry about at all,' says Tails, with a silly look on his face.\n\n'It's all right. It's a map. Come on!' Sonic steps through the door and finds himself in a tunnel. It is lit by star-shaped lanterns hung along the wall, though the light they give out is very dim.\n\nOn some of the following sections you will see the * symbol. When you see this, roll the die. If the score is 1, then you must turn to <b>211</b>. Remember to make a note of the section number you were on, so that you will know where to return to!\n\nShould Sonic go to the left (turn to <b>282</b>) or to the right (turn to <b>224</b>)?",
		choices = new int[2] {282, 224}
	};

	public static Section section286 = new Section()
	{
		text = "Tails walks around the comer, not knowing exactly what he's going to say. The man with the club sees him. It is too late to turn back now!\n\n'Ah,' the man says, 'what a pleasure it is to welcome a new customer. Tell me, sir, is this your first visit to the casino?' Tails is quite taken aback by this. 'I'm afraid we've had a little trouble with vandals recently, but I'm sure sir will still have a good time.'\n\n'Erm, what trouble might that have been?' asks Tails innocently.\n\nThe man tells Tails (at great length) how the the great Sonic the Hedgehog has just smashed up his lovely casino. The man is no less a person than the casino's commissionaire!\n\nTails is now faced with a problem. Will he tell the commissionaire about Zonik (who must be the one who has smashed up the casino) or not? Tails, being Tails, tells him and, after what seems like ages, manages to convince him that the real Sonic will try and put things right for him. Turn to <b>2</b>.",
		choices = new int[1] {2}
	};

	public static Section section287 = new Section()
	{
		text = "Sonic realizes that these jars must be smashed as well, otherwise the mini-Zoniks might hatch. Both he and Tails set about the jars and soon all of them lie smashed on the floor. As soon as each jar is broken, the mini-Zonik dissolves into a blobby blue mess. Turn to <b>130</b>.",
		choices = new int[1] {130}
	};

	public static Section section288 = new Section()
	{
		text = "Oh dear! The level of the Mack is now so high that it's beginning to lap around the feet of the intrepid heroes. Each extra point you get will now destroy 1 ring in Sonic's Stuff. If you haven't got out of the maze by the time all of the rings have been destroyed, you <i>must</i> turn to <b>25</b>. Write this number down so you do not forget it. Go back to the maze where you left it and carry on.",
		choices = new int[0] {}
	};

	public static Section section289 = new Section()
	{
		text = "Grabbing the energy gun, Sonic quickly powers it up with 10 rings (remember to subtract them from Sonic's Stuff), and takes aim at the hover ship. Roll the die; if the score is 1, then turn to <b>159</b>. If the score is 2 or more, turn to <b>71</b>.",
		choices = new int[2] {159, 71}
	};

	public static Section section290 = new Section()
	{
		text = "The door opens automatically to reveal a long corridor. It's all white and completely empty. The corridor soon opens into a wide room. Dominating the whole place is a motionless silver robot, standing bang in the middle of the room. Its right hand is outstretched and holds a small bag. On the wall over to the left is a red button labelled Return. Does the robot need a closer look (turn to <b>184</b>)? Or would it be a better idea to press the red Return button (turn to <b>187</b>)?",
		choices = new int[2] {184, 187}
	};

	public static Section section291 = new Section()
	{
		text = "Needless to say, Tails had something of a story to tell Sonic! '... so you see, he, it – whatever it is – looked just like you and every time it touched me, it burnt. Look!' Tails pointed to the singe marks all over his fur. 'That's why I knew it was really you when I touched you.'\n\nSonic was baffled. Who on earth would want to go and impersonate him? 'Who can it be?' he said aloud.\n\n'I don't know,' replied Tails, 'but whoever it is, he needs to be stopped. I wouldn't be at all surprised if Robotnik wasn't behind all this.'\n\nThe idea did make sense. All the good creatures of Mobius looked to Sonic as the one thing that could stand up to Robotnik. Make Sonic look bad and Robotnik's job got a lot easier.\n\n'Right! Let's go get him, Tails.' Sonic was on his feet in an instant.\n\n'But we don't know where to look,' said Tails. Now that, annoying as it was, was a very good point.\n\n'Any ideas?' said Sonic.\n\nTails paused and thought for a while. 'I last saw it ... the Bad Sonic ... heading for the Chemical Zone, but that was about an hour ago, I think.'\n\n'Right! Let's go that way, then.' Sonic was already coiling up for a sprint ...\n\n'But when I first saw him, he was hanging around outside that secret cave ...'\n\n'What cave?' said Sonic, not really listening.\n\n'You know, the one where we used to hide rings for safe keeping, over by the little river.'\n\nWhat will they do? Will they go and look in the cave (turn to <b>9</b>)? Or should they hurry on towards the Chemical Zone (turn to <b>201</b>)?",
		choices = new int[2] {9, 201}
	};

	public static Section section292 = new Section()
	{
		text = "The Crawlton disintegrates into a smoking heap of junk on the floor. Although both Tails and Sonic himself search the area thoroughly, they find nothing of any worth. Their only option now is to retrace their steps and explore the other passageway. Turn to <b>267</b>.",
		choices = new int[1] {267}
	};

	public static Section section293 = new Section()
	{
		text = "Sonic and Tails attack Grabber. Grabber's fighting score is usually 8, but since he's already been smashed up by Zonik, it's now only 6. If you are unsure what to do, look back to the beginning of the book for instructions.\n\nGrabber will now fight to the death, so if they lose this fight, Sonic and Tails will have to start all over again! If they defeat Grabber, turn to <b>243</b>. If Grabber beats Sonic and Tails, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {243}
	};

	public static Section section294 = new Section()
	{
		text = "It looks like the only way out of this cave is to try and open the steel door. Both of them look at the lever by the side of the door.\n\n'After you,' says Sonic, gesturing for Tails to try the lever.\n\n'No, after you,' replies Tails.\n\n'No, really,' says Sonic.\n\n'No, you try it, Sonic. I insist!' smiles Tails, bowing gracefully to his friend. Gingerly, Sonic reaches out and pulls the lever. The door slides open with a faint whooshing sound.\n\n'There you are,' he says triumphantly. 'Nothing to it.'\n\n'Let's hope you feel the same way about those, then!' says Tails, pointing towards the door. Emerging from beyond it are two Guardbots! Sonic and Tails must fight the Guardbots using Strength. The Guardbots have a fighting score of 6, but both can attack Sonic each round. Tails will help Sonic. If the heroes win, turn to <b>256</b>.\n\nIf the Guardbots beat Sonic and Tails, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
		choices = new int[1] {256}
	};

	public static Section section295 = new Section()
	{
		text = "Sonic and Tails speed out into the game at terrific speed. Everything is a blur, and only at the very last minute does Sonic see a large target flashing with bright red lights. First Sonic, and then Tails, hits the target square in the middle. If this is the first time that Sonic and Tails have been to this target, they score 10 points (add them to Sonic's Point Score). Now roll the die and add the result to Sonic's Agility. If the score is less than 6, then you <i>must</i> turn to <b>283</b>. If the score is 6 or more, then Sonic and Tails may go either to a bouncer (turn to <b>189</b>), to another bouncer (turn to <b>36</b>), or spring back (turn to <b>124</b>).",
		choices = new int[4] {283, 189, 36, 124}
	};

	public static Section section296 = new Section()
	{
		text = "Very soon this tunnel opens up into a small room. Heaped everywhere are dozens of rusting barrels with Mack seeping from their rotten joints. The stench is so bad that even the air seems heavy.\n\n'I don't think even Robotnik would have come in here by choice,' says Tails, still holding his nose. Should Sonic and Tails explore this room (turn to <b>260</b>), or should they leave (turn to <b>101</b>)?",
		choices = new int[2] {260, 101}
	};

	public static Section section297 = new Section()
	{
		text = "Sonic notices the small black and red wire underneath the Mega Drive. Following it with his eyes, he sees it leads underneath the console to a ... 'OH NO!!! Don't touch it, it's a BOMB!!!' Just in time, he reaches out to grab Tails' paw. 'Pheeew, that was close!' exclaims Sonic.\n\nTails swallows hard. 'That was close,' he says after a pause.\n\nSkilfully, Sonic fiddles with the wires, and in a few seconds the screen of the Mega Drive goes blank. 'Nothing to it. WHEN YOU KNOW HOW!'\n\nUnder the circumstances, Tails thinks it better to keep quiet.\n\n'Well, I suppose we had better get moving, old friend,' says Sonic. There is only one way out of this room, conveniently marked Exit. Turn to <b>157</b>.",
		choices = new int[1] {157}
	};

	public static Section section298 = new Section()
	{
		text = "Suddenly, all the spines on Sonic's back stand on end. 'Shh,' he says, straining his ears.\n\n'What's the matter?' asks Tails. He doesn't have to wait for an answer! Out of the blue a huge silver ball comes crashing towards them. Roll the die and add the result to Sonic's Speed. If the score is 6 or more, turn to <b>22</b>. If the score is less than 6, turn to <b>235</b>.",
		choices = new int[2] {22, 235}
	};

	public static Section section299 = new Section()
	{
		text = "Sonic and Tails speed out into the game at terrific speed. Everything is a blur, and only at the very last minute does Sonic see a large target flashing with bright yellow lights. First Sonic, and then Tails, hits the target bang in the middle. If this is the first time that Sonic and Tails have been to this target, then they score 10 points (add them to Sonic's Point Score). Now roll the die and add the result to Sonic's Quick Wits. If the score is less than 6, then you <i>must</i> turn to <b>283</b>. If the score is 6 or more, then Sonic and Tails may go either to a bouncer (turn to <b>189</b>), or to another bouncer (turn to <b>36</b>), or spring back (turn to <b>124</b>).",
		choices = new int[4] {283, 189, 36, 124}
	};

	public static Section section300 = new Section()
	{
		text = "The evil Zonik has been defeated at last, and Sonic and Tails stare at him as he slowly dissolves into a nasty blue blob on the ground. With him gone, and the Fak-Tor-Eee gone as well, the Zones will return to normal.\n\n'Well, I suppose that's that then,' says Tails.\n\n'Yep, guess it is,' replies Sonic.\n\n'Any idea how we're going to get back home?' asks Tails.\n\n'Nothing to it,' says Sonic and with that he spins off into the distance.\n\n'Hey, wait for me!' cries Tails. And with that our two pals disappear over the horizon.",
		choices = new int[0] {}
	};
	
	public static Section[] sectionLibrary = new Section[301] {section0, section1, section2, section3, section4, section5, section6, section7, section8, section9, section10, section11, section12, section13, section14, section15, section16, section17, section18, section19, section20, section21, section22, section23, section24, section25, section26, section27, section28, section29, section30, section31, section32, section33, section34, section35, section36, section37, section38, section39, section40, section41, section42, section43, section44, section45, section46, section47, section48, section49, section50, section51, section52, section53, section54, section55, section56, section57, section58, section59, section60, section61, section62, section63, section64, section65, section66, section67, section68, section69, section70, section71, section72, section73, section74, section75, section76, section77, section78, section79, section80, section81, section82, section83, section84, section85, section86, section87, section88, section89, section90, section91, section92, section93, section94, section95, section96, section97, section98, section99, section100, section101, section102, section103, section104, section105, section106, section107, section108, section109, section110, section111, section112, section113, section114, section115, section116, section117, section118, section119, section120, section121, section122, section123, section124, section125, section126, section127, section128, section129, section130, section131, section132, section133, section134, section135, section136, section137, section138, section139, section140, section141, section142, section143, section144, section145, section146, section147, section148, section149, section150, section151, section152, section153, section154, section155, section156, section157, section158, section159, section160, section161, section162, section163, section164, section165, section166, section167, section168, section169, section170, section171, section172, section173, section174, section175, section176, section177, section178, section179, section180, section181, section182, section183, section184, section185, section186, section187, section188, section189, section190, section191, section192, section193, section194, section195, section196, section197, section198, section199, section200, section201, section202, section203, section204, section205, section206, section207, section208, section209, section210, section211, section212, section213, section214, section215, section216, section217, section218, section219, section220, section221, section222, section223, section224, section225, section226, section227, section228, section229, section230, section231, section232, section233, section234, section235, section236, section237, section238, section239, section240, section241, section242, section243, section244, section245, section246, section247, section248, section249, section250, section251, section252, section253, section254, section255, section256, section257, section258, section259, section260, section261, section262, section263, section264, section265, section266, section267, section268, section269, section270, section271, section272, section273, section274, section275, section276, section277, section278, section279, section280, section281, section282, section283, section284, section285, section286, section287, section288, section289, section290, section291, section292, section293, section294, section295, section296, section297, section298, section299, section300};
	
	public void UpdateText() {
		if (isHeader) {
			if (sectionLibrary[SonicVsZonikGame.index].mackSection
				|| sectionLibrary[SonicVsZonikGame.index].asteronSection) {
				currentText.text = "Section " + SonicVsZonikGame.index + " *";
			}
			else {
				currentText.text = "Section " + SonicVsZonikGame.index;
			}
		}
		else {
			currentText.text = sectionLibrary[SonicVsZonikGame.index].text;
		}
	}
}
