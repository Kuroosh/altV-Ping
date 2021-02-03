//----------------------------------//
///// VenoX Gaming & Fun 2021 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

let Ping = 0;
let ColorEntry = { R: 255, G: 255, B: 255, A: 255 };
alt.onServer('PingContainer:SendResult', result => {
	if (result > 100) ColorEntry = { R: 175, G: 0, B: 0 };
	else if (result > 50) ColorEntry = { R: 175, G: 175, B: 0 };
	else ColorEntry = { R: 0, G: 175, B: 0 };
	Ping = result;
});


alt.everyTick(() => {
	DrawText(Ping.toString(), [0.005, 0.98], [0.3, 0.3], 0, [ColorEntry.R, ColorEntry.G, ColorEntry.B, 255], true, true);
});


export function DrawText(msg, screenPos, scale, fontType, ColorRGB, useOutline = true, useDropShadow = true, layer = 0, align = 0) {
	let hex = msg.match('{.*}');
	if (hex) {
		const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
		r = rgb[0];
		g = rgb[1];
		b = rgb[2];
		msg = msg.replace(hex[0], '');
	}
	if (ColorRGB == undefined || ColorRGB == null) {
		ColorRGB = 255;
	}
	//game.setScriptGfxDrawOrder(layer);
	game.beginTextCommandDisplayText('STRING');
	game.addTextComponentSubstringPlayerName(msg);
	game.setTextFont(fontType);
	game.setTextScale(scale[0], scale[1]);
	game.setTextWrap(0.0, 1.0);
	game.setTextCentre(true);
	game.setTextColour(ColorRGB[0], ColorRGB[1], ColorRGB[2], ColorRGB[3]);
	game.setTextJustification(align);

	if (useOutline) game.setTextOutline();

	if (useDropShadow) game.setTextDropShadow();

	game.endTextCommandDisplayText(screenPos[0], screenPos[1]);
}