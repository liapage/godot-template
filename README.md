# Idle

## Overview
- A zombie apocalypse broke, and you are tasked with managing a sanctuary city and keeping your residents alive.
- You start with a few residents placed on a grid alongside any buildings or items you might place. 
- Residents can be assigned jobs which take varying amounts of time.
- You lose if all residents die.

### Expeditions
- Residents can also go on expeditions, risking their lives to bring resources from outside the sanctuary for the survival of the sanctuary.
- Select a resident for the "Lead an Expedition" job and optionally select up to 3 support residents.
- Support residents increase the chances of success by lending their stats to the expedition - the better the combined resident stats for the expedition goal, the more likely the expedition to succeed.
- The bigger the resource goal you set the more time and residents will be required
- The less support residents you take the less the survival chance of the expedition group.
- Start with a low-risk resource goal with 100% success rate but low yield
- Some or all residents may not come back from the expedition.
- A failed expedition means no one came back and no resources were brought.
- STRETCH: Expeditions are simulated, you will receive an event log of what happened during the expedition

### Vitals System
- Manage your resident's health, hunger and sanity to keep them alive
- If all your residents die, you lose

### Stats system
- Residents have stats (and varying stat maxes) that you can upgrade by having them do various jobs (study for INT, train for STR, etc.)
- Using the resources you retrieve from expeditions (e.g. food, books, guns, gym equipment, drugs/alcohol, medicine, etc.) the more you can improve your resident's stats and go on better expeditions.
  Residents also have different limits for their stats so you should invest different stats to different residents
  Certain stat achievements unlock abilities like creating a school, gym, building guns, etc.

## Steamworks

To make it work for MacOS Apple Silicon, I had to clone https://github.com/rlabrecque/Steamworks.NET and build it myself:

```bash
dotnet build -c Release /p:PlatformTarget=AnyCPU
cp bin/x86/Windows/netstandard2.1/Steamworks.NET.dll ~/Development/lumi4x/chaos/Steamworks/OSX-Linux-x64/
```
