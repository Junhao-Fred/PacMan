# Enemy Piskel sources

Each colour has four editable 32×32 Piskel files. The orange frames come from the updated 30-frame `Enemy Orange-20260920-161245.piskel` drawing. Green, red and purple use the same pixels with only the orange accent colour changed. The older 19-frame files in `../A3_Complete` remain unchanged.

- `Normal.piskel`: 16 frames — Down 1–4, Up 1–4, Left 1–4, Right 1–4.
- `Scared.piskel`: 8 frames — Down 1–2, Up 1–2, Left 1–2, Right 1–2.
- `Recovering.piskel`: 2 frames.
- `Dead.piskel`: 4 frames — return pose without arms.

The corresponding PNGs are in `Assets/Project/Art/Sprites/Characters/Enemies/<Colour>/`. Editing a Piskel source later does not automatically update its Unity PNGs.
