# Enemy sprites

The supplied RBC_Enemy_Green_32.piskel is the base model. Red, Orange and Purple use the same shape with different colours. The white recovery frame is shared.

- Editable sources: the four .piskel files in this folder.
- Sheets: four 288×32 transparent PNGs; frame order follows the supplied source, left to right.
- Unity sprites: Assets/Project/Art/Sprites/Characters/Enemies/<Color>/, nine separate 32×32 PNGs per color.
- Source frame order: 01–04 normal directional poses, 05–06 scared X, 07 white recovering X, 08–09 dead return without arms. Frame names retain source numbering.

The extra normal and scared frames are in `A3_Complete`. The original nine-frame files remain here.

Unity import settings: Sprite (single), 32 pixels per unit, point filtering, clamp wrapping and no mipmaps.
