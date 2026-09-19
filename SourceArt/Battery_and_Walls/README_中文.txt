Robot Battery Collector — 电池与墙体
全部图案在 Piskel 编辑器中逐像素绘制；PNG 由编辑器复制出的原始像素无损编码。无网络视觉素材。

单个 PNG 均为 32×32，透明背景。文件名中的 01 / 02 为能量电池的两帧，建议每秒 4–6 帧。
RBC_PowerBattery_32_sheet.png：64×32，从左到右两帧。
RBC_Walls_32_sheet.png：96×64，第一行：外直墙、外转角、内直墙；第二行：内转角、T 形墙、激光出口门。
RBC_BatteryAndWalls_32_sheet.png：96×96，第一行：普通电池、能量电池 1、能量电池 2；之后两行同墙体表。

继续编辑：在 Piskel 选择 Import → Browse images → Import as spritesheet，Frame size 设为 32×32，Offset 0×0。单张 PNG 也可直接打开修改。
墙体连接中心位于第 15–16 像素（从 0 计数），可旋转 90°、180°、270°复用。外墙厚 12 像素，内墙厚 6 像素。激光出口门与内墙连接。
PNG 用于游戏导入；Preview 只是放大展示图，不应当作为精灵素材。
