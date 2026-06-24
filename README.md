# 🥾 HikeRPG

An OOP project built in C# (.NET 8). It demonstrates core OOP principles (encapsulation, inheritance, polymorphism, interfaces) plus two design patterns (Observer and Simple Factory), through a console app that turns real hikes into character progression data.



\## What it demonstrates



The app logs real hikes (distance, elevation, type) and uses that data to drive a character's stats, leveling, achievements, and a persistent leaderboard. The game part is really just a concrete use case for the architecture. The actual focus is the class design: how responsibilities are split across interfaces, abstract classes, and concrete implementations, and how the patterns keep the system decoupled and extensible.



\## Architecture overview



\- \*\*Interfaces\*\* (`IHike`, `IHikeObserver`, `IAchievement`, `IBoost`) define contracts so concrete classes can be swapped without touching the code that depends on them.

\- \*\*Abstraction \& inheritance\*\*: `Hike` is abstract, with `TrailHike`, `MountainHike`, `NightHike`, and `LoggedHike` as subtypes, each overriding `GetXP()` and `GetDifficulty()` differently.

\- \*\*Encapsulation\*\*: internal state (stats, hike history, observers) is private behind public methods. `Character` and `GameEngine` only expose what's needed.

\- \*\*Composition\*\*: `Character` is made up of `HikeHistory`, `BadgeCollection`, and `CharacterStats`, instead of inheriting from them.



\## Design patterns



\- \*\*Observer pattern\*\*: `Character` is the subject. `StatObserver`, `AchievementObserver`, and `LevelObserver` all implement `IHikeObserver` and react automatically when a hike is logged. Logging a hike doesn't manually trigger stat updates, achievement checks, or level checks, each observer just listens and responds on its own. New reactions can be added without touching `Character`.

\- \*\*Simple Factory pattern\*\*: `HikeFactory` builds the correct `Hike` subtype (`TrailHike`, `MountainHike`, `NightHike`) based on a type string, so the rest of the program only ever depends on the abstract `Hike` type.



\## Features (the use case)



\- 3 hike types, each with its own difficulty logic (trail, mountain, night)

\- Leveling system with XP, levels, and 3 core stats (Energy, Strength, Stamina)

\- Achievements (distance, elevation, streak milestones) paired with automatic boosts

\- Global leaderboard, persisted across sessions via JSON

\- Per player hike history with distance/elevation totals

\- Character switching without restarting

\- Energy system that blocks hiking when you're exhausted

\- Persistent save files (Newtonsoft.Json)

\- Animated console UI: colored stat bars, startup/goodbye screens, level up/achievement animations



\## Installation



Published as a \[.NET global tool](https://www.nuget.org/packages/HikeRPG) on NuGet.org. Everything below runs straight from a terminal, no manual downloads.



\*\*1. Check if .NET is already installed:\*\*

```bash

dotnet --version

```

If you see 8.0 or higher, skip to step 3.



\*\*2. Install .NET (if step 1 failed):\*\*



\- \*\*Windows:\*\*

&#x20; ```bash

&#x20; winget install Microsoft.DotNet.SDK.8

&#x20; ```

\- \*\*Mac:\*\*

&#x20; ```bash

&#x20; brew install dotnet@8

&#x20; ```

\- \*\*Linux:\*\* see the \[official install guide](https://learn.microsoft.com/en-us/dotnet/core/install/linux) for your distro



> If this is the first time installing .NET on this machine, close your terminal completely and open a new one before continuing. This avoids almost all PATH issues.



\*\*3. Install HikeRPG:\*\*

```bash

dotnet tool install --global HikeRPG

```



\*\*4. Run it:\*\*

```bash

hikerpg

```



\*\*5. Update later:\*\*

```bash

dotnet tool update --global HikeRPG

```



\## Running from source



If you'd rather build and run the actual source code instead of installing the package, here's the full flow from an empty console:



\*\*1. Check .NET is installed:\*\*

```bash

dotnet --version

```



\*\*2. Clone the repo:\*\*

```bash

git clone https://github.com/dashaakvasha/HikeRPG.git

```



\*\*3. Move into the project folder\*\* (the one with `HikeRPG.csproj`):

```bash

cd HikeRPG/HikeRPG/HikeRPG

```



\*\*4. Restore dependencies:\*\*

```bash

dotnet restore

```



\*\*5. Build:\*\*

```bash

dotnet build

```



\*\*6. Run:\*\*

```bash

dotnet run

```



Clone, restore, build, run. After the first build, `dotnet run` rebuilds automatically if you've changed anything, so you usually just need that last command.



\## Usage



```

\[1] 🥾 Log a Hike

\[2] 📊 My Stats

\[3] 🏆 Achievements

\[4] 🏅 Leaderboard

\[5] 📜 View Hike History

\[6] 🔄 Switch Character

\[7] 🗑 Delete Leaderboard Entry

\[8] 🚪 Exit

```



\## Project structure



```

HikeRPG/

├── Interfaces/      IHike, IHikeObserver, IAchievement, IBoost

├── Models/          Character, CharacterStats, HikeHistory, BadgeCollection, Leaderboard

├── Hikes/           Hike (abstract), TrailHike, MountainHike, NightHike, LoggedHike, HikeFactory

├── Achievements/     DistanceAchievement, ElevationAchievement, StreakAchievement

├── Boosts/          EnergyBoost, StreakBoost, LevelUpBoost

├── Observers/       StatObserver, AchievementObserver, LevelObserver

├── Engine/          GameEngine

├── Data/            DataStorage

├── UI/              ConsoleUI

└── Program.cs

```



\## Tech stack



\- C# / .NET 8

\- \[Newtonsoft.Json](https://www.newtonsoft.com/json) for serialization

\- Built and published with GitHub Actions, using NuGet \[Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing)



\## Future extensibility



The architecture is deliberately modular. The separation between observers, factories, and storage layers means this system could plug into a bigger application later (like a hiking safety platform) as its own module, without rewriting the core class design.







