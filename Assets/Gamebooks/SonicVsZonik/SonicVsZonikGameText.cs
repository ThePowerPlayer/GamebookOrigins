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
		text = "",
		choices = new int[0] {}
	};

	public static Section section3 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section4 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section5 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section6 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section7 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section8 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section9 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section10 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section11 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section12 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section13 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section14 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section15 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section16 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section17 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section18 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section19 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section20 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section21 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section22 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section23 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section24 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section25 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section26 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section27 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section28 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section29 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section30 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section31 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section32 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section33 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section34 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section35 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section36 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section37 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section38 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section39 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section40 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section41 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section42 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section43 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section44 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section45 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section46 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section47 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section48 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section49 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section50 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section51 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section52 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section53 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section54 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section55 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section56 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section57 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section58 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section59 = new Section()
	{
		text = "",
		choices = new int[0] {}
	};

	public static Section section60 = new Section()
	{
		text = "",
		choices = new int[0] {}
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
