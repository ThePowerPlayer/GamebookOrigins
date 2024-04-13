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
	};
	
	public static Section section0 = new Section()
	{
		text = "This is dummy text. If you're reading this, something's gone wrong!",
		choices = new int[0] {}
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
		choices = new int[2] {151, 21}
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
		choices = new int[2] {125, 204}
	};

	public static Section section14 = new Section()
	{
		text = "Picking their moment carefully, Sonic and Tails prepare to fight the Badnik. It has a fighting score of 7 and it will need five hits to be destroyed. Tails will help Sonic. This is one MEAN dude!\n\nIf you think it might be wiser for Sonic and Tails to try something else, there is still time. But what should they do:\n\nUse the energy gun?\t\t\t Turn to <b>230></b>\nTry using some glue?\t\t\tTurn to <b>107</b>\nTry to roll the Badnik over?\t\t\tTurn to <b>53</b>\n\nIf you decide Sonic and Tails shouldn't be such wimps, then fight the Badnik. If they win, turn to <b>249<\b>. If Sonic and Tails fail to beat the Badnik, then ...\n\n<b>YOUR ADVENTURE ENDS HERE</b>",
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
		choices = new int[4] {194, 240, 179, 100}
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
		text = "Sonic and Tails walk around a comer in the tunnel and, surprise surprise, come to another junction. Will they go to the left (turn to <b>261</b>), or will they carry straight on (turn to <b>103</b>)?",
		choices = new int[2] {261, 103}
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
		choices = new int[2] {282, 103}
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
		text = "",
		choices = new int[0] {}
	};

	public static Section section62 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section63 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section64 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section65 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section66 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section67 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section68 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section69 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section70 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section71 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section72 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section73 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section74 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section75 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section76 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section77 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section78 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section79 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section80 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section81 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section82 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section83 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section84 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section85 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section86 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section87 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section88 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section89 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section90 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section91 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section92 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section93 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section94 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section95 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section96 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section97 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section98 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section99 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section100 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section101 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section102 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section103 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section104 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section105 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section106 = new Section()
	{
		text = "The hills looked just like Sonic expected them to look - all green and, well, hilly. Sonic stopped. Up ahead was one of the star posts. Usually he could see it from far away, its light shining out like a beacon. Today Sonic couldn't see it at all.\n\n'That's strange,' he said. Sonic had been to the post so many times that even if he couldn't see it, he could still find it. This fact didn't make the discovery he was about to make any easier.\n\nAfter a few more steps, Sonic discovered why he hadn't been able to see the post, for, in a little hollow in the hillside, there was a black and twisted lump of metal about two metres long. That was all that remained of the post! Who could have done such a thing? Sonic stared down at the post. Should he try to repair it (turn to <b>63</b>), or should he move on and find out what is going on (turn to <b>155</b>)?",
		choices = new int[2] {63, 155}
	};

	public static Section section107 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section108 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section109 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section110 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section111 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section112 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section113 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section114 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section115 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section116 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section117 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section118 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section119 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section120 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section121 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section122 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section123 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section124 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section125 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section126 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section127 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section128 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section129 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section130 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section131 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section132 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section133 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section134 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section135 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section136 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section137 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section138 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section139 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section140 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section141 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section142 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section143 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section144 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section145 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section146 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section147 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section148 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section149 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section150 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section151 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section152 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section153 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section154 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section155 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section156 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section157 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section158 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section159 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section160 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section161 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section162 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section163 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section164 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section165 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section166 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section167 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section168 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section169 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section170 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section171 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section172 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section173 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section174 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section175 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section176 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section177 = new Section()
	{
		text = "The familiar sound of the river could be clearly heard in the distance. Sonic didn't really like the river. He didn't really like any rivers. They were all right to look at, but he didn't fancy getting wet one little bit!\n\nSonic walked into the valley and breathed a sigh of relief; at least there was a proper bridge here today. The Green Hill Zone bridges had a nasty habit of doing their own thing. Sometimes they were normal, other times bits of them collapsed as you walked on them. Sometimes they even disappeared when you were half-way across! Gingerly, Sonic tiptoes across the bridge, casting a cautious eye at the water. Somewhat relieved, he reaches the other side — you could never be too careful with bridges! Turn to <b>12</b>.",
		choices = new int[1] {12}
	};

	public static Section section178 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section179 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section180 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section181 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section182 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section183 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section184 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section185 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section186 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section187 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section188 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section189 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section190 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section191 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section192 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section193 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section194 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section195 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section196 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section197 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section198 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section199 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section200 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};
	
	public static Section section201 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section202 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section203 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section204 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section205 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section206 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section207 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section208 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section209 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section210 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section211 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section212 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section213 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section214 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section215 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section216 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section217 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section218 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section219 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section220 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section221 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section222 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section223 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section224 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section225 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section226 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section227 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section228 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section229 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section230 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section231 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section232 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section233 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section234 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section235 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section236 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section237 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section238 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section239 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section240 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section241 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section242 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section243 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section244 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section245 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section246 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section247 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section248 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section249 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section250 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section251 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section252 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section253 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section254 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section255 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section256 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section257 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section258 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section259 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section260 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section261 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section262 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section263 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section264 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section265 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section266 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section267 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section268 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section269 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section270 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section271 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section272 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section273 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section274 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section275 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section276 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section277 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section278 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section279 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section280 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section281 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section282 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section283 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section284 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section285 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section286 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section287 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section288 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section289 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section290 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section291 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section292 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section293 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section294 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section295 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section296 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section297 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section298 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section299 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section300 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};
	
	public static Section[] sectionLibrary = new Section[] {section0, section1, section2, section3, section4, section5, section6, section7, section8, section9, section10, section11, section12, section13, section14, section15, section16, section17, section18, section19, section20, section21, section22, section23, section24, section25, section26, section27, section28, section29, section30, section31, section32, section33, section34, section35, section36, section37, section38, section39, section40, section41, section42, section43, section44, section45, section46, section47, section48, section49, section50, section51, section52, section53, section54, section55, section56, section57, section58, section59, section60, section61, section62, section63, section64, section65, section66, section67, section68, section69, section70, section71, section72, section73, section74, section75, section76, section77, section78, section79, section80, section81, section82, section83, section84, section85, section86, section87, section88, section89, section90, section91, section92, section93, section94, section95, section96, section97, section98, section99, section100, section101, section102, section103, section104, section105, section106, section107, section108, section109, section110, section111, section112, section113, section114, section115, section116, section117, section118, section119, section120, section121, section122, section123, section124, section125, section126, section127, section128, section129, section130, section131, section132, section133, section134, section135, section136, section137, section138, section139, section140, section141, section142, section143, section144, section145, section146, section147, section148, section149, section150, section151, section152, section153, section154, section155, section156, section157, section158, section159, section160, section161, section162, section163, section164, section165, section166, section167, section168, section169, section170, section171, section172, section173, section174, section175, section176, section177, section178, section179, section180, section181, section182, section183, section184, section185, section186, section187, section188, section189, section190, section191, section192, section193, section194, section195, section196, section197, section198, section199, section200, section201, section202, section203, section204, section205, section206, section207, section208, section209, section210, section211, section212, section213, section214, section215, section216, section217, section218, section219, section220, section221, section222, section223, section224, section225, section226, section227, section228, section229, section230, section231, section232, section233, section234, section235, section236, section237, section238, section239, section240, section241, section242, section243, section244, section245, section246, section247, section248, section249, section250, section251, section252, section253, section254, section255, section256, section257, section258, section259, section260, section261, section262, section263, section264, section265, section266, section267, section268, section269, section270, section271, section272, section273, section274, section275, section276, section277, section278, section279, section280, section281, section282, section283, section284, section285, section286, section287, section288, section289, section290, section291, section292, section293, section294, section295, section296, section297, section298, section299, section300};
	
	public void UpdateText() {
		if (isHeader) {
			currentText.text = "Section " + SonicVsZonikGame.index;
		}
		else {
			currentText.text = sectionLibrary[SonicVsZonikGame.index].text;
		}
	}
}
