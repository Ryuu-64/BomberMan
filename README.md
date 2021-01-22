# BomberMan

BomberMan - Michael

# 2D Tilemap Extras Rule Tile

## 安装 2d-extras

打开 Package Manager

单击左上方的 **+**

选择 Add package from git URL 输入

```website
https://github.com/Unity-Technologies/2d-extras.git#master
```

即可安装 2d-extras 包

速度据网速各有不同 稍作等待即可

或直接在项目文件中  Packages / manifest.json 添加以下信息

``` json
"com.unity.2d.tilemap.extras": "https://github.com/Unity-Technologies/2d-extras.git#master"
```

## 2D Tilemap Extras

在本地文件中单击右键 Create- > Tiles -> Rule Tile (根据设定规则自动选择显示瓦片)

查看 Inspector 窗口

> 为其添加默认 Sprite (作为该 Rule Tile 在 Palette 的默认显示 Sprite )
>
> 单击 Tiling Rules **+** 并选择图片并在图片右侧设置该图片的显示规则
>
> 白点为该 Sprite **绿色箭头**为匹配指定方位**有 Sprite**  **红色叉**为匹配指定方位**无 Sprite**
>
> 例: 还没写
>
> 且规则节点越在列表上层越有限匹配

将该Rule Tile 添加至 Palette **直接拖动**

直接用框或涂都能按指定 Rule 匹配应显示的 Sprite

