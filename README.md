## 快速开始

### 方式一：用 .NET CLI 运行（推荐）

```bash
# 1. 克隆仓库
git clone https://github.com/smallH11/Snake_VS_ConsoleApp.git
cd Snake_VS_ConsoleApp

# 2. 直接运行（项目在子目录中，用 --project 指定 csproj）
dotnet run --project "贪吃蛇Game-控制台应用/贪吃蛇Game-控制台应用.csproj"
```

### 方式二：编译后运行可执行文件

```bash
# 1. 编译（Release 配置）
dotnet build -c Release

# 2. 运行生成的可执行文件
./贪吃蛇Game-控制台应用/bin/Release/net10.0/贪吃蛇Game-控制台应用.exe
```

Windows CMD / PowerShell 下运行 exe：

```powershell
.\贪吃蛇Game-控制台应用\bin\Release\net10.0\贪吃蛇Game-控制台应用.exe
```

### 方式三：用 Visual Studio 打开

直接双击解决方案文件 `贪吃蛇Game-控制台应用\贪吃蛇Game-控制台应用.slnx`，按 `F5` 运行。

> **注意**：`.slnx` 需要 Visual Studio 2022 17.10 及以上版本；旧版本请直接打开 `贪吃蛇Game-控制台应用\贪吃蛇Game-控制台应用.csproj`。

### 打包给没有 .NET 环境的电脑

仓库不包含编译产物，如需免安装单文件版本，可执行：

```powershell
dotnet publish "贪吃蛇Game-控制台应用/贪吃蛇Game-控制台应用.csproj" -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

生成的单文件 exe 不依赖 .NET 运行时，可直接拷贝给他人运行。

> 若窗口尺寸被系统限制（部分终端不允许缩放），可在终端属性中把窗口调整为至少 80x20 后再运行；建议使用 Windows Terminal 运行，中文与宽字符显示更稳定。