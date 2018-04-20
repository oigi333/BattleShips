import os

references = [
	'dependencies\\lib\\sfmlnet-audio-2.dll',
	'dependencies\\lib\\sfmlnet-graphics-2.dll',
	'dependencies\\lib\\sfmlnet-system-2.dll',
	'dependencies\\lib\\sfmlnet-window-2.dll'
]

src = 'src\\*.cs'
lib = 'dependencies\\extlibs\\'
out = 'out\\BattleShipsClient.exe'
csc = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\\Bin\\Roslyn\\csc.exe'


compilerArgs = [
	'-out:' + out,
	'-langversion:7',
	'-lib:' + lib,
	'-platform:x64',
	'-reference:' + ','.join(references)
]

commands = [
	' '.join(['"' + csc + '"', src, ' '.join(compilerArgs)]),
	'copy dependencies\\extlibs\\* out\\',
	'copy dependencies\\lib\\* out\\'
]

for cmd in commands:
	os.system(cmd)
