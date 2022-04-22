To use any downloaded Humanoid animation — firstly you should setup them.

Animations can be separated files with .anim extention or thay can be part of .FBX file which contains other model and armature.

If you work with .FBX you should select that file in Project window. Than look into Inspector window and you will see tabs with names | Model | Rig | Animation | Materials |, press to | Rig | tab and change Animation Type from Generic to Humanoid.

Now you able use animations from that file with you Animation controller on your character. Be care, check loop option in your animation settings if it looks like not animated.

IMPORTANT FOR MIXAMO USERS: If you wish to download animations from MIXAMO left all settings in "DOWNLOAD SETTINGS" window by default, do not change them, otherwise you can recive broken animation with wrong rotations, if you will select "Without skin" - avatar goes to be broken.

Please note:
1. When you download animations from mixamo please download it with default options (with skin and etc).
2. When you setup animation for better visual you should set "Root transform position" options "Bake into pose" to "true" and "Based Upon" to "Feet"