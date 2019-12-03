# PKHeX_Raid_Plugin
Plugin for PKHeX to display all raids and a few more info.

# How To Use
## Installation
Download ``PKHeX_Raid_Plugin.dll`` and put it in the ``plugins/`` directory of PKHeX. If the directory does not exist, create a new one.

## Useage
Open PKHeX, load a savegame, and go to Tool -> Display Raids. You will see the content of every currently active den, including the IVs. Clicking on ``Predict IVs`` will show you the IVs for this den when you "reload" it.

# How To "Reload" A Den
Talk to the Den, click on "Invite Others", then advance the time of your Switch by at least 1 day and then go back into the game. Cancel the raid search and talk to the den again. This advances the den by 1 frame. It is not possible to advance frames by more than 1, so you have to repeat this process.

# Limitations
Basically this only works to predict IVs of current dens. When you throw in a new Wishing Piece, the seed is newly generated using a Cryptographical Secure RNG, which means the output cannot be predicted. Further, only the current den content, and the following 2 frames are pre-determined (/stored in your savegame). Everything after this is completly random and cannot be predicted, which means that if you find  Frame that gives you 6 times 31 IVs for 4 fixed IVs (5 Star Raids and some 4 Star Raids), it is not guaranteed that you will have a 4 or 5 Star Raid.
