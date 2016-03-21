# they-live

vogel.site/they-live-glasses

Prototype of an arduino-based alternative controller for a They Live-inspired videogame, in the form of sunglasses.

Attach a photosensor to the arm of your sunglasses, connect it to an Arduino as shown in the link above, and you'll be seeing new layers of reality in no time.

This repo has two crucial parts: an Arduino sketch to detect light and print the reading to Serial, and a script within Unity to read from Serial and swap textures depending on the reading (i.e. whether or not the glasses are being worn).
