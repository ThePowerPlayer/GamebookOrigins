using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SonicVsZonikGameText : MonoBehaviour
{
	[SerializeField] private bool isHeader;
	[SerializeField] private TMP_Text currentText;
	
	
	public static string text0 =
		"This is dummy text. If you're reading this, something's gone wrong!";
	public static int[] choices0 = new int[0] {};
	
	public static string text1 =
		"Something very strange had happened in the Green Hill Zone. One minute Sonic had been sitting playing with his Mega Drive, the next thing he was being attacked by a group of maniac bunnies. They were usually his friends! He'd tried to speak to them, but all they kept shouting at him was something about him filling all their burrows with rotten eggs. Sonic didn't even like eggs, and the bunnies were his mates, so he'd never dream of doing that to them. Suddenly, everything had gone black... Sonic could see stars, not the kind of stars in the night sky, but the kind that whizz around the inside of your head. It was as if the whole of the universe was circling around him — Sonic, of course, being the centre of the universe.\n\n'Hey, slow down, it was day-time a minute ago!'\n\nSuddenly, his senses returned and he jumped to his feet. The bunnies were gone. He was alone, confused and not sure what was going on.\n\n'Wow, this is weird,' says Sonic.\n\nSonic might be covered in spines, but they don't protect his head. Gingerly, he raises a paw to the rapidly growing bruise.\n\n'Oh no! It's the size of an egg ... hey, now don't say egg! Bad vibes about that word. I suppose I'd better find out whether the bunnies were right.'\n\nSonic set out through the Green Hills, still not really believing what had happened in the past ten minutes. Everything looked normal, the hills were green, the sky was blue. Yes, this had to be the Green Hill Zone. But there was something, something odd, nagging him.\n\n'ZZZZzzzzwing!'\n\nA small silver object flew towards Sonic's head, embedding itself in a tree behind him. Sonic turned around to take a look at the tree. There, half-buried in the bark, was the familiar shape of a Buzzer.\n\n'ZZZzzz ... buzzzz! Get ya next time. Buzzz!' threatened the Buzzer, rather pathetically, as he was firmly stuck in the tree.\n\nSonic smiled, all was well in the Green Hill Zone. They always try to get me, he thought, but never manage it. The thought formed a smile. Sonic started walking away from the cursing Buzzer, wondering whether to head for the hills or one of the bridges. Imagine you are Sonic - what would you do? Go to the hills (turn to <b>106</b>)? If you think Sonic should head towards the river, then turn to <b>177</b>.";
	public static int[] choices1 = new int[2] {106, 167};

	public static string text2 =
		"";
	public static int[] choices2 = new int[0] {};

	public static string text3 =
		"";
	public static int[] choices3 = new int[0] {};

	public static string text4 =
		"";
	public static int[] choices4 = new int[0] {};

	public static string text5 =
		"";
	public static int[] choices5 = new int[0] {};

	public static string text6 =
		"";
	public static int[] choices6 = new int[0] {};

	public static string text7 =
		"";
	public static int[] choices7 = new int[0] {};

	public static string text8 =
		"";
	public static int[] choices8 = new int[0] {};

	public static string text9 =
		"";
	public static int[] choices9 = new int[0] {};

	public static string text10 =
		"";
	public static int[] choices10 = new int[0] {};

	public static string text11 =
		"";
	public static int[] choices11 = new int[0] {};

	public static string text12 =
		"";
	public static int[] choices12 = new int[0] {};

	public static string text13 =
		"";
	public static int[] choices13 = new int[0] {};

	public static string text14 =
		"";
	public static int[] choices14 = new int[0] {};

	public static string text15 =
		"";
	public static int[] choices15 = new int[0] {};

	public static string text16 =
		"";
	public static int[] choices16 = new int[0] {};

	public static string text17 =
		"";
	public static int[] choices17 = new int[0] {};

	public static string text18 =
		"";
	public static int[] choices18 = new int[0] {};

	public static string text19 =
		"";
	public static int[] choices19 = new int[0] {};

	public static string text20 =
		"";
	public static int[] choices20 = new int[0] {};

	public static string text21 =
		"";
	public static int[] choices21 = new int[0] {};

	public static string text22 =
		"";
	public static int[] choices22 = new int[0] {};

	public static string text23 =
		"";
	public static int[] choices23 = new int[0] {};

	public static string text24 =
		"";
	public static int[] choices24 = new int[0] {};

	public static string text25 =
		"";
	public static int[] choices25 = new int[0] {};

	public static string text26 =
		"";
	public static int[] choices26 = new int[0] {};

	public static string text27 =
		"";
	public static int[] choices27 = new int[0] {};

	public static string text28 =
		"";
	public static int[] choices28 = new int[0] {};

	public static string text29 =
		"";
	public static int[] choices29 = new int[0] {};

	public static string text30 =
		"";
	public static int[] choices30 = new int[0] {};

	public static string text31 =
		"";
	public static int[] choices31 = new int[0] {};

	public static string text32 =
		"";
	public static int[] choices32 = new int[0] {};

	public static string text33 =
		"";
	public static int[] choices33 = new int[0] {};

	public static string text34 =
		"";
	public static int[] choices34 = new int[0] {};

	public static string text35 =
		"";
	public static int[] choices35 = new int[0] {};

	public static string text36 =
		"";
	public static int[] choices36 = new int[0] {};

	public static string text37 =
		"";
	public static int[] choices37 = new int[0] {};

	public static string text38 =
		"";
	public static int[] choices38 = new int[0] {};

	public static string text39 =
		"";
	public static int[] choices39 = new int[0] {};

	public static string text40 =
		"";
	public static int[] choices40 = new int[0] {};

	public static string text41 =
		"";
	public static int[] choices41 = new int[0] {};

	public static string text42 =
		"";
	public static int[] choices42 = new int[0] {};

	public static string text43 =
		"";
	public static int[] choices43 = new int[0] {};

	public static string text44 =
		"";
	public static int[] choices44 = new int[0] {};

	public static string text45 =
		"";
	public static int[] choices45 = new int[0] {};

	public static string text46 =
		"";
	public static int[] choices46 = new int[0] {};

	public static string text47 =
		"";
	public static int[] choices47 = new int[0] {};

	public static string text48 =
		"";
	public static int[] choices48 = new int[0] {};

	public static string text49 =
		"";
	public static int[] choices49 = new int[0] {};

	public static string text50 =
		"";
	public static int[] choices50 = new int[0] {};

	public static string text51 =
		"";
	public static int[] choices51 = new int[0] {};

	public static string text52 =
		"";
	public static int[] choices52 = new int[0] {};

	public static string text53 =
		"";
	public static int[] choices53 = new int[0] {};

	public static string text54 =
		"";
	public static int[] choices54 = new int[0] {};

	public static string text55 =
		"";
	public static int[] choices55 = new int[0] {};

	public static string text56 =
		"";
	public static int[] choices56 = new int[0] {};

	public static string text57 =
		"";
	public static int[] choices57 = new int[0] {};

	public static string text58 =
		"";
	public static int[] choices58 = new int[0] {};

	public static string text59 =
		"";
	public static int[] choices59 = new int[0] {};

	public static string text60 =
		"";
	public static int[] choices60 = new int[0] {};

	public static string text61 =
		"";
	public static int[] choices61 = new int[0] {};

	public static string text62 =
		"";
	public static int[] choices62 = new int[0] {};

	public static string text63 =
		"";
	public static int[] choices63 = new int[0] {};

	public static string text64 =
		"";
	public static int[] choices64 = new int[0] {};

	public static string text65 =
		"";
	public static int[] choices65 = new int[0] {};

	public static string text66 =
		"";
	public static int[] choices66 = new int[0] {};

	public static string text67 =
		"";
	public static int[] choices67 = new int[0] {};

	public static string text68 =
		"";
	public static int[] choices68 = new int[0] {};

	public static string text69 =
		"";
	public static int[] choices69 = new int[0] {};

	public static string text70 =
		"";
	public static int[] choices70 = new int[0] {};

	public static string text71 =
		"";
	public static int[] choices71 = new int[0] {};

	public static string text72 =
		"";
	public static int[] choices72 = new int[0] {};

	public static string text73 =
		"";
	public static int[] choices73 = new int[0] {};

	public static string text74 =
		"";
	public static int[] choices74 = new int[0] {};

	public static string text75 =
		"";
	public static int[] choices75 = new int[0] {};

	public static string text76 =
		"";
	public static int[] choices76 = new int[0] {};

	public static string text77 =
		"";
	public static int[] choices77 = new int[0] {};

	public static string text78 =
		"";
	public static int[] choices78 = new int[0] {};

	public static string text79 =
		"";
	public static int[] choices79 = new int[0] {};

	public static string text80 =
		"";
	public static int[] choices80 = new int[0] {};

	public static string text81 =
		"";
	public static int[] choices81 = new int[0] {};

	public static string text82 =
		"";
	public static int[] choices82 = new int[0] {};

	public static string text83 =
		"";
	public static int[] choices83 = new int[0] {};

	public static string text84 =
		"";
	public static int[] choices84 = new int[0] {};

	public static string text85 =
		"";
	public static int[] choices85 = new int[0] {};

	public static string text86 =
		"";
	public static int[] choices86 = new int[0] {};

	public static string text87 =
		"";
	public static int[] choices87 = new int[0] {};

	public static string text88 =
		"";
	public static int[] choices88 = new int[0] {};

	public static string text89 =
		"";
	public static int[] choices89 = new int[0] {};

	public static string text90 =
		"";
	public static int[] choices90 = new int[0] {};

	public static string text91 =
		"";
	public static int[] choices91 = new int[0] {};

	public static string text92 =
		"";
	public static int[] choices92 = new int[0] {};

	public static string text93 =
		"";
	public static int[] choices93 = new int[0] {};

	public static string text94 =
		"";
	public static int[] choices94 = new int[0] {};

	public static string text95 =
		"";
	public static int[] choices95 = new int[0] {};

	public static string text96 =
		"";
	public static int[] choices96 = new int[0] {};

	public static string text97 =
		"";
	public static int[] choices97 = new int[0] {};

	public static string text98 =
		"";
	public static int[] choices98 = new int[0] {};

	public static string text99 =
		"";
	public static int[] choices99 = new int[0] {};

	public static string text100 =
		"";
	public static int[] choices100 = new int[0] {};

	public static string text101 =
		"";
	public static int[] choices101 = new int[0] {};

	public static string text102 =
		"";
	public static int[] choices102 = new int[0] {};

	public static string text103 =
		"";
	public static int[] choices103 = new int[0] {};

	public static string text104 =
		"";
	public static int[] choices104 = new int[0] {};

	public static string text105 =
		"";
	public static int[] choices105 = new int[0] {};

	public static string text106 =
		"";
	public static int[] choices106 = new int[0] {};

	public static string text107 =
		"";
	public static int[] choices107 = new int[0] {};

	public static string text108 =
		"";
	public static int[] choices108 = new int[0] {};

	public static string text109 =
		"";
	public static int[] choices109 = new int[0] {};

	public static string text110 =
		"";
	public static int[] choices110 = new int[0] {};

	public static string text111 =
		"";
	public static int[] choices111 = new int[0] {};

	public static string text112 =
		"";
	public static int[] choices112 = new int[0] {};

	public static string text113 =
		"";
	public static int[] choices113 = new int[0] {};

	public static string text114 =
		"";
	public static int[] choices114 = new int[0] {};

	public static string text115 =
		"";
	public static int[] choices115 = new int[0] {};

	public static string text116 =
		"";
	public static int[] choices116 = new int[0] {};

	public static string text117 =
		"";
	public static int[] choices117 = new int[0] {};

	public static string text118 =
		"";
	public static int[] choices118 = new int[0] {};

	public static string text119 =
		"";
	public static int[] choices119 = new int[0] {};

	public static string text120 =
		"";
	public static int[] choices120 = new int[0] {};

	public static string text121 =
		"";
	public static int[] choices121 = new int[0] {};

	public static string text122 =
		"";
	public static int[] choices122 = new int[0] {};

	public static string text123 =
		"";
	public static int[] choices123 = new int[0] {};

	public static string text124 =
		"";
	public static int[] choices124 = new int[0] {};

	public static string text125 =
		"";
	public static int[] choices125 = new int[0] {};

	public static string text126 =
		"";
	public static int[] choices126 = new int[0] {};

	public static string text127 =
		"";
	public static int[] choices127 = new int[0] {};

	public static string text128 =
		"";
	public static int[] choices128 = new int[0] {};

	public static string text129 =
		"";
	public static int[] choices129 = new int[0] {};

	public static string text130 =
		"";
	public static int[] choices130 = new int[0] {};

	public static string text131 =
		"";
	public static int[] choices131 = new int[0] {};

	public static string text132 =
		"";
	public static int[] choices132 = new int[0] {};

	public static string text133 =
		"";
	public static int[] choices133 = new int[0] {};

	public static string text134 =
		"";
	public static int[] choices134 = new int[0] {};

	public static string text135 =
		"";
	public static int[] choices135 = new int[0] {};

	public static string text136 =
		"";
	public static int[] choices136 = new int[0] {};

	public static string text137 =
		"";
	public static int[] choices137 = new int[0] {};

	public static string text138 =
		"";
	public static int[] choices138 = new int[0] {};

	public static string text139 =
		"";
	public static int[] choices139 = new int[0] {};

	public static string text140 =
		"";
	public static int[] choices140 = new int[0] {};

	public static string text141 =
		"";
	public static int[] choices141 = new int[0] {};

	public static string text142 =
		"";
	public static int[] choices142 = new int[0] {};

	public static string text143 =
		"";
	public static int[] choices143 = new int[0] {};

	public static string text144 =
		"";
	public static int[] choices144 = new int[0] {};

	public static string text145 =
		"";
	public static int[] choices145 = new int[0] {};

	public static string text146 =
		"";
	public static int[] choices146 = new int[0] {};

	public static string text147 =
		"";
	public static int[] choices147 = new int[0] {};

	public static string text148 =
		"";
	public static int[] choices148 = new int[0] {};

	public static string text149 =
		"";
	public static int[] choices149 = new int[0] {};

	public static string text150 =
		"";
	public static int[] choices150 = new int[0] {};

	public static string text151 =
		"";
	public static int[] choices151 = new int[0] {};

	public static string text152 =
		"";
	public static int[] choices152 = new int[0] {};

	public static string text153 =
		"";
	public static int[] choices153 = new int[0] {};

	public static string text154 =
		"";
	public static int[] choices154 = new int[0] {};

	public static string text155 =
		"";
	public static int[] choices155 = new int[0] {};

	public static string text156 =
		"";
	public static int[] choices156 = new int[0] {};

	public static string text157 =
		"";
	public static int[] choices157 = new int[0] {};

	public static string text158 =
		"";
	public static int[] choices158 = new int[0] {};

	public static string text159 =
		"";
	public static int[] choices159 = new int[0] {};

	public static string text160 =
		"";
	public static int[] choices160 = new int[0] {};

	public static string text161 =
		"";
	public static int[] choices161 = new int[0] {};

	public static string text162 =
		"";
	public static int[] choices162 = new int[0] {};

	public static string text163 =
		"";
	public static int[] choices163 = new int[0] {};

	public static string text164 =
		"";
	public static int[] choices164 = new int[0] {};

	public static string text165 =
		"";
	public static int[] choices165 = new int[0] {};

	public static string text166 =
		"";
	public static int[] choices166 = new int[0] {};

	public static string text167 =
		"";
	public static int[] choices167 = new int[0] {};

	public static string text168 =
		"";
	public static int[] choices168 = new int[0] {};

	public static string text169 =
		"";
	public static int[] choices169 = new int[0] {};

	public static string text170 =
		"";
	public static int[] choices170 = new int[0] {};

	public static string text171 =
		"";
	public static int[] choices171 = new int[0] {};

	public static string text172 =
		"";
	public static int[] choices172 = new int[0] {};

	public static string text173 =
		"";
	public static int[] choices173 = new int[0] {};

	public static string text174 =
		"";
	public static int[] choices174 = new int[0] {};

	public static string text175 =
		"";
	public static int[] choices175 = new int[0] {};

	public static string text176 =
		"";
	public static int[] choices176 = new int[0] {};

	public static string text177 =
		"";
	public static int[] choices177 = new int[0] {};

	public static string text178 =
		"";
	public static int[] choices178 = new int[0] {};

	public static string text179 =
		"";
	public static int[] choices179 = new int[0] {};

	public static string text180 =
		"";
	public static int[] choices180 = new int[0] {};

	public static string text181 =
		"";
	public static int[] choices181 = new int[0] {};

	public static string text182 =
		"";
	public static int[] choices182 = new int[0] {};

	public static string text183 =
		"";
	public static int[] choices183 = new int[0] {};

	public static string text184 =
		"";
	public static int[] choices184 = new int[0] {};

	public static string text185 =
		"";
	public static int[] choices185 = new int[0] {};

	public static string text186 =
		"";
	public static int[] choices186 = new int[0] {};

	public static string text187 =
		"";
	public static int[] choices187 = new int[0] {};

	public static string text188 =
		"";
	public static int[] choices188 = new int[0] {};

	public static string text189 =
		"";
	public static int[] choices189 = new int[0] {};

	public static string text190 =
		"";
	public static int[] choices190 = new int[0] {};

	public static string text191 =
		"";
	public static int[] choices191 = new int[0] {};

	public static string text192 =
		"";
	public static int[] choices192 = new int[0] {};

	public static string text193 =
		"";
	public static int[] choices193 = new int[0] {};

	public static string text194 =
		"";
	public static int[] choices194 = new int[0] {};

	public static string text195 =
		"";
	public static int[] choices195 = new int[0] {};

	public static string text196 =
		"";
	public static int[] choices196 = new int[0] {};

	public static string text197 =
		"";
	public static int[] choices197 = new int[0] {};

	public static string text198 =
		"";
	public static int[] choices198 = new int[0] {};

	public static string text199 =
		"";
	public static int[] choices199 = new int[0] {};

	public static string text200 =
		"";
	public static int[] choices200 = new int[0] {};

	public static string text201 =
		"";
	public static int[] choices201 = new int[0] {};

	public static string text202 =
		"";
	public static int[] choices202 = new int[0] {};

	public static string text203 =
		"";
	public static int[] choices203 = new int[0] {};

	public static string text204 =
		"";
	public static int[] choices204 = new int[0] {};

	public static string text205 =
		"";
	public static int[] choices205 = new int[0] {};

	public static string text206 =
		"";
	public static int[] choices206 = new int[0] {};

	public static string text207 =
		"";
	public static int[] choices207 = new int[0] {};

	public static string text208 =
		"";
	public static int[] choices208 = new int[0] {};

	public static string text209 =
		"";
	public static int[] choices209 = new int[0] {};

	public static string text210 =
		"";
	public static int[] choices210 = new int[0] {};

	public static string text211 =
		"";
	public static int[] choices211 = new int[0] {};

	public static string text212 =
		"";
	public static int[] choices212 = new int[0] {};

	public static string text213 =
		"";
	public static int[] choices213 = new int[0] {};

	public static string text214 =
		"";
	public static int[] choices214 = new int[0] {};

	public static string text215 =
		"";
	public static int[] choices215 = new int[0] {};

	public static string text216 =
		"";
	public static int[] choices216 = new int[0] {};

	public static string text217 =
		"";
	public static int[] choices217 = new int[0] {};

	public static string text218 =
		"";
	public static int[] choices218 = new int[0] {};

	public static string text219 =
		"";
	public static int[] choices219 = new int[0] {};

	public static string text220 =
		"";
	public static int[] choices220 = new int[0] {};

	public static string text221 =
		"";
	public static int[] choices221 = new int[0] {};

	public static string text222 =
		"";
	public static int[] choices222 = new int[0] {};

	public static string text223 =
		"";
	public static int[] choices223 = new int[0] {};

	public static string text224 =
		"";
	public static int[] choices224 = new int[0] {};

	public static string text225 =
		"";
	public static int[] choices225 = new int[0] {};

	public static string text226 =
		"";
	public static int[] choices226 = new int[0] {};

	public static string text227 =
		"";
	public static int[] choices227 = new int[0] {};

	public static string text228 =
		"";
	public static int[] choices228 = new int[0] {};

	public static string text229 =
		"";
	public static int[] choices229 = new int[0] {};

	public static string text230 =
		"";
	public static int[] choices230 = new int[0] {};

	public static string text231 =
		"";
	public static int[] choices231 = new int[0] {};

	public static string text232 =
		"";
	public static int[] choices232 = new int[0] {};

	public static string text233 =
		"";
	public static int[] choices233 = new int[0] {};

	public static string text234 =
		"";
	public static int[] choices234 = new int[0] {};

	public static string text235 =
		"";
	public static int[] choices235 = new int[0] {};

	public static string text236 =
		"";
	public static int[] choices236 = new int[0] {};

	public static string text237 =
		"";
	public static int[] choices237 = new int[0] {};

	public static string text238 =
		"";
	public static int[] choices238 = new int[0] {};

	public static string text239 =
		"";
	public static int[] choices239 = new int[0] {};

	public static string text240 =
		"";
	public static int[] choices240 = new int[0] {};

	public static string text241 =
		"";
	public static int[] choices241 = new int[0] {};

	public static string text242 =
		"";
	public static int[] choices242 = new int[0] {};

	public static string text243 =
		"";
	public static int[] choices243 = new int[0] {};

	public static string text244 =
		"";
	public static int[] choices244 = new int[0] {};

	public static string text245 =
		"";
	public static int[] choices245 = new int[0] {};

	public static string text246 =
		"";
	public static int[] choices246 = new int[0] {};

	public static string text247 =
		"";
	public static int[] choices247 = new int[0] {};

	public static string text248 =
		"";
	public static int[] choices248 = new int[0] {};

	public static string text249 =
		"";
	public static int[] choices249 = new int[0] {};

	public static string text250 =
		"";
	public static int[] choices250 = new int[0] {};

	public static string text251 =
		"";
	public static int[] choices251 = new int[0] {};

	public static string text252 =
		"";
	public static int[] choices252 = new int[0] {};

	public static string text253 =
		"";
	public static int[] choices253 = new int[0] {};

	public static string text254 =
		"";
	public static int[] choices254 = new int[0] {};

	public static string text255 =
		"";
	public static int[] choices255 = new int[0] {};

	public static string text256 =
		"";
	public static int[] choices256 = new int[0] {};

	public static string text257 =
		"";
	public static int[] choices257 = new int[0] {};

	public static string text258 =
		"";
	public static int[] choices258 = new int[0] {};

	public static string text259 =
		"";
	public static int[] choices259 = new int[0] {};

	public static string text260 =
		"";
	public static int[] choices260 = new int[0] {};

	public static string text261 =
		"";
	public static int[] choices261 = new int[0] {};

	public static string text262 =
		"";
	public static int[] choices262 = new int[0] {};

	public static string text263 =
		"";
	public static int[] choices263 = new int[0] {};

	public static string text264 =
		"";
	public static int[] choices264 = new int[0] {};

	public static string text265 =
		"";
	public static int[] choices265 = new int[0] {};

	public static string text266 =
		"";
	public static int[] choices266 = new int[0] {};

	public static string text267 =
		"";
	public static int[] choices267 = new int[0] {};

	public static string text268 =
		"";
	public static int[] choices268 = new int[0] {};

	public static string text269 =
		"";
	public static int[] choices269 = new int[0] {};

	public static string text270 =
		"";
	public static int[] choices270 = new int[0] {};

	public static string text271 =
		"";
	public static int[] choices271 = new int[0] {};

	public static string text272 =
		"";
	public static int[] choices272 = new int[0] {};

	public static string text273 =
		"";
	public static int[] choices273 = new int[0] {};

	public static string text274 =
		"";
	public static int[] choices274 = new int[0] {};

	public static string text275 =
		"";
	public static int[] choices275 = new int[0] {};

	public static string text276 =
		"";
	public static int[] choices276 = new int[0] {};

	public static string text277 =
		"";
	public static int[] choices277 = new int[0] {};

	public static string text278 =
		"";
	public static int[] choices278 = new int[0] {};

	public static string text279 =
		"";
	public static int[] choices279 = new int[0] {};

	public static string text280 =
		"";
	public static int[] choices280 = new int[0] {};

	public static string text281 =
		"";
	public static int[] choices281 = new int[0] {};

	public static string text282 =
		"";
	public static int[] choices282 = new int[0] {};

	public static string text283 =
		"";
	public static int[] choices283 = new int[0] {};

	public static string text284 =
		"";
	public static int[] choices284 = new int[0] {};

	public static string text285 =
		"";
	public static int[] choices285 = new int[0] {};

	public static string text286 =
		"";
	public static int[] choices286 = new int[0] {};

	public static string text287 =
		"";
	public static int[] choices287 = new int[0] {};

	public static string text288 =
		"";
	public static int[] choices288 = new int[0] {};

	public static string text289 =
		"";
	public static int[] choices289 = new int[0] {};

	public static string text290 =
		"";
	public static int[] choices290 = new int[0] {};

	public static string text291 =
		"";
	public static int[] choices291 = new int[0] {};

	public static string text292 =
		"";
	public static int[] choices292 = new int[0] {};

	public static string text293 =
		"";
	public static int[] choices293 = new int[0] {};

	public static string text294 =
		"";
	public static int[] choices294 = new int[0] {};

	public static string text295 =
		"";
	public static int[] choices295 = new int[0] {};

	public static string text296 =
		"";
	public static int[] choices296 = new int[0] {};

	public static string text297 =
		"";
	public static int[] choices297 = new int[0] {};

	public static string text298 =
		"";
	public static int[] choices298 = new int[0] {};

	public static string text299 =
		"";
	public static int[] choices299 = new int[0] {};

	public static string text300 =
		"";
	public static int[] choices300 = new int[0] {};
	
	public static string[] textLibrary = new string[] {text0, text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12, text13, text14, text15, text16, text17, text18, text19, text20, text21, text22, text23, text24, text25, text26, text27, text28, text29, text30, text31, text32, text33, text34, text35, text36, text37, text38, text39, text40, text41, text42, text43, text44, text45, text46, text47, text48, text49, text50, text51, text52, text53, text54, text55, text56, text57, text58, text59, text60, text61, text62, text63, text64, text65, text66, text67, text68, text69, text70, text71, text72, text73, text74, text75, text76, text77, text78, text79, text80, text81, text82, text83, text84, text85, text86, text87, text88, text89, text90, text91, text92, text93, text94, text95, text96, text97, text98, text99, text100, text101, text102, text103, text104, text105, text106, text107, text108, text109, text110, text111, text112, text113, text114, text115, text116, text117, text118, text119, text120, text121, text122, text123, text124, text125, text126, text127, text128, text129, text130, text131, text132, text133, text134, text135, text136, text137, text138, text139, text140, text141, text142, text143, text144, text145, text146, text147, text148, text149, text150, text151, text152, text153, text154, text155, text156, text157, text158, text159, text160, text161, text162, text163, text164, text165, text166, text167, text168, text169, text170, text171, text172, text173, text174, text175, text176, text177, text178, text179, text180, text181, text182, text183, text184, text185, text186, text187, text188, text189, text190, text191, text192, text193, text194, text195, text196, text197, text198, text199, text200, text201, text202, text203, text204, text205, text206, text207, text208, text209, text210, text211, text212, text213, text214, text215, text216, text217, text218, text219, text220, text221, text222, text223, text224, text225, text226, text227, text228, text229, text230, text231, text232, text233, text234, text235, text236, text237, text238, text239, text240, text241, text242, text243, text244, text245, text246, text247, text248, text249, text250, text251, text252, text253, text254, text255, text256, text257, text258, text259, text260, text261, text262, text263, text264, text265, text266, text267, text268, text269, text270, text271, text272, text273, text274, text275, text276, text277, text278, text279, text280, text281, text282, text283, text284, text285, text286, text287, text288, text289, text290, text291, text292, text293, text294, text295, text296, text297, text298, text299, text300};
	
	public static int[][] choicesLibrary = new int[][] {choices0, choices1, choices2, choices3, choices4, choices5, choices6, choices7, choices8, choices9, choices10, choices11, choices12, choices13, choices14, choices15, choices16, choices17, choices18, choices19, choices20, choices21, choices22, choices23, choices24, choices25, choices26, choices27, choices28, choices29, choices30, choices31, choices32, choices33, choices34, choices35, choices36, choices37, choices38, choices39, choices40, choices41, choices42, choices43, choices44, choices45, choices46, choices47, choices48, choices49, choices50, choices51, choices52, choices53, choices54, choices55, choices56, choices57, choices58, choices59, choices60, choices61, choices62, choices63, choices64, choices65, choices66, choices67, choices68, choices69, choices70, choices71, choices72, choices73, choices74, choices75, choices76, choices77, choices78, choices79, choices80, choices81, choices82, choices83, choices84, choices85, choices86, choices87, choices88, choices89, choices90, choices91, choices92, choices93, choices94, choices95, choices96, choices97, choices98, choices99, choices100, choices101, choices102, choices103, choices104, choices105, choices106, choices107, choices108, choices109, choices110, choices111, choices112, choices113, choices114, choices115, choices116, choices117, choices118, choices119, choices120, choices121, choices122, choices123, choices124, choices125, choices126, choices127, choices128, choices129, choices130, choices131, choices132, choices133, choices134, choices135, choices136, choices137, choices138, choices139, choices140, choices141, choices142, choices143, choices144, choices145, choices146, choices147, choices148, choices149, choices150, choices151, choices152, choices153, choices154, choices155, choices156, choices157, choices158, choices159, choices160, choices161, choices162, choices163, choices164, choices165, choices166, choices167, choices168, choices169, choices170, choices171, choices172, choices173, choices174, choices175, choices176, choices177, choices178, choices179, choices180, choices181, choices182, choices183, choices184, choices185, choices186, choices187, choices188, choices189, choices190, choices191, choices192, choices193, choices194, choices195, choices196, choices197, choices198, choices199, choices200, choices201, choices202, choices203, choices204, choices205, choices206, choices207, choices208, choices209, choices210, choices211, choices212, choices213, choices214, choices215, choices216, choices217, choices218, choices219, choices220, choices221, choices222, choices223, choices224, choices225, choices226, choices227, choices228, choices229, choices230, choices231, choices232, choices233, choices234, choices235, choices236, choices237, choices238, choices239, choices240, choices241, choices242, choices243, choices244, choices245, choices246, choices247, choices248, choices249, choices250, choices251, choices252, choices253, choices254, choices255, choices256, choices257, choices258, choices259, choices260, choices261, choices262, choices263, choices264, choices265, choices266, choices267, choices268, choices269, choices270, choices271, choices272, choices273, choices274, choices275, choices276, choices277, choices278, choices279, choices280, choices281, choices282, choices283, choices284, choices285, choices286, choices287, choices288, choices289, choices290, choices291, choices292, choices293, choices294, choices295, choices296, choices297, choices298, choices299, choices300};
	
	public void UpdateText() {
		if (isHeader) {
			currentText.text = "Section " + SonicVsZonikGame.index;
		}
		else {
			currentText.text = textLibrary[SonicVsZonikGame.index];
		}
	}
}
