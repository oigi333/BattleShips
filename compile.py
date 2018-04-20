import os

references = [
    "",
    "dependencies\\lib\\sfmlnet-audio-2.dll",
    "dependencies\\lib\\sfmlnet-graphics-2.dll",
    "dependencies\\lib\\sfmlnet-system-2.dll",
    "dependencies\\lib\\sfmlnet-window-2.dll",
]

cscPath = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\\Bin\\Roslyn\\"

commands = [
    "\""+cscPath+"csc.exe\" code\\*.cs -out:output\\BattleShips.exe -langversion:7 -lib:dependencies\\extlibs\\ -platform:x64" + " -reference:" + ",".join(references),
]

for command in commands:
    os.system(command)