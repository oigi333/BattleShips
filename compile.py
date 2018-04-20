import os
import sys


debug = False
if len(sys.argv) > 1:
	if sys.argv[1] == "debug":
		debug = True


references = [
	'dependencies\\lib\\sfmlnet-audio-2.dll',
	'dependencies\\lib\\sfmlnet-graphics-2.dll',
	'dependencies\\lib\\sfmlnet-system-2.dll',
	'dependencies\\lib\\sfmlnet-window-2.dll',
	'dependencies\\lib\\Newtonsoft.Json.dll'
]

src = 'src\\*.cs'
lib = 'dependencies\\extlibs\\'
out = 'out\\BattleShipsClient.exe'
csc = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\\Bin\\Roslyn\\csc.exe'

compilerArgs = [
	'-out:' + out,
	'-lib:' + lib,
	'-reference:' + ','.join(references),
	'-langversion:7',
	'-platform:x64',
	'-target:winexe' if not debug else ''
]


commands = [
	' '.join(['"' + csc + '"', src, ' '.join(compilerArgs)]),
	'xcopy res out\\res\\ /s /e /y',
	'xcopy dependencies\\extlibs out\\ /s /e /y',
	'xcopy dependencies\\lib out\\ /s /e /y'
]

for cmd in commands:
	os.system(cmd)
