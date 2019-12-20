# PKHeX_Raid_Plugin
Plugin for PKHeX to display all raids and a few more info. 

# How To Use
## Installation
Download ``PKHeX_Raid_Plugin.dll`` and put it in the ``plugins/`` directory of PKHeX. If the directory does not exist, create a new one.

### Note
In order to use the efficient method for Seed Calculation, Z3 is required (https://github.com/Z3Prover/z3/releases). Download the latest release for your OS, put ``Microsoft.Z3.dll`` in ``plugins/`` as well. Further, put the ``bin/`` directory into your path.

## Useage
Open PKHeX, load a savegame, and go to Tool -> Display Raids. You will see the content of every currently active den, including the IVs. Clicking on ``Raid Calculator`` will show you the details for this den when you "reload" it as well as other interesting information.

# How To "Reload" A Den
Talk to the Den, click on "Invite Others", then advance the time of your Switch by at least 1 day and then go back into the game. Cancel the raid search and talk to the den again. This advances the den by 1 frame. It is not possible to advance frames by more than 1, so you have to repeat this process.

# Full Guide
Available here: https://github.com/zaksabeast/PokemonRNGGuides/blob/add/swsh/raid/guides/swsh/en/Raid%20RNG.md

# Compiling
To compile this project, ``PKHeX.Core.dll``, ``PKHeX.Drawing.dll``, and ``Microsoft.Z3.dll`` are required as references.
