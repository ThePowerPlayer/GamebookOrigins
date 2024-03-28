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

	public static string text1 =
		"Something very strange had happened in the Green Hill Zone. One minute Sonic had been sitting playing with his Mega Drive, the next thing he was being attacked by a group of maniac bunnies. They were usually his friends! He'd tried to speak to them, but all they kept shouting at him was something about him filling all their burrows with rotten eggs. Sonic didn't even like eggs, and the bunnies were his mates, so he'd never dream of doing that to them. Suddenly, everything had gone black... Sonic could see stars, not the kind of stars in the night sky, but the kind that whizz around the inside of your head. It was as if the whole of the universe was circling around him — Sonic, of course, being the centre of the universe.\n\n'Hey, slow down, it was day-time a minute ago!'\n\nSuddenly, his senses returned and he jumped to his feet. The bunnies were gone. He was alone, confused and not sure what was going on.\n\n'Wow, this is weird,' says Sonic.\n\nSonic might be covered in spines, but they don't protect his head. Gingerly, he raises a paw to the rapidly growing bruise.\n\n'Oh no! It's the size of an egg ... hey, now don't say egg! Bad vibes about that word. I suppose I'd better find out whether the bunnies were right.'\n\nSonic set out through the Green Hills, still not really believing what had happened in the past ten minutes. Everything looked normal, the hills were green, the sky was blue. Yes, this had to be the Green Hill Zone. But there was something, something odd, nagging him.\n\n'ZZZZzzzzwing!'\n\nA small silver object flew towards Sonic's head, embedding itself in a tree behind him. Sonic turned around to take a look at the tree. There, half-buried in the bark, was the familiar shape of a Buzzer.\n\n'ZZZzzz ... buzzzz! Get ya next time. Buzzz!' threatened the Buzzer, rather pathetically, as he was firmly stuck in the tree.\n\nSonic smiled, all was well in the Green Hill Zone. They always try to get me, he thought, but never manage it. The thought formed a smile. Sonic started walking away from the cursing Buzzer, wondering whether to head for the hills or one of the bridges. Imagine you are Sonic - what would you do? Go to the hills (turn to <b>106</b>)? If you think Sonic should head towards the river, then turn to <b>177</b>.";

	public static string text2 =
		"";

	public static string text3 =
		"";

	public static string text4 =
		"";

	public static string text5 =
		"";

	public static string text6 =
		"";

	public static string text7 =
		"";

	public static string text8 =
		"";

	public static string text9 =
		"";

	public static string text10 =
		"";

	public static string text11 =
		"";

	public static string text12 =
		"";

	public static string text13 =
		"";

	public static string text14 =
		"";

	public static string text15 =
		"";

	public static string text16 =
		"";

	public static string text17 =
		"";

	public static string text18 =
		"";

	public static string text19 =
		"";

	public static string text20 =
		"";

	public static string text21 =
		"";

	public static string text22 =
		"";

	public static string text23 =
		"";

	public static string text24 =
		"";

	public static string text25 =
		"";

	public static string text26 =
		"";

	public static string text27 =
		"";

	public static string text28 =
		"";

	public static string text29 =
		"";

	public static string text30 =
		"";

	public static string text31 =
		"";

	public static string text32 =
		"";

	public static string text33 =
		"";

	public static string text34 =
		"";

	public static string text35 =
		"";

	public static string text36 =
		"";

	public static string text37 =
		"";

	public static string text38 =
		"";

	public static string text39 =
		"";

	public static string text40 =
		"";

	public static string text41 =
		"";

	public static string text42 =
		"";

	public static string text43 =
		"";

	public static string text44 =
		"";

	public static string text45 =
		"";

	public static string text46 =
		"";

	public static string text47 =
		"";

	public static string text48 =
		"";

	public static string text49 =
		"";

	public static string text50 =
		"";

	public static string text51 =
		"";

	public static string text52 =
		"";

	public static string text53 =
		"";

	public static string text54 =
		"";

	public static string text55 =
		"";

	public static string text56 =
		"";

	public static string text57 =
		"";

	public static string text58 =
		"";

	public static string text59 =
		"";

	public static string text60 =
		"";

	public static string text61 =
		"";

	public static string text62 =
		"";

	public static string text63 =
		"";

	public static string text64 =
		"";

	public static string text65 =
		"";

	public static string text66 =
		"";

	public static string text67 =
		"";

	public static string text68 =
		"";

	public static string text69 =
		"";

	public static string text70 =
		"";

	public static string text71 =
		"";

	public static string text72 =
		"";

	public static string text73 =
		"";

	public static string text74 =
		"";

	public static string text75 =
		"";

	public static string text76 =
		"";

	public static string text77 =
		"";

	public static string text78 =
		"";

	public static string text79 =
		"";

	public static string text80 =
		"";

	public static string text81 =
		"";

	public static string text82 =
		"";

	public static string text83 =
		"";

	public static string text84 =
		"";

	public static string text85 =
		"";

	public static string text86 =
		"";

	public static string text87 =
		"";

	public static string text88 =
		"";

	public static string text89 =
		"";

	public static string text90 =
		"";

	public static string text91 =
		"";

	public static string text92 =
		"";

	public static string text93 =
		"";

	public static string text94 =
		"";

	public static string text95 =
		"";

	public static string text96 =
		"";

	public static string text97 =
		"";

	public static string text98 =
		"";

	public static string text99 =
		"";

	public static string text100 =
		"";

	public static string text101 =
		"";

	public static string text102 =
		"";

	public static string text103 =
		"";

	public static string text104 =
		"";

	public static string text105 =
		"";

	public static string text106 =
		"";

	public static string text107 =
		"";

	public static string text108 =
		"";

	public static string text109 =
		"";

	public static string text110 =
		"";

	public static string text111 =
		"";

	public static string text112 =
		"";

	public static string text113 =
		"";

	public static string text114 =
		"";

	public static string text115 =
		"";

	public static string text116 =
		"";

	public static string text117 =
		"";

	public static string text118 =
		"";

	public static string text119 =
		"";

	public static string text120 =
		"";

	public static string text121 =
		"";

	public static string text122 =
		"";

	public static string text123 =
		"";

	public static string text124 =
		"";

	public static string text125 =
		"";

	public static string text126 =
		"";

	public static string text127 =
		"";

	public static string text128 =
		"";

	public static string text129 =
		"";

	public static string text130 =
		"";

	public static string text131 =
		"";

	public static string text132 =
		"";

	public static string text133 =
		"";

	public static string text134 =
		"";

	public static string text135 =
		"";

	public static string text136 =
		"";

	public static string text137 =
		"";

	public static string text138 =
		"";

	public static string text139 =
		"";

	public static string text140 =
		"";

	public static string text141 =
		"";

	public static string text142 =
		"";

	public static string text143 =
		"";

	public static string text144 =
		"";

	public static string text145 =
		"";

	public static string text146 =
		"";

	public static string text147 =
		"";

	public static string text148 =
		"";

	public static string text149 =
		"";

	public static string text150 =
		"";

	public static string text151 =
		"";

	public static string text152 =
		"";

	public static string text153 =
		"";

	public static string text154 =
		"";

	public static string text155 =
		"";

	public static string text156 =
		"";

	public static string text157 =
		"";

	public static string text158 =
		"";

	public static string text159 =
		"";

	public static string text160 =
		"";

	public static string text161 =
		"";

	public static string text162 =
		"";

	public static string text163 =
		"";

	public static string text164 =
		"";

	public static string text165 =
		"";

	public static string text166 =
		"";

	public static string text167 =
		"";

	public static string text168 =
		"";

	public static string text169 =
		"";

	public static string text170 =
		"";

	public static string text171 =
		"";

	public static string text172 =
		"";

	public static string text173 =
		"";

	public static string text174 =
		"";

	public static string text175 =
		"";

	public static string text176 =
		"";

	public static string text177 =
		"";

	public static string text178 =
		"";

	public static string text179 =
		"";

	public static string text180 =
		"";

	public static string text181 =
		"";

	public static string text182 =
		"";

	public static string text183 =
		"";

	public static string text184 =
		"";

	public static string text185 =
		"";

	public static string text186 =
		"";

	public static string text187 =
		"";

	public static string text188 =
		"";

	public static string text189 =
		"";

	public static string text190 =
		"";

	public static string text191 =
		"";

	public static string text192 =
		"";

	public static string text193 =
		"";

	public static string text194 =
		"";

	public static string text195 =
		"";

	public static string text196 =
		"";

	public static string text197 =
		"";

	public static string text198 =
		"";

	public static string text199 =
		"";

	public static string text200 =
		"";

	public static string text201 =
		"";

	public static string text202 =
		"";

	public static string text203 =
		"";

	public static string text204 =
		"";

	public static string text205 =
		"";

	public static string text206 =
		"";

	public static string text207 =
		"";

	public static string text208 =
		"";

	public static string text209 =
		"";

	public static string text210 =
		"";

	public static string text211 =
		"";

	public static string text212 =
		"";

	public static string text213 =
		"";

	public static string text214 =
		"";

	public static string text215 =
		"";

	public static string text216 =
		"";

	public static string text217 =
		"";

	public static string text218 =
		"";

	public static string text219 =
		"";

	public static string text220 =
		"";

	public static string text221 =
		"";

	public static string text222 =
		"";

	public static string text223 =
		"";

	public static string text224 =
		"";

	public static string text225 =
		"";

	public static string text226 =
		"";

	public static string text227 =
		"";

	public static string text228 =
		"";

	public static string text229 =
		"";

	public static string text230 =
		"";

	public static string text231 =
		"";

	public static string text232 =
		"";

	public static string text233 =
		"";

	public static string text234 =
		"";

	public static string text235 =
		"";

	public static string text236 =
		"";

	public static string text237 =
		"";

	public static string text238 =
		"";

	public static string text239 =
		"";

	public static string text240 =
		"";

	public static string text241 =
		"";

	public static string text242 =
		"";

	public static string text243 =
		"";

	public static string text244 =
		"";

	public static string text245 =
		"";

	public static string text246 =
		"";

	public static string text247 =
		"";

	public static string text248 =
		"";

	public static string text249 =
		"";

	public static string text250 =
		"";

	public static string text251 =
		"";

	public static string text252 =
		"";

	public static string text253 =
		"";

	public static string text254 =
		"";

	public static string text255 =
		"";

	public static string text256 =
		"";

	public static string text257 =
		"";

	public static string text258 =
		"";

	public static string text259 =
		"";

	public static string text260 =
		"";

	public static string text261 =
		"";

	public static string text262 =
		"";

	public static string text263 =
		"";

	public static string text264 =
		"";

	public static string text265 =
		"";

	public static string text266 =
		"";

	public static string text267 =
		"";

	public static string text268 =
		"";

	public static string text269 =
		"";

	public static string text270 =
		"";

	public static string text271 =
		"";

	public static string text272 =
		"";

	public static string text273 =
		"";

	public static string text274 =
		"";

	public static string text275 =
		"";

	public static string text276 =
		"";

	public static string text277 =
		"";

	public static string text278 =
		"";

	public static string text279 =
		"";

	public static string text280 =
		"";

	public static string text281 =
		"";

	public static string text282 =
		"";

	public static string text283 =
		"";

	public static string text284 =
		"";

	public static string text285 =
		"";

	public static string text286 =
		"";

	public static string text287 =
		"";

	public static string text288 =
		"";

	public static string text289 =
		"";

	public static string text290 =
		"";

	public static string text291 =
		"";

	public static string text292 =
		"";

	public static string text293 =
		"";

	public static string text294 =
		"";

	public static string text295 =
		"";

	public static string text296 =
		"";

	public static string text297 =
		"";

	public static string text298 =
		"";

	public static string text299 =
		"";

	public static string text300 =
		"";
	
	public static string[] textLibrary = {text0, text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12, text13, text14, text15, text16, text17, text18, text19, text20, text21, text22, text23, text24, text25, text26, text27, text28, text29, text30, text31, text32, text33, text34, text35, text36, text37, text38, text39, text40, text41, text42, text43, text44, text45, text46, text47, text48, text49, text50, text51, text52, text53, text54, text55, text56, text57, text58, text59, text60, text61, text62, text63, text64, text65, text66, text67, text68, text69, text70, text71, text72, text73, text74, text75, text76, text77, text78, text79, text80, text81, text82, text83, text84, text85, text86, text87, text88, text89, text90, text91, text92, text93, text94, text95, text96, text97, text98, text99, text100, text101, text102, text103, text104, text105, text106, text107, text108, text109, text110, text111, text112, text113, text114, text115, text116, text117, text118, text119, text120, text121, text122, text123, text124, text125, text126, text127, text128, text129, text130, text131, text132, text133, text134, text135, text136, text137, text138, text139, text140, text141, text142, text143, text144, text145, text146, text147, text148, text149, text150, text151, text152, text153, text154, text155, text156, text157, text158, text159, text160, text161, text162, text163, text164, text165, text166, text167, text168, text169, text170, text171, text172, text173, text174, text175, text176, text177, text178, text179, text180, text181, text182, text183, text184, text185, text186, text187, text188, text189, text190, text191, text192, text193, text194, text195, text196, text197, text198, text199, text200, text201, text202, text203, text204, text205, text206, text207, text208, text209, text210, text211, text212, text213, text214, text215, text216, text217, text218, text219, text220, text221, text222, text223, text224, text225, text226, text227, text228, text229, text230, text231, text232, text233, text234, text235, text236, text237, text238, text239, text240, text241, text242, text243, text244, text245, text246, text247, text248, text249, text250, text251, text252, text253, text254, text255, text256, text257, text258, text259, text260, text261, text262, text263, text264, text265, text266, text267, text268, text269, text270, text271, text272, text273, text274, text275, text276, text277, text278, text279, text280, text281, text282, text283, text284, text285, text286, text287, text288, text289, text290, text291, text292, text293, text294, text295, text296, text297, text298, text299, text300};
	
	public void UpdateText() {
		if (isHeader) {
			currentText.text = "Section " + SonicVsZonikGame.index;
		}
		else {
			currentText.text = textLibrary[SonicVsZonikGame.index];
		}
	}
}
