# Enemy sprites

The supplied RBC_Enemy_Green_32.piskel is the canonical model. Green is copied unchanged; Red, Orange and Purple were recolored in Piskel, preserving all nine frames and every pixel position. The white recovery frame is shared. Each recolored frame was checked against the Piskel clipboard pixel checksum.

- Editable sources: the four .piskel files in this folder.
- Sheets: four 288×32 transparent PNGs; frame order follows the supplied source, left to right.
- Unity sprites: Assets/Project/Art/Sprites/Characters/Enemies/<Color>/, nine separate 32×32 PNGs per color.
- Source frame order: 01–04 normal directional poses, 05–06 scared X, 07 white recovering X, 08–09 dead return without arms. Frame names retain source numbering.

This replacement preserves the supplied nine-frame set. It does not add the second normal frame per direction or four distinct scared directions required by the earlier assessment checklist. Animation clips and controllers are not created in this asset import.

Unity frame import settings: Sprite (single), 32 pixels per unit, point filtering, clamp wrapping, no mipmaps, no texture compression, transparent alpha, full rectangle mesh. Unity generated all asset GUIDs.
