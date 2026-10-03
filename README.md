# 贪吃蛇大作战（控制台版）

一个用 C# 编写的控制台贪吃蛇小游戏，基于**场景切换 + 面向对象**的思路实现：主界面、游戏场景、结束场景各自独立成类，通过统一的 `ISceneUpdate` 接口驱动更新循环。

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![Language](https://img.shields.io/badge/C%23-console%20game-239120?logo=csharp)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows)

---

## 目录

- [游戏特性](#游戏特性)
- [运行环境](#运行环境)
- [快速开始](#快速开始)
- [操作说明](#操作说明)
- [项目结构](#项目结构)
- [核心设计](#核心设计)
- [上传到 GitHub](#上传到-github)
- [已知限制与可改进点](#已知限制与可改进点)

---

## 游戏特性

- **纯控制台渲染**：使用 `Console.SetCursorPosition` 精确定位绘制，自绘围墙、蛇身与食物，不依赖任何第三方库。
- **三场景状态机**：主界面 → 游戏场景 → 结束场景，可循环回到主界面重新开局。
- **固定窗口尺寸**：固定 `80 x 20` 的窗口与缓冲区，隐藏光标避免闪烁。
- **方向键防反向**：蛇身长度大于 1 时不能 180° 掉头，避免直接撞上自己。
- **食物不重叠生成**：随机生成食物时会检测是否与蛇身重合，重合则重新生成。
- **吃到食物自动增长**：每次得分蛇身长度 +1。

## 运行环境

| 项目 | 要求 |
| --- | --- |
| SDK | .NET 10 SDK（目标框架 `net10.0`） |
| 语言版本 | C#（启用 `ImplicitUsings` 与 `Nullable`） |
| 操作系统 | Windows（依赖 `Console.SetWindowSize` / `Console.SetBufferSize`） |
| 编码 | 源码含中文，建议使用 UTF-8 打开 |

> 终端需支持宽字符与彩色输出（Windows Terminal、CMD、PowerShell 均可）。

## 快速开始

```bash
# 1. 克隆仓库
git clone https://github.com/<your-name>/<your-repo>.git
cd <your-repo>

# 2. 直接运行
dotnet run

# 或：编译后运行生成的可执行文件
dotnet build -c Release
bin/Release/net10.0/贪吃蛇Game-控制台应用.exe
```

> 若窗口尺寸被系统限制（部分终端不允许缩放），可在终端属性中把窗口调整为至少 80x20 后再运行。

## 操作说明

### 菜单场景（主界面 / 结束界面）

| 按键 | 功能 |
| --- | --- |
| `W` / `S` | 上移 / 下移选项（红色高亮为当前选中项） |
| `J` | 确认当前选项 |

- **主界面**：`开始游戏` / `退出游戏`
- **结束界面**：`回到主界面` / `退出游戏`

### 游戏场景

| 按键 | 功能 |
| --- | --- |
| `W` | 向上 |
| `A` | 向左 |
| `S` | 向下 |
| `D` | 向右 |

### 画面元素

| 元素 | 外观 | 颜色 |
| --- | --- | --- |
| 围墙 | `■` | 红色 |
| 蛇头 | `●` | 黄色 |
| 蛇身 | `◎` | 绿色 |
| 食物 | `★` | 蓝色 |

## 项目结构

```
贪吃蛇Game-控制台应用/
├── 贪吃蛇Game-控制台应用.slnx      # 解决方案文件
├── 贪吃蛇Game-控制台应用.csproj    # 项目文件（net10.0）
├── Program.cs                      # 程序入口
├── Game.cs                         # 游戏主循环 / 场景枚举 / 全局宽高常量
├── ISceneUpdate.cs                 # 场景更新接口
├── IDraw.cs                        # 可绘制对象接口
├── GameObject.cs                   # 可绘制对象抽象基类（持有坐标）
├── Position.cs                     # 位置结构体（重载 == / !=）
├── Map.cs                          # 围墙集合，负责生成边框
├── Wall.cs                         # 单个墙体
├── Snake.cs                        # 蛇：移动、转向、碰撞、吃食物增长
├── SnakeBody.cs                    # 蛇身节点（头 / 身两种类型）
├── Food.cs                         # 食物：随机生成 + 不重叠检测
├── BeginOrEndScene.cs              # 菜单类场景抽象基类
├── BeginScene.cs                   # 主界面场景
├── GameScene.cs                    # 游戏进行场景
└── EndScene.cs                     # 游戏结束场景
```

## 核心设计

### 1. 主循环与场景切换

`Program.Main` 只做一件事：创建 `Game` 并调用 `Start()`。主循环是一个永不退出的 `while (true)`，每帧只调用当前场景的 `Update()`：

```csharp
public void Start()
{
    while (true)
    {
        sceneUpdate.Update();   // 多态：调用当前场景的更新逻辑
    }
}
```

场景切换由静态方法 `Game.ChangeScene(E_Scene_Type)` 完成，它先清屏，再根据枚举实例化对应场景并赋给静态字段 `sceneUpdate`——用枚举 + 多态实现一个简单状态机。

### 2. 接口分层

- `ISceneUpdate`：只要求实现 `Update()`，是主循环与场景之间唯一的契约。
- `IDraw`：只要求实现 `Draw()`，墙体、蛇、食物都通过它被统一绘制。
- `GameObject`：抽象类，实现 `IDraw` 并提供 `Position` 字段，让 `Wall`、`Food`、`SnakeBody` 共享坐标数据。

### 3. 蛇的移动算法

`Snake.Move()` 采用**尾节点擦除 + 坐标整体后移 + 头节点前进**的方式，避免整条蛇重绘导致的闪烁：

```csharp
// 1. 擦掉尾巴
Console.SetCursorPosition(bodys[nowNum - 1].position.x, bodys[nowNum - 1].position.y);
Console.Write(" ");
// 2. 从尾到头，每个节点继承前一个节点的坐标
for (int i = nowNum - 1; i > 0; i--)
    bodys[i].position = bodys[i - 1].position;
// 3. 头节点按当前方向前进一格
```

由于横向的宽字符占 2 列，水平移动步长为 `±2`、纵向为 `±1`，围墙与食物坐标也按 2 的倍数生成以保持对齐。

### 4. 碰撞与得分

- 撞墙：`Snake.isCheckBorder(Map)` 遍历所有墙体坐标，命中则切到结束场景。
- 吃食物：`Snake.CheckFood(Food)` 比较蛇头与食物坐标，命中则调用 `Food.RandomPos` 重生成食物，并 `AddBody()` 让蛇增长一格。

## 已知限制与可改进点

以下问题保留为后续优化方向：

- **只有撞墙判定，没有自撞判定**：蛇穿过自己的身体不会结束游戏，可增加 `Snake` 内部的自身坐标碰撞检测。
- **刷新节奏用计数取模实现**：`GameScene.Update` 中通过 `updateIndex % 5000 == 0` 控制移动频率，实际速度随 CPU 性能浮动。建议改用 `Stopwatch` 或帧间隔做固定步长控制。
- **无分数统计与最高分**：吃食物只增长身体，没有分数显示与持久化记录。
- **无暂停功能**：可加入空格键暂停 / 继续。
- **窗口尺寸硬编码**：`Game.w` / `Game.h` 为常量 80x20，且 `Console.SetWindowSize` 在部分终端会抛异常，可加 `try/catch` 或按控制台实际尺寸自适应。
- **`Position` 重载了 `==` / `!=` 但未重写 `Equals` / `GetHashCode`**：会产生编译警告，正式使用建议一并重写。

---

如果这个项目对你有帮助，欢迎点个 Star ⭐